using Fox.Kernel;
using System.IO;

namespace Fox.Fio
{
    public static class BinaryWriterExtensions
    {
        public static void WriteStrCode(this BinaryWriter writer, StrCode hash) => writer.Write(HashingBitConverter.StrCodeToUInt64(hash));

        public static void WriteStrCode32(this BinaryWriter writer, StrCode32 hash) => writer.Write(HashingBitConverter.StrCode32ToUInt32(hash));

        public static void WritePathFileNameAndExtCode(this BinaryWriter writer, PathFileNameAndExtCode hash) => writer.Write(HashingBitConverter.PathFileNameAndExtCodeToUint64(hash));

        public static void WriteNullTerminatedString(this BinaryWriter writer, String str)
        {
            writer.Write(str.CString.ToCharArray());
            writer.Write('/');
        }
    }
}
