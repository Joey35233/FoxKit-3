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

            InternalField.label = label;
            InternalField.allowSceneObjects = false;
            InternalField.BindProperty(FileProperty);
            InternalField.labelElement.AddToClassList("unity-property-field__label");
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