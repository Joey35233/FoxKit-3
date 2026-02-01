using System.Runtime.InteropServices;
using UnityEngine.Serialization;

namespace Fox.Gr.Terrain
{
    internal static class TerrainFileFormat
    {
        [StructLayout(LayoutKind.Sequential, Size = 0x30)]
        public struct BaseLayoutDescription
        {
            public ulong UnknownA;
            public ulong UnknownB;
            public uint GridWidth;
            public uint GridHeight;
            public uint PatchOffset;
            public float MaxHeightWS;
            public float MinHeightWS;
            public float GridDistance;
            public ushort LodCount;
        };
        
        [StructLayout(LayoutKind.Sequential, Size = 0x18)]
        public struct PatchDescription
        {
            public ulong UnknownA;
            public ulong UnknownB;
            public uint UnknownC;
            public uint PatchOffset;
        };

        [StructLayout(LayoutKind.Explicit, Size = 0x52)]
        public struct Patch
        {
            [FieldOffset(0x0)] public HeightMap HeightMap;
            [FieldOffset(0x14)] public uint ComboFormat;
            [FieldOffset(0x18)] public uint ComboTextureOffset;
            [FieldOffset(0x1C)] public uint ComboTextureSize;

            [FieldOffset(0x20)] public PatchConfiguration PatchConfiguration;
            
            [FieldOffset(0x40)] public uint Unknown;
            [FieldOffset(0x44)] public uint Height;
            [FieldOffset(0x48)] public uint Width;
            [FieldOffset(0x4C)] public ushort ClusterGridSize;
            [FieldOffset(0x4E)] public ushort MaxLodLevel;
            [FieldOffset(0x50)] public ushort LodCount;
        };

        [StructLayout(LayoutKind.Sequential, Size = 0x14)]
        public struct HeightMap
        {
            public uint HeightFormat;
            public float MaxHeightWS;
            public float MinHeightWS;
            public uint HeightMapOffset;
            public uint HeightMapSize;
        };

        [StructLayout(LayoutKind.Sequential, Size = 0x1C)]
        public struct PatchConfiguration
        {
            public ulong BaseOffset;
            public uint MaterialIdsOffset;
            public uint ConfigurationIdsOffset;
            public uint MaxHeightOffset;
            public uint MinHeightOffset;
            public uint ParamOffset;
        };
    }
}