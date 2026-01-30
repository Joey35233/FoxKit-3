using System;
using UnityEngine;

namespace Fox.GameKit
{
    [Serializable]
    public struct ObjectBrushObject
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public float NormalizedScale;

        public string Plugin;
    };
    
    public class ObjectBrushAsset : ScriptableObject
    {
        public float BlockSizeW;
        public float BlockSizeH;
        public uint NumBlocksW;
        public uint NumBlocksH;

        public ObjectBrushObject[] Objects;
    }
}
