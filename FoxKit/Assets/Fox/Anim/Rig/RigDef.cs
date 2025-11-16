using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox.Anim
{
    public enum RigUnitType : uint
    {
        Root = 1,
        Orientation = 2,
        TwoBone = 3,
        LocalOrientation = 4,
        LocalTransform = 5,

        ThreeBoneLikeTwoBone = 6,

        Transform = 7,
        Arm = 8,

        LocalTransformSRT = 9,
        AnimalLeg = 10,

        MultiLocalOrientation = 11,

        TwoBoneTrans = 12,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigRootDef
    {
        public RigUnitType Type;
        
        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Specific
        public short PositionSegmentIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigOrientationDef
    {
        public RigUnitType Type;

        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        public short BoneIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigTwoBoneDef
    {
        public RigUnitType Type;

        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Specific
        private Vector4 _Padding1;
        
        public Vector3 ChainPlaneNormal;
        private uint _PaddingW;

		public short UpperBoneIndex;
		public short MidBoneIndex;

        public short EffectorPositionSegmentIndex;
		public short PoleRotationSegmentIndex;

		public short EffectorBoneIndex;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct RigLocalOrientationDef
    {
        public RigUnitType Type;

        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Specific
        public short BoneIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigLocalTransformDef
    {
        public RigUnitType Type;

        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Specific
        public short BoneIndex;

        public short RotationSegmentIndex;
        public short PositionSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigTransformDef
    {
        public RigUnitType Type;

        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Specific
        public short BoneIndex;

        public short RotationSegmentIndex;
        public short PositionSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigArmDef
    {
        public RigUnitType Type;

        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Specific
        private Vector4 _Padding1;
        
        public Vector3 ChainPlaneNormal;
        private uint _PaddingW;

        public short ShoulderBoneIndex;
        public short UpperBoneIndex;
        public short LowerBoneIndex;

        public short ShoulderRotationSegmentIndex;
        public short EffectorPositionSegmentIndex;
        public short PoleRotationSegmentIndex;

        public short EffectorBoneIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigMultiLocalOrientationDef
    {
        public RigUnitType Type;

        public short SegmentCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Specific
        public short StartBoneIndex;
        public short StartSegmentIndex;
    }
}