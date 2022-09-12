using System.IO;
using System.Text;
using Fox.Kernel;

namespace Fox.Fio
{
    public static class StreamExtensions
    {
        public static void Skip(this Stream stream, long count)
        {
            stream.Seek(count, SeekOrigin.Current);
        }

        public static void Seek(this Stream stream, long count)
        {
            stream.Seek(count, SeekOrigin.Begin);
        }

        public static void Align(this Stream input, int alignment)
        {
            long alignmentRequired = input.Position % alignment;
            if (alignmentRequired > 0)
                input.Position += alignment - alignmentRequired;
        }
    }
}
