using Fox;
using Fox.Core;
using Fox.EdCore;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    [CustomEntityField]
    public class DataSetField : EntityField<DataSet>
    {
        static DataSetField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new DataSetField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            CustomEntityFieldManager.Register(DataSet.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
        }
    }
}