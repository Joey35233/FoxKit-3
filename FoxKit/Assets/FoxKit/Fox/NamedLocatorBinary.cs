namespace Fox
{
    using System;
    using UnityEngine;

    [Serializable]
    public sealed class NamedLocatorBinary
    {
        [SerializeField]
        private UnityEngine.Vector4 translation;

        [SerializeField]
        private UnityEngine.Quaternion rotation;

        [SerializeField]
        private Fox.String locatorName;

        // FIXME: This should be a Path
        [SerializeField]
        private Fox.String dataSetName;

        public NamedLocatorBinary(UnityEngine.Vector4 translation, UnityEngine.Quaternion rotation, Fox.String locatorName, Fox.String dataSetName)
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