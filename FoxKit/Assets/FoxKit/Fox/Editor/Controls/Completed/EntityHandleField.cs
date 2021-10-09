﻿using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Fox.Core;
using System.Collections.Generic;

namespace Fox.Editor
{
    public class EntityHandleField : IFoxField
    {
        private ObjectField InternalField;
        private SerializedProperty EntityProperty;

        public EntityHandleField() : this(default)
        {
        }

        public EntityHandleField(string label)
        {
            InternalField = new ObjectField();
            InternalField.label = label;
            InternalField.labelElement.AddToClassList("unity-property-field__label");

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            this.EntityProperty = property.FindPropertyRelative("entity");

            InternalField.label = label;
            InternalField.objectType = typeof(Entity);
            InternalField.BindProperty(EntityProperty);
        }
    }

    [CustomPropertyDrawer(typeof(EntityHandle))]
    public class EntityHandleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new EntityHandleField(property.name);
            container.BindProperty(property);

            return container;
        }
    }
}