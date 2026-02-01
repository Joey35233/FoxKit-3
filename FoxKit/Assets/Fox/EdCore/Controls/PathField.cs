using System.Collections.Generic;
using Fox.Core;
using Fox;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class PathField : BaseField<Path>, IFoxField
    {
        private readonly TextField TextField;
        
        public static new readonly string ussClassName = "fox-path-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        
        public override Path value
        {
            get => new (TextField.value);
            set
            {
                TextField.value = value?.String;
            }
        }

        public VisualElement visualInput
        {
            get;
        }

        public PathField()
            : this(label: null)
        {
        }
        
        public PathField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public PathField(string label)
            : this(label, new VisualElement())
        {
        }

        public PathField(string label, VisualElement visInput, int maxLength = -1)
            : base(label, visInput)
        {
            visualInput = visInput;

            TextField = new TextField(maxLength, false, false, '*');
            TextField.bindingPath = "cString";
            TextField.AddToClassList(BaseCompositeField<Path, FloatField, float>.firstFieldVariantUssClassName);
            TextField.AddToClassList(BaseCompositeField<Path, FloatField, float>.fieldUssClassName);
            visualInput.Add(TextField);

            TextField.RegisterValueChangedCallback((ce) =>
            {
                using (ChangeEvent<Path> pooled = ChangeEvent<Path>.GetPooled(new Path(ce.previousValue), new Path(ce.newValue)))
                {
                    pooled.target = (IEventHandler)this;
                    this.SendEvent((EventBase)pooled);
                }
                ce.StopImmediatePropagation();
            });
            
            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<Path, FloatField, float>.ussClassName);
            
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.labelUssClassName);
            
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.inputUssClassName);

            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
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
            {
                OnMouseDown(evt as MouseDownEvent);
            }
            else if (evt.eventTypeId == KeyDownEvent.TypeId())
            {
                var kdEvt = evt as KeyDownEvent;
                
                if (kdEvt.keyCode is KeyCode.Delete or KeyCode.Backspace)
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
        
        private void OnMouseDown(MouseDownEvent evt)
        {
            if (value == (Path)null)
                return;
            
            if ((evt.clickCount == 1 || evt.clickCount == 2) && (evt.shiftKey || evt.ctrlKey))
            {
                GameObject targetObject = Fox.Fs.FileSystem.LoadAsset<GameObject>(value.String);
                if (!targetObject)
                    return;
                
                // Show where the referenced asset is
                if (evt.clickCount == 1)
                {
                    EditorGUIUtility.PingObject(targetObject);
                }
                // Open the asset in external app
                else if (evt.clickCount == 2)
                {
                    AssetDatabase.OpenAsset(targetObject);
                    GUIUtility.ExitGUI();
                }
                
                evt.StopPropagation();
            }
        }

        private void OnKeyboardDelete() => value = null;

        private Object GetDragAndDropObject()
        {
            Object[] references = DragAndDrop.objectReferences;
            if (references.Length < 1 || references[0] is not Object reference)
                return null;

            if (EditorUtility.IsPersistent(reference))
                return reference;

            return null;
        }

        private void OnDragUpdated(EventBase evt)
        {
            Object validatedObject = GetDragAndDropObject();
            if (validatedObject != null)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                AddToClassList("unity-object-field-display--accept-drop");

                evt.StopPropagation();
            }
        }

        private void OnDragPerform(EventBase evt)
        {
            Object validatedObject = GetDragAndDropObject();
            if (validatedObject != null)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                
                string unityPath = AssetDatabase.GetAssetPath(validatedObject);
                value = new Path(Fox.Fs.FileSystem.GetFoxPathFromUnityPath(unityPath));

                DragAndDrop.AcceptDrag();
                RemoveFromClassList("unity-object-field-display--accept-drop");

                evt.StopPropagation();
            }
        }
        
        private void OnDragLeave() => RemoveFromClassList("unity-object-field-display--accept-drop");
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}