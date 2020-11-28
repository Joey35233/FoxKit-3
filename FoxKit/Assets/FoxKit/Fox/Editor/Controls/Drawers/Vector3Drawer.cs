using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(UnityEngine.Vector3))]
    public class Vector3Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new Vector3Field(property.name);
            container.BindProperty(property);
            container.labelElement.AddToClassList("unity-property-field__label");
            container.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/NumericInputDrawer.uss"));

            return container;
        }
    }
}