using Fox.Kernel;
using System;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Tpp.GameKit
{
    [Serializable]
    public sealed class NamedLocatorBinary
    {
        [SerializeField]
        private UnityEngine.Vector4 translation;

        [SerializeField]
        private UnityEngine.Quaternion rotation;

        [SerializeField]
        private String locatorName;

        [SerializeField]
        private Path dataSetName;

        public NamedLocatorBinary(UnityEngine.Vector4 translation, UnityEngine.Quaternion rotation, String locatorName, Path dataSetName)
        {
            this.translation = translation;
            this.rotation = rotation;
            this.locatorName = locatorName;
            this.dataSetName = dataSetName;
        }

        public NamedLocatorBinary()
        {
        }

        public UnityEngine.Vector4 GetTranslation() => translation;

        public UnityEngine.Quaternion GetRotation() => rotation;

        public String GetLocatorName() => locatorName;

        public Path GetDataSetName() => dataSetName;
    }
}