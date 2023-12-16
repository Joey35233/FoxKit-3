using Fox.Kernel;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Animx
{
    public enum DriverUnitAction : short
    {
        TypeInvalid = -1,
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
        Type4 = 4,
        Type5 = 5,
        Type6 = 6,
        Type7 = 7,
        Type8 = 8,
        Type9 = 9,
        Type10 = 10,
        Type11 = 11,
        Type12 = 12,
        Type13 = 13,
        Type14 = 14,
        Type15 = 15,
        Type16 = 16,
        Type17 = 17,
        Type18 = 18,
        Type19 = 19,
        Type20 = 20,
        Type21 = 21,
        Type22 = 22,
        Type23 = 23,
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
    public struct DriverUnit
    {
        public DriverUnitAction Type;

        public short TargetSkelIndex;
        public short SourceSkelIndex;
        public short SourceSkelIndex2;
        public short TargetParentIndex;
        public short SourceParentSkelIndex;
        public short SourceParentSkelIndex2;

        public float Weight;
        public float Offset;
        public float LimitMin;
        public float LimitMax;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DriverUnitParamsMultiAxis
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
    public struct DriverUnitParamsMaterial
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

    public class RigDriver : MonoBehaviour
    {
        public DriverUnitAction Type;

        public Transform Target;

        public Transform Source;
        public Transform SourceParent;

        public Transform Source2;
        public Transform Source2Parent;

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

        public String MaterialNameA;

        public String MaterialNameC;
        public String MaterialParameterC;
        public String MaterialNameB;
        public String MaterialParameterA;
        public String MaterialParameterB;

        public Vector3 VectorA;
        public Vector3 VectorB;
        public Vector3 VectorC;
        public Vector3 VectorD;

        public static unsafe RigDriver Deserialize(RigDriver driver, DriverUnit* unit, Transform[] bones)
        {
            driver.Type = unit->Type;
            driver.Target = GetBoneByIndex(bones, unit->TargetSkelIndex);
            driver.Source = GetBoneByIndex(bones, unit->SourceSkelIndex);
            driver.SourceParent = GetBoneByIndex(bones, unit->SourceParentSkelIndex);
            driver.Source2 = GetBoneByIndex(bones, unit->SourceSkelIndex2);
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

            return driver;
        }

        private static Transform GetBoneByIndex(Transform[] bones, short skelIndex) =>
            (skelIndex > 0 && skelIndex < bones.Length) ? bones[skelIndex] : null;
    }
}