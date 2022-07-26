using Fox.Core;
using Fox.Kernel;

namespace Fox.Phx
{
    public partial class PhxVehicleAxis : Fox.Core.Data
    {
        private PhxWheelConstraintParam wheelConstraint => (wheelConstraintParam.Get() as PhxWheelConstraintParam);
        private PhVehicleAxisParam vehicleAxis => (vehicleAxisParam.Get() as PhVehicleAxisParam);

        protected partial UnityEngine.Vector3 Get_wheelFront() => wheelConstraint.GetFrontL();
        protected partial void Set_wheelFront(UnityEngine.Vector3 value) { wheelConstraint.SetFrontL(value); }

        protected partial UnityEngine.Vector3 Get_wheelUp() => wheelConstraint.GetUpL();
        protected partial void Set_wheelUp(UnityEngine.Vector3 value) { wheelConstraint.SetUpL(value); }

        protected partial UnityEngine.Vector3 Get_wheelPositionOffset() => wheelConstraint.GetWheelPositionOffset();
        protected partial void Set_wheelPositionOffset(UnityEngine.Vector3 value) { wheelConstraint.SetWheelPositionOffset(value); }

        protected partial float Get_wheelRadius() => wheelConstraint.GetRadius();
        protected partial void Set_wheelRadius(float value) { wheelConstraint.SetRadius(value); }

        protected partial float Get_wheelFriction() => wheelConstraint.GetFriction();
        protected partial void Set_wheelFriction(float value) { wheelConstraint.SetFriction(value); }

        protected partial float Get_wheelRestitution() => wheelConstraint.GetRestitution();
        protected partial void Set_wheelRestitution(float value) { wheelConstraint.SetRestitution(value); }

        protected partial float Get_wheelInertia() => wheelConstraint.GetInertia();
        protected partial void Set_wheelInertia(float value) { wheelConstraint.SetIntertia(value); }

        protected partial float Get_suspentionLength() => wheelConstraint.GetSuspensionLength();
        protected partial void Set_suspentionLength(float value) { wheelConstraint.SetSuspensionLength(value); }

        protected partial float Get_maxSuspentionForceCoeff() => wheelConstraint.GetMaxSuspensionForce();
        protected partial void Set_maxSuspentionForceCoeff(float value) { wheelConstraint.SetMaxSuspensionForce(value); }

        protected partial float Get_dampingCoeffElong() => wheelConstraint.GetDampingFactorElong();
        protected partial void Set_dampingCoeffElong(float value) { wheelConstraint.SetDampingFactorElong(value); }

        protected partial float Get_dampingCoeffCompress() => wheelConstraint.GetDampingFactorCompress();
        protected partial void Set_dampingCoeffCompress(float value) { wheelConstraint.SetDampingFactorCompress(value); }

        protected partial float Get_maxBreakTorqueCoeff() => vehicleAxis.GetMaxBrakeTorque();
        protected partial void Set_maxBreakTorqueCoeff(float value) { vehicleAxis.SetMaxBrakeTorque(value); }

        protected partial bool Get_useDifferential() => vehicleAxis.GetUseDifferential();
        protected partial void Set_useDifferential(bool value) { vehicleAxis.SetUseDifferential(value); }

        protected partial DynamicArray<String> Get_AssignedBoneNames()
        {
            DynamicArray<String> assignedBoneNames = new DynamicArray<String>();
            foreach (var wheelAssociationUnit in wheelAssociationUnitParams)
                assignedBoneNames.Add(wheelAssociationUnit.Get().GetBoneName());

            return assignedBoneNames;
        }
        protected partial void Set_AssignedBoneNames(DynamicArray<String> value)
        {
            int i = 0;
            foreach (var wheelAssociationUnit in wheelAssociationUnitParams)
            {
                wheelAssociationUnit.Get().SetBoneName(value[i]);

                i++;
            }
        }
    }
}
