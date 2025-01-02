using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class EntityLinkField : BaseField<Core.EntityLink>, IFoxField
    {
        private readonly EntityHandleField InternalHandleField;
        private readonly PathField InternalPackagePathField;
        private readonly PathField InternalArchivePathField;
        private readonly StringField InternalNameField;

        public static new readonly string ussClassName = "fox-entitylink-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }
        public EntityLinkField() 
            : this(label: null)
        {
        }
        
        public EntityLinkField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public EntityLinkField(string label)
            : this(label, new VisualElement())
        {
        }

        private EntityLinkField(string label, VisualElement visInput)
            : base(label, visInput)
        {
            visualInput = visInput;

            VisualElement row0 = new();
            row0.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldGroupUssClassName);
            InternalHandleField = new EntityHandleField();
            InternalHandleField.bindingPath = nameof(EntityLink.handle);
            InternalHandleField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalHandleField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalHandleField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalHandleField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalHandleField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList("unity-composite-field__field--last");
            row0.Add(InternalHandleField);
            visualInput.Add(row0);

            VisualElement row1 = new();
            row1.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldGroupUssClassName);
            InternalPackagePathField = new PathField();
            InternalPackagePathField.bindingPath = nameof(EntityLink.packagePath);
            InternalPackagePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalPackagePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalPackagePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalPackagePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalPackagePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList("unity-composite-field__field--last");
            row1.Add(InternalPackagePathField);
            visualInput.Add(row1);

            VisualElement row2 = new();
            row2.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldGroupUssClassName);
            InternalArchivePathField = new PathField();
            InternalArchivePathField.bindingPath = nameof(EntityLink.archivePath);
            InternalArchivePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalArchivePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalArchivePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalArchivePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalArchivePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList("unity-composite-field__field--last");
            row2.Add(InternalArchivePathField);
            visualInput.Add(row2);

            VisualElement row3 = new();
            row3.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldGroupUssClassName);
            InternalNameField = new StringField();
            InternalNameField.bindingPath = nameof(EntityLink.nameInArchive);
            InternalNameField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalNameField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalNameField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalNameField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalNameField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList("unity-composite-field__field--last");
            row3.Add(InternalNameField);
            visualInput.Add(row3);

            AddToClassList(ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.ussClassName);
            AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.multilineVariantUssClassName);
            labelElement.AddToClassList(labelUssClassName);
            labelElement.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            visualInput.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(Core.EntityLink))]
    // public class EntityLinkDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new EntityLinkField(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<Core.EntityLink>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}