using System.IO;
using System.Text;
using Fox.Kernel;

namespace Fox.Fs
{
    public static class BinaryReaderExtensions
    {
        public static StrCode ReadStrCode(this BinaryReader binaryReader)
        {
            return HashingBitConverter.ToStrCode(binaryReader.ReadUInt64());
        }

        public static StrCode32 ReadStrCode32(this BinaryReader binaryReader)
        {
            return HashingBitConverter.ToStrCode32(binaryReader.ReadUInt32());
        }

        public static void Skip(this BinaryReader reader, long count)
        {
            reader.BaseStream.Seek(count, SeekOrigin.Current);
        }

        public static void Seek(this BinaryReader reader, long count)
        {
            reader.BaseStream.Seek(count, SeekOrigin.Begin);
        }

        public static void AlignRead(this Stream input, int alignment)
        {
            long alignmentRequired = input.Position % alignment;
            if (alignmentRequired > 0)
                input.Position += alignment - alignmentRequired;
        }

        public static string ReadNullTerminatedString(this BinaryReader reader)
        {
            var builder = new StringBuilder();
            char nextCharacter;
            while ((nextCharacter = reader.ReadChar()) != 0x00)
            {
                builder.Append(nextCharacter);
            }
            return builder.ToString();
        }
    }
}
