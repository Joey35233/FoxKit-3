using Fox.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Fox.Editor
{
    public class EntityHandleFieldTest : BaseField<FoxEntity>
    {
        public override void SetValueWithoutNotify(FoxEntity newValue)
        {
            var valueChanged = !EqualityComparer<Object>.Default.Equals(this.value, newValue);

            base.SetValueWithoutNotify(newValue);

            if (valueChanged)
            {
                m_ObjectFieldDisplay.Update();
            }
        }

        private class ObjectFieldDisplay : VisualElement
        {
            private readonly EntityHandleFieldTest m_ObjectField;
            private readonly Label m_ObjectLabel;

            static readonly string ussClassName = "unity-object-field-display";
            static readonly string labelUssClassName = ussClassName + "__label";
            static readonly string acceptDropVariantUssClassName = ussClassName + "--accept-drop";

            public ObjectFieldDisplay(EntityHandleFieldTest objectField)
            {
                AddToClassList(ussClassName);
                m_ObjectLabel = new Label { pickingMode = PickingMode.Ignore };
                m_ObjectLabel.AddToClassList(labelUssClassName);
                m_ObjectField = objectField;

                Update();

                Add(m_ObjectLabel);
            }

            // JOEY: This is the fundamental display code. This whole inner class needs to be hooked into the TextValueField.
            public void Update()
            {
                GUIContent content = EditorGUIUtility.ObjectContent(m_ObjectField.value, typeof(FoxEntity));
                m_ObjectLabel.text = content.text;
            }

            [EventInterest(typeof(MouseDownEvent), typeof(KeyDownEvent), typeof(DragUpdatedEvent), typeof(DragPerformEvent), typeof(DragLeaveEvent))]
            protected override void ExecuteDefaultActionAtTarget(EventBase evt)
            {
                base.ExecuteDefaultActionAtTarget(evt);

                if (evt == null)
                {
                    return;
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
                RemoveFromClassList(acceptDropVariantUssClassName);
            }

            private void OnMouseDown(MouseDownEvent evt)
            {
                GameObject targetGameObject = m_ObjectField.value?.gameObject;

                if (targetGameObject == null)
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
                m_ObjectField.ShowObjectSelector();
            }

            private void OnKeyboardDelete()
            {
                m_ObjectField.value = null;
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
                    AddToClassList(acceptDropVariantUssClassName);

                    evt.StopPropagation();
                }
            }

            private void OnDragPerform(EventBase evt)
            {
                FoxEntity validatedObject = GetDragAndDropObject();
                if (validatedObject != null)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    m_ObjectField.value = validatedObject;

                    DragAndDrop.AcceptDrag();
                    RemoveFromClassList(acceptDropVariantUssClassName);

                    evt.StopPropagation();
                }
            }
        }

        // Literally just a button that calls this.ShowObjectSelector
        private class ObjectFieldSelector : VisualElement
        {
            private readonly EntityHandleFieldTest m_ObjectField;

            public ObjectFieldSelector(EntityHandleFieldTest objectField)
            {
                m_ObjectField = objectField;
            }

            [EventInterest(typeof(MouseDownEvent))]
            protected override void ExecuteDefaultAction(EventBase evt)
            {
                base.ExecuteDefaultAction(evt);

                if ((evt as MouseDownEvent)?.button == (int)MouseButton.LeftMouse)
                    m_ObjectField.ShowObjectSelector();
            }
        }

        private readonly ObjectFieldDisplay m_ObjectFieldDisplay;
        private readonly Action m_AsyncOnProjectOrHierarchyChangedCallback;
        private readonly Action m_OnProjectOrHierarchyChangedCallback;

        public new static readonly string ussClassName = "unity-object-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public static readonly string objectUssClassName = ussClassName + "__object";
        public static readonly string selectorUssClassName = ussClassName + "__selector";

        public VisualElement visualInput { get; }

        public EntityHandleFieldTest()
            : this(null) { }

        public EntityHandleFieldTest(string label)
            : this(label, new VisualElement())
        {
        }

        private EntityHandleFieldTest(string label, VisualElement visualInput)
            : base(label, new VisualElement())
        {
            visualInput.focusable = false;
            labelElement.focusable = false;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);

            m_ObjectFieldDisplay = new ObjectFieldDisplay(this) { focusable = true };
            m_ObjectFieldDisplay.AddToClassList(objectUssClassName);
            var objectSelector = new ObjectFieldSelector(this);
            objectSelector.AddToClassList(selectorUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.Add(m_ObjectFieldDisplay);
            visualInput.Add(objectSelector);

            // Get notified when hierarchy or project changes so we can update the display to handle renamed/missing objects.
            // This event is occasionally triggered before the reference in memory is updated, so we give it time to process.
            m_AsyncOnProjectOrHierarchyChangedCallback = () => schedule.Execute(m_OnProjectOrHierarchyChangedCallback);
            m_OnProjectOrHierarchyChangedCallback = () => m_ObjectFieldDisplay.Update();
            RegisterCallback<AttachToPanelEvent>((evt) =>
            {
                EditorApplication.projectChanged += m_AsyncOnProjectOrHierarchyChangedCallback;
                EditorApplication.hierarchyChanged += m_AsyncOnProjectOrHierarchyChangedCallback;
            });
            RegisterCallback<DetachFromPanelEvent>((evt) =>
            {
                EditorApplication.projectChanged -= m_AsyncOnProjectOrHierarchyChangedCallback;
                EditorApplication.hierarchyChanged -= m_AsyncOnProjectOrHierarchyChangedCallback;
            });
        }

        private FoxEntity TryReadFoxEntityFromGameObject(Object obj)
        {
            var gameObject = obj as GameObject;

            return gameObject?.GetComponent<FoxEntity>();
        }

        internal void ShowObjectSelector()
        {
            ObjectSelector.Show(obj: value, requiredType: typeof(FoxEntity), objectBeingEdited: null, allowSceneObjects: true, null, null, (Object obj) => value = TryReadFoxEntityFromGameObject(obj));
        }
    }
}
