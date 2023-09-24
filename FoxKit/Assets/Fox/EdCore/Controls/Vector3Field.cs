using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Vector3Field : BaseField<UnityEngine.Vector3>, IFoxField, ICustomBindable
    {
        private readonly FloatField XField;
        private readonly FloatField YField;
        private readonly FloatField ZField;

        public static new readonly string ussClassName = "fox-vector3-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Vector3Field() : this(default)
        {
        }

        public Vector3Field(string label)
            : this(label, new VisualElement())
        {
        }

        private Vector3Field(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            XField = new FloatField("X");
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.firstFieldVariantUssClassName);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(XField);
            YField = new FloatField("Y");
            YField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(YField);
            ZField = new FloatField("Z");
            ZField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            ZField.AddToClassList("unity-composite-field__field--last");
            visualInput.Add(ZField);

            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.inputUssClassName);
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

                    // Stop the Vector3Field itself's binding event; it's just a container for the actual BindableElements.
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
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Vector3))]
    public class Vector3Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Vector3Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<UnityEngine.Vector3>.alignedFieldUssClassName);

            return field;
        }
    }
}