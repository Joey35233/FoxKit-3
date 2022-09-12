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
        public enum Endianess
        {
            LittleEndian,
            BigEndian
        }

        private const int LittleEndianConstant = 0x0000454C; // LE
        private const int BigEndianConstant = 0x00004542; // BE

        public List<LangFileEntry> Read(Stream inputStream, Dictionary<uint, string> langIdDictionary)
        {
            BinaryReader headerReader = new BinaryReader(inputStream, Encoding.UTF8, true);
            BinaryReader reader;

            int magicNumber = headerReader.ReadInt32();
            int version = headerReader.ReadInt32(); // GZ 2, TPP 3
            int endianess = headerReader.ReadInt32(); // LE, BE
            switch (endianess)
            {
                case LittleEndianConstant: // LE
                    reader = headerReader;
                    break;
                case BigEndianConstant: // BE
                    version = EndianessBitConverter.FlipEndianess(version);
                    reader = new BigEndianBinaryReader(inputStream, Encoding.UTF8, true);
                    break;
                default:
                    Debug.LogError(string.Format("Unknown endianess: {0:X}", endianess));
                    return null;
            }

            int entryCount = reader.ReadInt32();
            int valuesOffset = reader.ReadInt32();
            int keysOffset = reader.ReadInt32();

            inputStream.Position = valuesOffset;
            Dictionary<int, LangFileEntry> offsetEntryDictionary = new Dictionary<int, LangFileEntry>();
            for (int i = 0; i < entryCount; i++)
            {
                int valuePosition = (int)inputStream.Position - valuesOffset;
                short colorId = headerReader.ReadInt16();
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