using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhRigidBody : Fox.Ph.PhSubObject
    {
        private partial UnityEngine.Vector3 Get_defaultPosition() => param == null ? Vector3.zero : param.GetDefaultPosition();
        private partial void Set_defaultPosition(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            param.SetDefaultPosition(value);
        }

        private partial UnityEngine.Quaternion Get_defaultRotation() => param == null ? Quaternion.identity : param.GetDefaultRotation();
        private partial void Set_defaultRotation(UnityEngine.Quaternion value)
        {
            if (param == null)
                return;

            param.SetDefaultRotation(value);
        }

        private partial float Get_mass() => param == null ? 0.0f : param.GetMass();
        private partial void Set_mass(float value)
        {
            if (param == null)
                return;

            param.SetMass(value);
        }

        private partial float Get_friction() => param == null ? 0.0f : param.GetFriction();
        private partial void Set_friction(float value)
        {
            if (param == null)
                return;

            param.SetFriction(value);
        }

        private partial float Get_restitution() => param == null ? 0.0f : param.GetRestitution();
        private partial void Set_restitution(float value)
        {
            if (param == null)
                return;

            param.SetRestitution(value);
        }

        private partial float Get_maxLinearVelocity() => param == null ? 0.0f : param.GetMaxLinearVelocity();
        private partial void Set_maxLinearVelocity(float value)
        {
            if (param == null)
                return;

            param.SetMaxLinearVelocity(value);
        }

        private partial float Get_maxAngularVelocity() => param == null ? 0.0f : param.GetMaxAngularVelocity();
        private partial void Set_maxAngularVelocity(float value)
        {
            if (param == null)
                return;

            param.SetMaxAngularVelocity(value);
        }

        private partial float Get_linearVelocityDamp() => param == null ? 0.0f : param.GetLinearVelocityDamp();
        private partial void Set_linearVelocityDamp(float value)
        {
            if (param == null)
                return;

            param.SetLinearVelocityDamp(value);
        }

        private partial float Get_angularVelocityDamp() => param == null ? 0.0f : param.GetAngularVelocityDamp();
        private partial void Set_angularVelocityDamp(float value)
        {
            if (param == null)
                return;

            param.SetAngularVelocityDamp(value);
        }

        private partial float Get_permittedDepth() => param == null ? 0.0f : param.GetPermittedDepth();
        private partial void Set_permittedDepth(float value)
        {
            if (param == null)
                return;

            param.SetPermittedDepth(value);
        }

        private partial bool Get_sleepEnable() => param == null ? false : param.GetSleepEnable();
        private partial void Set_sleepEnable(bool value)
        {
            if (param == null)
                return;

            param.SetSleepEnable(value);
        }

        private partial float Get_sleepLinearVelocityTh() => param == null ? 0.0f : param.GetSleepLinearVelocityTh();
        private partial void Set_sleepLinearVelocityTh(float value)
        {
            if (param == null)
                return;

            param.SetSleepLinearVelocityTh(value);
        }

        private partial float Get_sleepAngularVelocityTh() => param == null ? 0.0f : param.GetSleepAngularVelocityTh();
        private partial void Set_sleepAngularVelocityTh(float value)
        {
            if (param == null)
                return;

            param.SetSleepAngularVelocityTh(value);
        }

        private partial float Get_sleepTimeTh() => param == null ? 0.0f : param.GetSleepTimeTh();
        private partial void Set_sleepTimeTh(float value)
        {
            if (param == null)
                return;

            param.SetSleepTimeTh(value);
        }

        private partial ushort Get_collisionGroup() => param == null ? (ushort)0 : param.GetCollisionGroup();
        private partial void Set_collisionGroup(ushort value)
        {
            if (param == null)
                return;

            param.SetCollisionGroup(value);
        }

        private partial ushort Get_collisionType() => param == null ? (ushort)0 : param.GetCollisionType();
        private partial void Set_collisionType(ushort value)
        {
            if (param == null)
                return;

            param.SetCollisionType(value);
        }

        private partial uint Get_collisionId() => param == null ? 0u : param.GetCollisionId();
        private partial void Set_collisionId(uint value)
        {
            if (param == null)
                return;

            param.SetCollisionId(value);
        }

        private partial UnityEngine.Vector3 Get_centerOfMassOffset() => param == null ? Vector3.zero : param.GetCenterOfMassOffset();
        private partial void Set_centerOfMassOffset(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            param.SetCenterOfMassOffset(value);
        }

        private partial PhRigidBodyType Get_motionType() => param == null ? default : param.GetMotionType();
        private partial void Set_motionType(PhRigidBodyType value)
        {
            if (param == null)
                return;

            param.SetMotionType(value);
        }

        private partial string Get_material() => param == null ? null : param.GetMaterial();
        private partial void Set_material(string value)
        {
            if (param == null)
                return;

            param.SetMaterial(value);
        }
    }
}
