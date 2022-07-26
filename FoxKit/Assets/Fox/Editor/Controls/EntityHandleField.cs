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
using Object = UnityEngine.Object;

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

        // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
        //[EventInterest(typeof(MouseDownEvent), typeof(KeyDownEvent), typeof(DragUpdatedEvent), typeof(DragPerformEvent), typeof(DragLeaveEvent))]
        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            if (evt == null)
            {
                return;
            }

            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                EntityProperty = property.FindPropertyRelative("_entity");

                BindingExtensions.TrackPropertyValue(this, EntityProperty, OnPropertyChanged);

                OnPropertyChanged(null);

                // Stop the EntityPtrField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }

            if ((evt as MouseDownEvent)?.button == (int)MouseButton.LeftMouse)
                OnMouseDown(evt as MouseDownEvent);
            else if (evt.eventTypeId == KeyDownEvent.TypeId())
            {
                var kdEvt = evt as KeyDownEvent;

                if (((evt as KeyDownEvent)?.keyCode == KeyCode.Space) ||
                    ((evt as KeyDownEvent)?.keyCode == KeyCode.KeypadEnter) ||
                    ((evt as KeyDownEvent)?.keyCode == KeyCode.Return))
                {
                    OnKeyboardEnter();
                }
                else if (kdEvt.keyCode == KeyCode.Delete ||
                         kdEvt.keyCode == KeyCode.Backspace)
                {
                    OnKeyboardDelete();
                }
            }
            else if (evt.eventTypeId == DragUpdatedEvent.TypeId())
                OnDragUpdated(evt);
            else if (evt.eventTypeId == DragPerformEvent.TypeId())
                OnDragPerform(evt);
            else if (evt.eventTypeId == DragLeaveEvent.TypeId())
                OnDragLeave();
        }

        //[EventInterest(typeof(MouseDownEvent))]
        //internal override void ExecuteDefaultActionDisabledAtTarget(EventBase evt)
        //{
        //    base.ExecuteDefaultActionDisabledAtTarget(evt);

        //    if ((evt as MouseDownEvent)?.button == (int)MouseButton.LeftMouse)
        //        OnMouseDown(evt as MouseDownEvent);
        //}

        private void OnDragLeave()
        {
            // Make sure we've cleared the accept drop look, whether we we in a drop operation or not.
            RemoveFromClassList("unity-object-field-display--accept-drop");
        }

        private void OnMouseDown(MouseDownEvent evt)
        {
            //GameObject targetGameObject = value?.gameObject;

            //if (targetGameObject == null)
            //    return;

            //// One click shows where the referenced object is, or pops up a preview
            //if (evt.clickCount == 1)
            //{
            //    // ping object
            //    bool anyModifiersPressed = evt.shiftKey || evt.ctrlKey;
            //    if (!anyModifiersPressed && targetGameObject)
            //    {
            //        EditorGUIUtility.PingObject(targetGameObject);
            //    }
            //    evt.StopPropagation();
            //}
            //// Double click opens the asset in external app or changes selection to referenced object
            //else if (evt.clickCount == 2)
            //{
            //    if (targetGameObject)
            //    {
            //        AssetDatabase.OpenAsset(targetGameObject);
            //        GUIUtility.ExitGUI();
            //    }
            //    evt.StopPropagation();
            //}
        }

        private void OnKeyboardEnter()
        {
            //m_ObjectField.ShowObjectSelector();
        }

        private void OnKeyboardDelete()
        {
            value = new EntityHandle();
        }

        private FoxEntity GetDragAndDropObject()
        {
            Object[] references = DragAndDrop.objectReferences;

            FoxEntity validatedObject = null;
            if (references[0] != null && references[0] is GameObject && (references[0] as GameObject).TryGetComponent<FoxEntity>(out validatedObject))
            {
                if (!EditorUtility.IsPersistent(validatedObject))
                    return validatedObject;
            }

            return null;
        }

        private void OnDragUpdated(EventBase evt)
        {
            FoxEntity validatedObject = GetDragAndDropObject();
            if (validatedObject != null)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                AddToClassList("unity-object-field-display--accept-drop");

                evt.StopPropagation();
            }
        }

        private void OnDragPerform(EventBase evt)
        {
            FoxEntity validatedObject = GetDragAndDropObject();
            if (validatedObject != null)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                value = EntityHandle.Get(validatedObject.Entity);

                DragAndDrop.AcceptDrag();
                RemoveFromClassList("unity-object-field-display--accept-drop");

                evt.StopPropagation();
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