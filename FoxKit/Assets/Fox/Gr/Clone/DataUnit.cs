using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Gr
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
    public struct DataUnit
    {
        public float PositionY;
        public short PositionX;
        public short PositionZ;
            
        public Half RotationX;
        public Half RotationY;
        public Half RotationZ;
        public Half RotationW;
        
        public ushort BlockId;
        public byte PluginIndex;

        public byte NormalizedScale;
        
        public uint GlobalIndex;
    }
}