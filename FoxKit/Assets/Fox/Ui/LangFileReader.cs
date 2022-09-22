using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

using Fox.Fio;
using Fox.Kernel;

namespace Fox.Ui
{
    public class LangFileReader
    {
        private const int LittleEndianConstant = 0x0000454C; // LE
        private const int BigEndianConstant = 0x00004542; // BE

        public List<LangFileEntry> Read(Stream inputStream, Dictionary<uint, string> langIdDictionary)
        {
            using (FileStreamReader reader = new FileStreamReader(inputStream, Encoding.UTF8, false))
            {
                int magicNumber = reader.ReadInt32();
                int version = reader.ReadInt32(); // GZ 2, TPP 3
                int endianness = reader.ReadInt32(); // LE, BE
                reader.StreamEndianness =
                    endianness switch
                    {
                        LittleEndianConstant => Endianness.LittleEndian,
                        BigEndianConstant => Endianness.BigEndian,
                        _ => throw new System.Exception($"Unknown Endianness: {endianness:X}"),
                    };

                int entryCount = reader.ReadInt32();
                int valuesOffset = reader.ReadInt32();
                int keysOffset = reader.ReadInt32();

                inputStream.Position = valuesOffset;
                Dictionary<int, LangFileEntry> offsetEntryDictionary = new Dictionary<int, LangFileEntry>();
                for (int i = 0; i < entryCount; i++)
                {
                    int valuePosition = (int)inputStream.Position - valuesOffset;
                    short colorId = reader.ReadInt16();
                    string value = reader.ReadNullTerminatedString();
                    offsetEntryDictionary.Add(valuePosition, new LangFileEntry
                    {
                        Color = colorId,
                        Value = value
                    });
                }

                inputStream.Position = keysOffset;
                for (int i = 0; i < entryCount; i++)
                {
                    uint langIdCode = reader.ReadUInt32();
                    int offset = reader.ReadInt32();

                    if (langIdDictionary.TryGetValue(langIdCode, out string langId))
                    {
                        offsetEntryDictionary[offset].LangId = langId;
                    }

                    offsetEntryDictionary[offset].Key = langIdCode;
                }

                return offsetEntryDictionary.Values.ToList();
            }
        }
    }
}