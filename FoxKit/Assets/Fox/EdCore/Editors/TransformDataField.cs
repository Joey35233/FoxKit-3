using Fox;
using Fox.Core;
using Fox.EdCore;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    [CustomEntityField]
    public class TransformDataField : EntityField<TransformData>
    {
        static TransformDataField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new TransformDataField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.SpecificClassOverride,
                BuildHeader = BuildHeader,
                BuildBody = BuildBody
            };
            
            CustomEntityFieldManager.Register(TransformData.ClassInfo, desc);
        }

        private static void BuildHeader(EntityFieldBuildContext context)
        {
            context.BodyElement.Add(new HelpBox("One of transform, shearTransform, pivotTransform must be set and a direct child of this TransformData.", HelpBoxMessageType.Warning));
        }
        
        private static void BuildBody(EntityFieldBuildContext context)
        {
            EntityPtrField<TransformEntity> transformField = new EntityPtrField<TransformEntity>("transform");
            context.AddPropertyField(context.BodyElement, transformField, transformField.label);
            
            EntityPtrField<ShearTransformEntity> shearTransformField = new EntityPtrField<ShearTransformEntity>("shearTransform");
            context.AddPropertyField(context.BodyElement, shearTransformField, shearTransformField.label);
            
            EntityPtrField<PivotTransformEntity> pivotTransformField = new EntityPtrField<PivotTransformEntity>("pivotTransform");
            context.AddPropertyField(context.BodyElement, pivotTransformField, pivotTransformField.label);
            
            EnumFlagsField flagsField = new EnumFlagsField("flags");
            context.AddPropertyField(context.BodyElement, flagsField, flagsField.label);
        }
    }
}