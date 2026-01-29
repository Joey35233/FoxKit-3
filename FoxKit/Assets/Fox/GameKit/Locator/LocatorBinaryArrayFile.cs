using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.GameKit
{
    public class LocatorBinaryArrayFile
    {
        [Flags]
        public enum LocatorBinaryFlags : uint
        {
            UseScale = 1 << 0,
            UseIds = 1 << 1,
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
        public struct LocatorBinaryHeader
        {
            public uint LocatorCount;
            public LocatorBinaryFlags Flags;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 32)]
        public struct LocatorBinary
        {
            public Vector3 Position;
            private uint Padding0;
            
            public Quaternion Rotation;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 48)]
        public struct LocatorBinaryScaled
        {
            public Vector3 Position;
            private uint Padding0;
            
            public Quaternion Rotation;
            
            public Vector3 Scale;
            private uint Padding1;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
        public struct LocatorBinaryId
        {
            public StrCode32 Name;
            public StrCode32 DataSetName;
        }

        public static unsafe LocatorEntry[] Convert(byte[] file)
        {
            LocatorEntry[] locators = null;
            
            fixed (byte* data = file)
            {
                LocatorBinaryHeader* header = (LocatorBinaryHeader*)data;

                locators = new LocatorEntry[header->LocatorCount];

                LocatorBinaryId* ids = (LocatorBinaryId*)header;
                if (!header->Flags.HasFlag(LocatorBinaryFlags.UseScale))
                {
                    LocatorBinary* binaryLocators = (LocatorBinary*)(header + 1); 
                    for (uint i = 0; i < header->LocatorCount; i++)
                    {
                        LocatorBinary entryBinary = binaryLocators[i];

                        locators[i] = new LocatorEntry
                        {
                            Position = Fox.Math.FoxToUnityVector3(entryBinary.Position),
                            Rotation = Fox.Math.FoxToUnityQuaternion(entryBinary.Rotation),
                            Scale = Vector3.one,
                        };
                    }

                    ids = (LocatorBinaryId*)(binaryLocators + header->LocatorCount);
                }
                else
                {
                    LocatorBinaryScaled* binaryLocators = (LocatorBinaryScaled*)(header + 1); 
                    for (uint i = 0; i < header->LocatorCount; i++)
                    {
                        LocatorBinaryScaled entryBinary = binaryLocators[i];

                        locators[i] = new LocatorEntry
                        {
                            Position = Fox.Math.FoxToUnityVector3(entryBinary.Position),
                            Rotation = Fox.Math.FoxToUnityQuaternion(entryBinary.Rotation),
                            Scale = entryBinary.Scale,
                        };
                    }
                    
                    ids = (LocatorBinaryId*)(binaryLocators + header->LocatorCount);
                }

                if (header->Flags.HasFlag(LocatorBinaryFlags.UseIds))
                {
                    for (uint i = 0; i < header->LocatorCount; i++)
                    {
                        LocatorBinaryId id = ids[i];

                        ref LocatorEntry locator = ref locators[i];
                        locator.Name = id.Name.ToString();
                        locator.DataSetPath = id.DataSetName.ToString();
                    }
                }
            }

            return locators;
        }
    }
}