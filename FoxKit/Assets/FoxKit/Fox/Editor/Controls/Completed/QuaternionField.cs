﻿using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class QuaternionField : BaseField<UnityEngine.Quaternion>/*, FoxField*/
    {
        private FloatField XField;
        private FloatField YField;
        private FloatField ZField;
        private FloatField WField;

        public new static readonly string ussClassName = "fox-quaternion-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

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
            visualInput.Add(WField);

            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        //public override void BindProperty(SerializedProperty property)
        //{
        //    BindProperty(property, property.name);
        //}

        //public override void BindProperty(SerializedProperty property, string label)
        //{
        //    if (!IsUserAssignedLabel)
        //        InternalField.label = label;

        //    InternalField.BindProperty(property);
        //}
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