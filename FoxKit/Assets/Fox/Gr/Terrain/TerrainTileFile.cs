using Fox.Core;
using Fox.Gr.Terrain;
using System;

namespace Fox.Gr
{
    public partial class TerrainTileFile
    {
        private MappedData MappedData;
        
        public bool TryDeserialize(ReadOnlySpan<byte> data)
        {
            TerrainFileReader.DeserializationDescription desc = new TerrainFileReader.DeserializationDescription
            {
                Type = TerrainFileReader.FileType.Patch
            };
            
            return TerrainFileReader.TryReadTerrainFile(ref MappedData, data, desc);
        }
    }
}
