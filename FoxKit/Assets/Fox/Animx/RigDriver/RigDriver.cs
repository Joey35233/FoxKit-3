using Fox.Kernel;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Animx
{
    public enum DriverUnitAction : short
    {
        DriverUnitActionInvalid = -1,
        DriverUnitAction1 = 1,
        DriverUnitAction2 = 2,
        DriverUnitAction3 = 3,
        DriverUnitAction4 = 4,
        DriverUnitAction5 = 5,
        DriverUnitAction6 = 6,
        DriverUnitAction7 = 7,
        DriverUnitAction8 = 8,
        DriverUnitAction9 = 9,
        DriverUnitAction10 = 10,
        DriverUnitAction11 = 11,
        DriverUnitAction12 = 12,
        DriverUnitAction13 = 13,
        DriverUnitAction14 = 14,
        DriverUnitAction15 = 15,
        DriverUnitAction16 = 16,
        DriverUnitAction17 = 17,
        DriverUnitAction18 = 18,
        DriverUnitAction19 = 19,
        DriverUnitAction20 = 20,
        DriverUnitAction21 = 21,
        DriverUnitAction22 = 22,
        DriverUnitAction23 = 23,
    };

    public enum DriverLimitAxis : uint
    {
        X=0,
        Y=1,
        Z=2,
    };

    public enum DriverType14Enum : uint
    {
        DriverType14Enum_0 = 0,
        DriverType14Enum_1 = 1,
        DriverType14Enum_2 = 2,
        DriverType14Enum_3 = 3,
        DriverType14Enum_4 = 4,
        DriverType14Enum_5 = 5,
    };

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DriverUnit
    {
        public readonly DriverUnitAction Type;

        public readonly short TargetSkelIndex;
        public readonly short SourceSkelIndex;
        public readonly short SourceSkelIndex2;
        public readonly short TargetParentIndex;
        public readonly short SourceParentSkelIndex;
        public readonly short SourceParentSkelIndex2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DriverUnitParams
    {
        public readonly float Weight;
        public readonly float Offset;
        public readonly float LimitMin;
        public readonly float LimitMax;
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DriverUnitHelper
    {
        public readonly DriverLimitAxis Axis;
        public readonly float WeightB;
        public readonly float OffsetB; //doesn't exist?
        public readonly float LimitMinB;

        public readonly float LimitMaxB;
        public readonly DriverLimitAxis AxisB;
        public readonly bool Type14Bool;
        private readonly byte Padding1;
        private readonly byte Padding2;
        private readonly byte Padding3;
        public readonly DriverType14Enum Type14Enum;
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DriverUnitMaterial
    {
        public readonly StrCode32 MaterialNameA;
        private readonly uint Padding0;
        private readonly uint Padding1;
        public readonly StrCode32 MaterialNameC;
        public readonly StrCode32 MaterialParameterC;
        public readonly StrCode32 MaterialNameB;
        public readonly StrCode32 MaterialParameterA;
        public readonly StrCode32 MaterialParameterB;
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DriverUnitVectors
    {
        public readonly Vector3 VectorA;
        private readonly uint Padding0;
        public readonly Vector3 VectorB;
        private readonly uint Padding1;
        public readonly Vector3 VectorC;
        private readonly uint Padding2;
        public readonly Vector3 VectorD;
        private readonly uint Padding3;
    }

    public class RigDriver : MonoBehaviour
    {
        public DriverUnitAction ActionType;

        public Transform Source;
        public Transform Source2;

        public float Weight;
        public float Offset;
        public float LimitMin;
        public float LimitMax;

        public DriverLimitAxis Axis;
        public float WeightB;
        public float OffsetB;
        public float LimitMinB;
        public float LimitMaxB;
        public DriverLimitAxis AxisB;
        public bool Type14Bool;
        public DriverType14Enum Type14Enum;

        public StrCode32 MaterialNameA;

        public StrCode32 MaterialNameC;
        public StrCode32 MaterialParameterC;
        public StrCode32 MaterialNameB;
        public StrCode32 MaterialParameterA;
        public StrCode32 MaterialParameterB;

        public Vector3 VectorA;
        public Vector3 VectorB;
        public Vector3 VectorC;
        public Vector3 VectorD;

        public static unsafe RigDriver Deserialize(DriverUnit* unit, Transform[] bones)
        {
            Transform target = GetBoneByIndex(bones, unit->TargetSkelIndex);
            if (target == null)
                return null;

            RigDriver targetComponent = target.gameObject.AddComponent<RigDriver>();

            Transform source = GetBoneByIndex(bones, unit->SourceSkelIndex);
            if (source != null)
                targetComponent.Source = source;

            Transform source2 = GetBoneByIndex(bones, unit->SourceSkelIndex2);
            if (source2 != null)
                targetComponent.Source2 = source2;

            return targetComponent;
        }

        public static unsafe void DeserializeParam(RigDriver driver, DriverUnitParams* unitParams)
        {
            driver.Weight = unitParams->Weight;
            driver.Offset = unitParams->Offset;
            driver.LimitMin = unitParams->LimitMin;
            driver.LimitMax = unitParams->LimitMax;
        }

        public static unsafe void DeserializeHelper(RigDriver driver, DriverUnitHelper* unitHelper)
        {
            driver.Axis = unitHelper->Axis;
            driver.WeightB = unitHelper->WeightB;
            driver.OffsetB = unitHelper->OffsetB;
            driver.LimitMinB = unitHelper->LimitMinB;
            driver.LimitMaxB = unitHelper->LimitMaxB;
            driver.AxisB = unitHelper->AxisB;
            driver.Type14Bool = unitHelper->Type14Bool;
            driver.Type14Enum = unitHelper->Type14Enum;
        }

        public static unsafe void DeserializeMaterial(RigDriver driver, DriverUnitMaterial* unitMaterial)
        {
            driver.MaterialNameA = unitMaterial->MaterialNameA;
            driver.MaterialNameC = unitMaterial->MaterialNameC;
            driver.MaterialParameterC = unitMaterial->MaterialParameterC;
            driver.MaterialNameB = unitMaterial->MaterialNameB;
            driver.MaterialParameterA = unitMaterial->MaterialParameterA;
            driver.MaterialParameterB = unitMaterial->MaterialParameterB;
        }

        public static unsafe void DeserializeVectors(RigDriver driver, DriverUnitVectors* unitVectors)
        {
            driver.VectorA = unitVectors->VectorA;
            driver.VectorB = unitVectors->VectorB;
            driver.VectorC = unitVectors->VectorC;
            driver.VectorD = unitVectors->VectorD;
        }

        private static Transform GetBoneByIndex(Transform[] bones, short skelIndex)
        {
            if (skelIndex > 0)
            {
                if (bones.Length <= skelIndex)
                    return bones[skelIndex];
            }
            return null;
        }
    }
}