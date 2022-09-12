using System.IO;
using System.Text;
using Fox.Kernel;
using UnityEngine;

namespace Fox.Fio
{
    public static class BinaryReaderExtensions
    {
        public static StrCode ReadStrCode(this BinaryReader reader)
        {
            return HashingBitConverter.ToStrCode(reader.ReadUInt64());
        }

        public static StrCode32 ReadStrCode32(this BinaryReader reader)
        {
            return HashingBitConverter.ToStrCode32(reader.ReadUInt32());
        }

        public static string ReadNullTerminatedString(this BinaryReader reader)
        {
            int charCount = 0;
            while (reader.ReadChar() != 0x00)
                charCount++;

            return new string(reader.ReadChars(charCount));
        }

        public static Vector3 ReadVector3(this BinaryReader reader)
        {
            return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
        public static Vector3 ReadPositionF(this BinaryReader reader) => Math.FoxToUnityVector3(ReadVector3(reader));

        public static Vector3 ReadWideVector3(this BinaryReader reader)
        {
            Vector3 result = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

            Debug.Assert(reader.ReadUInt32() == 0, "Invalid WideVector3.");

            return result;
        }
        public static Vector3 ReadWidePositionF(this BinaryReader reader) => Math.FoxToUnityVector3(ReadWideVector3(reader));

        public static Vector4 ReadVector4(this BinaryReader reader)
        {
            return new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        public static Quaternion ReadQuaternion(this BinaryReader reader)
        {
            return new Quaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
        public static Quaternion ReadRotationF(this BinaryReader reader) => Math.FoxToUnityQuaternion(ReadQuaternion(reader));
    }
}
