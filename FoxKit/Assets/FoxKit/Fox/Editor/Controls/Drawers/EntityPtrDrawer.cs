using Fox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

//namespace Fox.Editor
//{
//    [CustomPropertyDrawer(typeof(EntityPtr<>))]
//    public class EntityPtrDrawer : PropertyDrawer
//    {
//        private enum CreateDeleteButtonMode
//        {
//            CreateEntity,
//            DeleteEntity
//        }

//        private SerializedProperty Property;
//        private SerializedProperty PtrProperty;

//        private Foldout Foldout;
//        private TextField ClassNameLabel;
//        private Button CreateDeleteButton;

//        private Action<Entity> setEntityPtr;
//        private string EntityTypeName;
//        private CreateDeleteButtonMode CreateDeleteMode;
//        private readonly List<PropertyField> nestedProperties = new List<PropertyField>();

//        public override VisualElement CreatePropertyGUI(SerializedProperty property)
//        {
//            Property = property;
//            PtrProperty = Property.FindPropertyRelative("ptr");
//            this.setEntityPtr = PtrProperty.SetValue;

//            EntityTypeName = GetEntityPtrTypeName(Property);

//            var entity = PtrProperty.GetValue() as Entity;
//            InitCreateDeleteMode(entity);

//            var genericType = GetEntityPtrGenericType(Property);
//            UnityEngine.Debug.Assert(genericType != null);

//            Foldout = new Foldout();
//            Foldout.text = Property.name;

//            ClassNameLabel = new TextField();
//            ClassNameLabel.value = $"{EntityTypeName} ({genericType.Name})";
//            ClassNameLabel.SetEnabled(false);

//            CreateDeleteButton = new Button();
//            CreateDeleteButton.clicked += () => CreateDeleteButton_clicked(genericType);

//            if (CreateDeleteMode == CreateDeleteButtonMode.CreateEntity)
//            {
//                CreateDeleteButton.text = "+";
//            }
//            else
//            {
//                CreateDeleteButton.text = "x";
//            }

//            if (entity != null)
//            {
//                //this.AddNestedPropertyFields();
//            }

//            return Foldout;
//        }

//        private void ClearNestedPropertyFields()
//        {
//            foreach (var property in this.nestedProperties)
//            {
//                property.RemoveFromHierarchy();
//            }

//            this.nestedProperties.Clear();
//        }

//        private void AddNestedPropertyFields()
//        {
//            var entityProp = PtrProperty.Copy();
//            entityProp.serializedObject.Update();

//            var childProperties = new List<SerializedProperty>();
//            var originalChildren = entityProp.GetChildren().ToArray();
//            foreach (var child in originalChildren)
//            {
//                var childProperty = child as SerializedProperty;
//                childProperties.Add(childProperty.Copy());
//            }

//            entityProp.Reset();

//            foreach (var property in childProperties)
//            {
//                var propertyField = new PropertyField(property.Copy());
//                propertyField.Bind(entityProp.serializedObject);

//                Foldout.Add(propertyField);
//                this.nestedProperties.Add(propertyField);
//            }
//        }

//        private void InitCreateDeleteMode(Entity ptrValue)
//        {
//            if (ptrValue == null)
//            {
//                CreateDeleteMode = CreateDeleteButtonMode.CreateEntity;
//            }
//            else
//            {
//                CreateDeleteMode = CreateDeleteButtonMode.DeleteEntity;
//            }
//        }

//        private void UpdateClassNameControl(Type newType)
//        {
//            var genericTypeName = GetEntityPtrGenericType(Property).Name;
//            ClassNameLabel.value = $"{newType.Name} ({genericTypeName})";
//        }

//        private void ClearClassNameControl()
//        {
//            ClassNameLabel.value = $"Null ({EntityTypeName})";
//        }

//        private void CreateDeleteButton_clicked(Type baseType)
//        {
//            if (CreateDeleteMode == CreateDeleteButtonMode.CreateEntity)
//            {
//                EntityTypePicker.Show(baseType, EntityTypePicker_onTypeSelected);
//                return;
//            }

//            this.setEntityPtr(null);
//            this.ClearClassNameControl();
//            this.ClearNestedPropertyFields();
//            CreateDeleteMode = CreateDeleteButtonMode.CreateEntity;
//            CreateDeleteButton.text = "+";
//        }

//        private void EntityTypePicker_onTypeSelected(Type newEntityType)
//        {
//            UnityEngine.Debug.Assert(newEntityType != null);

//            var instance = Activator.CreateInstance(newEntityType) as Entity;
//            UnityEngine.Debug.Assert(instance != null);

//            this.setEntityPtr(instance);
//            this.UpdateClassNameControl(newEntityType);
//            CreateDeleteMode = CreateDeleteButtonMode.DeleteEntity;
//            CreateDeleteButton.text = "x";

//            this.ClearNestedPropertyFields();
//            this.AddNestedPropertyFields();
//        }

//        //private SerializedProperty GetEntityProperty()
//        //{
//        //    var obj = this.property.serializedObject;
//        //    return obj.FindProperty(this.property.propertyPath).FindPropertyRelative("ptr");
//        //}

//        private static string GetEntityPtrTypeName(SerializedProperty property)
//        {
//            var obj = property.serializedObject.targetObject as object;
//            foreach (var path in property.propertyPath.Split('.'))
//            {
//                var type = obj.GetType();
//                System.Reflection.FieldInfo field = type.GetField(path);
//                obj = field.GetValue(obj);
//            }

//            var entityPtr = obj as IEntityPtr;
//            var ptrValue = entityPtr.Get();
//            if (ptrValue == null)
//            {
//                return "Null";
//            }

//            return ptrValue.GetType().Name;
//        }

//        private static Type GetEntityPtrGenericType(SerializedProperty property)
//        {
//            object obj = property.serializedObject.targetObject;
//            foreach (var path in property.propertyPath.Split('.'))
//            {
//                var type = obj.GetType();
//                System.Reflection.FieldInfo field = type.GetField(path);
//                obj = field.GetValue(obj);
//            }

//            return obj.GetType().GetGenericArguments()[0];
//        }
//    }
//}

//namespace Fox.Editor
//{
//    [CustomPropertyDrawer(typeof(EntityPtr<>))]
//    public class EntityPtrDrawer : PropertyDrawer
//    {
//        public override VisualElement CreatePropertyGUI(SerializedProperty property)
//        {
//            var ptrProperty = property.FindPropertyRelative("ptr");

//            if (ptrProperty.managedReferenceFullTypename != "")
//            {
//                var field = new PropertyField();
//                field.label = property.name;
//                field.BindProperty(ptrProperty);
//                return field;
//            }
//            else
//            {
//                var toggle = new Toggle(property.name);
//                return toggle;
//            }
//        }
//    }
//}