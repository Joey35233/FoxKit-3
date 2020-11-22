using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Reflection;
using System;
using System.Linq;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.String))]
    public class StringDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var isHashToggle = new ToolbarToggle();
            var ss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/StringDrawer.uss");
            isHashToggle.styleSheets.Add(ss);
            isHashToggle.text = "0x";

            var child = isHashToggle.Children().First();
            child.AddToClassList("unity-button");

            var field = new StringField(property.name);
            field.BindProperty(property);

            field.Insert(1, isHashToggle);

            isHashToggle.BindProperty(property.FindPropertyRelative("isHash"));
            isHashToggle.RegisterValueChangedCallback(OnValueChanged);

            return field;
        }

        private void OnValueChanged(ChangeEvent<bool> changeEvent)
        {
        }
    }
}