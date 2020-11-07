﻿using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.SByte))]
    public class Int8Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var foldout = new Int8Field();
            foldout.label = property.name;

            container.Add(foldout);
            return container;
        }
    }
}