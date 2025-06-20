using Fox.Core;
using System;
using Fox.Gr.Terrain;
using UnityEngine;

namespace Fox.Gr
{
    public partial class TerrainFile
    {
        private MappedData MappedData;
        
        public bool TryDeserialize(ReadOnlySpan<byte> data)
        {
            TerrainFileReader.DeserializationDescription desc = new TerrainFileReader.DeserializationDescription
            {
                Type = TerrainFileReader.FileType.BaseLayout
            };
            
            return TerrainFileReader.TryReadTerrainFile(ref MappedData, data, desc);
        }
    }
}
