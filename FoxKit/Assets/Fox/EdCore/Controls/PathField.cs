using Fox.Core;
using Fox;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class PathField : BaseField<Path>, IFoxField
    {
        private readonly TextField TextField;
        
        public static new readonly string ussClassName = "fox-path-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public PathField()
            : this(label: null)
        {
        }
        
        public PathField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public PathField(string label)
            : this(label, new VisualElement())
        {
        }

        public PathField(string label, VisualElement visInput, int maxLength = -1)
            : base(label, visInput)
        {
            visualInput = visInput;

            TextField = new TextField(maxLength, false, false, '*');
            TextField.bindingPath = "_cString";
            TextField.AddToClassList(BaseCompositeField<Path, FloatField, float>.firstFieldVariantUssClassName);
            TextField.AddToClassList(BaseCompositeField<Path, FloatField, float>.fieldUssClassName);
            visualInput.Add(TextField);
            
            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<Path, FloatField, float>.ussClassName);
            
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.labelUssClassName);
            
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.inputUssClassName);

            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(Path))]
    // public class PathDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new PathField(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<Path>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}