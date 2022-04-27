﻿using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class BoolField : FoxField
    {
        private Toggle InternalField;
        private SerializedProperty Property;

        public override string label 
        { 
            get => InternalField.label; 
            set
            {
                IsUserAssignedLabel = true;
                InternalField.label = value;
            }
        }

        public BoolField() : this(default)
        {
        }

        public BoolField(string label)
        {
            InternalField = new Toggle(label);
            InternalField.style.marginTop = 3;
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-bool-field");
			this.AddToClassList("fox-base-field");
            this.styleSheets.Add(FoxField.FoxFieldStyleSheet);
            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label)
        {
            this.Property = property;

            if (!IsUserAssignedLabel)
                InternalField.label = label;
            InternalField.BindProperty(property);
        }
    }

    [CustomPropertyDrawer(typeof(System.Boolean))]
    public class BoolDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new BoolField();
            field.BindProperty(property);

            return field;
        }
    }
}