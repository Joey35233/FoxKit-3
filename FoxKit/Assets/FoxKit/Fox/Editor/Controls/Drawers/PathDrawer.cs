using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Reflection;
using System;
using System.Linq;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.Path))]
    public class PathDrawer : PropertyDrawer
    {
        SerializedProperty property;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            var field = new TextField(property.name);
            field.BindProperty(property.FindPropertyRelative("_cString"));
            field.RegisterValueChangedCallback(OnValueChanged);
            field.labelElement.AddToClassList("unity-property-field__label");

            return field;
        }

        private void OnValueChanged(ChangeEvent<string> changeEvent) => property.SetValue(new Path(changeEvent.newValue));
    }
}