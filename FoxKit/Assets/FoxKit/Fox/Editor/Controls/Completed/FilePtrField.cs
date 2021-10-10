using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class FilePtrField : FoxField
    {
        private PathField InternalField;
        private SerializedProperty FileProperty;

        public override string label
        {
            get => InternalField.label;
            set => InternalField.label = value;
        }

        public FilePtrField() : this(default)
        {
        }

        public FilePtrField(string label)
        {
            InternalField = new PathField(label);
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-fileptr-field");
			this.AddToClassList("fox-base-field");
            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label)
        {
            FileProperty = property.FindPropertyRelative("path");

            if (!IsUserAssignedLabel)
                InternalField.label = label;
            InternalField.BindProperty(FileProperty);
        }
    }

    [CustomPropertyDrawer(typeof(FilePtr<>))]
    public class FilePtrDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new FilePtrField(property.name);
            field.BindProperty(property);
            field.styleSheets.Add(FoxField.FoxFieldStyleSheet);

            return field;
        }
    }
}