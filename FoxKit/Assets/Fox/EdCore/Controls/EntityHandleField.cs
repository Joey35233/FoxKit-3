using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Fox.EdCore
{
    public class EntityHandleField : BaseField<Entity>, IFoxField
    {
        private SerializedProperty EntityProperty;

        public override Entity value
        {
            get => base.value;
            set
            {
                Entity newValue = value;
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        Entity previousValue = this.value;
                        SetValueWithoutNotify(newValue);

                        Update();

                        // "Custom binding"
                        if (newValue != EntityProperty.objectReferenceValue)
                        {
                            EntityProperty.objectReferenceValue = newValue;
                            _ = EntityProperty.serializedObject.ApplyModifiedProperties();
                        }

                        using (var evt = ChangeEvent<Entity>.GetPooled(previousValue, newValue))
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
                        if (newValue != EntityProperty.objectReferenceValue)
                        {
                            EntityProperty.objectReferenceValue = newValue;
                            _ = EntityProperty.serializedObject.ApplyModifiedProperties();
                        }
                    }
                }
            }
        }

        private readonly Button PasteButton;
        private readonly Label EntityLabel;
        private readonly Button DeleteButton;

        public static new readonly string ussClassName = "fox-entityhandle-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string inputLivePtrUssClassName = inputUssClassName + "--live-ptr";
        public static readonly string pasteButtonUssClassName = ussClassName + "__paste-button";
        public static readonly string deleteButtonUssClassName = ussClassName + "__delete-button";

        public VisualElement visualInput
        {
            get;
        }

        public EntityHandleField()
            : this(label: null)
        {
        }
        
        public EntityHandleField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public EntityHandleField(string label)
            : this(label, new VisualElement()) { }

        private EntityHandleField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            DeleteButton = new Button(DeleteButton_clicked)
            {
                text = "－"
            };
            DeleteButton.AddToClassList(deleteButtonUssClassName);
            visualInput.Add(DeleteButton);

            EntityLabel = new Label();
            visualInput.Add(EntityLabel);

            PasteButton = new Button(PasteButton_clicked)
            {
                text = "Paste"
            };
            PasteButton.AddToClassList(pasteButtonUssClassName);
            visualInput.Add(PasteButton);

            AddToClassList(ussClassName);
            visualInput.AddToClassList(inputUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            Update();
        }

        private void PasteButton_clicked()
        {
            string copyBuffer = EditorGUIUtility.systemCopyBuffer;
            if (copyBuffer.StartsWith("FoxObj: "))
            {
                if (Int32.TryParse(copyBuffer.Substring(8), out int instanceID))
                {
                    EntityProperty.objectReferenceInstanceIDValue = instanceID;
                    _ = EntityProperty.serializedObject.ApplyModifiedProperties();
                }
            }
        }

        private void DeleteButton_clicked()
        {
            EntityProperty.objectReferenceInstanceIDValue = 0;
            _ = EntityProperty.serializedObject.ApplyModifiedProperties();
        }

        private void Update()
        {
            if (value == null)
            {
                EntityLabel.style.display = DisplayStyle.None;
                EntityLabel.text = "<b>null</b>";
                visualInput.RemoveFromClassList(inputLivePtrUssClassName);
            }
            else
            {
                EntityLabel.style.display = DisplayStyle.Flex;
                EntityLabel.text = $"<b>{value.GetClassEntityInfo().Name}</b> {value.name}";
                visualInput.AddToClassList(inputLivePtrUssClassName);
            }
        }

        private void OnPropertyChanged(SerializedProperty property) => value = EntityProperty.objectReferenceValue as Entity;

        // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
        //[EventInterest(typeof(MouseDownEvent), typeof(KeyDownEvent), typeof(DragUpdatedEvent), typeof(DragPerformEvent), typeof(DragLeaveEvent))]
        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            if (evt == null)
            {
                return;
            }

            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !System.String.IsNullOrWhiteSpace(bindingPath))
            {
                var property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                EntityProperty = property;

                BindingExtensions.TrackPropertyValue(this, EntityProperty, OnPropertyChanged);

                OnPropertyChanged(null);

                // Stop the EntityPtrField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }

            if ((evt as MouseDownEvent)?.button == (int)MouseButton.LeftMouse)
            {
                OnMouseDown(evt as MouseDownEvent);
            }
            else if (evt.eventTypeId == KeyDownEvent.TypeId())
            {
                var kdEvt = evt as KeyDownEvent;

                if ((evt as KeyDownEvent)?.keyCode is KeyCode.Space or KeyCode.KeypadEnter or KeyCode.Return)
                {
                    OnKeyboardEnter();
                }
                else if (kdEvt.keyCode is KeyCode.Delete or KeyCode.Backspace)
                {
                    OnKeyboardDelete();
                }
            }
            else if (evt.eventTypeId == DragUpdatedEvent.TypeId())
            {
                OnDragUpdated(evt);
            }
            else if (evt.eventTypeId == DragPerformEvent.TypeId())
            {
                OnDragPerform(evt);
            }
            else if (evt.eventTypeId == DragLeaveEvent.TypeId())
            {
                OnDragLeave();
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
            if (value == null || value.gameObject is not GameObject targetGameObject)
                return;

            // One click shows where the referenced object is, or pops up a preview
            if (evt.clickCount == 1)
            {
                // ping object
                bool anyModifiersPressed = evt.shiftKey || evt.ctrlKey;
                if (!anyModifiersPressed && targetGameObject)
                {
                    EditorGUIUtility.PingObject(targetGameObject);
                }
                evt.StopPropagation();
            }
            // Double click opens the asset in external app or changes selection to referenced object
            else if (evt.clickCount == 2)
            {
                if (targetGameObject)
                {
                    AssetDatabase.OpenAsset(targetGameObject);
                    GUIUtility.ExitGUI();
                }
                evt.StopPropagation();
            }
        }

        private void OnKeyboardEnter()
        {
            //m_ObjectField.ShowObjectSelector();
        }

        private void OnKeyboardDelete() => value = null;

        private Entity GetDragAndDropObject()
        {
            Object[] references = DragAndDrop.objectReferences;
            if (references.Length < 1 || references[0] is not GameObject reference || reference.GetComponent<Entity>() is not { } entityReference)
                return null;

            if (!EditorUtility.IsPersistent(entityReference))
                return entityReference;

            return null;
        }

        private void OnDragUpdated(EventBase evt)
        {
            Entity validatedObject = GetDragAndDropObject();
            if (validatedObject != null)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                AddToClassList("unity-object-field-display--accept-drop");

                evt.StopPropagation();
            }
        }

        private void OnDragPerform(EventBase evt)
        {
            Entity validatedObject = GetDragAndDropObject();
            if (validatedObject != null)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                value = validatedObject;

                DragAndDrop.AcceptDrag();
                RemoveFromClassList("unity-object-field-display--accept-drop");

                evt.StopPropagation();
            }
        }

        // Make sure we've cleared the accept drop look, whether we we in a drop operation or not.
        private void OnDragLeave() => RemoveFromClassList("unity-object-field-display--accept-drop");
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(EntityHandle))]
    // public class EntityHandleDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new EntityHandleField(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<Fox.Core.Entity>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}