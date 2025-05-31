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
    public class DataField : BaseEntityField<Data>
    {
        static DataField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new DataField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody,
            };
            
            EntityEditorManager.Register(Data.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
        }
    }
}