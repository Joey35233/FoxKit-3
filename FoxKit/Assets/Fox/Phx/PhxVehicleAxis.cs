using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Phx
{
    public partial class PhxVehicleAxis : Fox.Core.Data
    {
        private PhxWheelConstraintParam wheelConstraint => wheelConstraintParam;
        private PhVehicleAxisParam vehicleAxis => vehicleAxisParam;

        private partial UnityEngine.Vector3 Get_wheelFront() => wheelConstraint.GetFrontL();
        private partial void Set_wheelFront(UnityEngine.Vector3 value) => wheelConstraint.SetFrontL(value);

        private partial UnityEngine.Vector3 Get_wheelUp() => wheelConstraint.GetUpL();
        private partial void Set_wheelUp(UnityEngine.Vector3 value) => wheelConstraint.SetUpL(value);

        private partial UnityEngine.Vector3 Get_wheelPositionOffset() => wheelConstraint.GetWheelPositionOffset();
        private partial void Set_wheelPositionOffset(UnityEngine.Vector3 value) => wheelConstraint.SetWheelPositionOffset(value);

        private partial float Get_wheelRadius() => wheelConstraint.GetRadius();
        private partial void Set_wheelRadius(float value) => wheelConstraint.SetRadius(value);

        private partial float Get_wheelFriction() => wheelConstraint.GetFriction();
        private partial void Set_wheelFriction(float value) => wheelConstraint.SetFriction(value);

        private partial float Get_wheelRestitution() => wheelConstraint.GetRestitution();
        private partial void Set_wheelRestitution(float value) => wheelConstraint.SetRestitution(value);

        private partial float Get_wheelInertia() => wheelConstraint.GetInertia();
        private partial void Set_wheelInertia(float value) => wheelConstraint.SetIntertia(value);

        private partial float Get_suspentionLength() => wheelConstraint.GetSuspensionLength();
        private partial void Set_suspentionLength(float value) => wheelConstraint.SetSuspensionLength(value);

        private partial float Get_maxSuspentionForceCoeff() => wheelConstraint.GetMaxSuspensionForce();
        private partial void Set_maxSuspentionForceCoeff(float value) => wheelConstraint.SetMaxSuspensionForce(value);

        private partial float Get_dampingCoeffElong() => wheelConstraint.GetDampingFactorElong();
        private partial void Set_dampingCoeffElong(float value) => wheelConstraint.SetDampingFactorElong(value);

        private partial float Get_dampingCoeffCompress() => wheelConstraint.GetDampingFactorCompress();
        private partial void Set_dampingCoeffCompress(float value) => wheelConstraint.SetDampingFactorCompress(value);

        private partial float Get_maxBreakTorqueCoeff() => vehicleAxis.GetMaxBrakeTorque();
        private partial void Set_maxBreakTorqueCoeff(float value) => vehicleAxis.SetMaxBrakeTorque(value);

        private partial bool Get_useDifferential() => vehicleAxis.GetUseDifferential();
        private partial void Set_useDifferential(bool value) => vehicleAxis.SetUseDifferential(value);

        private partial System.Collections.Generic.List<string> Get_AssignedBoneNames()
        {
            var assignedBoneNames = new System.Collections.Generic.List<string>();
            foreach (PhxWheelAssociationUnitParam wheelAssociationUnit in wheelAssociationUnitParams)
                assignedBoneNames.Add(wheelAssociationUnit.GetBoneName());

            return assignedBoneNames;
        }

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            wheelFront = Fox.Math.FoxToUnityVector3(wheelFront);
            wheelUp = Fox.Math.FoxToUnityVector3(wheelUp);
            wheelPositionOffset = Fox.Math.FoxToUnityVector3(wheelPositionOffset);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            context.OverrideProperty(nameof(wheelFront), Fox.Math.UnityToFoxVector3(wheelFront));
            context.OverrideProperty(nameof(wheelUp), Fox.Math.UnityToFoxVector3(wheelUp)); ;
            context.OverrideProperty(nameof(wheelPositionOffset), Fox.Math.UnityToFoxVector3(wheelPositionOffset)); ;

            base.OverridePropertiesForExport(context);
        }
    }
}
