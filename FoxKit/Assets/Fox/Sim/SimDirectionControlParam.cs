using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Sim
{
    public partial class SimDirectionControlParam : Fox.Sim.SimControlParam
    {
        internal string GetRefBone() => refBone;
        internal void SetRefBone(string value) => refBone = value;

        internal UnityEngine.Quaternion GetOffset() => offset;
        internal void SetOffset(UnityEngine.Quaternion value) => offset = value;
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            offset = Fox.Math.FoxToUnityQuaternion(offset);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(offset), Fox.Math.UnityToFoxQuaternion(offset));
        }
    }
}
