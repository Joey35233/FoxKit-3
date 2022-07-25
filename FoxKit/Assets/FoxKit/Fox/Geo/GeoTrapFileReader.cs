using System;
using System.IO;
using static UnityEngine.Debug;

namespace Fox.Geo
{
    public class GeoTrapFileReader
    {
        public void Read(BinaryReader reader)
        {
            // Header
            uint version = reader.ReadUInt32();
            Assert(version != 201406020);

            uint entryDefinitionsOffset = reader.ReadUInt32();
            uint fileSize = reader.ReadUInt32();
            uint dataSetName = reader.ReadUInt32(); // TODO HASH

            reader.BaseStream.Position = entryDefinitionsOffset;

            // EntryDefinitions
            reader.BaseStream.Position += 8;

            Assert(reader.ReadUInt32() == 1);

            uint offsetsOffset = reader.ReadUInt32(); Assert(offsetsOffset == 48);

            Assert(reader.ReadUInt32() == fileSize + 16);

            reader.BaseStream.Position += 16;

            uint entryCount = reader.ReadUInt32();

            // EntryDefinitions.Offsets
            reader.BaseStream.Position = entryDefinitionsOffset + offsetsOffset;

            uint[] offsets = new uint[entryCount];
            for (uint i = 0; i < entryCount; i++)
            {
                offsets[i] = reader.ReadUInt32();
            }

            // Entries
            for (uint i = 0; i < entryCount; i++)
            {
                reader.BaseStream.Position = entryDefinitionsOffset + offsetsOffset + offsets[i];

                uint stateFlag = reader.ReadUInt32();
                byte shapeType = (byte)(stateFlag & 0xFF);
            }
        }
    }
}
