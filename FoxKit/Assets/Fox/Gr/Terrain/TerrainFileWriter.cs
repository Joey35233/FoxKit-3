using Fox.Gr;
using System.IO;

public class TerrainFileWriter
{
    private BinaryWriter writer;
    private TerrainFileAsset terrain;

    internal void Write(BinaryWriter binWriter, TerrainFileAsset terrain)
    {
        this.writer = binWriter;
        this.terrain = terrain;

        WriteHeader();
    }

    private void WriteHeader()
    {
        writer.Write((int)4);
        writer.Write((int)32);
        writer.Write((int)1049512);
        writer.Write(1840366096);
        writer.Write(1049268);
        writer.Write(0);
    }
}
