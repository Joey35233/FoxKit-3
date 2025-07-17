using System;
using System.Runtime.InteropServices;
using Fox.Core;
using UnityEngine;

namespace Fox.Anim
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RigFileHeader
    {
        public FoxDataString Name;

        public uint Version;
	
        public uint RigUnitCount;
        public uint SegmentCount;
        public uint FileSize;
        public uint BoneListOffset;
        public uint MaskDefOffset;
    }
}