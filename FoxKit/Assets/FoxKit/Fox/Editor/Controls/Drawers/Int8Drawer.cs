﻿using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.SByte))]
    public class Int8Drawer : PropertyDrawer
    {
        private SerializedProperty property;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;
            var container = new VisualElement();

            var foldout = new Int8Field();
            foldout.label = property.name;
            foldout.value = (sbyte)property.GetValue();
            foldout.RegisterValueChangedCallback(OnValueChanged);

            field.RegisterValueChangedCallback(OnValueChanged);

            container.Add(field);
            return container;
        }

        private void OnValueChanged(ChangeEvent<sbyte> evt)
        {
            this.property.SetValue(evt.newValue);
        }
    }
}