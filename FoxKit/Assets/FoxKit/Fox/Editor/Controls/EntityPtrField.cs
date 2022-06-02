using Fox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor.delete
{
    //[CustomPropertyDrawer(typeof(EntityPtr<>))]
    public class EntityPtrDrawer : PropertyDrawer
    {
        private enum CreateDeleteButtonMode
        {
            CreateEntity,
            DeleteEntity
        }

        private SerializedProperty Property;
        private SerializedProperty PtrProperty;

        private Foldout Foldout;
        private TextField ClassNameLabel;
        private Button CreateDeleteButton;

        private Action<Entity> setEntityPtr;
        private string EntityTypeName;
        private CreateDeleteButtonMode CreateDeleteMode;
        private readonly List<PropertyField> nestedProperties = new List<PropertyField>();

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            Property = property;
            PtrProperty = Property.FindPropertyRelative("ptr");
            this.setEntityPtr = PtrProperty.SetValue;

            EntityTypeName = GetEntityPtrTypeName(Property);

            var entity = PtrProperty.GetValue() as Entity;
            InitCreateDeleteMode(entity);

            var genericType = GetEntityPtrGenericType(Property);
            UnityEngine.Debug.Assert(genericType != null);

            Foldout = new Foldout();
            Foldout.text = Property.name;

            ClassNameLabel = new TextField();
            ClassNameLabel.value = $"{EntityTypeName} ({genericType.Name})";
            ClassNameLabel.SetEnabled(false);
            Foldout.Add(ClassNameLabel);

            CreateDeleteButton = new Button();
            CreateDeleteButton.clicked += () => CreateDeleteButton_clicked(genericType);
            Foldout.Add(CreateDeleteButton);

            if (CreateDeleteMode == CreateDeleteButtonMode.CreateEntity)
            {
                CreateDeleteButton.text = "＋";
            }
            else
            {
                CreateDeleteButton.text = "Ｘ";
            }

            if (entity != null)
            {
                this.AddNestedPropertyFields();
            }

            return Foldout;
        }

        private void ClearNestedPropertyFields()
        {
            foreach (var property in this.nestedProperties)
            {
                property.RemoveFromHierarchy();
            }

            this.nestedProperties.Clear();
        }

        private void AddNestedPropertyFields()
        {
            var entityProp = PtrProperty.Copy();
            entityProp.serializedObject.Update();

            var childProperties = new List<SerializedProperty>();
            foreach (var child in entityProp)
            {
                var childProperty = child as SerializedProperty;
                childProperties.Add(childProperty.Copy());
            }

            entityProp.Reset();

            foreach (var property in childProperties)
            {
                var propertyField = new PropertyField(property.Copy());
                propertyField.Bind(entityProp.serializedObject);

                Foldout.Add(propertyField);
                this.nestedProperties.Add(propertyField);
            }
        }

        private void InitCreateDeleteMode(Entity ptrValue)
        {
            if (ptrValue == null)
            {
                CreateDeleteMode = CreateDeleteButtonMode.CreateEntity;
            }
            else
            {
                CreateDeleteMode = CreateDeleteButtonMode.DeleteEntity;
            }
        }

        private void UpdateClassNameControl(Type newType)
        {
            var genericTypeName = GetEntityPtrGenericType(Property).Name;
            ClassNameLabel.value = $"{newType.Name} ({genericTypeName})";
        }

        private void ClearClassNameControl()
        {
            ClassNameLabel.value = $"Null ({EntityTypeName})";
        }

        private void CreateDeleteButton_clicked(Type baseType)
        {
            if (CreateDeleteMode == CreateDeleteButtonMode.CreateEntity)
            {
                EntityTypePicker.Show(baseType, EntityTypePicker_onTypeSelected);
                return;
            }

            this.setEntityPtr(null);
            this.ClearClassNameControl();
            this.ClearNestedPropertyFields();
            CreateDeleteMode = CreateDeleteButtonMode.CreateEntity;
            CreateDeleteButton.text = "＋";
        }

        private void EntityTypePicker_onTypeSelected(Type newEntityType)
        {
            UnityEngine.Debug.Assert(newEntityType != null);

            var instance = Activator.CreateInstance(newEntityType) as Entity;
            UnityEngine.Debug.Assert(instance != null);

            this.setEntityPtr(instance);
            this.UpdateClassNameControl(newEntityType);
            CreateDeleteMode = CreateDeleteButtonMode.DeleteEntity;
            CreateDeleteButton.text = "x";

            this.ClearNestedPropertyFields();
            this.AddNestedPropertyFields();
        }

        //private SerializedProperty GetEntityProperty()
        //{
        //    var obj = this.property.serializedObject;
        //    return obj.FindProperty(this.property.propertyPath).FindPropertyRelative("ptr");
        //}

        private static string GetEntityPtrTypeName(SerializedProperty property)
        {
            var obj = property.serializedObject.targetObject as object;
            foreach (var path in property.propertyPath.Split('.'))
            {
                var type = obj.GetType();
                System.Reflection.FieldInfo field = type.GetField(path);
                obj = field.GetValue(obj);
            }

            var entityPtr = obj as IEntityPtr;
            var ptrValue = entityPtr.Get();
            if (ptrValue == null)
            {
                return "Null";
            }

            return ptrValue.GetType().Name;
        }

        private static Type GetEntityPtrGenericType(SerializedProperty property)
        {
            object obj = property.serializedObject.targetObject;
            foreach (var path in property.propertyPath.Split('.'))
            {
                var type = obj.GetType();
                System.Reflection.FieldInfo field = type.GetField(path);
                obj = field.GetValue(obj);
            }

            return obj.GetType().GetGenericArguments()[0];
        }
    }
}

