using System;
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

    [StructLayout(LayoutKind.Sequential)]
    public struct DriverUnit
    {
        DriverUnitAction Type;

        short TargetSkelIndex;
        short SourceSkelIndex;
        short SourceSkelIndex2;
        short TargetParentIndex;
        short SourceParentSkelIndex;
        short SourceParentSkelIndex2;
    }

    public class RigDriver : MonoBehaviour
    {
        public static unsafe RigDriver Deserialize(DriverUnit* unit, Transform[] bones)
        {
            return null;
        }
    }
}