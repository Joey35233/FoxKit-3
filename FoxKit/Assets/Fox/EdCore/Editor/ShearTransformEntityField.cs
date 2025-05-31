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
    public class ShearTransformEntityField : BaseEntityField<ShearTransformEntity>
    {
        static ShearTransformEntityField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new ShearTransformEntityField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            EntityEditorManager.Register(ShearTransformEntity.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
            context.BodyElement.Add(new HelpBox("Required placeholder. Must be direct child of desired TransformData. The Transform of this ShearTransformEntity GameObject is unused.", HelpBoxMessageType.Warning));
        }
    }
}