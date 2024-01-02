using Fox.Core;
using Fox.Gr.Terrain;
using System;

namespace Fox.Gr
{
    public partial class TerrainTileFile
    {
        public static bool TryDeserialize(TerrainTileAsset asset, ReadOnlySpan<byte> data)
        {
            return Terrain.TerrainTileAsset.TryReadTerrainFile(asset, data, FileType.HTRE);
        }
    }
}
