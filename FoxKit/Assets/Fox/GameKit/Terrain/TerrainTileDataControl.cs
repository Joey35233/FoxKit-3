using UnityEngine;

namespace Fox.GameKit
{
    public struct TerrainTileDataControl
    {
        public float MinHeightWS;
        public float MaxHeightWS;

        public Texture2D HeightMap;

        public uint ComboFormat;
        public Texture2D ComboTexture;

        public TerrainTileMatMapControl MatMapControl;

        public uint MapChunkHeightWS;
        public uint MapChunkWidthWS;

        public ushort ExtraHighSizeWS;
        public ushort MaxLodLevel;
        public ushort LodCount;
    }
}
