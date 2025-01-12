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
            context.Element.Add(new HelpBox("One of transform, shearTransform, pivotTransform must be set and a direct child of this TransformData.", HelpBoxMessageType.Warning));
        }
        
        private static void BuildBody(EntityFieldBuildContext context)
        {
            EntityPtrField<TransformEntity> transformField = new EntityPtrField<TransformEntity>("transform");
            ((IFoxField)transformField).SetBindingPathForPropertyName(transformField.label);
            context.Element.Add(transformField);
            
            EntityPtrField<ShearTransformEntity> shearTransformField = new EntityPtrField<ShearTransformEntity>("shearTransform");
            ((IFoxField)shearTransformField).SetBindingPathForPropertyName(shearTransformField.label);
            context.Element.Add(shearTransformField);
            
            EntityPtrField<PivotTransformEntity> pivotTransformField = new EntityPtrField<PivotTransformEntity>("pivotTransform");
            ((IFoxField)pivotTransformField).SetBindingPathForPropertyName(pivotTransformField.label);
            context.Element.Add(pivotTransformField);
            
            EnumFlagsField flagsField = new EnumFlagsField("flags");
            ((IFoxField)flagsField).SetBindingPathForPropertyName(flagsField.label);
            context.Element.Add(flagsField);
        }
    }
}