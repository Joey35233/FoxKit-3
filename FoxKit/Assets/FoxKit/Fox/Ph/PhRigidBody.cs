using Fox.Core;
using Fox.FoxKernel;

namespace Fox.Ph
{
    public partial class PhRigidBody : Fox.Ph.PhSubObject
    {
        private PhRigidBodyParam rigidBodyParam => (param.Get() as PhRigidBodyParam);

        protected partial UnityEngine.Vector3 Get_defaultPosition() => rigidBodyParam.GetDefaultPosition();
        protected partial void Set_defaultPosition(UnityEngine.Vector3 value) { rigidBodyParam.SetDefaultPosition(value); }

        protected partial UnityEngine.Quaternion Get_defaultRotation() => rigidBodyParam.GetDefaultRotation();
        protected partial void Set_defaultRotation(UnityEngine.Quaternion value) { rigidBodyParam.SetDefaultRotation(value); }

        protected partial float Get_mass() => rigidBodyParam.GetMass();
        protected partial void Set_mass(float value) { rigidBodyParam.SetMass(value); }

        protected partial float Get_friction() => rigidBodyParam.GetFriction();
        protected partial void Set_friction(float value) { rigidBodyParam.SetFriction(value); }

        protected partial float Get_restitution() => rigidBodyParam.GetRestitution();
        protected partial void Set_restitution(float value) { rigidBodyParam.SetRestitution(value); }

        protected partial float Get_maxLinearVelocity() => rigidBodyParam.GetMaxLinearVelocity();
        protected partial void Set_maxLinearVelocity(float value) { rigidBodyParam.SetMaxLinearVelocity(value); }

        protected partial float Get_maxAngularVelocity() => rigidBodyParam.GetMaxAngularVelocity();
        protected partial void Set_maxAngularVelocity(float value) { rigidBodyParam.SetMaxAngularVelocity(value); }

        protected partial float Get_linearVelocityDamp() => rigidBodyParam.GetLinearVelocityDamp();
        protected partial void Set_linearVelocityDamp(float value) { rigidBodyParam.SetLinearVelocityDamp(value); }

        protected partial float Get_angularVelocityDamp() => rigidBodyParam.GetAngularVelocityDamp();
        protected partial void Set_angularVelocityDamp(float value) { rigidBodyParam.SetAngularVelocityDamp(value); }

        protected partial float Get_permittedDepth() => rigidBodyParam.GetPermittedDepth();
        protected partial void Set_permittedDepth(float value) { rigidBodyParam.SetPermittedDepth(value); }

        protected partial bool Get_sleepEnable() => rigidBodyParam.GetSleepEnable();
        protected partial void Set_sleepEnable(bool value) { rigidBodyParam.SetSleepEnable(value); }

        protected partial float Get_sleepLinearVelocityTh() => rigidBodyParam.GetSleepLinearVelocityTh();
        protected partial void Set_sleepLinearVelocityTh(float value) { rigidBodyParam.SetSleepLinearVelocityTh(value); }

        protected partial float Get_sleepAngularVelocityTh() => rigidBodyParam.GetSleepAngularVelocityTh();
        protected partial void Set_sleepAngularVelocityTh(float value) { rigidBodyParam.SetSleepAngularVelocityTh(value); }

        protected partial float Get_sleepTimeTh() => rigidBodyParam.GetSleepTimeTh();
        protected partial void Set_sleepTimeTh(float value) { rigidBodyParam.SetSleepTimeTh(value); }

        protected partial ushort Get_collisionGroup() => rigidBodyParam.GetCollisionGroup();
        protected partial void Set_collisionGroup(ushort value) { rigidBodyParam.SetCollisionGroup(value); }

        protected partial ushort Get_collisionType() => rigidBodyParam.GetCollisionType();
        protected partial void Set_collisionType(ushort value) { rigidBodyParam.SetCollisionType(value); }

        protected partial uint Get_collisionId() => rigidBodyParam.GetCollisionId();
        protected partial void Set_collisionId(uint value) { rigidBodyParam.SetCollisionId(value); }

        protected partial UnityEngine.Vector3 Get_centerOfMassOffset() => rigidBodyParam.GetCenterOfMassOffset();
        protected partial void Set_centerOfMassOffset(UnityEngine.Vector3 value) { rigidBodyParam.SetCenterOfMassOffset(value); }

        protected partial PhRigidBodyType Get_motionType() => rigidBodyParam.GetMotionType();
        protected partial void Set_motionType(PhRigidBodyType value) { rigidBodyParam.SetMotionType(value); }

        protected partial String Get_material() => rigidBodyParam.GetMaterial();
        protected partial void Set_material(String value) { rigidBodyParam.SetMaterial(value); }
    }
}
