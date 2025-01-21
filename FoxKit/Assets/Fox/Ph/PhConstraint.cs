using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhConstraint : Fox.Ph.PhSubObject
    {
        private partial UnityEngine.Vector3 Get_defaultPosition() => param.GetDefaultPosition();
        private partial void Set_defaultPosition(UnityEngine.Vector3 value) => param.SetDefaultPosition(value);

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            defaultPosition = Fox.Math.FoxToUnityVector3(defaultPosition);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(defaultPosition), Fox.Math.UnityToFoxVector3(defaultPosition));
        }
    }
}
