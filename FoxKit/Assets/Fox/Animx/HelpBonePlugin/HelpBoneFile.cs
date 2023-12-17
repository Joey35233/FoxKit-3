using Fox.Kernel;
using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Fox.Animx
{
    public partial class HelpBoneFile : Fox.Core.RawFile
    {
        [StructLayout(LayoutKind.Sequential, Size = 16)]
        private struct FrdvHeader
        {
            public uint Signature;

            public uint Version;

            public uint EntryCount;
        };

        [StructLayout(LayoutKind.Sequential)]
        private struct DriverUnit
        {
            public DriverUnitAction Type;

            public short TargetSkelIndex;
            public short SourceSkelIndex;
            public short SourceSkelIndex2;
            public short TargetParentSkelIndex;
            public short SourceParentSkelIndex;
            public short SourceParentSkelIndex2;

            public float Weight;
            public float Offset;
            public float LimitMin;
            public float LimitMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DriverUnitParamsMultiAxis
        {
            public DriverLimitAxis Axis;
            public float WeightB;
            public float OffsetB;
            public float LimitMinB;

            public float LimitMaxB;
            public DriverLimitAxis AxisB;
            public bool Type14Bool;

            public DriverType14Enum Type14Enum;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DriverUnitParamsMaterial
        {
            public StrCode32 MaterialNameA;
            private uint Padding0;
            private uint Padding1;
            public StrCode32 MaterialNameC;
            public StrCode32 MaterialParameterC;
            public StrCode32 MaterialNameB;
            public StrCode32 MaterialParameterA;
            public StrCode32 MaterialParameterB;
        }

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
                            ReadUnit(ref driver.data, unit, firstMeshRenderer.bones);
                    }
                }
            }
        }

        private static unsafe void ReadUnit(ref RigDriverData driver, DriverUnit* unit, Transform[] bones)
        {
            driver.Type = unit->Type;
            driver.Target = GetBoneByIndex(bones, unit->TargetSkelIndex);
            driver.Source = GetBoneByIndex(bones, unit->SourceSkelIndex);
            driver.Source2 = GetBoneByIndex(bones, unit->SourceSkelIndex2);
            driver.TargetParent = GetBoneByIndex(bones, unit->TargetParentSkelIndex);
            driver.SourceParent = GetBoneByIndex(bones, unit->SourceParentSkelIndex);
            driver.Source2Parent = GetBoneByIndex(bones, unit->SourceParentSkelIndex2);

            driver.Weight = unit->Weight;
            driver.Offset = unit->Offset;
            driver.LimitMin = unit->LimitMin;
            driver.LimitMax = unit->LimitMax;

            if (unit->Type < DriverUnitAction.Type19)
            {
                var multiAxisParam = (DriverUnitParamsMultiAxis*)(unit + 1);

                driver.Axis = multiAxisParam->Axis;
                driver.WeightB = multiAxisParam->WeightB;
                driver.OffsetB = multiAxisParam->OffsetB;
                driver.LimitMinB = multiAxisParam->LimitMinB;
                driver.LimitMaxB = multiAxisParam->LimitMaxB;
                driver.AxisB = multiAxisParam->AxisB;
                driver.Type14Bool = multiAxisParam->Type14Bool;
            }
            else
            {
                var materialParam = (DriverUnitParamsMaterial*)(unit + 1);

                driver.MaterialNameA = new String(materialParam->MaterialNameA.ToString());
                driver.MaterialNameC = new String(materialParam->MaterialNameC.ToString());
                driver.MaterialParameterC = new String(materialParam->MaterialParameterC.ToString());
                driver.MaterialNameB = new String(materialParam->MaterialNameB.ToString());
                driver.MaterialParameterA = new String(materialParam->MaterialParameterA.ToString());
                driver.MaterialParameterB = new String(materialParam->MaterialParameterB.ToString());
            }

            var vectors = (Vector4*)((byte*)(unit + 1) + sizeof(DriverUnitParamsMultiAxis));
            driver.VectorA = vectors[0];
            driver.VectorB = vectors[1];
            driver.VectorC = vectors[2];
            driver.VectorD = vectors[3];
        }

        private static Transform GetBoneByIndex(Transform[] bones, short skelIndex) =>
            (skelIndex > -1 && skelIndex < bones.Length) ? bones[skelIndex] : null;
    }
}
