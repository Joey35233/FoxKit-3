using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;

namespace Fox.Editor
{
    public class Matrix4Field : BaseField<UnityEngine.Matrix4x4>, IFoxField
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

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            Type evtType = evt.GetType();
            if ((evtType.Name == "SerializedPropertyBindEvent") && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty matrixProperty = evtType.GetProperty("bindProperty").GetValue(evt) as SerializedProperty;

                BindingExtensions.BindProperty(InternalFields[0, 0], matrixProperty.FindPropertyRelative("e00"));
                BindingExtensions.BindProperty(InternalFields[0, 1], matrixProperty.FindPropertyRelative("e01"));
                BindingExtensions.BindProperty(InternalFields[0, 2], matrixProperty.FindPropertyRelative("e02"));
                BindingExtensions.BindProperty(InternalFields[0, 3], matrixProperty.FindPropertyRelative("e03"));
                BindingExtensions.BindProperty(InternalFields[1, 0], matrixProperty.FindPropertyRelative("e10"));
                BindingExtensions.BindProperty(InternalFields[1, 1], matrixProperty.FindPropertyRelative("e11"));
                BindingExtensions.BindProperty(InternalFields[1, 2], matrixProperty.FindPropertyRelative("e12"));
                BindingExtensions.BindProperty(InternalFields[1, 3], matrixProperty.FindPropertyRelative("e13"));
                BindingExtensions.BindProperty(InternalFields[2, 0], matrixProperty.FindPropertyRelative("e20"));
                BindingExtensions.BindProperty(InternalFields[2, 1], matrixProperty.FindPropertyRelative("e21"));
                BindingExtensions.BindProperty(InternalFields[2, 2], matrixProperty.FindPropertyRelative("e22"));
                BindingExtensions.BindProperty(InternalFields[2, 3], matrixProperty.FindPropertyRelative("e23"));
                BindingExtensions.BindProperty(InternalFields[3, 0], matrixProperty.FindPropertyRelative("e30"));
                BindingExtensions.BindProperty(InternalFields[3, 1], matrixProperty.FindPropertyRelative("e31"));
                BindingExtensions.BindProperty(InternalFields[3, 2], matrixProperty.FindPropertyRelative("e32"));
                BindingExtensions.BindProperty(InternalFields[3, 3], matrixProperty.FindPropertyRelative("e33"));

                // Stop the Matrix4Field itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }
        }

        //public void BindProperty(SerializedProperty property)
        //{
        //    BindProperty(property, null);
        //}
        //public void BindProperty(SerializedProperty property, string label)
        //{
        //    if (label is not null)
        //        this.label = label;
        //    BindingExtensions.BindProperty(InternalFields[0, 0], property.FindPropertyRelative("e00"));
        //    BindingExtensions.BindProperty(InternalFields[0, 1], property.FindPropertyRelative("e01"));
        //    BindingExtensions.BindProperty(InternalFields[0, 2], property.FindPropertyRelative("e02"));
        //    BindingExtensions.BindProperty(InternalFields[0, 3], property.FindPropertyRelative("e03"));
        //    BindingExtensions.BindProperty(InternalFields[1, 0], property.FindPropertyRelative("e10"));
        //    BindingExtensions.BindProperty(InternalFields[1, 1], property.FindPropertyRelative("e11"));
        //    BindingExtensions.BindProperty(InternalFields[1, 2], property.FindPropertyRelative("e12"));
        //    BindingExtensions.BindProperty(InternalFields[1, 3], property.FindPropertyRelative("e13"));
        //    BindingExtensions.BindProperty(InternalFields[2, 0], property.FindPropertyRelative("e20"));
        //    BindingExtensions.BindProperty(InternalFields[2, 1], property.FindPropertyRelative("e21"));
        //    BindingExtensions.BindProperty(InternalFields[2, 2], property.FindPropertyRelative("e22"));
        //    BindingExtensions.BindProperty(InternalFields[2, 3], property.FindPropertyRelative("e23"));
        //    BindingExtensions.BindProperty(InternalFields[3, 0], property.FindPropertyRelative("e30"));
        //    BindingExtensions.BindProperty(InternalFields[3, 1], property.FindPropertyRelative("e31"));
        //    BindingExtensions.BindProperty(InternalFields[3, 2], property.FindPropertyRelative("e32"));
        //    BindingExtensions.BindProperty(InternalFields[3, 3], property.FindPropertyRelative("e33"));
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