using UnityEngine;
using System;

namespace Tpp.GameKit
{
    [Serializable]
    public sealed class PowerCutAreaLocatorBinary
    {
        [SerializeField]
        private Vector4 translation;

        [SerializeField]
        private Quaternion rotation;

        public PowerCutAreaLocatorBinary(Vector4 translation, Quaternion rotation)
        {
            this.translation = translation;
            this.rotation = rotation;
        }

        public PowerCutAreaLocatorBinary()
        {   
        }
    }
}