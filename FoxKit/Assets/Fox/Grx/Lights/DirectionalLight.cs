using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Grx
{
    public partial class DirectionalLight : Fox.Core.TransformData
    {
        private partial bool Get_enable() => throw new System.NotImplementedException();
        private partial void Set_enable(bool value) => throw new System.NotImplementedException();

        private partial bool Get_isCascadeBlend() => throw new System.NotImplementedException();
        private partial void Set_isCascadeBlend(bool value) => throw new System.NotImplementedException();

        private partial bool Get_castShadow() => throw new System.NotImplementedException();
        private partial void Set_castShadow(bool value) => throw new System.NotImplementedException();

        private partial bool Get_isBounced() => throw new System.NotImplementedException();
        private partial void Set_isBounced(bool value) => throw new System.NotImplementedException();

        private partial bool Get_showObject() => throw new System.NotImplementedException();
        private partial void Set_showObject(bool value) => throw new System.NotImplementedException();

        private partial bool Get_enableDistanceFade() => throw new System.NotImplementedException();
        private partial void Set_enableDistanceFade(bool value) => throw new System.NotImplementedException();

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            direction = Fox.Math.FoxToUnityVector3(direction);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(direction), Fox.Math.UnityToFoxVector3(direction));
        }
    }
}