using Fox;
using Fox.Core;
using Fox.EdCore;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Transform = Fox.Core.Transform;

namespace Fox.EdCore
{
    [CustomEntityField]
    public class PivotTransformEntityField : EntityField<PivotTransformEntity>
    {
        static PivotTransformEntityField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new PivotTransformEntityField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            CustomEntityFieldManager.Register(PivotTransformEntity.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
            context.BodyElement.Add(new HelpBox("Required placeholder. Must be direct child of desired TransformData. The Transform of the PivotTransformEntity GameObject is unused.", HelpBoxMessageType.Warning));
        }
    }
}