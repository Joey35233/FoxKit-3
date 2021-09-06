using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class FilePtrField : IFoxField
    {
        private ObjectField InternalField;
        private SerializedProperty FileProperty;

        public FilePtrField() : this(default)
        {
        }

        public FilePtrField(string label)
        {
            InternalField = new ObjectField(label);

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            FileProperty = property.FindPropertyRelative("file");

            InternalField.value = this.FileProperty.GetValue() as UnityEngine.Object;
            InternalField.label = label;
            InternalField.allowSceneObjects = false;
            InternalField.labelElement.AddToClassList("unity-property-field__label");

            // TODO: Filter this by asset type
            InternalField.objectType = typeof(UnityEngine.Object);
            InternalField.RegisterValueChangedCallback(OnValueChanged);
        }

        private void OnValueChanged(ChangeEvent<UnityEngine.Object> evt)
        {
            // TODO Figure out why undo doesn't appear instantly
            Undo.RecordObject(this.FileProperty.serializedObject.targetObject, "FilePtr");
            this.FileProperty.SetValue(evt.newValue);
            this.FileProperty.serializedObject.ApplyModifiedProperties();
        }
    }

    [CustomPropertyDrawer(typeof(FilePtr<>))]
    public class FilePtrDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new FilePtrField(property.name);
            container.BindProperty(property);

            return container;
        }
    }
}