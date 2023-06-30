using Fox.Fio;
using Fox.Gr;
using System.Collections.Generic;
using System.IO;

enum FOX_DATA_NODE_ENTRY_PARAM_TYPE
{
    FOX_DATA_NODE_ENTRY_PARAM_TYPE_UINT = 0,
	FOX_DATA_NODE_ENTRY_PARAM_TYPE_STRING = 1,
	FOX_DATA_NODE_ENTRY_PARAM_TYPE_FLOAT = 2,
}

public class TerrainFileWriter
{
    private BinaryWriter writer;
    private TerrainFileAsset terrain;

    /// <summary>
    /// Offsets at which to write string table offsets
    /// </summary>
    private readonly Dictionary<Fox.Kernel.String, long> stringLiterals = new Dictionary<Fox.Kernel.String, long>();

    internal void Write(BinaryWriter binWriter, TerrainFileAsset terrain)
    {
        this.writer = binWriter;
        this.terrain = terrain;

        WriteHeader();
        _ = writer.Seek(32, SeekOrigin.Begin);
        WriteNodes();

        // TODO Write strings
    }

    private void WriteHeader()
    {
        writer.Write((int)4);
        writer.Write((int)32);
        writer.Write((int)1049512);
        WriteFoxDataString(new Fox.Kernel.String("tre2"));
        writer.Write(0);
    }

    private void WriteNodes()
    {
    }

    private void WriteNode(Fox.Kernel.String name)
    {
        WriteFoxDataString(name);
    }

    private void WriteFoxDataString(Fox.Kernel.String str)
    {
        writer.WriteStrCode32(str.Hash32);
        stringLiterals.Add(str, writer.BaseStream.Position);
        writer.Write(-1);
    }
}
