using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.MotherBaseCore
{
    public partial class MotherBaseConstructData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            for (int i= 0; i < divisionRotate.Length; i++)
                divisionRotate[i] = (ushort)((divisionRotate[i] + 180) % 360);
        }
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            ushort[] _divisionRotate = divisionRotate;

            for (int i = 0; i < divisionRotate.Length; i++)
                _divisionRotate[i] = (ushort)((divisionRotate[i] + 180) % 360);

            context.OverrideProperty(nameof(divisionRotate), _divisionRotate);
        }
    }
}
