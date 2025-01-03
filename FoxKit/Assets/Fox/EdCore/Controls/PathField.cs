using System.Collections.Generic;
using Fox.Core;
using Fox;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
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
                TextField.value = value.CString;
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
            TextField.bindingPath = "_cString";
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
        
        private int PingEventClickCount;
        private void OnLoadPingTargetAsset(AsyncOperationHandle<Object> handle)
        {
            Object targetObject = null;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                targetObject = handle.Result;
            
                // Show where the referenced asset is
                if (PingEventClickCount == 1)
                    EditorGUIUtility.PingObject(targetObject);
                // Open the asset in external app
                else if (PingEventClickCount == 2)
                    AssetDatabase.OpenAsset(targetObject);
            }
            
            Addressables.Release(handle);
        }
        
        private void OnMouseDown(MouseDownEvent evt)
        {
            if (value == (Path)null)
                return;

            if ((evt.clickCount == 1 || evt.clickCount == 2)  && (evt.shiftKey || evt.ctrlKey))
            {
                // Explicit version of using a lambda + captured variables
                PingEventClickCount = evt.clickCount;
                Addressables.LoadResourceLocationsAsync(value.CString).Completed +=
                    (handle) =>
                    {
                        IList<IResourceLocation> results = handle.Result;
                        if (results.Count > 0)
                        {
                            IResourceLocation firstLocation = results[0];
                            Addressables.LoadAssetAsync<Object>(firstLocation).Completed += OnLoadPingTargetAsset;
                        }
                        
                        Addressables.Release(handle);
                    };
            }
            
            evt.StopPropagation();
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

                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(validatedObject, out string guid, out long localId))
                {
                    AddressableAssetEntry entry = AddressableAssetSettingsDefaultObject.Settings.FindAssetEntry(guid, true);
                    if (entry != null)
                    {
                        value = new Path(entry.address);

                        DragAndDrop.AcceptDrag();
                        RemoveFromClassList("unity-object-field-display--accept-drop");
                    }
                }

                evt.StopPropagation();
            }
        }
        
        private void OnDragLeave() => RemoveFromClassList("unity-object-field-display--accept-drop");
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(Path))]
    // public class PathDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new PathField(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<Path>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}