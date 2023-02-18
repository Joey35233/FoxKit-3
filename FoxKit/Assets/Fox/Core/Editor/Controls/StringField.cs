using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using String = Fox.Kernel.String;

namespace Fox.Editor
{
    public class StringField : TextField, IFoxField, ICustomBindable
    {
        public static new readonly string ussClassName = "fox-string-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public StringField()
            : this(null) { }

        public StringField(int maxLength)
            : this(null, false, maxLength) { }

        public StringField(bool multiline)
            : this(null, multiline) { }

        public StringField(string label, bool multiline = false, int maxLength = -1)
            : base(label, maxLength, multiline, false, '*')
        {
            RemoveFromClassList(TextField.ussClassName);
            AddToClassList(ussClassName);

            visualInput = this.Q(className: BaseField<string>.inputUssClassName);
            visualInput.RemoveFromClassList(TextField.inputUssClassName);
            visualInput.AddToClassList(inputUssClassName);

            labelElement.RemoveFromClassList(TextField.labelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !System.String.IsNullOrWhiteSpace(bindingPath))
            {
                var property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                if (property.propertyType != SerializedPropertyType.String)
                {
                    BindingExtensions.BindProperty(this, property.FindPropertyRelative("_cString"));

                    evt.StopPropagation();
                }
            }
        }

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property.FindPropertyRelative("_cString"));
        }
    }

    [CustomPropertyDrawer(typeof(String))]
    public class StringDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new StringField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<String>.alignedFieldUssClassName);

            return field;
        }
    }
}