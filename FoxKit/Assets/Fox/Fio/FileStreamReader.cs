using Fox.Kernel;
using UnityEngine;

namespace Fox.Fio
{
    public class FileStreamReader : System.IO.BinaryReader
    {
        public Endianness StreamEndianness;

        public FileStreamReader(System.IO.Stream input, System.Text.Encoding encoding, bool leaveOpen = false, Endianness endianness = Endianness.LittleEndian) : base(input, encoding, leaveOpen)
        {
            StreamEndianness = endianness;
        }
        public FileStreamReader(System.IO.Stream input, bool leaveOpen = false, Endianness endianness = Endianness.LittleEndian) : this(input, System.Text.Encoding.ASCII, leaveOpen, endianness)
        {
        }

        public override short ReadInt16() => StreamEndianness == Endianness.LittleEndian ? base.ReadInt16() : EndiannessBitConverter.FlipEndianness(base.ReadInt16());
        public override ushort ReadUInt16() => StreamEndianness == Endianness.LittleEndian ? base.ReadUInt16() : EndiannessBitConverter.FlipEndianness(base.ReadUInt16());
        public override int ReadInt32() => StreamEndianness == Endianness.LittleEndian ? base.ReadInt32() : EndiannessBitConverter.FlipEndianness(base.ReadInt32());
        public override uint ReadUInt32() => StreamEndianness == Endianness.LittleEndian ? base.ReadUInt32() : EndiannessBitConverter.FlipEndianness(base.ReadUInt32());
        public override long ReadInt64() => StreamEndianness == Endianness.LittleEndian ? base.ReadInt64() : EndiannessBitConverter.FlipEndianness(base.ReadInt64());
        public override ulong ReadUInt64() => StreamEndianness == Endianness.LittleEndian ? base.ReadUInt64() : EndiannessBitConverter.FlipEndianness(base.ReadUInt64());

        public System.Half ReadHalf() => StreamEndianness == Endianness.LittleEndian ? System.Half.ToHalf(base.ReadUInt16()) : System.Half.ToHalf(EndiannessBitConverter.FlipEndianness(base.ReadUInt16()));
        public override float ReadSingle() => StreamEndianness == Endianness.LittleEndian ? base.ReadSingle() : EndiannessBitConverter.FlipEndianness(base.ReadSingle());
        public override double ReadDouble() => StreamEndianness == Endianness.LittleEndian ? base.ReadDouble() : EndiannessBitConverter.FlipEndianness(base.ReadDouble());

        public StrCode ReadStrCode()
        {
            return HashingBitConverter.ToStrCode(ReadUInt64());
        }

        public StrCode32 ReadStrCode32()
        {
            return HashingBitConverter.ToStrCode32(ReadUInt32());
        }

        public String ReadNullTerminatedString()
        {
            return new String(ReadNullTerminatedCString());
        }

        public string ReadNullTerminatedCString()
        {
            long position = BaseStream.Position;

            int count = 0;
            while (PeekChar() != '\0') 
            {
                count++;
                BaseStream.Position++;
            }
            BaseStream.Position = position;
            return new string(ReadChars(count));
        }

        public Vector3 ReadVector3()
        {
            return new Vector3(ReadSingle(), ReadSingle(), ReadSingle());
        }
        public Vector3 ReadPositionF() => Math.FoxToUnityVector3(ReadVector3());
        public Vector3 ReadPositionHF()
        {
            Vector4 positionHF = ReadVector4();
            Debug.Assert(positionHF.w == 1, "W component of position in homogenous coordinates is not 1.");
            return Math.FoxToUnityVector3((Vector3)positionHF);
        }
        public Vector3 ReadScaleHF()
        {
            Vector4 scaleHF = ReadVector4();
            Debug.Assert(scaleHF.w == 0, "W component of scale in homogenous coordinates is not 0.");
            return scaleHF;
        }

        public Vector3 ReadWideVector3()
        {
            Vector3 result = new Vector3(ReadSingle(), ReadSingle(), ReadSingle());

            Debug.Assert(ReadUInt32() == 0, "W component of WideVector3 is not 0.");

            return result;
        }
        //public Vector3 ReadWidePositionF() => Math.FoxToUnityVector3(ReadWideVector3());

        public Vector4 ReadVector4()
        {
            return new Vector4(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
        }

        public Quaternion ReadQuaternion()
        {
            return new Quaternion(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
        }
        public Quaternion ReadRotationF() => Math.FoxToUnityQuaternion(ReadQuaternion());

        public Color ReadColor()
        {
            return new Color(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
        }

        public Matrix4x4 ReadMatrix4()
        {
            return new Matrix4x4(ReadVector4(), ReadVector4(), ReadVector4(), ReadVector4());
        }
        public Matrix4x4 ReadMatrix4F() => Math.FoxToUnityMatrix(ReadMatrix4());

        public void Skip(long count)
        {
            BaseStream.Seek(count, System.IO.SeekOrigin.Current);
        }

        public void Seek(long count)
        {
            BaseStream.Seek(count, System.IO.SeekOrigin.Begin);
        }

        public void Align(uint alignment)
        {
            BaseStream.Position = (BaseStream.Position + (alignment - 1)) & (-alignment);
        }
    }
}