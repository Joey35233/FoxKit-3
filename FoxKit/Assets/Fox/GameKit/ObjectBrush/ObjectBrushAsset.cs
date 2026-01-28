using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public class ObjectBrushObject
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public float NormalizedScale;

        public ObjectBrushPlugin Plugin;
    };
    
    public class ObjectBrushAsset : ScriptableObject
    {
        public float BlockSizeW;
        public float BlockSizeH;
        public uint NumBlocksW;
        public uint NumBlocksH;
        
        public List<ObjectBrushObject> Objects = new();
    }

    public class ObjectBrushBlockAsset : ScriptableObject
    {
        public List<ObjectBrushObject> Objects = new();
    }
}
