using System.IO;
using System.Linq;

namespace Fox.Core
{
    public static class BinaryWriterUtils
    {
        public static void WriteZeros(this BinaryWriter writer, int count)
        {
            byte[] zeros = new byte[count];
            writer.Write(zeros);
        }

        public static void AlignWrite(this Stream output, int alignment, byte data)
        {
            long alignmentRequired = output.Position % alignment;
            if (alignmentRequired > 0)
            {
                byte[] alignmentBytes = Enumerable.Repeat(data, (int)(alignment - alignmentRequired)).ToArray();
                output.Write(alignmentBytes, 0, alignmentBytes.Length);
            }
        }
    }
}
