using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Phx
{
    public partial class PhxVehicleAxis : Fox.Core.Data
    {
        private partial UnityEngine.Vector3 wheelFront_Get() => wheelConstraintParam.GetFrontL();
        private partial void wheelFront_Set(UnityEngine.Vector3 value) => wheelConstraintParam.SetFrontL(value);

        private partial UnityEngine.Vector3 wheelUp_Get() => wheelConstraintParam.GetUpL();
        private partial void wheelUp_Set(UnityEngine.Vector3 value) => wheelConstraintParam.SetUpL(value);

        private partial UnityEngine.Vector3 wheelPositionOffset_Get() => wheelConstraintParam.GetWheelPositionOffset();
        private partial void wheelPositionOffset_Set(UnityEngine.Vector3 value) => wheelConstraintParam.SetWheelPositionOffset(value);

        private partial float wheelRadius_Get() => wheelConstraintParam.GetRadius();
        private partial void wheelRadius_Set(float value) => wheelConstraintParam.SetRadius(value);

        private partial float wheelFriction_Get() => wheelConstraintParam.GetFriction();
        private partial void wheelFriction_Set(float value) => wheelConstraintParam.SetFriction(value);

        private partial float wheelRestitution_Get() => wheelConstraintParam.GetRestitution();
        private partial void wheelRestitution_Set(float value) => wheelConstraintParam.SetRestitution(value);

        private partial float wheelInertia_Get() => wheelConstraintParam.GetInertia();
        private partial void wheelInertia_Set(float value) => wheelConstraintParam.SetIntertia(value);

        private partial float suspentionLength_Get() => wheelConstraintParam.GetSuspensionLength();
        private partial void suspentionLength_Set(float value) => wheelConstraintParam.SetSuspensionLength(value);

        private partial float maxSuspentionForceCoeff_Get() => wheelConstraintParam.GetMaxSuspensionForce();
        private partial void maxSuspentionForceCoeff_Set(float value) => wheelConstraintParam.SetMaxSuspensionForce(value);

        private partial float dampingCoeffElong_Get() => wheelConstraintParam.GetDampingFactorElong();
        private partial void dampingCoeffElong_Set(float value) => wheelConstraintParam.SetDampingFactorElong(value);

        private partial float dampingCoeffCompress_Get() => wheelConstraintParam.GetDampingFactorCompress();
        private partial void dampingCoeffCompress_Set(float value) => wheelConstraintParam.SetDampingFactorCompress(value);

        private partial float maxBreakTorqueCoeff_Get() => vehicleAxisParam.GetMaxBrakeTorque();
        private partial void maxBreakTorqueCoeff_Set(float value) => vehicleAxisParam.SetMaxBrakeTorque(value);

        private partial bool useDifferential_Get() => vehicleAxisParam.GetUseDifferential();
        private partial void useDifferential_Set(bool value) => vehicleAxisParam.SetUseDifferential(value);

        public partial string AssignedBoneNames_Get(int index)
        {
            throw new System.NotImplementedException();
        }
        public partial void AssignedBoneNames_Set(int index, string value)
        {
            throw new System.NotImplementedException();
        }
        public partial void AssignedBoneNames_AddElement(int index, string value)
        {
            throw new System.NotImplementedException();
        }
        public partial void AssignedBoneNames_RemoveElement(int index)
        {
            throw new System.NotImplementedException();
        }
        public partial int AssignedBoneNames_GetContainerSize()
        {
            throw new System.NotImplementedException();
        }

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            wheelFront = Fox.Math.FoxToUnityVector3(wheelFront);
            wheelUp = Fox.Math.FoxToUnityVector3(wheelUp);
            wheelPositionOffset = Fox.Math.FoxToUnityVector3(wheelPositionOffset);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);
            
            context.OverrideProperty(nameof(wheelFront), Fox.Math.UnityToFoxVector3(wheelFront));
            context.OverrideProperty(nameof(wheelUp), Fox.Math.UnityToFoxVector3(wheelUp)); ;
            context.OverrideProperty(nameof(wheelPositionOffset), Fox.Math.UnityToFoxVector3(wheelPositionOffset)); ;
        }
    }
}
