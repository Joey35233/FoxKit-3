using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Vector3Field : BaseField<UnityEngine.Vector3>, IFoxField
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

        public Vector3Field()
            : this(label: null)
        {
        }
        
        public Vector3Field(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
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
            XField.bindingPath = nameof(Vector3.x);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.firstFieldVariantUssClassName);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(XField);
            YField = new FloatField("Y");
            YField.bindingPath = nameof(Vector3.y);
            YField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(YField);
            ZField = new FloatField("Z");
            ZField.bindingPath = nameof(Vector3.z);
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
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}