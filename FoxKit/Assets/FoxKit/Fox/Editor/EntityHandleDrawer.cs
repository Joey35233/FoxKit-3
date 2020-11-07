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
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/EntityHandleDrawer.uxml");
            var drawer = uxmlTemplate.CloneTree(property.propertyPath);

            container.Add(drawer);
            return container;
        }
    }
}