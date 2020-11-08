using ICSharpCode.NRefactory.Ast;
using NUnit.Framework;
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
        private string className;
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

            var type = GetEntityPtrType(property);
            UnityEngine.Debug.Assert(type != null);

            this.InitClassLabel(foldout, type);
            this.InitCreateDeleteButton(foldout, type);

            if (entity != null)
            {
                AddNestedPropertyFields(foldout, ptrProperty);
            }
        }

        private void ClearNestedPropertyFields()
        {
            foreach(var property in this.nestedProperties)
            {
                property.RemoveFromHierarchy();
            }

            this.nestedProperties.Clear();
        }

        private void AddNestedPropertyFields(Foldout foldout, SerializedProperty ptrProperty)
        {
            foreach (var innerProperty in ptrProperty.GetChildren())
            {
                var field = new PropertyField(innerProperty);
                foldout.Add(field);
                this.nestedProperties.Add(field);
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

        private void InitClassLabel(Foldout foldout, Type type)
        {
            this.classLabel = foldout.Q<TextField>("ClassLabel");
            this.className = GetEntityPtrClassName(this.property);
            classLabel.value = $"{className} ({type.Name})";
            classLabel.SetEnabled(false);
        }

        private TemplateContainer BuildDrawer()
        {
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/EntityPtrDrawer.uxml");
            var uss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/EntityPtrDrawer.uss");
            var drawer = uxmlTemplate.CloneTree(this.property.propertyPath);
            drawer.styleSheets.Add(uss);

            return drawer;
        }

        private void UpdateClassNameControl(Type newType)
        {
            classLabel.value = $"{newType.Name} ({this.className})";
        }

        private void ClearClassNameControl()
        {
            classLabel.value = $"Null ({this.className})";
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

        private void EntityTypePicker_onTypeSelected(Type type)
        {
            UnityEngine.Debug.Assert(type != null);

            var instance = Activator.CreateInstance(type) as Entity;
            UnityEngine.Debug.Assert(instance != null);

            this.setEntityPtr(instance);
            this.UpdateClassNameControl(type);
            this.createDeleteMode = CreateDeleteMode.DeleteEntity;
            this.createDeleteButton.text = "x";

            // BUG: Why does this not cause the fields to show up unless you click away and back?
            var ptrProperty = this.GetEntityProperty();
            this.ClearNestedPropertyFields();
            this.AddNestedPropertyFields(this.foldout, ptrProperty);
        }

        private SerializedProperty GetEntityProperty()
        {
            var obj = this.property.serializedObject;
            return obj.FindProperty(this.property.propertyPath).FindPropertyRelative("ptr");
        }

        private static string GetEntityPtrClassName(SerializedProperty property)
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

        private static Type GetEntityPtrType(SerializedProperty property)
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