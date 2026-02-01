using Fox.Core;
using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhConstraintParam : Fox.Core.Entity
    {
        internal UnityEngine.Vector3 GetDefaultPosition() => defaultPosition;
        internal void SetDefaultPosition(UnityEngine.Vector3 value) => defaultPosition = value;

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            defaultPosition = Fox.Math.FoxToUnityVector3(defaultPosition);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);
            
            context.OverrideProperty(nameof(defaultPosition), Fox.Math.UnityToFoxVector3(defaultPosition));
        }

        public virtual void DrawGizmos()
        {

        }
    }
}
