using Fox.Core;
using Fox.Gr.Terrain;
using System;

namespace Fox.Gr
{
    public partial class TerrainFile
    {
        public const uint CLUSTER_GRID_SIZE = 32;

        public static bool TryDeserialize(Terrain.TerrainTileAsset asset, ReadOnlySpan<byte> data)
        {
            return Terrain.TerrainTileAsset.TryReadTerrainFile(asset, data, FileType.TRE2);
        }
    }
}
