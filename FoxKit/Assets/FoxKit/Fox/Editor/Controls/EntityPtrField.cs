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
    public class EntityPtrField<T> : BaseField<Fox.Core.EntityPtr<T>>, IFoxField, ICustomBindable
        where T : Entity, new()
    {
        private VisualElement PropertyContainer;
        private VisualElement Header;
        private Button CopyButton;
        private Button CreateDeleteButton;
        private Label EntityLabel;

        public new static readonly string ussClassName = "fox-entityptr-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string headerUssClassName = ussClassName + "__header";
        public static readonly string headerLivePtrUssClassName = headerUssClassName + "--live-ptr";
        public static readonly string copyButtonUssClassName = ussClassName + "__copy-button";
        public static readonly string createButtonUssClassName = ussClassName + "__create-button";
        public static readonly string deleteButtonUssClassName = ussClassName + "__delete-button";
        public static readonly string propertyContainerUssClassName = ussClassName + "__property-container";

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

            Header = new VisualElement();
            Header.AddToClassList(headerUssClassName);

            ButtonMode = CreateDeleteButtonMode.CreateEntity;
            CreateDeleteButton = new Button(CreateDeleteButton_clicked);
            Header.Add(CreateDeleteButton);

            EntityLabel = new Label();
            Header.Add(EntityLabel);

            CopyButton = new Button(() => EditorGUIUtility.systemCopyBuffer = PtrProperty.managedReferenceId.ToString());
            CopyButton.text = "Copy";
            CopyButton.AddToClassList(copyButtonUssClassName);
            Header.Add(CopyButton);

            visualInput.Add(Header);

            PropertyContainer = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
            PropertyContainer.AddToClassList(propertyContainerUssClassName);

            visualInput.Add(PropertyContainer);

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                PtrProperty = property.FindPropertyRelative("_ptr");

                BindingExtensions.TrackPropertyValue(this, PtrProperty, OnPropertyChanged);

                OnPropertyChanged(null);

                // Stop the EntityPtrField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }
        }

        private void OnPropertyChanged(SerializedProperty property)
        {
            // [－] clicked
            if (PtrProperty.managedReferenceValue is null)
            {
                Header.RemoveFromClassList(headerLivePtrUssClassName);

                ButtonMode = CreateDeleteButtonMode.CreateEntity;
                CreateDeleteButton.text = "＋";
                CreateDeleteButton.RemoveFromClassList(deleteButtonUssClassName);
                CreateDeleteButton.AddToClassList(createButtonUssClassName);

                EntityLabel.text = $"<b>null</b> ({typeof(T).Name})";

                PropertyContainer.Clear();
                PropertyContainer.visible = false;
            }
            // [＋] clicked
            else
            {
                Header.AddToClassList(headerLivePtrUssClassName);

                ButtonMode = CreateDeleteButtonMode.DeleteEntity;
                CreateDeleteButton.text = "－";
                CreateDeleteButton.RemoveFromClassList(createButtonUssClassName);
                CreateDeleteButton.AddToClassList(deleteButtonUssClassName);

                EntityLabel.text = $"<b>{PtrProperty.managedReferenceValue.GetType().Name}</b> ({typeof(T).Name})";
                EntityLabel.enableRichText = true;

                PropertyContainer.visible = true;
                PropertyContainer.Clear();
                ICustomBindable entityField = Activator.CreateInstance(typeof(EntityField<>).MakeGenericType(new Type[] { typeof(T) })) as ICustomBindable;
                entityField.BindProperty(PtrProperty);
                PropertyContainer.Add(entityField as VisualElement);
            }
        }

        private void CreateDeleteButton_clicked()
        {
            switch (ButtonMode)
            {
                // [＋] clicked
                case CreateDeleteButtonMode.CreateEntity:
                    {
                        SpecificEntityType = EntityTypePickerPopup.ShowPopup(typeof(T))?.Type;
                        if (SpecificEntityType != null)
                        {
                            PtrProperty.managedReferenceValue = Activator.CreateInstance(SpecificEntityType);
                            PtrProperty.serializedObject.ApplyModifiedProperties();
                        }
                    }
                    break;
                // [－] clicked
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

            PtrProperty = property.FindPropertyRelative("_ptr");

            BindingExtensions.TrackPropertyValue(this, PtrProperty, OnPropertyChanged);

            OnPropertyChanged(null);
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