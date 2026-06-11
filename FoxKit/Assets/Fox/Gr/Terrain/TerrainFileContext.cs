namespace Fox.Gr.Terrain
{
    public unsafe class TerrainFileContext
    {
        public MappedData MappedData;
        
        public bool TryDeserialize(byte* data, uint dataSize)
        {
            TerrainFileReader.DeserializationDescription desc = new TerrainFileReader.DeserializationDescription
            {
                Type = TerrainFileReader.FileType.BaseLayout
            };
            
            return TerrainFileReader.TryReadTerrainFile(ref MappedData, data, dataSize, desc);
        }
    }
}