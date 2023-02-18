using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class QuaternionField : BaseField<UnityEngine.Quaternion>, IFoxField, ICustomBindable
    {
        private readonly FloatField XField;
        private readonly FloatField YField;
        private readonly FloatField ZField;
        private readonly FloatField WField;

        public static new readonly string ussClassName = "fox-quaternion-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public QuaternionField() : this(default)
        {
        }

        public QuaternionField(string label)
            : this(label, new VisualElement())
        {
        }

        private QuaternionField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            XField = new FloatField("X");
            XField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            visualInput.Add(XField);
            YField = new FloatField("Y");
            YField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            visualInput.Add(YField);
            ZField = new FloatField("Z");
            ZField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            visualInput.Add(ZField);
            WField = new FloatField("W");
            WField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            WField.AddToClassList("unity-composite-field__field--last");
            visualInput.Add(WField);

            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !String.IsNullOrWhiteSpace(bindingPath))
            {
                var property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                if (property.propertyType != SerializedPropertyType.Float)
                {
                    BindingExtensions.BindProperty(XField, property.FindPropertyRelative("x"));
                    BindingExtensions.BindProperty(YField, property.FindPropertyRelative("y"));
                    BindingExtensions.BindProperty(ZField, property.FindPropertyRelative("z"));
                    BindingExtensions.BindProperty(WField, property.FindPropertyRelative("w"));

                    // Stop the QuaternionField itself's binding event; it's just a container for the actual BindableElements.
                    evt.StopPropagation();
                }
            }
        }

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(XField, property.FindPropertyRelative("x"));
            BindingExtensions.BindProperty(YField, property.FindPropertyRelative("y"));
            BindingExtensions.BindProperty(ZField, property.FindPropertyRelative("z"));
            BindingExtensions.BindProperty(WField, property.FindPropertyRelative("w"));
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Quaternion))]
    public class QuaternionDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new QuaternionField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<UnityEngine.Quaternion>.alignedFieldUssClassName);

            return field;
        }
    }
}