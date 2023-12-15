using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Animx
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DriverUnit
    {

    }

    public class RigDriver : MonoBehaviour
    {
        public static unsafe RigDriver Deserialize(DriverUnit* unit)
        {
            return null;
        }
    }
}