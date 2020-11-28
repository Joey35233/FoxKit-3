using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Linq;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(UnityEngine.Matrix4x4))]
    public class Matrix4x4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new Foldout();
            //container.AddToClassList("unity-base-field");
            //container.AddToClassList("unity-composite-field");

            container.text = property.name;
            container.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/NumericInputDrawer.uss"));

            //var label = new Label(property.name);
            //label.AddToClassList("unity-base-field__label");
            //label.AddToClassList("unity-property-field__label");
            //container.Add(label);

            var innerContainer = new VisualElement();
            innerContainer.AddToClassList("unity-base-field__input");
            innerContainer.AddToClassList("unity-composite-field__input");
            innerContainer.style.flexDirection = FlexDirection.Column;

            {
                var rowContainer = new VisualElement();
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new FloatField("X");
                xField.BindProperty(property.FindPropertyRelative("e00"));
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e01"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e02"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e03"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);

                innerContainer.Add(rowContainer);
            }

            {
                var rowContainer = new VisualElement();
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new FloatField("X");
                xField.BindProperty(property.FindPropertyRelative("e10"));
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e11"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e12"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e13"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);

                innerContainer.Add(rowContainer);
            }

            {
                var rowContainer = new VisualElement();
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new FloatField("X");
                xField.BindProperty(property.FindPropertyRelative("e20"));
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e21"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e22"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e23"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);

                innerContainer.Add(rowContainer);
            }

            {
                var rowContainer = new VisualElement();
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new FloatField("X");
                xField.BindProperty(property.FindPropertyRelative("e30"));
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e31"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e32"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e33"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);

                innerContainer.Add(rowContainer);
            }

            container.Add(innerContainer);

            return container;
        }
    }
}