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
    public class TransformEntityField : EntityField<TransformEntity>
    {
        static TransformEntityField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new TransformEntityField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            CustomEntityFieldManager.Register(TransformEntity.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
            context.Element.Add(new HelpBox("Required placeholder. Must be direct child of desired TransformData. The Transform of the TransformEntity GameObject is unused.", HelpBoxMessageType.Warning));
        }
    }
}