using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

namespace Fox.Animx
{
    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    unsafe struct FrdvHeader
    {
        public uint Signature;

        public uint Version;

        public uint EntryCount;
    };

    public partial class HelpBoneFile : Fox.Core.RawFile
    {
        public static void Read(ReadOnlySpan<byte> data)
        {
            if (data.IsEmpty)
                return;

            if (Selection.transforms.Length < 1)
            {
                return;
            }
            else if (Selection.transforms.Length > 1)
            {
                Debug.LogWarning($"Multiple objects selected. Applying RigDrivers to first: {Selection.transforms[0].name}.");
            }

            UnityEngine.Transform target = Selection.transforms[0];
            SkinnedMeshRenderer firstMeshRenderer = target.GetComponentInChildren<SkinnedMeshRenderer>();

            GameObject rigObject = new ("RIG");
            rigObject.transform.SetParent(target);

            unsafe
            {
                fixed (byte* dataPtr = data)
                {
                    var header = (FrdvHeader*)dataPtr;
                    Debug.Assert(header->Version == 201306280);

                    uint* offsets = (uint*)(dataPtr + sizeof(FrdvHeader));

                    for (uint i = 0; i < header->EntryCount; i++)
                    {
                        uint offset = offsets[i];
                        if (offset == 0)
                            continue;

                        var unit = (DriverUnit*)(dataPtr + offsets[i]);

                        RigDriver driver = rigObject.AddComponent<RigDriver>();
                        if (driver != null)
                            RigDriver.Deserialize(driver, unit, firstMeshRenderer.bones);
                    }
                }
            }
        }
    }
}
