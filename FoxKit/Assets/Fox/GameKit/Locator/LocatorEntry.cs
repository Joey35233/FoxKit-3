using Fox;
using UnityEngine;

namespace Fox.GameKit
{
    [System.Serializable]
    public struct LocatorEntry
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;

        public string Name;
        public string DataSetPath;
    }
}