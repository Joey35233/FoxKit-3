using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Matrix4Field : BaseField<UnityEngine.Matrix4x4>, IFoxField
    {
        private readonly FloatField[,] InternalFields;

        public static new readonly string ussClassName = "fox-matrix4-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Matrix4Field() 
            : this(label: null)
        {
        }
        
        public Matrix4Field(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public Matrix4Field(string label)
            : this(label, new VisualElement())
        {
        }

        private Matrix4Field(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            InternalFields = new FloatField[4, 4];

            for (int i = 0; i < 4; i++)
            {
                VisualElement rowContainer = new();
                rowContainer.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldGroupUssClassName);

                for (int j = 0; j < 4; j++)
                {
                    FloatField field = new($"{i}{j}");
                    field.bindingPath = $"e{i}{j}";
                    field.labelElement.style.flexBasis = 22;
                    if (j == 0)
                        field.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
                    else if (j == 3)
                        field.AddToClassList("unity-composite-field__field--last");
                    field.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
                    InternalFields[i, j] = field;
                    rowContainer.Add(field);
                }

                visualInput.Add(rowContainer);
            }

            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.multilineVariantUssClassName);
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}