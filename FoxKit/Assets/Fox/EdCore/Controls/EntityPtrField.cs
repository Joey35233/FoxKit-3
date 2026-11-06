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
    public class EntityPtrField<T> : BaseField<Object>, IFoxField where T :  Entity
    {
        private Entity OwnerEntity;
        private EntityInfo EntityInfo = EntityInfo.GetEntityInfo<T>();

        private static string TypeName = typeof(T).Name;

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

            CreateDeleteButton = new Button(CreateDeleteButton_clicked);
            Header.Add(CreateDeleteButton);

            EntityLabel = new Label();
            Header.Add(EntityLabel);

            CopyButton = new Button(() => EditorGUIUtility.systemCopyBuffer = $"FoxObj: {value.GetInstanceID().ToString()}");
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

            this.RegisterValueChangedCallback(OnPropertyChanged);
        }

        [EventInterest(typeof(MouseDownEvent), typeof(KeyDownEvent))]
        protected override void HandleEventBubbleUp(EventBase evt)
        {
            base.HandleEventBubbleUp(evt);
        
            if (evt == null)
                return;
            
            if (evt.eventTypeId == MouseDownEvent.TypeId() && ((MouseDownEvent)evt).button == (int)MouseButton.LeftMouse)
            {
                OnMouseDown((MouseDownEvent)evt);
            }
            else if (evt.eventTypeId == KeyDownEvent.TypeId())
            {
                if (((KeyDownEvent)evt).keyCode is KeyCode.Delete or KeyCode.Backspace)
                {
                    OnKeyboardDelete();
                }
            }
        }

        // [EventInterest(typeof(MouseDownEvent))]
        // internal override void ExecuteDefaultActionDisabledAtTarget(EventBase evt)
        // {
        //     base.ExecuteDefaultActionDisabledAtTarget(evt);
        //
        //     if ((evt as MouseDownEvent)?.button == (int)MouseButton.LeftMouse)
        //         OnMouseDown(evt as MouseDownEvent);
        // }

        private void OnMouseDown(MouseDownEvent evt)
        {
            if (value == null || value is not Entity targetEntity)
                return;
        
            // One click shows where the referenced object is, or pops up a preview
            if (evt.clickCount == 1)
            {
                // ping object
                bool anyModifiersPressed = evt.shiftKey || evt.ctrlKey;
                if (!anyModifiersPressed && targetEntity)
                {
                    EditorGUIUtility.PingObject(targetEntity);
                }
                evt.StopPropagation();
            }
            // Double click opens the asset in external app or changes selection to referenced object
            else if (evt.clickCount == 2)
            {
                if (targetEntity)
                {
                    AssetDatabase.OpenAsset(targetEntity);
                    GUIUtility.ExitGUI();
                }
                evt.StopPropagation();
            }
        }

        private void OnKeyboardDelete() => value = null;

        private void OnPropertyChanged(ChangeEvent<Object> evt)
        {
            if (evt.target == this)
            {
                if (value == null)
                {
                    Header.RemoveFromClassList(headerLivePtrUssClassName);
        
                    ButtonMode = CreateDeleteButtonMode.CreateEntity;
                    CreateDeleteButton.text = "＋";
                    CreateDeleteButton.RemoveFromClassList(deleteButtonUssClassName);
                    CreateDeleteButton.AddToClassList(createButtonUssClassName);
        
                    EntityLabel.text = $"<b>{TypeName}</b>";
        
                    PropertyContainer.Clear();
                    PropertyContainer.visible = false;
                }
                else
                {
                    Header.AddToClassList(headerLivePtrUssClassName);
        
                    ButtonMode = CreateDeleteButtonMode.DeleteEntity;
                    CreateDeleteButton.text = "－";
                    CreateDeleteButton.RemoveFromClassList(createButtonUssClassName);
                    CreateDeleteButton.AddToClassList(deleteButtonUssClassName);
        
                    EntityLabel.text = $"<b>{TypeName}</b> {value.name}";
                    EntityLabel.enableRichText = true;
        
                    PropertyContainer.visible = true;
                    PropertyContainer.Clear();
                    CustomEntityFieldDesc? customFieldDesc = CustomEntityFieldManager.Get(EntityInfo);
                    IEntityField entityField = customFieldDesc?.Constructor is {} customConstructor ? customConstructor() : new EntityField<T>();
                    SerializedObject newObject = new SerializedObject(value);
                    entityField.Build(newObject);
                    VisualElement entityFieldElement = entityField as VisualElement;
                    entityFieldElement.Bind(newObject);
                    PropertyContainer.Add(entityFieldElement);
                }
            }
        }

        private void CreateDeleteButton_clicked()
        {
            switch (ButtonMode)
            {
                case CreateDeleteButtonMode.CreateEntity:
                {
                    SpecificEntityType = EntityTypePickerPopup.ShowPopup(typeof(T))?.Type;
                    if (SpecificEntityType != null)
                    {
                        GameObject newGameObject = new GameObject();
                        Entity newEntity = (Entity)newGameObject.AddComponent(SpecificEntityType);
                        newGameObject.name = newEntity.GenerateName();
                        value = (T)newEntity;
            
                        if (OwnerEntity != null)
                        {
                            newEntity.transform.SetParent(OwnerEntity.gameObject.transform);
                        }
                        else
                        {
                            Debug.LogWarning("EntityPtrField: Owning entity invalid.");
                        }
                    }
                }
                break;
                
                case CreateDeleteButtonMode.DeleteEntity:
                {
                    if (value is Entity entity)
                        Undo.DestroyObjectImmediate(entity.gameObject);
                    else
                        throw new ArgumentException($"EntityPtrField storing non-Entity");
            
                    value = null;
                }
                break;
            }
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}