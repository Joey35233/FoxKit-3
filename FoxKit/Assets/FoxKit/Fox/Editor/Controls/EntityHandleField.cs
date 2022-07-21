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
    public class EntityHandleField : BaseField<EntityHandle>, IFoxField, ICustomBindable
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

        private VisualElement DummyField;

        public new static readonly string ussClassName = "fox-entityhandle-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public EntityHandleField() 
            : this(null) { }

        public EntityHandleField(string label)
            : this(label, new VisualElement()) { }

        private EntityHandleField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            //DummyField = new VisualElement();
            //DummyField.AddToClassList("unity-base-text-field__input");
            //visualInput.Add(DummyField);

            AddToClassList(ussClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList("unity-base-text-field__input");
            labelElement.AddToClassList(labelUssClassName);
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