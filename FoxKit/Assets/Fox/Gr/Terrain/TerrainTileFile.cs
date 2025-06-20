using Fox.Core;
using Fox.Gr.Terrain;
using System;

namespace Fox.Gr
{
    public partial class TerrainTileFile
    {
        public static bool TryDeserialize(MappedData asset, ReadOnlySpan<byte> data)
        {
            return Terrain.MappedData.TryReadTerrainFile(asset, data, FileType.HTRE);
        }
    }
}
