using UnityEngine;

namespace FoxKit.Gr.Terrain
{
    [CreateAssetMenu(menuName = "FoxKit/Terrain File")]
    public class TerrainFileAsset : ScriptableObject
    {
        public uint Width;
        public uint Height;
        public uint HighPerLow;
        public uint MaxLodLevel;
        public float GridDistance;
        public uint HeightFormat;
        public float HeighRangeMax;
        public float HeighRangeMin;
        public uint ComboFormat;
        public uint WidthWorldSpace;
        public uint HeightWorldSpace;
        public float MaxHeightWorldSpace;
        public float MinHeightWorldSpace;
        public float LayoutDescriptionGridDistance;
        public ushort LayoutDescriptionUnknown2;
        public ushort LayoutDescriptionUnknown3;
        public uint LayoutDescriptionUnknown4;
    }
}