﻿using Fox.Kernel;

namespace Fox.Ph
{
    public partial class PhRigidBodyParam : Fox.Core.Entity
    {
        internal UnityEngine.Vector3 GetDefaultPosition() => defaultPosition;
        internal void SetDefaultPosition(UnityEngine.Vector3 value) => defaultPosition = value;

        internal UnityEngine.Quaternion GetDefaultRotation() => defaultRotation;
        internal void SetDefaultRotation(UnityEngine.Quaternion value) => defaultRotation = value;

        internal float GetMass() => mass;
        internal void SetMass(float value) => mass = value;

        internal float GetFriction() => friction;
        internal void SetFriction(float value) => friction = value;

        internal float GetRestitution() => restitution;
        internal void SetRestitution(float value) => restitution = value;

        internal float GetMaxLinearVelocity() => maxLinearVelocity;
        internal void SetMaxLinearVelocity(float value) => maxLinearVelocity = value;

        internal float GetMaxAngularVelocity() => maxAngularVelocity;
        internal void SetMaxAngularVelocity(float value) => maxAngularVelocity = value;

        internal float GetLinearVelocityDamp() => linearVelocityDamp;
        internal void SetLinearVelocityDamp(float value) => linearVelocityDamp = value;

        internal float GetAngularVelocityDamp() => angularVelocityDamp;
        internal void SetAngularVelocityDamp(float value) => angularVelocityDamp = value;

        internal float GetPermittedDepth() => permittedDepth;
        internal void SetPermittedDepth(float value) => permittedDepth = value;

        internal bool GetSleepEnable() => sleepEnable;
        internal void SetSleepEnable(bool value) => sleepEnable = value;

        internal float GetSleepLinearVelocityTh() => sleepLinearVelocityTh;
        internal void SetSleepLinearVelocityTh(float value) => sleepLinearVelocityTh = value;

        internal float GetSleepAngularVelocityTh() => sleepAngularVelocityTh;
        internal void SetSleepAngularVelocityTh(float value) => sleepAngularVelocityTh = value;

        internal float GetSleepTimeTh() => sleepTimeTh;
        internal void SetSleepTimeTh(float value) => sleepTimeTh = value;

        internal ushort GetCollisionGroup() => collisionGroup;
        internal void SetCollisionGroup(ushort value) => collisionGroup = value;

        internal ushort GetCollisionType() => collisionType;
        internal void SetCollisionType(ushort value) => collisionType = value;

        internal uint GetCollisionId() => collisionId;
        internal void SetCollisionId(uint value) => collisionId = value;

        internal UnityEngine.Vector3 GetCenterOfMassOffset() => centerOfMassOffset;
        internal void SetCenterOfMassOffset(UnityEngine.Vector3 value) => centerOfMassOffset = value;

        internal PhRigidBodyType GetMotionType() => motionType;
        internal void SetMotionType(PhRigidBodyType value) => motionType = value;

        internal String GetMaterial() => material;
        internal void SetMaterial(String value) => material = value;
    }
}