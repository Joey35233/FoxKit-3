using System;
using Fox.Core;
using Fox.EdCore;
using Fox.Ph;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using EnumField = Fox.EdCore.EnumField;
using FloatField = Fox.EdCore.FloatField;

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
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            //CustomEntityFieldManager.Register(PhPrimitiveShapeParam.ClassInfo, desc);
            
            MessageString = "<b>Primitive shapes only support one of the following types</b>:\n";
            foreach (var value in System.Enum.GetValues(typeof(PhPrimitiveShapeType)))
            {
                MessageString += $"\n{value}";
            }
        }
        
        private static void BuildBody(EntityFieldBuildContext context)
        {
            context.BodyElement.Clear();
            
            EnumField typeField = new EnumField("type");
            typeField.bindingPath = IFoxField.GetBindingPathForPropertyName("type");
            typeField.RegisterValueChangedCallback(evt => TypeChanged(evt, context));
            context.BodyElement.Add(typeField);
        }

        private static void BuildShapeBody(PhPrimitiveShapeType type, EntityFieldBuildContext context)
        {
            switch (type)
            {
                case PhPrimitiveShapeType.SPHERE:
                    FloatField radiusField = new FloatField("radius");
                    radiusField.bindingPath = $"{IFoxField.GetBindingPathForPropertyName("size")}.x";
                    context.BodyElement.Add(radiusField);
                    break;
                default:
                    BuildFooter(context);
                    break;
            }
        }

        private static void TypeChanged(ChangeEvent<Enum> evt, EntityFieldBuildContext context)
        {
            PhPrimitiveShapeType type = evt.newValue == null
                ? PhPrimitiveShapeType.NONE
                : (PhPrimitiveShapeType)evt.newValue;
            
            context.BodyElement.Clear();
            context.FooterElement?.Clear();
            BuildShapeBody(type, context);
        }
        
        private static void BuildFooter(EntityFieldBuildContext context)
        {
            context.BodyElement.Add(new HelpBox(MessageString, HelpBoxMessageType.Warning));
        }
    }
}