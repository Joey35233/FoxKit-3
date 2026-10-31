using Fox;
using Fox.Core;
using Fox.EdCore;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    [CustomEntityField]
    public class DataField : EntityField<Data>
    {
        static DataField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new DataField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            CustomEntityFieldManager.Register(Data.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
        }
    }
}