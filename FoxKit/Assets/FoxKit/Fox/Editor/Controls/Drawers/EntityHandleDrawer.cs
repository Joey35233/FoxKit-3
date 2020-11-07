using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(EntityHandle))]
    public class EntityHandleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/Controls/Drawers/EntityHandleDrawer.uxml");
            var drawer = uxmlTemplate.CloneTree(property.propertyPath);

            var foldout = drawer.Q<TextField>();
            foldout.label = property.name;

            container.Add(drawer);
            return container;
        }
    }
}