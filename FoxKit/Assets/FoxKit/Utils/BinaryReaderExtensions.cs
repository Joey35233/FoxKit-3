using System.IO;

namespace FoxKit.Utils
{
    internal static class BinaryReaderExtensions
    {
        public static void Skip(this BinaryReader reader, int count)
        {
            reader.BaseStream.Seek(count, SeekOrigin.Current);
        }

        public static void AlignRead(this Stream input, int alignment)
        {
            long alignmentRequired = input.Position % alignment;
            if (alignmentRequired > 0)
                input.Position += alignment - alignmentRequired;
        }
    }
}
