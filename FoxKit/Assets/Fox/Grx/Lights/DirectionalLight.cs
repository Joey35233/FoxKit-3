using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Grx
{
    public partial class DirectionalLight : Fox.Core.TransformData
    {
        private partial bool enable_Get() => throw new System.NotImplementedException();
        private partial void enable_Set(bool value) => throw new System.NotImplementedException();

        private partial bool isCascadeBlend_Get() => throw new System.NotImplementedException();
        private partial void isCascadeBlend_Set(bool value) => throw new System.NotImplementedException();

        private partial bool castShadow_Get() => throw new System.NotImplementedException();
        private partial void castShadow_Set(bool value) => throw new System.NotImplementedException();

        private partial bool isBounced_Get() => throw new System.NotImplementedException();
        private partial void isBounced_Set(bool value) => throw new System.NotImplementedException();

        private partial bool showObject_Get() => throw new System.NotImplementedException();
        private partial void showObject_Set(bool value) => throw new System.NotImplementedException();

        private partial bool enableDistanceFade_Get() => throw new System.NotImplementedException();
        private partial void enableDistanceFade_Set(bool value) => throw new System.NotImplementedException();

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            direction = Fox.Math.FoxToUnityVector3(direction);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(direction), Fox.Math.UnityToFoxVector3(direction));
        }
    }
}