namespace Fox.Editor
{
    public class EntityPtrField<T> : BaseField<Fox.Core.EntityPtr<T>>, IFoxField 
        where T : DataElement, new()
    {
        private VisualElement PropertyContainer;
        private SerializedProperty ReferenceProperty;

        public enum CreateDeleteButtonMode
        {
            CreateEntity,
            DeleteEntity
        }
        private CreateDeleteButtonMode ButtonMode;

        public new static readonly string ussClassName = "fox-entityptr-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string createButtonUssClassName = ussClassName + "__create-button";
        public static readonly string deleteButtonUssClassName = ussClassName + "__delete-button";

        public VisualElement visualInput { get; }

        public EntityPtrField() : this(default)
        {
        }

        public EntityPtrField(string label)
            : this(label, new VisualElement())
        {
        }

        private EntityPtrField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            ButtonMode = CreateDeleteButtonMode.CreateEntity;

            PropertyContainer = new VisualElement();

            var buttonContainer = new VisualElement();
            buttonContainer.style.flexDirection = FlexDirection.Row;

            void createButton_onClick()
            {
                var thisvar = this;

                if (ReferenceProperty is null/* || panel is null*/)
                    return;

                ReferenceProperty.managedReferenceValue = new T();
                ReferenceProperty.serializedObject.ApplyModifiedProperties();

                foreach (var child in ReferenceProperty.GetChildren())
                    PropertyContainer.Add(new Label(child.name));

                return;
            };
            var createButton = new Button(createButton_onClick);
            createButton.text = "＋";
            createButton.AddToClassList(createButtonUssClassName);

            void deleteButton_onClick()
            {
                var thisvar = this;

                if (ReferenceProperty is null/* || panel is null*/)
                    return;

                ReferenceProperty.managedReferenceValue = null;
                ReferenceProperty.serializedObject.ApplyModifiedProperties();

                PropertyContainer.Clear();

                return;
            };
            var deleteButton = new Button(deleteButton_onClick);
            deleteButton.AddToClassList(deleteButtonUssClassName);
            deleteButton.text = "－";

            buttonContainer.Add(createButton);
            buttonContainer.Add(deleteButton);
            visualInput.Add(buttonContainer);

            visualInput.Add(PropertyContainer);

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;

            ReferenceProperty = property.FindPropertyRelative("_ptr");
            foreach (var child in ReferenceProperty.GetChildren())
                PropertyContainer.Add(new Label(child.name));
        }
    }

    [CustomPropertyDrawer(typeof(Core.EntityPtr<>))]
    public class EntityPtrDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement genericField = (VisualElement)Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { fieldInfo.FieldType.GenericTypeArguments[0] }), new object[] { property.name });
            (genericField as BindableElement).BindProperty(property.FindPropertyRelative("_ptr"));
            (genericField as IFoxField).BindProperty(property);

            genericField.Q(className: BaseField<float>.labelUssClassName).AddToClassList(PropertyField.labelUssClassName);
            genericField.Q(className: BaseField<float>.inputUssClassName).AddToClassList(PropertyField.inputUssClassName);
            genericField.AddToClassList(BaseField<float>.alignedFieldUssClassName);

            return genericField;
        }
    }
}