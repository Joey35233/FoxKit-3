using Fox;
using System.IO;

namespace Fox.Fio
{
    public static class BinaryWriterExtensions
    {
        public static void Write(this BinaryWriter writer, UnityEngine.Quaternion vec)
        {
            writer.Write(vec.x);
            writer.Write(vec.y);
            writer.Write(vec.z);
            writer.Write(vec.w);
        }

        public static void Write(this BinaryWriter writer, UnityEngine.Vector4 vec)
        {
            writer.Write(vec.x);
            writer.Write(vec.y);
            writer.Write(vec.z);
            writer.Write(vec.w);
        }

        public static void Write(this BinaryWriter writer, UnityEngine.Vector3 vec)
        {
            writer.Write(vec.x);
            writer.Write(vec.y);
            writer.Write(vec.z);
            writer.Write(0);
        }

        public static void Write(this BinaryWriter writer, UnityEngine.Matrix4x4 val)
        {
            writer.Write(val.GetColumn(0));
            writer.Write(val.GetColumn(1));
            writer.Write(val.GetColumn(2));
            writer.Write(val.GetColumn(3));
        }

        public static void WriteStrCode(this BinaryWriter writer, StrCode hash) => writer.Write(HashingBitConverter.StrCodeToUInt64(hash));

        public static void WriteStrCode32(this BinaryWriter writer, StrCode32 hash) => writer.Write(HashingBitConverter.StrCode32ToUInt32(hash));

        public static void WritePathFileNameAndExtCode(this BinaryWriter writer, PathCode hash) => writer.Write(HashingBitConverter.PathFileNameAndExtCodeToUInt64(hash));

        public static void WriteNullTerminatedString(this BinaryWriter writer, string str)
        {
            writer.Write(str.ToCharArray());
            writer.Write('\0');
        }

        public static void WriteZeros(this BinaryWriter writer, int count)
        {
            for (int i = 0; i < count; i++)
                writer.Write((byte)0);
        }

        public static void AlignWrite(this BinaryWriter output, int alignment, byte data)
        {
            long alignmentRequired = output.BaseStream.Position % alignment;
            if (alignmentRequired > 0)
                for (int i = 0; i < (int)(alignment - alignmentRequired); i++)
                    output.Write(data);
        }
    }
}
