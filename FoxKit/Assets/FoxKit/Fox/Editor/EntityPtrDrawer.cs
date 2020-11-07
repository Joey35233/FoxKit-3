using System;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(EntityPtr<>))]
    public class EntityPtrDrawer : PropertyDrawer
    {
        private Action<Entity> setEntityPtr;
        private TextField classLabel;
        private string className;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.setEntityPtr = GetEntityProperty(property).SetValue;

            var container = new VisualElement();
            var drawer = BuildDrawer(property);
            this.InitControls(property, drawer);

            container.Add(drawer);
            return container;
        }

        private void InitControls(SerializedProperty property, TemplateContainer drawer)
        {
            var foldout = drawer.Q<Foldout>();
            foldout.text = property.name;

            var type = GetEntityPtrType(property);

            this.InitClassLabel(property, foldout, type);
            this.InitCreateDeleteButton(foldout, type);
        }

        private void InitCreateDeleteButton(Foldout foldout, Type type)
        {
            var createDeleteButton = foldout.Q<Button>("CreateDeleteEntityButton");
            createDeleteButton.clicked += () => CreateDeleteButton_clicked(type);
        }

        private void InitClassLabel(SerializedProperty property, Foldout foldout, Type type)
        {
            this.classLabel = foldout.Q<TextField>("ClassLabel");
            this.className = GetEntityPtrClassName(property);
            classLabel.value = $"{className} ({type.Name})";
            classLabel.SetEnabled(false);
        }

        private static TemplateContainer BuildDrawer(SerializedProperty property)
        {
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/EntityPtrDrawer.uxml");
            var uss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/EntityPtrDrawer.uss");
            var drawer = uxmlTemplate.CloneTree(property.propertyPath);
            drawer.styleSheets.Add(uss);

            return drawer;
        }

        private void UpdateClassNameControl(Type newType)
        {
            classLabel.value = $"{newType.Name} ({this.className})";
        }

        private void CreateDeleteButton_clicked(Type baseType)
        {
            EntityTypePicker.Show(baseType, EntityTypePicker_onTypeSelected);
        }

        private void EntityTypePicker_onTypeSelected(Type type)
        {
            var instance = Activator.CreateInstance(type) as Entity;
            this.setEntityPtr(instance);
            this.UpdateClassNameControl(type);
        }

        private static SerializedProperty GetEntityProperty(SerializedProperty thisProperty)
        {
            var obj = thisProperty.serializedObject;
            return obj.FindProperty(thisProperty.propertyPath).FindPropertyRelative("ptr");
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