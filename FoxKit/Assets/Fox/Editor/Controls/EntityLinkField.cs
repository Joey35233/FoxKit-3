using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityLinkField : BaseField<Core.EntityLink>, IFoxField, ICustomBindable
    {
        private EntityHandleField InternalHandleField;
        private PathField InternalPackagePathField;
        private PathField InternalArchivePathField;
        private StringField InternalNameField;

        public new static readonly string ussClassName = "fox-entitylink-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }
        public EntityLinkField() : this(default)
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
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                if (property.type == "EntityLink")
                {
                    InternalHandleField.BindProperty(property.FindPropertyRelative("handle"));
                    InternalPackagePathField.BindProperty(property.FindPropertyRelative("packagePath"));
                    InternalArchivePathField.BindProperty(property.FindPropertyRelative("archivePath"));
                    InternalNameField.BindProperty(property.FindPropertyRelative("nameInArchive"));

                    evt.StopPropagation();
                }
            }
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            InternalHandleField.BindProperty(property.FindPropertyRelative("handle"));
            InternalPackagePathField.BindProperty(property.FindPropertyRelative("packagePath"));
            InternalArchivePathField.BindProperty(property.FindPropertyRelative("archivePath"));
            InternalNameField.BindProperty(property.FindPropertyRelative("nameInArchive"));
        }
    }

    [CustomPropertyDrawer(typeof(Core.EntityLink))]
    public class EntityLinkDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new EntityLinkField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<Core.EntityLink>.alignedFieldUssClassName);

            return field;
        }
    }
}