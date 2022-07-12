﻿using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityLinkField : BaseField<Fox.Core.EntityLink>, IFoxField
    {
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
            InternalPackagePathField = new PathField();
            InternalPackagePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalPackagePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalPackagePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalPackagePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            row0.Add(InternalPackagePathField);
            visualInput.Add(row0);

            VisualElement row1 = new();
            row1.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldGroupUssClassName);
            InternalArchivePathField = new PathField();
            InternalArchivePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalArchivePathField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalArchivePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalArchivePathField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            row1.Add(InternalArchivePathField);
            visualInput.Add(row1);

            VisualElement row2 = new();
            row2.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldGroupUssClassName);
            InternalNameField = new StringField();
            InternalNameField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalNameField.AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            InternalNameField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.firstFieldVariantUssClassName);
            InternalNameField.Q(className: BaseField<UnityEngine.Quaternion>.ussClassName).AddToClassList(BaseCompositeField<UnityEngine.Quaternion, FloatField, float>.fieldUssClassName);
            row2.Add(InternalNameField);
            visualInput.Add(row2);

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
            Type evtType = evt.GetType();
            if ((evtType.Name == "SerializedPropertyBindEvent") && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty entityLinkProperty = evtType.GetProperty("bindProperty").GetValue(evt) as SerializedProperty;

                InternalPackagePathField.BindProperty(entityLinkProperty.FindPropertyRelative("packagePath"));
                InternalArchivePathField.BindProperty(entityLinkProperty.FindPropertyRelative("archivePath"));
                InternalNameField.BindProperty(entityLinkProperty.FindPropertyRelative("nameInArchive"));

                evt.StopPropagation();
            }
        }

        //public void BindProperty(SerializedProperty property)
        //{
        //    BindProperty(property, null);
        //}
        //public void BindProperty(SerializedProperty property, string label)
        //{
        //    if (label is not null)
        //        this.label = label;
        //    InternalHandleField.BindProperty(property.FindPropertyRelative("handle"));
        //    InternalPackagePathField.BindProperty(property.FindPropertyRelative("packagePath"));
        //    InternalArchivePathField.BindProperty(property.FindPropertyRelative("archivePath"));
        //    InternalNameField.BindProperty(property.FindPropertyRelative("nameInArchive"));
        //}
    }

    [CustomPropertyDrawer(typeof(Fox.Core.EntityLink))]
    public class EntityLinkDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new EntityLinkField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<Fox.Core.Path>.alignedFieldUssClassName);

            return field;
        }
    }
}