using Fox;
using Fox.EdCore;
using Fox.GameKit;
using UnityEngine;
using UnityEditor;

namespace Fox.EdGameKit
{
    [CustomEntityField]
    public class StaticModelArrayField : EntityField<StaticModelArray>
    {
        static StaticModelArrayField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new StaticModelArrayField(),
            };
            
            CustomEntityFieldManager.Register(StaticModelArray.ClassInfo, desc);
        }
    }
}