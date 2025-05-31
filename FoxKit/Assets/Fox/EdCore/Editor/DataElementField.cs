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
    public class DataElementField : BaseEntityField<DataElement>
    {
        static DataElementField()
        {
            CustomEntityFieldDesc desc = new CustomEntityFieldDesc
            {
                Constructor = () => new DataElementField(),
                BodyOverrideBehavior = BuildBodyOverrideBehavior.ChildrenOverride,
                BuildBody = BuildBody
            };
            
            EntityEditorManager.Register(DataElement.ClassInfo, desc);
        }

        private static void BuildBody(EntityFieldBuildContext context)
        {
        }
    }
}