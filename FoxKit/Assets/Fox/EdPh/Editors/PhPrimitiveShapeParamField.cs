using Fox.Core;
using Fox.EdCore;
using Fox.Ph;
using UnityEngine.UIElements;

namespace Fox.EdPh
{
    [CustomEntityField]
    public class PhPrimitiveShapeParamField : EntityField<PhPrimitiveShapeParam>
    {
        private static readonly string MessageString;
        
        static PhPrimitiveShapeParamField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new PhPrimitiveShapeParamField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.SpecificClassOverride,
                BuildFooter = BuildFooter
            };
            
            CustomEntityFieldManager.Register(PhPrimitiveShapeParam.ClassInfo, desc);
            
            MessageString = "<b>Primitive shapes only support one of the following types</b>:\n";
            foreach (var value in System.Enum.GetValues(typeof(PhPrimitiveShapeType)))
            {
                MessageString += $"\n{value}";
            }
        }
        
        private static void BuildFooter(EntityFieldBuildContext context)
        {
            context.Element.Add(new HelpBox(MessageString, HelpBoxMessageType.Warning));
        }
    }
}