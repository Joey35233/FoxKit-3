﻿using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Int64))]
    public class Int64Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Int64Field();
            field.BindProperty(property);
            field.label = property.name;
            field.labelElement.AddToClassList("unity-property-field__label");

            return field;
        }
    }
}