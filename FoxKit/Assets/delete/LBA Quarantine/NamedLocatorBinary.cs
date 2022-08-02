using System;
using Fox.Kernel;
using String = Fox.Kernel.String;
using UnityEngine;

namespace Fox
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

        // FIXME: This should be a Path
        [SerializeField]
        private String dataSetName;

        public NamedLocatorBinary(UnityEngine.Vector4 translation, UnityEngine.Quaternion rotation, String locatorName, String dataSetName)
        {
            this.translation = translation;
            this.rotation = rotation;
            this.locatorName = locatorName;
            this.dataSetName = dataSetName;
        }

        public NamedLocatorBinary()
        {
        }
    }
}