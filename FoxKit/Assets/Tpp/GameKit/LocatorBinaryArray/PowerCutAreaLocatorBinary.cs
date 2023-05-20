using System;
using UnityEngine;

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
        public UnityEngine.Vector4 GetTranslation() => translation;

        public UnityEngine.Quaternion GetRotation() => rotation;
    }
}