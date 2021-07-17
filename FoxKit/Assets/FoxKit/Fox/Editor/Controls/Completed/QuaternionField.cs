using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class QuaternionField : IFoxField
    {
        private Label LabelElement;
        private VisualElement InternalContainer;
        private FloatField[] InternalFields;

        public QuaternionField() : this(default)
        {
        }

        public QuaternionField(string label)
        {
            InternalFields = new FloatField[4];

            this.AddToClassList("unity-base-field");
            this.AddToClassList("unity-composite-field");

            LabelElement = new Label(label);
            LabelElement.AddToClassList("unity-base-field__label");
            LabelElement.AddToClassList("unity-property-field__label");
            this.Add(LabelElement);

            var innerContainer = new VisualElement();
            innerContainer.AddToClassList("unity-base-field__input");
            innerContainer.AddToClassList("unity-composite-field__input");

            InternalFields[0] = new FloatField("X");
            InternalFields[0].AddToClassList("unity-composite-field__field");
            InternalFields[0].AddToClassList("unity-composite-field__field--first");
            innerContainer.Add(InternalFields[0]);

            InternalFields[1] = new FloatField("Y");
            InternalFields[1].AddToClassList("unity-composite-field__field");
            innerContainer.Add(InternalFields[1]);

            InternalFields[2] = new FloatField("Z");
            InternalFields[2].AddToClassList("unity-composite-field__field");
            innerContainer.Add(InternalFields[2]);

            InternalFields[3] = new FloatField("W");
            InternalFields[3].AddToClassList("unity-composite-field__field");
            innerContainer.Add(InternalFields[3]);

            this.Add(innerContainer);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            LabelElement.text = label;

            InternalFields[0].BindProperty(property.FindPropertyRelative("x"));
            InternalFields[1].BindProperty(property.FindPropertyRelative("y"));
            InternalFields[2].BindProperty(property.FindPropertyRelative("z"));
            InternalFields[3].BindProperty(property.FindPropertyRelative("w"));
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Quaternion))]
    public class QuaternionDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new QuaternionField();
            field.BindProperty(property);

            return field;
        }
    }
}