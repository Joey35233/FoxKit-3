using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class QuaternionField : BaseField<UnityEngine.Quaternion>, IFoxField
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

        public QuaternionField() 
            : this(label: null)
        {
        }
        
        public QuaternionField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
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
            XField.bindingPath = nameof(Quaternion.x);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            visualInput.Add(XField);
            YField = new FloatField("Y");
            YField.bindingPath = nameof(Quaternion.y);
            YField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            visualInput.Add(YField);
            ZField = new FloatField("Z");
            ZField.bindingPath = nameof(Quaternion.z);
            ZField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            visualInput.Add(ZField);
            WField = new FloatField("W");
            WField.bindingPath = nameof(Quaternion.w);
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
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(UnityEngine.Quaternion))]
    // public class QuaternionDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new QuaternionField(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<UnityEngine.Quaternion>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}