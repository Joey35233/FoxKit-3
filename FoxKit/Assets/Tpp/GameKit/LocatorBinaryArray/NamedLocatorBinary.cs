using Fox;
using System;
using UnityEngine;

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
        private string locatorName;

        [SerializeField]
        private Path dataSetName;

        public NamedLocatorBinary(UnityEngine.Vector4 translation, UnityEngine.Quaternion rotation, string locatorName, Path dataSetName)
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

        public string GetLocatorName() => locatorName;

        public Path GetDataSetName() => dataSetName;
    }
}