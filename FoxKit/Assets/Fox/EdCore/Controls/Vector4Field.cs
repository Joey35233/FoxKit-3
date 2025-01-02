using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Vector4Field : BaseField<UnityEngine.Vector4>, IFoxField
    {
        private readonly FloatField XField;
        private readonly FloatField YField;
        private readonly FloatField ZField;
        private readonly FloatField WField;

        public static new readonly string ussClassName = "fox-vector4-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Vector4Field()
            : this(label: null)
        {
        }
        
        public Vector4Field(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public Vector4Field(string label)
            : this(label, new VisualElement())
        {
        }

        private Vector4Field(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            XField = new FloatField("X");
            XField.bindingPath = nameof(Vector4.x);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.firstFieldVariantUssClassName);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(XField);
            YField = new FloatField("Y");
            YField.bindingPath = nameof(Vector4.y);
            YField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(YField);
            ZField = new FloatField("Z");
            ZField.bindingPath = nameof(Vector4.z);
            ZField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(ZField);
            WField = new FloatField("W");
            WField.bindingPath = nameof(Vector4.w);
            WField.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.fieldUssClassName);
            ZField.AddToClassList("unity-composite-field__field--last");
            visualInput.Add(WField);

            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(UnityEngine.Vector4))]
    // public class Vector4Drawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new Vector4Field(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<UnityEngine.Vector4>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}