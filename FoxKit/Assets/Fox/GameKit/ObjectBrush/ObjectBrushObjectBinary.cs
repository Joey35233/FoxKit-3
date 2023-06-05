using Fox.Fio;
using System;
using UnityEngine;

namespace Fox.GameKit
{
    [Serializable]
    public sealed class ObjectBrushObjectBinary
    {
        [SerializeField]
        private float yPosition;
        [SerializeField]
        private short xPosition;
        [SerializeField]
        private short zPosition;
        [SerializeField]
        private Quaternion rotation;
        [SerializeField]
        private ushort blockIndex;
        [SerializeField]
        private byte pluginBrushIndex;
        [SerializeField]
        private byte normalizedScale;
        [SerializeField]
        private uint globalObjectIndex;

        public ObjectBrushObjectBinary(float yPosition, short xPosition, short zPosition,
            Quaternion rotation, ushort blockIndex, byte pluginBrushIndex, byte normalizedScale,
            uint globalObjectIndex)
        {
            this.yPosition = yPosition;
            this.xPosition = xPosition;
            this.zPosition = zPosition;
            this.rotation = rotation;
            this.blockIndex = blockIndex;
            this.pluginBrushIndex = pluginBrushIndex;
            this.normalizedScale = normalizedScale;
            this.globalObjectIndex = globalObjectIndex;
        }

        public ObjectBrushObjectBinary()
        {
        }

        public float GetYPosition() => yPosition;
        public short GetXPosition() => xPosition;
        public short GetZPosition() => zPosition;
        public Quaternion GetRotation() => rotation;
        public ushort GetBlockIndex() => blockIndex;
        public byte GetPluginBrushIndex() => pluginBrushIndex;
        public byte GetNormalizedScale() => normalizedScale;
        public uint GetGlobalObjectIndex() => globalObjectIndex;

        public ObjectBrushObjectBinary(FileStreamReader reader)
        {
            yPosition = reader.ReadSingle();
            xPosition = reader.ReadInt16();
            zPosition = reader.ReadInt16();
            rotation = new UnityEngine.Quaternion(
                reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            blockIndex = reader.ReadUInt16();
            pluginBrushIndex = reader.ReadByte();
            normalizedScale = reader.ReadByte();
            globalObjectIndex = reader.ReadUInt32();
        }
    }
}
