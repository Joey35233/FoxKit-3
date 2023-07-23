using UnityEngine;

namespace Fox.Gr
{
    public class TerrainTileDataControl
    {
        float MinHeightWS;
        float MaxHeightWS;

        Texture2D HeightMap;

        uint ComboFormat;
        Texture2D ComboTexture;

        TerrainTileMatMapControl MatMapControl;

        uint MapChunkHeightWS;
        uint MapChunkWidthWS;

        ushort MaxLodLevel;
        ushort MaxLodCount;
    }
}
