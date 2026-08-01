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
            public RouteAimTargetType AimTargetType;
            public RouteBodySectionType BodySectionType;
            public bool IsLoop;
            public ushort EncodedTime;
            public ushort EncodedDir;

            private const float DIR_DECODE = 2f * Mathf.PI / (UInt16.MaxValue + 1);
            private const float DIR_ENCODE = (UInt16.MaxValue + 1) / (360f);
            
            public Quaternion Dir
            {
                get => Quaternion.AngleAxis(EncodedDir * DIR_DECODE, Math.UnityToFoxVector3(Vector3.up));
                set => EncodedDir = (ushort)(value.eulerAngles.y * DIR_ENCODE);
            }

            public float Time
            {
                get => EncodedTime / KernelModule.NTSC_RATE;
                set => EncodedTime = (ushort)(value * KernelModule.NTSC_RATE);
            }

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
    }
}
