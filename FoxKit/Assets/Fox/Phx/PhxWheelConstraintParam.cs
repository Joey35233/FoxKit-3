using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Phx
{
    public partial class PhxWheelConstraintParam : Fox.Ph.PhConstraintParam
    {
        internal UnityEngine.Vector3 GetFrontL() => frontL;
        internal void SetFrontL(UnityEngine.Vector3 value) => frontL = value;

        internal UnityEngine.Vector3 GetUpL() => upL;
        internal void SetUpL(UnityEngine.Vector3 value) => upL = value;

        internal UnityEngine.Vector3 GetWheelPositionOffset() => wheelPositionOffset;
        internal void SetWheelPositionOffset(UnityEngine.Vector3 value) => wheelPositionOffset = value;

        internal float GetRadius() => radius;
        internal void SetRadius(float value) => radius = value;

        internal float GetFriction() => friction;
        internal void SetFriction(float value) => friction = value;

        internal float GetRestitution() => restitution;
        internal void SetRestitution(float value) => restitution = value;

        internal float GetInertia() => inertia;
        internal void SetIntertia(float value) => inertia = value;

        internal float GetSuspensionLength() => suspensionLength;
        internal void SetSuspensionLength(float value) => suspensionLength = value;

        internal float GetMaxSuspensionForce() => maxSuspensionForce;
        internal void SetMaxSuspensionForce(float value) => maxSuspensionForce = value;

        internal float GetDampingFactorElong() => dampingFactorElong;
        internal void SetDampingFactorElong(float value) => dampingFactorElong = value;

        internal float GetDampingFactorCompress() => dampingFactorCompress;
        internal void SetDampingFactorCompress(float value) => dampingFactorCompress = value;

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            frontL = Fox.Math.FoxToUnityVector3(frontL);
            upL = Fox.Math.FoxToUnityVector3(upL);
            wheelPositionOffset = Fox.Math.FoxToUnityVector3(wheelPositionOffset);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);
            
            context.OverrideProperty(nameof(frontL), Fox.Math.UnityToFoxVector3(frontL));
            context.OverrideProperty(nameof(upL), Fox.Math.UnityToFoxVector3(upL)); ;
            context.OverrideProperty(nameof(wheelPositionOffset), Fox.Math.UnityToFoxVector3(wheelPositionOffset)); ;
        }
    }
}
