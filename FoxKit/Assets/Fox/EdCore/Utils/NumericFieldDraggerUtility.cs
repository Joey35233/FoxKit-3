// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEngine;

namespace UnityEditor
{
    internal class NumericFieldDraggerUtility
    {
        internal static float Acceleration(bool shiftPressed, bool altPressed) => (shiftPressed ? 4 : 1) * (altPressed ? .25f : 1);

        private static bool s_UseYSign = false;

        internal static float NiceDelta(Vector2 deviceDelta, float acceleration)
        {
            deviceDelta.y = -deviceDelta.y;

            if (Mathf.Abs(Mathf.Abs(deviceDelta.x) - Mathf.Abs(deviceDelta.y)) / Mathf.Max(Mathf.Abs(deviceDelta.x), Mathf.Abs(deviceDelta.y)) > .1f)
            {
                s_UseYSign = Mathf.Abs(deviceDelta.x) <= Mathf.Abs(deviceDelta.y);
            }

            return s_UseYSign
                ? Mathf.Sign(deviceDelta.y) * deviceDelta.magnitude * acceleration
                : Mathf.Sign(deviceDelta.x) * deviceDelta.magnitude * acceleration;
        }

        private const float kDragSensitivity = .03f;

        internal static double CalculateFloatDragSensitivity(double value) => Double.IsInfinity(value) || Double.IsNaN(value) ? 0.0 : Math.Max(1, Math.Pow(Math.Abs(value), 0.5)) * kDragSensitivity;

        internal static long CalculateIntDragSensitivity(System.Numerics.BigInteger value) => (long)Math.Max(1, Math.Pow(Math.Abs((double)value), 0.5) * kDragSensitivity);
    }
}