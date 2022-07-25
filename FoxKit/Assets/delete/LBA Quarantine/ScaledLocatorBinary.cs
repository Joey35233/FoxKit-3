using Fox.FoxKernel;
using String = Fox.FoxKernel.String;

namespace Fox
{
    using System;
    using UnityEngine;

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

        // FIXME: This should be a Path
        [SerializeField]
        private String dataSetName;

        public ScaledLocatorBinary(UnityEngine.Vector4 translation, UnityEngine.Quaternion rotation, UnityEngine.Vector3 scale, short a, short b, String locatorName, String dataSetName)
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
    }
}