using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(EntityPtr<>))]
    public class EntityPtrDrawer : PropertyDrawer
    {
        private enum CreateDeleteMode
        {
            CreateEntity,
            DeleteEntity
        }

        private SerializedProperty property;
        private Action<Entity> setEntityPtr;
        private TextField classLabel;
        private string valueTypeName;
        private CreateDeleteMode createDeleteMode;
        private Button createDeleteButton;
        private Foldout foldout;
        private readonly List<PropertyField> nestedProperties = new List<PropertyField>();

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;
            this.setEntityPtr = this.GetEntityProperty().SetValue;

            var container = new VisualElement();
            var drawer = this.BuildDrawer();
            this.InitControls(drawer);

            container.Add(drawer);
            return container;
        }

        private void InitControls(TemplateContainer drawer)
        {
            this.foldout = drawer.Q<Foldout>();
            foldout.text = property.name;

            var ptrProperty = GetEntityProperty();
            var entity = ptrProperty.GetValue() as Entity;
            this.InitCreateDeleteMode(entity);

            var genericType = GetEntityPtrGenericType(property);
            UnityEngine.Debug.Assert(genericType != null);

            this.InitClassLabel(foldout, genericType);
            this.InitCreateDeleteButton(foldout, genericType);

            if (entity != null)
            {
                this.AddNestedPropertyFields();
            }
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
            var entityProp = this.GetEntityProperty().Copy();
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

                this.foldout.Add(propertyField);
                this.nestedProperties.Add(propertyField);
            }
        }

        private void InitCreateDeleteMode(Entity ptrValue)
        {
            if (ptrValue == null)
            {
                this.createDeleteMode = CreateDeleteMode.CreateEntity;
            }
            else
            {
                this.createDeleteMode = CreateDeleteMode.DeleteEntity;
            }
        }

        private void InitCreateDeleteButton(Foldout foldout, Type type)
        {
            this.createDeleteButton = foldout.Q<Button>("CreateDeleteEntityButton");
            createDeleteButton.clicked += () => CreateDeleteButton_clicked(type);

            if (this.createDeleteMode == CreateDeleteMode.CreateEntity)
            {
                createDeleteButton.text = "+";
            }
            else
            {
                createDeleteButton.text = "x";
            }
        }

        private void InitClassLabel(Foldout foldout, Type genericTypeName)
        {
            this.classLabel = foldout.Q<TextField>("ClassLabel");
            this.valueTypeName = GetEntityPtrTypeName(this.property);
            classLabel.value = $"{valueTypeName} ({genericTypeName.Name})";
            classLabel.SetEnabled(false);
        }

        private TemplateContainer BuildDrawer()
        {
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/Controls/Drawers/EntityPtrDrawer.uxml");
            var uss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/EntityPtrDrawer.uss");
            var drawer = uxmlTemplate.CloneTree(this.property.propertyPath);
            drawer.styleSheets.Add(uss);

            return drawer;
        }

        private void UpdateClassNameControl(Type newType)
        {
            var genericTypeName = GetEntityPtrGenericType(property).Name;
            classLabel.value = $"{newType.Name} ({genericTypeName})";
        }

        private void ClearClassNameControl()
        {
            classLabel.value = $"Null ({this.valueTypeName})";
        }

        private void CreateDeleteButton_clicked(Type baseType)
        {
            if (this.createDeleteMode == CreateDeleteMode.CreateEntity)
            {
                EntityTypePicker.Show(baseType, EntityTypePicker_onTypeSelected);
                return;
            }

            this.setEntityPtr(null);
            this.ClearClassNameControl();
            this.ClearNestedPropertyFields();
            this.createDeleteMode = CreateDeleteMode.CreateEntity;
            this.createDeleteButton.text = "+";
        }

        private void EntityTypePicker_onTypeSelected(Type newEntityType)
        {
            UnityEngine.Debug.Assert(newEntityType != null);

            var instance = Activator.CreateInstance(newEntityType) as Entity;
            UnityEngine.Debug.Assert(instance != null);

            this.setEntityPtr(instance);
            this.UpdateClassNameControl(newEntityType);
            this.createDeleteMode = CreateDeleteMode.DeleteEntity;
            this.createDeleteButton.text = "x";

            this.ClearNestedPropertyFields();
            this.AddNestedPropertyFields();
        }

        private SerializedProperty GetEntityProperty()
        {
            var obj = this.property.serializedObject;
            return obj.FindProperty(this.property.propertyPath).FindPropertyRelative("ptr");
        }

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