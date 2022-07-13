using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Fox.Editor
{
    public class ObjectField : /*TextInput*/BaseField<Object>
    {

        public override void SetValueWithoutNotify(Object newValue)
        {
            newValue = TryReadComponentFromGameObject(newValue, objectType);
            var valueChanged = !EqualityComparer<Object>.Default.Equals(this.value, newValue);

            base.SetValueWithoutNotify(newValue);

            if (valueChanged)
            {
                m_ObjectFieldDisplay.Update();
            }
        }

        private Type m_objectType;

        /// <summary>
        /// The type of the objects that can be assigned.
        /// </summary>
        public Type objectType
        {
            get { return m_objectType; }
            set
            {
                if (m_objectType != value)
                {
                    m_objectType = value;
                    m_ObjectFieldDisplay.Update();
                }
            }
        }

        /// <summary>
        /// Allows scene objects to be assigned to the field.
        /// </summary>
        public bool allowSceneObjects { get; set; }

        protected override void UpdateMixedValueContent()
        {
            m_ObjectFieldDisplay?.ShowMixedValue(showMixedValue);
        }

        private class ObjectFieldDisplay : VisualElement
        {
            private readonly ObjectField m_ObjectField;
            private readonly Image m_ObjectIcon;
            private readonly Label m_ObjectLabel;

            static readonly string ussClassName = "unity-object-field-display";
            static readonly string iconUssClassName = ussClassName + "__icon";
            static readonly string labelUssClassName = ussClassName + "__label";
            static readonly string acceptDropVariantUssClassName = ussClassName + "--accept-drop";

            internal void ShowMixedValue(bool show)
            {
                if (show)
                {
                    m_ObjectLabel.text = mixedValueString;
                    m_ObjectLabel.AddToClassList(mixedValueLabelUssClassName);
                    m_ObjectIcon.image = null;
                }
                else
                {
                    m_ObjectLabel.RemoveFromClassList(mixedValueLabelUssClassName);
                    Update();
                }
            }

            public ObjectFieldDisplay(ObjectField objectField)
            {
                AddToClassList(ussClassName);
                m_ObjectIcon = new Image { scaleMode = ScaleMode.ScaleAndCrop, pickingMode = PickingMode.Ignore };
                m_ObjectIcon.AddToClassList(iconUssClassName);
                m_ObjectLabel = new Label { pickingMode = PickingMode.Ignore };
                m_ObjectLabel.AddToClassList(labelUssClassName);
                m_ObjectField = objectField;

                Update();

                Add(m_ObjectIcon);
                Add(m_ObjectLabel);
            }

            public void Update()
            {
                GUIContent content = EditorGUIUtility.ObjectContent(m_ObjectField.value, m_ObjectField.objectType);
                m_ObjectIcon.image = content.image;
                m_ObjectLabel.text = content.text;
            }

            [EventInterest(typeof(MouseDownEvent), typeof(KeyDownEvent),
                typeof(DragUpdatedEvent), typeof(DragPerformEvent), typeof(DragLeaveEvent))]
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
                Object actualTargetObject = m_ObjectField.value;
                Component com = actualTargetObject as Component;
                if (com)
                    actualTargetObject = com.gameObject;

                if (actualTargetObject == null)
                    return;

                // One click shows where the referenced object is, or pops up a preview
                if (evt.clickCount == 1)
                {
                    // ping object
                    bool anyModifiersPressed = evt.shiftKey || evt.ctrlKey;
                    if (!anyModifiersPressed && actualTargetObject)
                    {
                        EditorGUIUtility.PingObject(actualTargetObject);
                    }
                    evt.StopPropagation();
                }
                // Double click opens the asset in external app or changes selection to referenced object
                else if (evt.clickCount == 2)
                {
                    if (actualTargetObject)
                    {
                        AssetDatabase.OpenAsset(actualTargetObject);
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

            private Object DNDValidateObject()
            {
                Object[] references = DragAndDrop.objectReferences;
                // Object validatedObject = EditorGUI.ValidateObjectFieldAssignment(references, m_ObjectField.objectType, null, EditorGUI.ObjectFieldValidatorOptions.None);
                Object validatedObject = null;
                if (references[0] != null && references[0] is GameObject && typeof(Component).IsAssignableFrom(m_ObjectField.objectType))
                {
                    GameObject go = (GameObject)references[0];
                    references = go.GetComponents(typeof(Component));
                }
                foreach (Object i in references)
                {
                    if (i != null && m_ObjectField.objectType.IsAssignableFrom(i.GetType()))
                    {
                        validatedObject = i;
                        break;
                    }
                }

                if (validatedObject != null)
                {
                    // If scene objects are not allowed and object is a scene object then clear
                    if (!m_ObjectField.allowSceneObjects && !EditorUtility.IsPersistent(validatedObject))
                        validatedObject = null;
                }
                return validatedObject;
            }

            private void OnDragUpdated(EventBase evt)
            {
                Object validatedObject = DNDValidateObject();
                if (validatedObject != null)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    AddToClassList(acceptDropVariantUssClassName);

                    evt.StopPropagation();
                }
            }

            private void OnDragPerform(EventBase evt)
            {
                Object validatedObject = DNDValidateObject();
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

        private class ObjectFieldSelector : VisualElement
        {
            private readonly ObjectField m_ObjectField;

            public ObjectFieldSelector(ObjectField objectField)
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

        public ObjectField()
            : this(null) { }
        public ObjectField(string label)
            : this(label, new VisualElement())
        {
        }

        private ObjectField(string label, VisualElement visualInput)
            : base(label, -1, '\0', visualInput)
        {
            visualInput.focusable = false;
            labelElement.focusable = false;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);

            allowSceneObjects = true;

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

        internal void OnObjectChanged(Object obj)
        {
            value = TryReadComponentFromGameObject(obj, objectType);
        }

        internal void ShowObjectSelector()
        {
            // Since we have nothing useful to do on the object selector closing action, we just do not assign any callback
            // All the object changes will be notified through the OnObjectChanged and a "cancellation" (Escape key) on the ObjectSelector is calling the closing callback without any good object
            ObjectSelector.Show(value, objectType, null, allowSceneObjects, null, null, OnObjectChanged);
        }

        private Object TryReadComponentFromGameObject(Object obj, Type type)
        {
            var go = obj as GameObject;
            if (go != null && type != null && type.IsSubclassOf(typeof(Component)))
            {
                var comp = go.GetComponent(objectType);
                if (comp != null)
                    return comp;
            }

            return obj;
        }

        //class ObjectFieldInput : TextField.TextInputBase
        //{
        //    ObjectField parentObjectField => (ObjectField)parent;

        //    internal ObjectFieldInput(string hey)
        //    {
        //        textEdition.AcceptCharacter = AcceptCharacter;
        //    }

        //    protected string allowedCharacters => "0123456789abcdefABCDEF";

        //    internal override bool AcceptCharacter(char c)
        //    {
        //        return base.AcceptCharacter(c) && c != 0 && allowedCharacters.IndexOf(c) != -1;
        //    }

        //    public string formatString => UINumericFieldsUtils.k_IntFieldFormatString;

        //    protected string ValueToString(Hash128 value)
        //    {
        //        return value.ToString();
        //    }

        //    protected override Hash128 StringToValue(string str)
        //    {
        //        // Hash128.Parse does not accept strings of Length == 1, but works well with Length in the range [2, 32]
        //        if (str.Length == 1 && ulong.TryParse(str, out var val))
        //            return new Hash128(val, 0L);

        //        return Hash128.Parse(str);
        //    }
        //}
    }

    public static class ObjectSelector
    {
        private static Type ObjectSelectorType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.ObjectSelector");
        private static PropertyInfo ObjectSelectorGetProperty = ObjectSelectorType.GetProperty("get", BindingFlags.Public | BindingFlags.Static);
        private static MethodInfo ObjectSelectorShowMethod = ObjectSelectorType.GetMethod("Show", BindingFlags.NonPublic | BindingFlags.Instance, null,
                new Type[]
                {
                    typeof(UnityEngine.Object),
                    typeof(System.Type),
                    typeof(UnityEngine.Object),
                    typeof(bool),
                    typeof(List<int>),
                    typeof(Action<UnityEngine.Object>),
                    typeof(Action<UnityEngine.Object>)
                }
                , new ParameterModifier[0]
            );

        private static object ObjectSelectorInstance = ObjectSelectorGetProperty.GetValue(null);

        public static void ShowObjectPicker<T>(T obj, T objectBeingEdited, bool allowSceneObjects, List<int> allowedInstanceIDs = null, Action<Object> onObjectSelectorClosed = null, Action<Object> onObjectSelectedUpdated = null) where T : UnityEngine.Object
        {
            Show(obj, typeof(T), objectBeingEdited, allowSceneObjects, allowedInstanceIDs, onObjectSelectorClosed, onObjectSelectedUpdated);
        }

        public static void Show(Object obj, Type requiredType, Object objectBeingEdited, bool allowSceneObjects, List<int> allowedInstanceIDs = null, Action<Object> onObjectSelectorClosed = null, Action<Object> onObjectSelectedUpdated = null)
        {
            ObjectSelectorShowMethod.Invoke(ObjectSelectorInstance, new object[] { obj, requiredType, objectBeingEdited, allowSceneObjects, allowedInstanceIDs, onObjectSelectorClosed, onObjectSelectedUpdated });
        }
    }

}
