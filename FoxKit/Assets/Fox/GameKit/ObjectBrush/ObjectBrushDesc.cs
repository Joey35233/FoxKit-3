using System;
using UnityEngine;

namespace Fox.GameKit
{
    public struct ObjectBrushObjectDesc
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public float NormalizedScale;

        public ObjectBrushPlugin Plugin;
    };
    
    public struct ObjectBrushDesc
    {
        public float BlockSizeW;
        public float BlockSizeH;
        public uint NumBlocksW;
        public uint NumBlocksH;

        public ObjectBrushObjectDesc[] Objects;
    }
}
