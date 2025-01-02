using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class FilePtrField : BaseField<FilePtr>, IFoxField
    {
        private readonly PathField PathField;
        
        public static new readonly string ussClassName = "fox-fileptr-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public FilePtrField()
            : this(label: null)
        {
        }
        
        public FilePtrField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public FilePtrField(string label)
            : this(label, new VisualElement())
        {
        }

        public FilePtrField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            PathField = new PathField();
            PathField.bindingPath = "path";
            PathField.AddToClassList(BaseCompositeField<Path, FloatField, float>.firstFieldVariantUssClassName);
            PathField.AddToClassList(BaseCompositeField<Path, FloatField, float>.fieldUssClassName);
            visualInput.Add(PathField);
            
            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<FilePtr, FloatField, float>.ussClassName);
            
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<FilePtr, FloatField, float>.labelUssClassName);
            
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<FilePtr, FloatField, float>.inputUssClassName);

            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(FilePtr))]
    // public class FilePtrDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new FilePtrField(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<UnityEngine.Color>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}