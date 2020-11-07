using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(EntityPtr<>))]
    public class EntityPtrDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/EntityPtrDrawer.uxml");
            var uss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/EntityPtrDrawer.uss");
            var drawer = uxmlTemplate.CloneTree(property.propertyPath);
            drawer.styleSheets.Add(uss);

            var foldout = drawer.Q<Foldout>();
            foldout.text = property.name;

            var classLabel = foldout.Q<TextField>("ClassLabel");
            var className = GetEntityPtrClassName(property);
            classLabel.value = $"{className} ({GetEntityPtrTypeName(property)})";
            classLabel.SetEnabled(false);

            container.Add(drawer);
            return container;
        }

        private static string GetEntityPtrClassName(SerializedProperty property)
        {
            object obj = property.serializedObject.targetObject;

            System.Reflection.FieldInfo field = null;
            foreach (var path in property.propertyPath.Split('.'))
            {
                var type = obj.GetType();
                field = type.GetField(path);
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

        private static string GetEntityPtrTypeName(SerializedProperty property)
        {
            object obj = property.serializedObject.targetObject;

            System.Reflection.FieldInfo field = null;
            foreach (var path in property.propertyPath.Split('.'))
            {
                var type = obj.GetType();
                field = type.GetField(path);
                obj = field.GetValue(obj);
            }

            return obj.GetType().GetGenericArguments()[0].Name;
        }
    }
}