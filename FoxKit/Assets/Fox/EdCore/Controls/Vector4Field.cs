﻿using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Vector4Field : BaseField<UnityEngine.Vector4>, IFoxField, ICustomBindable
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

        public Vector4Field() : this(default)
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
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.firstFieldVariantUssClassName);
            XField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(XField);
            YField = new FloatField("Y");
            YField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(YField);
            ZField = new FloatField("Z");
            ZField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
            visualInput.Add(ZField);
            WField = new FloatField("W");
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

                    // Stop the Vector4Field itself's binding event; it's just a container for the actual BindableElements.
                    evt.StopPropagation();
                }
            }
        }

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label, PropertyInfo propertyInfo = null)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(XField, property.FindPropertyRelative("x"));
            BindingExtensions.BindProperty(YField, property.FindPropertyRelative("y"));
            BindingExtensions.BindProperty(ZField, property.FindPropertyRelative("z"));
            BindingExtensions.BindProperty(WField, property.FindPropertyRelative("w"));
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Vector4))]
    public class Vector4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Vector4Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<UnityEngine.Vector4>.alignedFieldUssClassName);

            return field;
        }
    }
}