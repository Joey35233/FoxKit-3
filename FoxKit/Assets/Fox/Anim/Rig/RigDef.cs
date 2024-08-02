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

        Unknown6 = 6,

        Transform = 7,
        Arm = 8,

        Unknown9 = 9,
        Unknown10 = 10,

        List = 11,

        Unknown12 = 12,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigRootDef
    {
        public RigUnitType Type;
        
        public short TrackCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Indices
        public short PositionSegmentIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigOrientationDef
    {
        public RigUnitType Type;

        public short TrackCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        public short SkelIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigTwoBone
    {
        public RigUnitType Type;

        public short TrackCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Indices
        private Vector4 _Padding1;
        
        public Vector3 ChainPlaneNormal;
        private uint _PaddingW;

		public short UpperSkelIndex;
		public short MidSkelIndex;

		public short PoleRotationSegmentIndex;
		public short EffectorPositionSegmentIndex;

		public short EffectorSkelIndex;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct RigLocalOrientationDef
    {
        public RigUnitType Type;

        public short TrackCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        public short SkelIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigLocalTransformDef
    {
        public RigUnitType Type;

        public short TrackCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Indices
        public short SkelIndex;

        public short PositionSegmentIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigTransformDef
    {
        public RigUnitType Type;

        public short TrackCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Indices
        public short SkelIndex;

        public short PositionSegmentIndex;
        public short RotationSegmentIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RigArmDef
    {
        public RigUnitType Type;

        public short TrackCount;
        public short BoneCount;
        public short ParentBoneIndex;
        public short ParentUnitIndex;
        
        private uint _Padding;
        
        // Indices
        private Vector4 _Padding1;
        
        public Vector3 ChainPlaneNormal;
        private uint _PaddingW;

        public short ShoulderSkelIndex;
        public short UpperSkelIndex;
        public short LowerSkelIndex;

        public short ShoulderRotationSegmentIndex;
        public short PoleRotationSegmentIndex;
        public short EffectorPositionSegmentIndex;

        public short EffectorSkelIndex;
    }
}