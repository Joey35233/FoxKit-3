using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.GameService
{
    internal static unsafe class RouteFile
    {
        public const uint Signature = 0x54554F52; // ROUT
        
        public enum FormatVersion : ushort
        {
            V2 = 0x0002,
            V3 = 0x0003,
            
            V2_BE = 0x0200,
            V3_BE = 0x0300,
        }
        
        // Hack to "preview" version before reading requisite header
        [StructLayout(LayoutKind.Sequential)]
        public struct BaseHeader
        {
            public uint Signature;
            public FormatVersion Version;
            public ushort RouteCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HeaderV2
        {
            // BaseHeader
            public uint Signature;
            public FormatVersion Version;
            public ushort RouteCount;

            public UnityEngine.Vector3 Origin;
            
            public uint RouteIdsOffset;
            public uint RouteDefinitionsOffset;
            public uint RouteNodesOffset;
            public uint RouteEventTablesOffset;
            public uint RouteEventsOffset;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0x10)]
        public struct HeaderV3
        {
            // BaseHeader
            public uint Signature;
            public FormatVersion Version;
            public ushort RouteCount;
            
            public uint RouteIdsOffset;
            public uint RouteDefinitionsOffset;
            public uint RouteNodesOffset;
            public uint RouteEventTablesOffset;
            public uint RouteEventsOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RouteDef
        {
            public uint VerticesOffset;
            public uint EventSpanOffset;
            public uint EventsOffset;
            public ushort NodeCount;
            public ushort EventCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EventSpan
        {
            public ushort Count;
            public ushort StartIndex;
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x30)]
        public struct EventDef
        {
            public StrCode32 Id;
            public RouteEventType Type;
            public GsRouteDataEventAimPoint_TargetType AimTargetType;
            public GsRouteDataEventAimPoint_BodySection AimBodySection;
            public bool IsLoop;
            public ushort EncodedTime;
            public ushort EncodedDir;

            private const float DIR_DECODE = 360f / (UInt16.MaxValue + 1);
            private const float DIR_ENCODE = (UInt16.MaxValue + 1) / 360f;
            
            public Quaternion GetFoxDirection() => Quaternion.AngleAxis(EncodedDir * DIR_DECODE, Vector3.up);
            
            public void SetFoxDirection(Quaternion foxDirection) => EncodedDir = (ushort)(Mathf.RoundToInt(foxDirection.eulerAngles.y * DIR_ENCODE) & 0xFFFF);

            public float GetTime() => EncodedTime / KernelModule.NTSC_RATE;

            public void SetTime(float time) => EncodedTime = (ushort)Mathf.Clamp(Mathf.RoundToInt(time * KernelModule.NTSC_RATE), 0, UInt16.MaxValue);

            public byte* GetAimPointData(FormatVersion version)
            {
                fixed (EventDef* selfPtr = &this)
                {
                    switch (version)
                    {
                        case FormatVersion.V2:
                        case FormatVersion.V2_BE:
                            return (byte*)selfPtr + 0x10;
                        case FormatVersion.V3:
                        case FormatVersion.V3_BE:
                            return (byte*)selfPtr + 0x0C;
                        default:
                            return null;
                    }
                }
            }

            public uint* GetExtensionData(FormatVersion version)
            {
                fixed (EventDef* selfPtr = &this)
                {
                    switch (version)
                    {
                        case FormatVersion.V2:
                        case FormatVersion.V2_BE:
                            return (uint*)((byte*)selfPtr + 0x20);
                        case FormatVersion.V3:
                        case FormatVersion.V3_BE:
                            return (uint*)((byte*)selfPtr + 0x1C);
                        default:
                            return null;
                    }
                }
            }
        }
        
        public static Vector3 UnpackVertexV2(ulong packedVertex)
        {
            // Unpack each component then sign-extend to full integer
            int x = (int)(packedVertex & 0x3FFFFF) << 10 >> 10;
            int y = (int)((packedVertex >> 22) & 0xFFFFF) << 12 >> 12;
            int z = (int)((packedVertex >> 42) & 0x3FFFFF) << 10 >> 10;

            return new Vector3(x, y, z) / 1024f;
        }
    }
}
