using System;
using System.IO;
using System.Text;

namespace Fox.Fio
{
    public class BigEndianBinaryReader : BinaryReader
    {
        public BigEndianBinaryReader(Stream input) : base(input) { }

        public BigEndianBinaryReader(Stream input, Encoding encoding) : base(input, encoding) { }

        public BigEndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen) { }

        private byte[] Reverse(byte[] b)
        {
            Array.Reverse(b);
            return b;
        }

        private byte[] ReadBytesRequired(int byteCount)
        {
            byte[] result = ReadBytes(byteCount);

            return result.Length != byteCount
                ? throw new EndOfStreamException(string.Format("{0} bytes required from stream, but only {1} returned.",
                    byteCount, result.Length))
                : result;
        }

        public override decimal ReadDecimal()
        {
            byte[] buffer = Reverse(ReadBytesRequired(sizeof(decimal)));
            int i1 = BitConverter.ToInt32(buffer, 0);
            int i2 = BitConverter.ToInt32(buffer, 4);
            int i3 = BitConverter.ToInt32(buffer, 8);
            int i4 = BitConverter.ToInt32(buffer, 12);
            return new decimal(new[] { i1, i2, i3, i4 });
        }

        public override double ReadDouble() => BitConverter.ToDouble(Reverse(ReadBytesRequired(sizeof(double))), 0);

        public override short ReadInt16() => BitConverter.ToInt16(Reverse(ReadBytesRequired(sizeof(short))), 0);

        public override int ReadInt32() => BitConverter.ToInt32(Reverse(ReadBytesRequired(sizeof(int))), 0);

        public override long ReadInt64() => BitConverter.ToInt64(Reverse(ReadBytesRequired(sizeof(long))), 0);

        public override float ReadSingle() => BitConverter.ToSingle(Reverse(ReadBytesRequired(sizeof(float))), 0);

        public override ushort ReadUInt16() => BitConverter.ToUInt16(Reverse(ReadBytesRequired(sizeof(ushort))), 0);

        public override uint ReadUInt32() => BitConverter.ToUInt32(Reverse(ReadBytesRequired(sizeof(uint))), 0);

        public override ulong ReadUInt64() => BitConverter.ToUInt64(Reverse(ReadBytesRequired(sizeof(ulong))), 0);
    }
}