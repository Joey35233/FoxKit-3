using Fox;
using Fox.Core;
using Fox.EdCore;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Transform = Fox.Core.Transform;

namespace Fox.EdGameKit
{
    [InitializeOnLoad]
    public class TransformEntityField : EntityField<TransformEntity>
    { 
        static TransformEntityField Create() => new();
        static TransformEntityField()
        {
            EntityFieldCustomEditorCollector.Register(TransformEntity.ClassInfo, Create);
        }

        protected override bool ShouldOverrideBuildBody() => true;

        protected override void BuildBodyOverride(VisualElement element, SerializedObject serializedObject)
        {
            element.Add(new UnityEngine.UIElements.HelpBox("TransformEntity required.", HelpBoxMessageType.Info));
        }
    }

    [CustomEditor(typeof(TransformEntity))]
    public class TransformEntityEditor : EntityEditor
    {
        protected override IEntityField CreateField() => new TransformEntityField();
    }
}