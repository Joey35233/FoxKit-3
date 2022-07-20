using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Fox.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using System;
using System.Reflection;

namespace Fox.Editor
{
    public class EntityHandleField : TextValueField<EntityHandle>, IFoxField, ICustomBindable
    {
        private SerializedProperty EntityProperty;
        public override EntityHandle value
        {
            get => base.value;
            set
            {
                EntityHandle newValue = value;
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        var previousValue = this.value;
                        SetValueWithoutNotify(newValue);

                        // "Custom binding"
                        if (newValue.Entity != EntityProperty.managedReferenceValue)
                        {
                            EntityProperty.managedReferenceValue = newValue.Entity;
                            EntityProperty.serializedObject.ApplyModifiedProperties();
                        }

                        using (ChangeEvent<EntityHandle> evt = ChangeEvent<EntityHandle>.GetPooled(previousValue, newValue))
                        {
                            evt.target = this;
                            SendEvent(evt);
                        }
                    }
                    else
                    {
                        SetValueWithoutNotify(value);

                        // "Custom binding"
                        if (newValue.Entity != EntityProperty.managedReferenceValue)
                        {
                            EntityProperty.managedReferenceValue = newValue.Entity;
                            EntityProperty.serializedObject.ApplyModifiedProperties();
                        }
                    }
                }
            }
        }

        EntityHandleInput integerInput => (EntityHandleInput)textInputBase;

        protected override string ValueToString(EntityHandle v)
        {
            if (this.EntityProperty == null)
                return "null";

            string serializedPropertyPath = this.EntityProperty.propertyPath;

            StringBuilder outputPath = new StringBuilder(serializedPropertyPath.Length);
            string[] tokens = serializedPropertyPath.Split('.');
            int i = 1;
            while (i < tokens.Length)
            {
                string token = tokens[i];

                if (i != 1)
                    outputPath.Append('.');

                // Array
                // StringMap

                // EntityPtr
                if (i < tokens.Length - 1 && tokens[i + 1] == "_ptr")
                {
                    outputPath.Append(tokens[i]);
                    i += 2;
                    continue;
                }

                // EntityHandle
                if (i < tokens.Length - 1 && tokens[i + 1] == "_entity")
                {
                    outputPath.Append(tokens[i]);
                    i += 2;
                    continue;
                }

                outputPath.Append(tokens[i]);
                i++;
            }

            bool debug = false;
            if (debug == true)
                return serializedPropertyPath;

            return outputPath.ToString();
        }

        protected override EntityHandle StringToValue(string str)
        {
            throw new System.NotImplementedException();
        }

        public new static readonly string ussClassName = "fox-entityhandle-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public EntityHandleField() 
            : this(null) { }

        public EntityHandleField(string label)
            : this(label, new EntityHandleInput()) { }

        private EntityHandleField(string label, EntityHandleInput visInput)
            : base(label, -1, visInput)
        {
            visualInput = visInput;

            isDelayed = true;

            AddToClassList(ussClassName);

            visualInput.AddToClassList(inputUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                EntityProperty = property.FindPropertyRelative("_entity");

                BindingExtensions.TrackPropertyValue(this, EntityProperty, OnPropertyChanged);

                OnPropertyChanged(null);

                // Stop the EntityPtrField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }
        }

        private void OnPropertyChanged(SerializedProperty property)
        {
            value = EntityHandle.Get(EntityProperty.managedReferenceValue as Entity);
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, EntityHandle startValue) { throw new System.NotImplementedException(); }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            EntityProperty = property.FindPropertyRelative("_entity");

            BindingExtensions.TrackPropertyValue(this, EntityProperty, OnPropertyChanged);

            OnPropertyChanged(null);
        }

        class EntityHandleInput : TextValueInput
        {
            EntityHandleField parentEntityHandleField => (EntityHandleField)parent;

            internal EntityHandleInput()
            {
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, EntityHandle startValue) { throw new System.NotImplementedException(); }

            protected override string ValueToString(EntityHandle v)
            {
                if (v == null)
                    return "null";
                else
                    throw new System.NotImplementedException();
            }

            protected override EntityHandle StringToValue(string str)
            {
                throw new System.NotImplementedException();
            }
        }
    }

    [CustomPropertyDrawer(typeof(EntityHandle))]
    public class EntityHandleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new EntityHandleField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<Fox.Core.EntityHandle>.alignedFieldUssClassName);

            return field;
        }
    }
}