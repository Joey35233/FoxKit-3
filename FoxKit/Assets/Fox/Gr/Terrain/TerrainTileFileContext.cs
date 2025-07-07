using Fox.Core;
using Fox.Gr.Terrain;
using System;

namespace Fox.Gr
{
    public unsafe class TerrainTileFileContext
    {
        public MappedData MappedData;
        
        public bool TryDeserialize(byte* data, uint dataSize)
        {
            TerrainFileReader.DeserializationDescription desc = new TerrainFileReader.DeserializationDescription
            {
                Type = TerrainFileReader.FileType.Patch
            };
            
            return TerrainFileReader.TryReadTerrainFile(ref MappedData, data, dataSize, desc);
        }
    }
}
