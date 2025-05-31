using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhRigidBody : Fox.Ph.PhSubObject
    {
        private partial UnityEngine.Vector3 Get_defaultPosition() => param.GetDefaultPosition();
        private partial void Set_defaultPosition(UnityEngine.Vector3 value) => param.SetDefaultPosition(value);

        private partial UnityEngine.Quaternion Get_defaultRotation() => param.GetDefaultRotation();
        private partial void Set_defaultRotation(UnityEngine.Quaternion value) => param.SetDefaultRotation(value);

        private partial float Get_mass() => param.GetMass();
        private partial void Set_mass(float value) => param.SetMass(value);

        private partial float Get_friction() => param.GetFriction();
        private partial void Set_friction(float value) => param.SetFriction(value);

        private partial float Get_restitution() => param.GetRestitution();
        private partial void Set_restitution(float value) => param.SetRestitution(value);

        private partial float Get_maxLinearVelocity() => param.GetMaxLinearVelocity();
        private partial void Set_maxLinearVelocity(float value) => param.SetMaxLinearVelocity(value);

        private partial float Get_maxAngularVelocity() => param.GetMaxAngularVelocity();
        private partial void Set_maxAngularVelocity(float value) => param.SetMaxAngularVelocity(value);

        private partial float Get_linearVelocityDamp() => param.GetLinearVelocityDamp();
        private partial void Set_linearVelocityDamp(float value) => param.SetLinearVelocityDamp(value);

        private partial float Get_angularVelocityDamp() => param.GetAngularVelocityDamp();
        private partial void Set_angularVelocityDamp(float value) => param.SetAngularVelocityDamp(value);

        private partial float Get_permittedDepth() => param.GetPermittedDepth();
        private partial void Set_permittedDepth(float value) => param.SetPermittedDepth(value);

        private partial bool Get_sleepEnable() => param.GetSleepEnable();
        private partial void Set_sleepEnable(bool value) => param.SetSleepEnable(value);

        private partial float Get_sleepLinearVelocityTh() => param.GetSleepLinearVelocityTh();
        private partial void Set_sleepLinearVelocityTh(float value) => param.SetSleepLinearVelocityTh(value);

        private partial float Get_sleepAngularVelocityTh() => param.GetSleepAngularVelocityTh();
        private partial void Set_sleepAngularVelocityTh(float value) => param.SetSleepAngularVelocityTh(value);

        private partial float Get_sleepTimeTh() => param.GetSleepTimeTh();
        private partial void Set_sleepTimeTh(float value) => param.SetSleepTimeTh(value);

        private partial ushort Get_collisionGroup() => param.GetCollisionGroup();
        private partial void Set_collisionGroup(ushort value) => param.SetCollisionGroup(value);

        private partial ushort Get_collisionType() => param.GetCollisionType();
        private partial void Set_collisionType(ushort value) => param.SetCollisionType(value);

        private partial uint Get_collisionId() => param.GetCollisionId();
        private partial void Set_collisionId(uint value) => param.SetCollisionId(value);

        private partial UnityEngine.Vector3 Get_centerOfMassOffset() => param.GetCenterOfMassOffset();
        private partial void Set_centerOfMassOffset(UnityEngine.Vector3 value) => param.SetCenterOfMassOffset(value);

        private partial PhRigidBodyType Get_motionType() => param.GetMotionType();
        private partial void Set_motionType(PhRigidBodyType value) => param.SetMotionType(value);

        private partial string Get_material() => param.GetMaterial();
        private partial void Set_material(string value) => param.SetMaterial(value);
    }
}
