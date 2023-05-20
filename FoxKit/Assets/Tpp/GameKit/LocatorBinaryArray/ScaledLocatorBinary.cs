using Fox.Kernel;
using System;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Tpp.GameKit
{
    [Serializable]
    public sealed class ScaledLocatorBinary
    {
        [SerializeField]
        private UnityEngine.Vector4 translation;

        [SerializeField]
        private UnityEngine.Quaternion rotation;

        [SerializeField]
        private UnityEngine.Vector3 scale;

        [SerializeField]
        private short a;

        [SerializeField]
        private short b;

        [SerializeField]
        private String locatorName;

        [SerializeField]
        private Path dataSetName;

        public ScaledLocatorBinary(UnityEngine.Vector4 translation, UnityEngine.Quaternion rotation, UnityEngine.Vector3 scale, short a, short b, String locatorName, Path dataSetName)
        {
            this.translation = translation;
            this.rotation = rotation;
            this.scale = scale;
            this.a = a;
            this.b = b;
            this.locatorName = locatorName;
            this.dataSetName = dataSetName;
        }

        public ScaledLocatorBinary()
        {

        }

        public UnityEngine.Vector4 GetTranslation() => translation;

        public UnityEngine.Quaternion GetRotation() => rotation;

        public UnityEngine.Vector3 GetScale() => scale;

        public String GetLocatorName() => locatorName;

        public Path GetDataSetName() => dataSetName;
    }
}