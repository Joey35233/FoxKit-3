using Fox;
using Fox.Core;
using Fox.EdCore;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Transform = Fox.Core.Transform;

namespace Fox.EdCore
{
    [CustomEntityInspector]
    public class PivotTransformEntityField : BaseEntityField<PivotTransformEntity>
    {
        static PivotTransformEntityField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new PivotTransformEntityField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            EntityEditorManager.Register(PivotTransformEntity.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
            context.BodyElement.Add(new HelpBox("Required placeholder. Must be direct child of desired TransformData. The Transform of this PivotTransformEntity GameObject is unused.", HelpBoxMessageType.Warning));
        }
    }
}