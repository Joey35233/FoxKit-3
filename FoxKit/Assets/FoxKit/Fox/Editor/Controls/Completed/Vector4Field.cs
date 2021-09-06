//using UnityEditor;
//using UnityEngine.UIElements;
//using UnityEditor.UIElements;

//namespace Fox.Editor
//{
//    public class Vector4Field : IFoxField
//    {
//        private Label LabelElement;
//        private VisualElement InternalContainer;
//        private FloatField[] InternalFields;

//        public Vector4Field() : this(default)
//        {
//        }

//        public Vector4Field(string label)
//        {
//            InternalFields = new FloatField[4];

//            this.AddToClassList("unity-base-field");
//            this.AddToClassList("unity-composite-field");

//            LabelElement = new Label(label);
//            LabelElement.AddToClassList("unity-base-field__label");
//            LabelElement.AddToClassList("unity-property-field__label");
//            this.Add(LabelElement);

//            var innerContainer = new VisualElement();
//            innerContainer.AddToClassList("unity-base-field__input");
//            innerContainer.AddToClassList("unity-composite-field__input");

//            InternalFields[0] = new FloatField("X");
//            InternalFields[0].AddToClassList("unity-composite-field__field");
//            InternalFields[0].AddToClassList("unity-composite-field__field--first");
//            innerContainer.Add(InternalFields[0]);

//            InternalFields[1] = new FloatField("Y");
//            InternalFields[1].AddToClassList("unity-composite-field__field");
//            innerContainer.Add(InternalFields[1]);

//            InternalFields[2] = new FloatField("Z");
//            InternalFields[2].AddToClassList("unity-composite-field__field");
//            innerContainer.Add(InternalFields[2]);

//            InternalFields[3] = new FloatField("W");
//            InternalFields[3].AddToClassList("unity-composite-field__field");
//            innerContainer.Add(InternalFields[3]);

//            this.Add(innerContainer);
//        }

//        public override void BindProperty(SerializedProperty property)
//        {
//            BindProperty(property, property.name);
//        }

//        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
//        {
//            LabelElement.text = label;

//            InternalFields[0].BindProperty(property.FindPropertyRelative("x"));
//            InternalFields[1].BindProperty(property.FindPropertyRelative("y"));
//            InternalFields[2].BindProperty(property.FindPropertyRelative("z"));
//            InternalFields[3].BindProperty(property.FindPropertyRelative("w"));
//        }
//    }

//    [CustomPropertyDrawer(typeof(UnityEngine.Vector4))]
//    public class Vector4Drawer : PropertyDrawer
//    {
//        public override VisualElement CreatePropertyGUI(SerializedProperty property)
//        {
//            var field = new Vector4Field();
//            field.BindProperty(property);

//            return field;
//        }
//    }
//}

using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class Vector4Field : IFoxField
    {
        private UnityEditor.UIElements.Vector4Field InternalField;

        public Vector4Field() : this(default)
        {
        }

        public Vector4Field(string label)
        {
            InternalField = new UnityEditor.UIElements.Vector4Field();
            InternalField.label = label;
            InternalField.labelElement.AddToClassList("unity-property-field__label");
            InternalField.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);

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

    [CustomPropertyDrawer(typeof(UnityEngine.Vector4))]
    public class Vector4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new Vector4Field(property.name);
            container.BindProperty(property);

            return container;
        }
    }
}