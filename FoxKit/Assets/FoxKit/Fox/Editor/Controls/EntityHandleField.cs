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

                        Update();

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

                        Update();

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

        private Button PasteButton;
        private Label EntityLabel;
        private Button DeleteButton;

        public new static readonly string ussClassName = "fox-entityhandle-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string inputLivePtrUssClassName = inputUssClassName + "--live-ptr";
        public static readonly string pasteButtonUssClassName = ussClassName + "__paste-button";
        public static readonly string deleteButtonUssClassName = ussClassName + "__delete-button";

        public VisualElement visualInput { get; }

        public EntityHandleField() 
            : this(null) { }

        public EntityHandleField(string label)
            : this(label, new VisualElement()) { }

        private EntityHandleField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            DeleteButton = new Button(DeleteButton_clicked);
            DeleteButton.text = "－";
            DeleteButton.AddToClassList(deleteButtonUssClassName);
            visualInput.Add(DeleteButton);

            EntityLabel = new Label();
            visualInput.Add(EntityLabel);

            PasteButton = new Button(PasteButton_clicked);
            PasteButton.text = "Paste";
            PasteButton.AddToClassList(pasteButtonUssClassName);
            visualInput.Add(PasteButton);

            AddToClassList(ussClassName);
            visualInput.AddToClassList(inputUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            Update();
        }

        private void PasteButton_clicked()
        {
            long address = 0;
            if (long.TryParse(EditorGUIUtility.systemCopyBuffer, out address))
            {
                if (address != UnityEngine.Serialization.ManagedReferenceUtility.RefIdNull)
                {
                    EntityProperty.managedReferenceId = address;
                    EntityProperty.serializedObject.ApplyModifiedProperties();
                }
            }
        }

        private void DeleteButton_clicked()
        {
            EntityProperty.managedReferenceId = UnityEngine.Serialization.ManagedReferenceUtility.RefIdNull;
            EntityProperty.serializedObject.ApplyModifiedProperties();
        }

        private void Update()
        {
            if (value.Entity == null)
            {
                EntityLabel.style.display = DisplayStyle.None;
                EntityLabel.text = "<b>null</b>";
                visualInput.RemoveFromClassList(inputLivePtrUssClassName);
            }
            else
            {
                EntityLabel.style.display = DisplayStyle.Flex;
                EntityLabel.text = $"<b>{value.Entity.GetClassEntityInfo().Name}</b>";
                visualInput.AddToClassList(inputLivePtrUssClassName);
            }
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