using Fox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityPtrField<T> : BaseField<Fox.Core.EntityPtr<T>>, IFoxField 
        where T : Entity, new()
    {
        private VisualElement PropertyContainer;
        private Button CreateDeleteButton;
        private Label EntityLabel;

        public new static readonly string ussClassName = "fox-entityptr-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string createButtonUssClassName = ussClassName + "__create-button";
        public static readonly string deleteButtonUssClassName = ussClassName + "__delete-button";

        public VisualElement visualInput { get; }

        private SerializedProperty PtrProperty;

        public enum CreateDeleteButtonMode
        {
            CreateEntity,
            DeleteEntity
        }
        public CreateDeleteButtonMode ButtonMode { get; private set; }

        public Type SpecificEntityType { get; private set; }

        public EntityPtrField() : this(default)
        {
        }

        public EntityPtrField(string label)
            : this(label, new VisualElement())
        {
        }

        private EntityPtrField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            PropertyContainer = new VisualElement();

            var header = new VisualElement();
            header.style.flexDirection = FlexDirection.Row;

            CreateDeleteButton = new Button(CreateDeleteButton_clicked);

            EntityLabel = new Label();

            ButtonMode = CreateDeleteButtonMode.CreateEntity;

            header.Add(CreateDeleteButton);
            header.Add(EntityLabel);
            visualInput.Add(header);

            visualInput.Add(PropertyContainer);

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            Type evtType = evt.GetType();
            if ((evtType.Name == "SerializedPropertyBindEvent") && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty entityPtrProperty = evtType.GetProperty("bindProperty").GetValue(evt) as SerializedProperty;
                PtrProperty = entityPtrProperty.FindPropertyRelative("_ptr");

                if (PtrProperty != null)
                {
                    OnPtrPropertyChanged(PtrProperty);

                    BindingExtensions.TrackPropertyValue(this, PtrProperty, OnPtrPropertyChanged);
                    BindingExtensions.TrackPropertyValue(this, entityPtrProperty, (SerializedProperty property) => UnityEngine.Debug.Log("Parent changed!"));
                }

                // Stop the EntityPtrField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }
            else if (evt is SerializedPropertyChangeEvent changeEvent)
            {
                OnPtrPropertyChanged(changeEvent.changedProperty);
            }
        }

        private void OnPtrPropertyChanged(SerializedProperty property)
        {
            PtrProperty = property.Copy();

            UnityEngine.Debug.Log("EntityPtr<T> property changed callback!");
            if (PtrProperty.managedReferenceValue is null)
            {
                ButtonMode = CreateDeleteButtonMode.CreateEntity;
                CreateDeleteButton.text = "＋";
                CreateDeleteButton.RemoveFromClassList(deleteButtonUssClassName);
                CreateDeleteButton.AddToClassList(createButtonUssClassName);

                EntityLabel.text = "null";

                PropertyContainer.Clear();
            }
            else
            {
                ButtonMode = CreateDeleteButtonMode.DeleteEntity;
                CreateDeleteButton.text = "－";
                CreateDeleteButton.RemoveFromClassList(createButtonUssClassName);
                CreateDeleteButton.AddToClassList(deleteButtonUssClassName);

                EntityLabel.text = $"{PtrProperty.managedReferenceValue.GetType().Name} ({typeof(T).Name})";

                PropertyContainer.Clear();
                foreach (SerializedProperty child in PtrProperty.GetChildren())
                {
                    var propField = new PropertyField(child);
                    propField.BindProperty(child);
                    PropertyContainer.Add(propField);
                }
            }
        }

        private void CreateDeleteButton_clicked()
        {
            if (PtrProperty == null)
                return;

            switch (ButtonMode)
            {
                case CreateDeleteButtonMode.CreateEntity:
                    {
                        SpecificEntityType = EntityTypePickerPopup.ShowPopup(typeof(T)).Type;
                        PtrProperty.managedReferenceValue = Activator.CreateInstance(SpecificEntityType);
                        PtrProperty.serializedObject.ApplyModifiedProperties();
                    }
                    break;
                case CreateDeleteButtonMode.DeleteEntity:
                    {
                        PtrProperty.managedReferenceValue = null;
                        PtrProperty.serializedObject.ApplyModifiedProperties();
                    }
                    break;
            }
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;

            BindingExtensions.BindProperty(this, property);
        }
    }

    [CustomPropertyDrawer(typeof(Core.EntityPtr<>))]
    public class EntityPtrDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            BindableElement genericField = (BindableElement)Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { fieldInfo.FieldType.GenericTypeArguments[0] }), new object[] { property.name });
            genericField.BindProperty(property);

            genericField.Q(className: BaseField<float>.labelUssClassName).AddToClassList(PropertyField.labelUssClassName);
            genericField.Q(className: BaseField<float>.inputUssClassName).AddToClassList(PropertyField.inputUssClassName);
            genericField.AddToClassList(BaseField<float>.alignedFieldUssClassName);

            return genericField;
        }
    }
}