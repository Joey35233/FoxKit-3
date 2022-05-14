using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class Matrix4Field : BaseField<UnityEngine.Matrix4x4>/*, FoxField*/
    {
        private FloatField[,] InternalFields;

        public new static readonly string ussClassName = "fox-matrix4-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public Matrix4Field() : this(default)
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
                    FloatField field = new ($"{i}{j}");
                    field.labelElement.style.flexBasis = 22;
                    if (j == 0)
                        field.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
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

    [CustomPropertyDrawer(typeof(UnityEngine.Matrix4x4))]
    public class Matrix4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Matrix4Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<Fox.Core.Path>.alignedFieldUssClassName);

            return field;
        }
    }
}