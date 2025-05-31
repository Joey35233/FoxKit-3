using Fox.Core;
using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
using PropertyInfo = Fox.Core.PropertyInfo;

namespace Fox.EdCore
{
    public class EntityPtrField<T> : BaseField<T>, IFoxField
        where T : Entity
    {
        private SerializedProperty PtrProperty;
        private EntityInfo EntityInfo = EntityInfo.GetEntityInfo<T>();

        private readonly VisualElement PropertyContainer;
        private readonly VisualElement Header;
        private readonly Button CopyButton;
        private readonly Button CreateDeleteButton;
        private readonly Label EntityLabel;

        public static new readonly string ussClassName = "fox-entityptr-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string headerUssClassName = ussClassName + "__header";
        public static readonly string headerLivePtrUssClassName = headerUssClassName + "--live-ptr";
        public static readonly string copyButtonUssClassName = ussClassName + "__copy-button";
        public static readonly string createButtonUssClassName = ussClassName + "__create-button";
        public static readonly string deleteButtonUssClassName = ussClassName + "__delete-button";
        public static readonly string propertyContainerUssClassName = ussClassName + "__property-container";

        public VisualElement visualInput
        {
            get;
        }

        public enum CreateDeleteButtonMode
        {
            CreateEntity,
            DeleteEntity
        }
        public CreateDeleteButtonMode ButtonMode
        {
            get; private set;
        }

        public Type SpecificEntityType
        {
            get; private set;
        }

        public EntityPtrField() 
            : this(label: null)
        {
        }
        
        public EntityPtrField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
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

            CopyButton = new Button(() => EditorGUIUtility.systemCopyBuffer = $"FoxObj: {PtrProperty.objectReferenceInstanceIDValue.ToString()}")
            {
                text = "Copy"
            };
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
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !System.String.IsNullOrWhiteSpace(bindingPath))
            {
                var property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                PtrProperty = property;

                BindingExtensions.TrackPropertyValue(this, PtrProperty, OnPropertyChanged);

                OnPropertyChanged(null);

                // Stop the EntityPtrField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }
        }

        private void OnPropertyChanged(SerializedProperty property)
        {
            // [-] clicked
            if (PtrProperty.objectReferenceValue is null)
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
            // [+] clicked
            else
            {
                Header.AddToClassList(headerLivePtrUssClassName);

                ButtonMode = CreateDeleteButtonMode.DeleteEntity;
                CreateDeleteButton.text = "－";
                CreateDeleteButton.RemoveFromClassList(createButtonUssClassName);
                CreateDeleteButton.AddToClassList(deleteButtonUssClassName);

                EntityLabel.text = $"<b>{PtrProperty.objectReferenceValue.GetType().Name}</b> ({typeof(T).Name})";
                EntityLabel.enableRichText = true;

                PropertyContainer.visible = true;
                PropertyContainer.Clear();
                CustomEntityFieldDesc? customFieldDesc = EntityEditorManager.Get(EntityInfo);
                IEntityField entityField = customFieldDesc?.Constructor is {} customConstructor ? customConstructor() : new BaseEntityField<T>();
                SerializedObject newObject = new SerializedObject(PtrProperty.objectReferenceValue);
                entityField.Build(newObject);
                VisualElement entityFieldElement = entityField as VisualElement;
                entityFieldElement.Bind(newObject);
                PropertyContainer.Add(entityFieldElement);
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
                        GameObject newGameObject = new GameObject();
                        Entity newEntity = newGameObject.AddComponent(SpecificEntityType) as Entity;
                        newGameObject.name = newEntity.ToString();
                        PtrProperty.objectReferenceValue = newEntity;

                        Object targetObject = PtrProperty.serializedObject.targetObject;
                        if (targetObject != null && targetObject is Entity targetEntity)
                        {
                            newEntity.transform.SetParent(targetEntity.gameObject.transform);
                        }
                        else
                        {
                            Debug.LogWarning("EntityPtrField: Owning entity invalid.");
                        }
                        
                        _ = PtrProperty.serializedObject.ApplyModifiedProperties();
                    }
                }
                break;
                // [－] clicked
                case CreateDeleteButtonMode.DeleteEntity:
                {
                    // UnityEngine.Object obj = PtrProperty.objectReferenceValue;
                    // if (obj is Entity entity)
                    //     Undo.DestroyObjectImmediate(entity.gameObject);
                    // else
                    //     throw new ArgumentException($"EntityPtrField storing non-Entity");

                    PtrProperty.objectReferenceValue = null;

                    _ = PtrProperty.serializedObject.ApplyModifiedProperties();
                }
                break;
            }
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}