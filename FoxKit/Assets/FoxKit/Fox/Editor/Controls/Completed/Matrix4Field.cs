using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class Matrix4Field : FoxField
    {
        private Foldout InternalFoldout;
        private Label InternalLabel;
        private VisualElement InternalContainer;
        private bool IsInline;

        // [Row, Column]
        private UnityEditor.UIElements.FloatField[,] InternalFields;

        public override string label
        {
            get => InternalFoldout.text;
            set
            {
                IsUserAssignedLabel = true;
                InternalFoldout.text = value;
            }
        }

        public Matrix4Field(bool isInline = false) : this(null, isInline)
        {

        }

        public Matrix4Field(string label) : this(label, false)
        {

        }
        
        public Matrix4Field(string label, bool isInline)
        {
            IsInline = isInline;

            InternalFields = new UnityEditor.UIElements.FloatField[4, 4];

            if (!IsInline)
            {
                InternalFoldout = new Foldout();
                InternalFoldout.text = label;
                if (label != null)
                    IsUserAssignedLabel = true;
            }
            else
            {
                InternalContainer = new VisualElement();
                InternalContainer.style.flexDirection = FlexDirection.Row;
                InternalLabel = new Label();
                InternalLabel.AddToClassList("unity-base-field__label");
                InternalContainer.Add(InternalLabel);
                InternalLabel.text = label;
                if (label != null)
                    IsUserAssignedLabel = true;
            }

            var innerContainer = new VisualElement();
            innerContainer.AddToClassList("unity-base-field__input");
            innerContainer.AddToClassList("unity-composite-field__input");
            innerContainer.style.flexDirection = FlexDirection.Column;

            {
                var rowContainer = new VisualElement();
                rowContainer.style.paddingTop = 1;
                rowContainer.style.paddingBottom = 1;
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new UnityEditor.UIElements.FloatField("X");
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);
                InternalFields[0, 0] = xField;

                var yField = new UnityEditor.UIElements.FloatField("Y");
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[0, 1] = yField;

                var zField = new UnityEditor.UIElements.FloatField("Z");
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[0, 2] = zField;

                var wField = new UnityEditor.UIElements.FloatField("W");
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[0, 3] = wField;

                innerContainer.Add(rowContainer);
            }

            {
                var rowContainer = new VisualElement();
                rowContainer.style.paddingTop = 1;
                rowContainer.style.paddingBottom = 1;
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new UnityEditor.UIElements.FloatField("X");
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);
                InternalFields[1, 0] = xField;

                var yField = new UnityEditor.UIElements.FloatField("Y");
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[1, 1] = yField;

                var zField = new UnityEditor.UIElements.FloatField("Z");
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[1, 2] = zField;

                var wField = new UnityEditor.UIElements.FloatField("W");
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[1, 3] = wField;

                innerContainer.Add(rowContainer);
            }

            {
                var rowContainer = new VisualElement();
                rowContainer.style.paddingTop = 1;
                rowContainer.style.paddingBottom = 1;
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new UnityEditor.UIElements.FloatField("X");
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);
                InternalFields[2, 0] = xField;

                var yField = new UnityEditor.UIElements.FloatField("Y");
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[2, 1] = yField;

                var zField = new UnityEditor.UIElements.FloatField("Z");
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[2, 2] = zField;

                var wField = new UnityEditor.UIElements.FloatField("W");
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[2, 3] = wField;

                innerContainer.Add(rowContainer);
            }

            {
                var rowContainer = new VisualElement();
                rowContainer.style.paddingTop = 1;
                rowContainer.style.paddingBottom = 1;
                rowContainer.AddToClassList("unity-base-field__input");
                rowContainer.AddToClassList("unity-composite-field__input");
                rowContainer.style.flexDirection = FlexDirection.Row;

                var xField = new UnityEditor.UIElements.FloatField("X");
                xField.AddToClassList("unity-composite-field__field");
                xField.AddToClassList("unity-composite-field__field--first");
                rowContainer.Add(xField);
                InternalFields[3, 0] = xField;

                var yField = new UnityEditor.UIElements.FloatField("Y");
                yField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(yField);
                InternalFields[3, 1] = yField;

                var zField = new UnityEditor.UIElements.FloatField("Z");
                zField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(zField);
                InternalFields[3, 2] = zField;

                var wField = new UnityEditor.UIElements.FloatField("W");
                wField.AddToClassList("unity-composite-field__field");
                rowContainer.Add(wField);
                InternalFields[3, 3] = wField;

                innerContainer.Add(rowContainer);
            }

            this.AddToClassList("fox-matrix4-field");
            this.AddToClassList("fox-base-field");
            this.styleSheets.Add(FoxField.FoxFieldStyleSheet);

            if (!isInline)
            {
                InternalFoldout.Add(innerContainer);
                this.Add(InternalFoldout);
            }
            else
            {
                InternalContainer.Add(innerContainer);
                this.Add(InternalContainer);
            }
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label)
        {
            if (!IsUserAssignedLabel)
            {
                if (!IsInline)
                    InternalFoldout.text = label;
                else
                    InternalLabel.text = label;
            }    

            InternalFields[0, 0].BindProperty(property.FindPropertyRelative("e00"));
            InternalFields[0, 1].BindProperty(property.FindPropertyRelative("e01"));
            InternalFields[0, 2].BindProperty(property.FindPropertyRelative("e02"));
            InternalFields[0, 3].BindProperty(property.FindPropertyRelative("e03"));

            InternalFields[1, 0].BindProperty(property.FindPropertyRelative("e10"));
            InternalFields[1, 1].BindProperty(property.FindPropertyRelative("e11"));
            InternalFields[1, 2].BindProperty(property.FindPropertyRelative("e12"));
            InternalFields[1, 3].BindProperty(property.FindPropertyRelative("e13"));

            InternalFields[2, 0].BindProperty(property.FindPropertyRelative("e20"));
            InternalFields[2, 1].BindProperty(property.FindPropertyRelative("e21"));
            InternalFields[2, 2].BindProperty(property.FindPropertyRelative("e22"));
            InternalFields[2, 3].BindProperty(property.FindPropertyRelative("e23"));

            InternalFields[3, 0].BindProperty(property.FindPropertyRelative("e30"));
            InternalFields[3, 1].BindProperty(property.FindPropertyRelative("e31"));
            InternalFields[3, 2].BindProperty(property.FindPropertyRelative("e32"));
            InternalFields[3, 3].BindProperty(property.FindPropertyRelative("e33"));
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Matrix4x4))]
    public class Matrix4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Matrix4Field();
            field.BindProperty(property);

            return field;
        }
    }
}