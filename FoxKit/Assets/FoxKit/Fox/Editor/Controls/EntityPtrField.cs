using Fox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

// UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
// Unfortunately, I have had to implement manual binding, rather than via SerializedPropertyChangeEvent.
// This means that any programmatic changes to the data, such as via Undo or scripting, will not automatically be reflected in the UI.

namespace Fox.Editor
{
    public class EntityPtrField<T> : BaseField<Fox.Core.EntityPtr<T>>, IFoxField 
        where T : Entity, new()
    {
        private VisualElement PropertyContainer;
        private VisualElement Header;
        private Button CreateDeleteButton;
        private Label EntityLabel;

        public new static readonly string ussClassName = "fox-entityptr-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string headerUssClassName = ussClassName + "__header";
        public static readonly string headerLivePtrUssClassName = headerUssClassName + "--live-ptr";
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

            PropertyContainer = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
            PropertyContainer.AddToClassList(propertyContainerUssClassName);

            CreateDeleteButton = new Button(CreateDeleteButton_clicked);

            EntityLabel = new Label();

            ButtonMode = CreateDeleteButtonMode.CreateEntity;

            Header = new VisualElement();
            Header.AddToClassList(headerUssClassName);
            Header.Add(CreateDeleteButton);
            Header.Add(EntityLabel);
            visualInput.Add(Header);

            visualInput.Add(PropertyContainer);

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            Type evtType = evt.GetType();
            if ((evtType.Name == "SerializedPropertyBindEvent") && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty entityPtrProperty = evtType.GetProperty("bindProperty").GetValue(evt) as SerializedProperty;

                OnPtrPropertyChanged(entityPtrProperty.FindPropertyRelative("_ptr"));

                // UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
                // BindingExtensions.TrackPropertyValue(this, PtrProperty, OnPtrPropertyChanged);

                // Stop the EntityPtrField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }
            // UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
            //else if (evt is SerializedPropertyChangeEvent changeEvent)
            //{
            //    OnPtrPropertyChanged(changeEvent.changedProperty);
            //}
        }

        // UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
        private void OnPtrPropertyChanged(SerializedProperty property)
        {
            // The only place that makes me wonder if this is necessary is changeEvent.changedProperty.
            PtrProperty = property.Copy();

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
            switch (ButtonMode)
            {
                // [＋] clicked
                case CreateDeleteButtonMode.CreateEntity:
                    {
                        SpecificEntityType = EntityTypePickerPopup.ShowPopup(typeof(T)).Type;
                        PtrProperty.managedReferenceValue = Activator.CreateInstance(SpecificEntityType);
                        // UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
                        // Disable undo functionality until bug is fixed.
                        // PtrProperty.serializedObject.ApplyModifiedProperties();
                        PtrProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();

                        // UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
                        // This line should not exist.
                        OnPtrPropertyChanged(PtrProperty);
                    }
                    break;
                // [－] clicked
                case CreateDeleteButtonMode.DeleteEntity:
                    {
                        PtrProperty.managedReferenceValue = null;

                        // UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
                        // Disable undo functionality until bug is fixed.
                        // PtrProperty.serializedObject.ApplyModifiedProperties();
                        PtrProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();

                        // UNITYBUG: https://github.com/Joey35233/FoxKit-3/issues/9
                        // This line should not exist.
                        OnPtrPropertyChanged(PtrProperty);
                    }
                    break;
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

        //    BindingExtensions.BindProperty(this, property);
        //}
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