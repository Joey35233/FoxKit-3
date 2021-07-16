using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class Matrix4Field : IFoxField
    {
        // [Row, Column]
        private FloatField[,] InternalFields;
        private SerializedProperty Property;

        public Matrix4Field() : this(default)
        {

        }

        public Matrix4Field(string label)
        {
            var container = new Foldout();

            container.text = property.name;
            container.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);

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
                InternalFields[0, 0] = xField;

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e01"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[0, 1] = yField;

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e02"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[0, 2] = zField;

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e03"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[0, 3] = wField;

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
                InternalFields[1, 0] = xField;

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e11"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[1, 1] = yField;

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e12"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[1, 2] = zField;

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e13"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[1, 3] = wField;

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
                InternalFields[2, 0] = xField;

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e21"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[2, 1] = yField;

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e22"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[2, 2] = zField;

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e23"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[2, 3] = wField;

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
                InternalFields[3, 0] = xField;

                var yField = new FloatField("Y");
                yField.BindProperty(property.FindPropertyRelative("e31"));
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[3, 1] = yField;

                var zField = new FloatField("Z");
                zField.BindProperty(property.FindPropertyRelative("e32"));
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[3, 2] = zField;

                var wField = new FloatField("W");
                wField.BindProperty(property.FindPropertyRelative("e33"));
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[3, 3] = wField;

                innerContainer.Add(rowContainer);
            }

            container.Add(innerContainer);

            this.Add(container);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            this.Property = property;

            InternalField.label = label;
            InternalField.BindProperty(property.FindPropertyRelative("_cString"));
            InternalField.RegisterValueChangedCallback(OnValueChanged);
            InternalField.labelElement.AddToClassList("unity-property-field__label");
            if (ussClassNames != null)
                foreach (var className in ussClassNames)
                    InternalField.labelElement.AddToClassList(className);
        }

        private void OnValueChanged(ChangeEvent<string> changeEvent) => Property.SetValue(new Fox.Core.Path(changeEvent.newValue));
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Matrix4x4))]
    public class Matrix4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new Foldout();

            container.text = property.name;
            container.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);

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