using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

namespace Fox.Animx
{
    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    unsafe struct FrdvHeader
    {
        public fixed char Signature[4];

        public uint Version;

        public uint EntryCount;
    };

    public partial class HelpBoneFile : Fox.Core.RawFile
    {
        public void Read(ReadOnlySpan<byte> data)
        {
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

            unsafe
            {
                fixed (byte* dataPtr = data)
                {
                    var header = (FrdvHeader*)dataPtr;
                    Debug.Assert(header->Version == 2830171915);

                    uint* offsets = (uint*)(dataPtr + sizeof(FrdvHeader));

                    for (uint i = 0; i < header->EntryCount; i++)
                    {
                        var unit = (DriverUnit*)(dataPtr + offsets[i]);

                        var driver = RigDriver.Deserialize(unit, firstMeshRenderer.bones);
                        driver.name = $"RigDriver{i:D4}";

                        var unitParams = (DriverUnitParams*)(dataPtr + offsets[i] + sizeof(DriverUnit));
                        RigDriver.DeserializeParam(driver, unitParams);
                        if (unit->Type < DriverUnitAction.DriverUnitAction19)
                        {
                            var unitHelper = (DriverUnitHelper*)(dataPtr + offsets[i] + sizeof(DriverUnit) + sizeof(DriverUnitParams));
                            RigDriver.DeserializeHelper(driver, unitHelper);
                        }
                        else
                        {
                            var unitMaterial = (DriverUnitMaterial*)(dataPtr + offsets[i] + sizeof(DriverUnit) + sizeof(DriverUnitParams));
                            RigDriver.DeserializeMaterial(driver, unitMaterial);
                        }
                        var unitVectors = (DriverUnitVectors*)(dataPtr + offsets[i] + sizeof(DriverUnit) + 0x30);
                        RigDriver.DeserializeVectors(driver, unitVectors);
                    }
                }
            }
        }
    }
}
