using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class WindParameter : Fox.GameKit.EnvironmentParameter
    {
        private partial float speed_Get() => throw new System.NotImplementedException();
        private partial void speed_Set(float value) => throw new System.NotImplementedException();

        private partial UnityEngine.Quaternion rotation_Get() => throw new System.NotImplementedException();
        private partial void rotation_Set(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        internal float GetInfluenceOfGlobal() => influenceOfGlobal;
        internal void SetInfluenceOfGlobal(float value) => influenceOfGlobal = value;
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            velocity = Fox.Math.FoxToUnityVector3(velocity);
            rotation = Fox.Math.FoxToUnityQuaternion(rotation);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(velocity), Fox.Math.UnityToFoxVector3(velocity));
            context.OverrideProperty(nameof(rotation), Fox.Math.UnityToFoxQuaternion(rotation));
        }
    }
}