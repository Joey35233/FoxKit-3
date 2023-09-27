using Fox.Kernel;

namespace Fox.Ph
{
    public partial class PhRigidBody : Fox.Ph.PhSubObject
    {
        private PhRigidBodyParam rigidBodyParam => param.Get();

        private partial UnityEngine.Vector3 Get_defaultPosition() => rigidBodyParam.GetDefaultPosition();
        private partial void Set_defaultPosition(UnityEngine.Vector3 value) => rigidBodyParam.SetDefaultPosition(value);

        private partial UnityEngine.Quaternion Get_defaultRotation() => rigidBodyParam.GetDefaultRotation();
        private partial void Set_defaultRotation(UnityEngine.Quaternion value) => rigidBodyParam.SetDefaultRotation(value);

        private partial float Get_mass() => rigidBodyParam.GetMass();
        private partial void Set_mass(float value) => rigidBodyParam.SetMass(value);

        private partial float Get_friction() => rigidBodyParam.GetFriction();
        private partial void Set_friction(float value) => rigidBodyParam.SetFriction(value);

        private partial float Get_restitution() => rigidBodyParam.GetRestitution();
        private partial void Set_restitution(float value) => rigidBodyParam.SetRestitution(value);

        private partial float Get_maxLinearVelocity() => rigidBodyParam.GetMaxLinearVelocity();
        private partial void Set_maxLinearVelocity(float value) => rigidBodyParam.SetMaxLinearVelocity(value);

        private partial float Get_maxAngularVelocity() => rigidBodyParam.GetMaxAngularVelocity();
        private partial void Set_maxAngularVelocity(float value) => rigidBodyParam.SetMaxAngularVelocity(value);

        private partial float Get_linearVelocityDamp() => rigidBodyParam.GetLinearVelocityDamp();
        private partial void Set_linearVelocityDamp(float value) => rigidBodyParam.SetLinearVelocityDamp(value);

        private partial float Get_angularVelocityDamp() => rigidBodyParam.GetAngularVelocityDamp();
        private partial void Set_angularVelocityDamp(float value) => rigidBodyParam.SetAngularVelocityDamp(value);

        private partial float Get_permittedDepth() => rigidBodyParam.GetPermittedDepth();
        private partial void Set_permittedDepth(float value) => rigidBodyParam.SetPermittedDepth(value);

        private partial bool Get_sleepEnable() => rigidBodyParam.GetSleepEnable();
        private partial void Set_sleepEnable(bool value) => rigidBodyParam.SetSleepEnable(value);

        private partial float Get_sleepLinearVelocityTh() => rigidBodyParam.GetSleepLinearVelocityTh();
        private partial void Set_sleepLinearVelocityTh(float value) => rigidBodyParam.SetSleepLinearVelocityTh(value);

        private partial float Get_sleepAngularVelocityTh() => rigidBodyParam.GetSleepAngularVelocityTh();
        private partial void Set_sleepAngularVelocityTh(float value) => rigidBodyParam.SetSleepAngularVelocityTh(value);

        private partial float Get_sleepTimeTh() => rigidBodyParam.GetSleepTimeTh();
        private partial void Set_sleepTimeTh(float value) => rigidBodyParam.SetSleepTimeTh(value);

        private partial ushort Get_collisionGroup() => rigidBodyParam.GetCollisionGroup();
        private partial void Set_collisionGroup(ushort value) => rigidBodyParam.SetCollisionGroup(value);

        private partial ushort Get_collisionType() => rigidBodyParam.GetCollisionType();
        private partial void Set_collisionType(ushort value) => rigidBodyParam.SetCollisionType(value);

        private partial uint Get_collisionId() => rigidBodyParam.GetCollisionId();
        private partial void Set_collisionId(uint value) => rigidBodyParam.SetCollisionId(value);

        private partial UnityEngine.Vector3 Get_centerOfMassOffset() => rigidBodyParam.GetCenterOfMassOffset();
        private partial void Set_centerOfMassOffset(UnityEngine.Vector3 value) => rigidBodyParam.SetCenterOfMassOffset(value);

        private partial PhRigidBodyType Get_motionType() => rigidBodyParam.GetMotionType();
        private partial void Set_motionType(PhRigidBodyType value) => rigidBodyParam.SetMotionType(value);

        private partial String Get_material() => rigidBodyParam.GetMaterial();
        private partial void Set_material(String value) => rigidBodyParam.SetMaterial(value);
    }
}
