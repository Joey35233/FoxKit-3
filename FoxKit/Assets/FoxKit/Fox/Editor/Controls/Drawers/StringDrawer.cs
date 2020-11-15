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

            isHashToggle.style.borderLeftWidth = 0;
            isHashToggle.style.borderRightWidth = 0;
            isHashToggle.style.paddingLeft = 0;
            isHashToggle.style.paddingRight = 0;
            isHashToggle.style.paddingTop = 0;

            var child = isHashToggle.Children().First();
            child.AddToClassList("unity-button");

            var field = new StringField(property.name);
            field.BindProperty(property);

            field.Insert(1, isHashToggle);

            return field;
        }

        bool isClicked = false;

        private void MouseDown(MouseDownEvent args)
        {
            var toggle = args.target as Button;
            var clickable = toggle.clickable;
            var type = clickable.GetType();
            var prop = type.GetProperty("active", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            prop.SetValue(clickable, true);
            UnityEngine.Debug.Log("Clicked!");

            args.StopImmediatePropagation();
        }

        /*
        private void Clickable_clickedWithEventInfo(EventBase obj)
        {
            var toggle = obj.target as Button;
            Clickable clickable = toggle.clickable;

            if (isClicked)
            {
                var type = clickable.GetType();
                var prop = type.GetProperty("active", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                prop.SetValue(clickable, false);
            }
            else
            {
                var type = clickable.GetType();
                //var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var prop = type.GetProperty("active", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                prop.SetValue(clickable, true);
            }

            isClicked = !isClicked;
        }
        */
    }
}