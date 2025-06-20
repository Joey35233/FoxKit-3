using System.Runtime.InteropServices;

namespace Fox.Gr.Terrain
{
    internal static class TerrainFileFormat
    {
        [StructLayout(LayoutKind.Sequential, Size = 0x30)]
        public struct BaseLayoutDescription
        {
            ulong UnknownA;
            ulong UnknownB;
            uint GridWidth;
            uint GridHeight;
            uint PatchOffset;
            float MaxHeightWS;
            float MinHeightWS;
            float GridDistance;
            ushort LodCount;
        };
        
        [StructLayout(LayoutKind.Sequential, Size = 0x18)]
        public struct PatchDescription
        {
            ulong UnknownA;
            ulong UnknownB;
            uint HeightFormat;
            uint PatchOffset;
        };

        [StructLayout(LayoutKind.Explicit, Size = 0x52)]
        public struct Patch
        {
            [FieldOffset(0x0)] HeightMap HeightMap;
            [FieldOffset(0x14)] uint ComboFormat;
            [FieldOffset(0x18)] uint ComboTextureOffset;
            [FieldOffset(0x1C)] uint ComboTextureSize;

            [FieldOffset(0x20)] PatchConfigration PatchConfiguration;
            
            [FieldOffset(0x40)] uint Unknown;
            [FieldOffset(0x44)] uint Height;
            [FieldOffset(0x48)] uint Width;
            [FieldOffset(0x4C)] ushort ClusterGridSize;
            [FieldOffset(0x4E)] ushort MaxLodLevel;
            [FieldOffset(0x50)] ushort LodCount;
        };

        [StructLayout(LayoutKind.Sequential, Size = 0x14)]
        public struct HeightMap
        {
            uint HeightFormat;
            float MaxHeightWS;
            float MinHeightWS;
            uint HeightMapOffset;
            uint HeightMapSize;
        };

        [StructLayout(LayoutKind.Sequential, Size = 0x1C)]
        public struct PatchConfigration
        {
            ulong BaseOffset;
            uint MaterialIdsOffset;
            uint ConfigrationIdsOffset;
            uint MaxHeightOffset;
            uint MinHeightOffset;
            uint ParamOffset;
        };
    }
}