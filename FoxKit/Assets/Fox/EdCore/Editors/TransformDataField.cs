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
            context.BodyElement.Add(new HelpBox("One of transform, shearTransform, pivotTransform must be set and a direct child of this TransformData.", HelpBoxMessageType.Warning));
        }
        
        private static void BuildBody(EntityFieldBuildContext context)
        {
            EntityPtrField<TransformEntity> transformField = new EntityPtrField<TransformEntity>("transform");
            transformField.bindingPath = IFoxField.GetBindingPathForPropertyName(transformField.label);
            context.BodyElement.Add(transformField);
            
            EntityPtrField<ShearTransformEntity> shearTransformField = new EntityPtrField<ShearTransformEntity>("shearTransform");
            shearTransformField.bindingPath = IFoxField.GetBindingPathForPropertyName(shearTransformField.label);
            context.BodyElement.Add(shearTransformField);
            
            EntityPtrField<PivotTransformEntity> pivotTransformField = new EntityPtrField<PivotTransformEntity>("pivotTransform");
            pivotTransformField.bindingPath = IFoxField.GetBindingPathForPropertyName(pivotTransformField.label);
            context.BodyElement.Add(pivotTransformField);
            
            EnumFlagsField flagsField = new EnumFlagsField("flags");
            flagsField.bindingPath = IFoxField.GetBindingPathForPropertyName(flagsField.label);
            context.BodyElement.Add(flagsField);
        }
    }
}