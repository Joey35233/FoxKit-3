using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityPtrField : FoxField
    {
        private PropertyField InternalField;
        private Toggle TempToggle;

        public override string label
        {
            get => InternalField.label;
            set
            {
                IsUserAssignedLabel = true;
                InternalField.label = value;
            }
        }

        public EntityPtrField() : this(default)
        {
        }

        public EntityPtrField(string label)
        {
            InternalField = new PropertyField();
            InternalField.label = label;
            if (label != null)
                IsUserAssignedLabel = true;

            TempToggle = new Toggle();
            this.Add(TempToggle);

            this.AddToClassList("fox-entityptr-field");
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
            var ptrProperty = property.FindPropertyRelative("ptr");

            if (ptrProperty.managedReferenceFullTypename != "")
            {
                if (!IsUserAssignedLabel)
                    InternalField.label = label;
                InternalField.BindProperty(ptrProperty);
            }
            else
            {
                TempToggle.name = label;
                this.Remove(InternalField);
            }
        }
    }

    [CustomPropertyDrawer(typeof(EntityPtr<>))]
    public class EntityPtrDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new EntityPtrField(property.name);
            field.BindProperty(property);

            return field;
        }
    }
}