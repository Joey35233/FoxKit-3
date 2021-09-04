using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class ColorField : IFoxField
    {
        private UnityEditor.UIElements.ColorField InternalField;

        public ColorField() : this(default)
        {
        }

        public ColorField(string label)
        {
            InternalField = new UnityEditor.UIElements.ColorField();
            InternalField.labelElement.AddToClassList("unity-property-field__label");

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            InternalField.label = label;

            InternalField.BindProperty(property);
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Color))]
    public class ColorDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new ColorField(property.name);
            container.BindProperty(property);

            return container;
        }
    }
}

//using UnityEditor;
//using UnityEngine.UIElements;
//using UnityEditor.UIElements;

//namespace Fox.Editor
//{
//    [CustomPropertyDrawer(typeof(UnityEngine.Color))]
//    public class ColorDrawer : PropertyDrawer
//    {
//        public override VisualElement CreatePropertyGUI(SerializedProperty property)
//        {
//            var field = new ColorField();
//            field.label = property.name;
//            field.BindProperty(property);
//            field.labelElement.AddToClassList("unity-property-field__label");

//            return field;
//        }
//    }
//}