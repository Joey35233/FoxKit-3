using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhConstraintParam : Fox.Core.Entity
    {
        internal UnityEngine.Vector3 GetDefaultPosition() => defaultPosition;
        internal void SetDefaultPosition(UnityEngine.Vector3 value) => defaultPosition = value;

        [NonSerialized]
        internal PhRigidBodyParam BodyA;
        [NonSerialized]
        internal PhRigidBodyParam BodyB;

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            defaultPosition = Fox.Kernel.Math.FoxToUnityVector3(defaultPosition);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public virtual void DrawGizmos()
        {

        }
    }
}
