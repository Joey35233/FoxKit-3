using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhRigidBody : Fox.Ph.PhSubObject
    {
        private partial UnityEngine.Vector3 defaultPosition_Get() => param == null ? Vector3.zero : param.GetDefaultPosition();
        private partial void defaultPosition_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            param.SetDefaultPosition(value);
        }

        private partial UnityEngine.Quaternion defaultRotation_Get() => param == null ? Quaternion.identity : param.GetDefaultRotation();
        private partial void defaultRotation_Set(UnityEngine.Quaternion value)
        {
            if (param == null)
                return;

            param.SetDefaultRotation(value);
        }

        private partial float mass_Get() => param == null ? 0.0f : param.GetMass();
        private partial void mass_Set(float value)
        {
            if (param == null)
                return;

            param.SetMass(value);
        }

        private partial float friction_Get() => param == null ? 0.0f : param.GetFriction();
        private partial void friction_Set(float value)
        {
            if (param == null)
                return;

            param.SetFriction(value);
        }

        private partial float restitution_Get() => param == null ? 0.0f : param.GetRestitution();
        private partial void restitution_Set(float value)
        {
            if (param == null)
                return;

            param.SetRestitution(value);
        }

        private partial float maxLinearVelocity_Get() => param == null ? 0.0f : param.GetMaxLinearVelocity();
        private partial void maxLinearVelocity_Set(float value)
        {
            if (param == null)
                return;

            param.SetMaxLinearVelocity(value);
        }

        private partial float maxAngularVelocity_Get() => param == null ? 0.0f : param.GetMaxAngularVelocity();
        private partial void maxAngularVelocity_Set(float value)
        {
            if (param == null)
                return;

            param.SetMaxAngularVelocity(value);
        }

        private partial float linearVelocityDamp_Get() => param == null ? 0.0f : param.GetLinearVelocityDamp();
        private partial void linearVelocityDamp_Set(float value)
        {
            if (param == null)
                return;

            param.SetLinearVelocityDamp(value);
        }

        private partial float angularVelocityDamp_Get() => param == null ? 0.0f : param.GetAngularVelocityDamp();
        private partial void angularVelocityDamp_Set(float value)
        {
            if (param == null)
                return;

            param.SetAngularVelocityDamp(value);
        }

        private partial float permittedDepth_Get() => param == null ? 0.0f : param.GetPermittedDepth();
        private partial void permittedDepth_Set(float value)
        {
            if (param == null)
                return;

            param.SetPermittedDepth(value);
        }

        private partial bool sleepEnable_Get() => param == null ? false : param.GetSleepEnable();
        private partial void sleepEnable_Set(bool value)
        {
            if (param == null)
                return;

            param.SetSleepEnable(value);
        }

        private partial float sleepLinearVelocityTh_Get() => param == null ? 0.0f : param.GetSleepLinearVelocityTh();
        private partial void sleepLinearVelocityTh_Set(float value)
        {
            if (param == null)
                return;

            param.SetSleepLinearVelocityTh(value);
        }

        private partial float sleepAngularVelocityTh_Get() => param == null ? 0.0f : param.GetSleepAngularVelocityTh();
        private partial void sleepAngularVelocityTh_Set(float value)
        {
            if (param == null)
                return;

            param.SetSleepAngularVelocityTh(value);
        }

        private partial float sleepTimeTh_Get() => param == null ? 0.0f : param.GetSleepTimeTh();
        private partial void sleepTimeTh_Set(float value)
        {
            if (param == null)
                return;

            param.SetSleepTimeTh(value);
        }

        private partial ushort collisionGroup_Get() => param == null ? (ushort)0 : param.GetCollisionGroup();
        private partial void collisionGroup_Set(ushort value)
        {
            if (param == null)
                return;

            param.SetCollisionGroup(value);
        }

        private partial ushort collisionType_Get() => param == null ? (ushort)0 : param.GetCollisionType();
        private partial void collisionType_Set(ushort value)
        {
            if (param == null)
                return;

            param.SetCollisionType(value);
        }

        private partial uint collisionId_Get() => param == null ? 0u : param.GetCollisionId();
        private partial void collisionId_Set(uint value)
        {
            if (param == null)
                return;

            param.SetCollisionId(value);
        }

        private partial UnityEngine.Vector3 centerOfMassOffset_Get() => param == null ? Vector3.zero : param.GetCenterOfMassOffset();
        private partial void centerOfMassOffset_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            param.SetCenterOfMassOffset(value);
        }

        private partial PhRigidBodyType motionType_Get() => param == null ? default : param.GetMotionType();
        private partial void motionType_Set(PhRigidBodyType value)
        {
            if (param == null)
                return;

            param.SetMotionType(value);
        }

        private partial string material_Get() => param == null ? null : param.GetMaterial();
        private partial void material_Set(string value)
        {
            if (param == null)
                return;

            param.SetMaterial(value);
        }
    }
}
