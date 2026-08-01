using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Sim
{
    public partial class SimDirectionControl : Fox.Sim.SimControlElement
    {
        private SimDirectionControlParam param => controlParam;

        private partial string refBone_Get() => param == null ? null : param.GetRefBone();
        private partial void refBone_Set(string value)
        {
            if (param == null)
                return;
            
            param.SetRefBone(value);
        }

        private partial UnityEngine.Quaternion offset_Get() => param == null ? Quaternion.identity : param.GetOffset();
        private partial void offset_Set(UnityEngine.Quaternion value)
        {
            if (param == null)
                return;
            
            param.SetOffset(value);
        }
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            offset = Fox.Math.FoxToUnityQuaternion(offset);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(offset), Fox.Math.UnityToFoxQuaternion(offset));
        }
    }
}
