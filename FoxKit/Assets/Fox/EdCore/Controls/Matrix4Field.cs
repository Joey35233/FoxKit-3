using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Matrix4Field : BaseField<UnityEngine.Matrix4x4>, IFoxField, ICustomBindable
    {
        private readonly FloatField[,] InternalFields;

        public static new readonly string ussClassName = "fox-matrix4-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

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
                    FloatField field = new($"{i}{j}");
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

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !String.IsNullOrWhiteSpace(bindingPath))
            {
                var property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                if (property.propertyType != SerializedPropertyType.Float)
                {
                    BindingExtensions.BindProperty(InternalFields[0, 0], property.FindPropertyRelative("e00"));
                    BindingExtensions.BindProperty(InternalFields[0, 1], property.FindPropertyRelative("e01"));
                    BindingExtensions.BindProperty(InternalFields[0, 2], property.FindPropertyRelative("e02"));
                    BindingExtensions.BindProperty(InternalFields[0, 3], property.FindPropertyRelative("e03"));
                    BindingExtensions.BindProperty(InternalFields[1, 0], property.FindPropertyRelative("e10"));
                    BindingExtensions.BindProperty(InternalFields[1, 1], property.FindPropertyRelative("e11"));
                    BindingExtensions.BindProperty(InternalFields[1, 2], property.FindPropertyRelative("e12"));
                    BindingExtensions.BindProperty(InternalFields[1, 3], property.FindPropertyRelative("e13"));
                    BindingExtensions.BindProperty(InternalFields[2, 0], property.FindPropertyRelative("e20"));
                    BindingExtensions.BindProperty(InternalFields[2, 1], property.FindPropertyRelative("e21"));
                    BindingExtensions.BindProperty(InternalFields[2, 2], property.FindPropertyRelative("e22"));
                    BindingExtensions.BindProperty(InternalFields[2, 3], property.FindPropertyRelative("e23"));
                    BindingExtensions.BindProperty(InternalFields[3, 0], property.FindPropertyRelative("e30"));
                    BindingExtensions.BindProperty(InternalFields[3, 1], property.FindPropertyRelative("e31"));
                    BindingExtensions.BindProperty(InternalFields[3, 2], property.FindPropertyRelative("e32"));
                    BindingExtensions.BindProperty(InternalFields[3, 3], property.FindPropertyRelative("e33"));

                    // Stop the Matrix4Field itself's binding event; it's just a container for the actual BindableElements.
                    evt.StopPropagation();
                }
            }
        }

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label, PropertyInfo propertyInfo = null)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(InternalFields[0, 0], property.FindPropertyRelative("e00"));
            BindingExtensions.BindProperty(InternalFields[0, 1], property.FindPropertyRelative("e01"));
            BindingExtensions.BindProperty(InternalFields[0, 2], property.FindPropertyRelative("e02"));
            BindingExtensions.BindProperty(InternalFields[0, 3], property.FindPropertyRelative("e03"));
            BindingExtensions.BindProperty(InternalFields[1, 0], property.FindPropertyRelative("e10"));
            BindingExtensions.BindProperty(InternalFields[1, 1], property.FindPropertyRelative("e11"));
            BindingExtensions.BindProperty(InternalFields[1, 2], property.FindPropertyRelative("e12"));
            BindingExtensions.BindProperty(InternalFields[1, 3], property.FindPropertyRelative("e13"));
            BindingExtensions.BindProperty(InternalFields[2, 0], property.FindPropertyRelative("e20"));
            BindingExtensions.BindProperty(InternalFields[2, 1], property.FindPropertyRelative("e21"));
            BindingExtensions.BindProperty(InternalFields[2, 2], property.FindPropertyRelative("e22"));
            BindingExtensions.BindProperty(InternalFields[2, 3], property.FindPropertyRelative("e23"));
            BindingExtensions.BindProperty(InternalFields[3, 0], property.FindPropertyRelative("e30"));
            BindingExtensions.BindProperty(InternalFields[3, 1], property.FindPropertyRelative("e31"));
            BindingExtensions.BindProperty(InternalFields[3, 2], property.FindPropertyRelative("e32"));
            BindingExtensions.BindProperty(InternalFields[3, 3], property.FindPropertyRelative("e33"));
        }
    }

    // [CustomPropertyDrawer(typeof(UnityEngine.Matrix4x4))]
    // public class Matrix4Drawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new Matrix4Field(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<UnityEngine.Matrix4x4>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}