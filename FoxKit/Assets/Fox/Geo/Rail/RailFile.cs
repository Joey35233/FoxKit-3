using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Geo
{
    public partial class RailFile
    {
        public const uint Signature = 0x4C494152; // RAIL

        public enum FormatVersion : ushort
        {
            V2 = 0x0002,

            V2_BE = 0x0200,
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x10)]
        public struct Header
        {
            public uint Signature;
            public FormatVersion Version;
            public ushort RailCount;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct RailDef
        {
            [FieldOffset(0x0)]
            public Vector3 Min;

            [FieldOffset(0x10)]
            public Vector3 Max;

            [FieldOffset(0x20)]
            public uint VerticesOffset;
            
            [FieldOffset(0x24)]
            public uint NotesOffset;
            
            [FieldOffset(0x28)]
            public uint ExtensionsOffset;
            
            [FieldOffset(0x2c)]
            public ushort VertexCount;
            
            [FieldOffset(0x2e)]
            public ushort NoteCount;
        }

        // Cubic Hermite spline control point.
        [StructLayout(LayoutKind.Sequential)]
        public struct RailVertex
        {
            public Vector3 Position;
            public float ArcLength;
            public Vector3 Tangent;
            public float TangentLength;
        }

        public enum RailNoteType : byte
        {
            None = 0,
            Start = 1,
            End = 2,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RailNote
        {
            public float Position;
            public ushort ExtensionStartIndex;
            public byte Id;
            public RailNoteType Type;
        }
    }
}
