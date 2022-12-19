using UnityEngine;
using Fox.Kernel;
using Fox.Fio;

namespace Fox.Core
{
    public struct FoxDataParameterContext
    {
        public enum DataType
        { 
            UInt = 0,
            String = 1,
            Float = 2,
        }

        public long Position { get; }
        private FileStreamReader Reader;
        private FoxDataStringContext.HashFormat StringFormat;
        private FoxDataStringContext.DataOffsetMode StringOffsetMode;

        public const uint Offset_Type = 0;
        public const uint Offset_NextParameterOffset = 2;
        public const uint Offset_Name = 4;
        public const uint Offset_Value = 12;

        public FoxDataParameterContext(FileStreamReader reader, long position, FoxDataStringContext.HashFormat stringFormat = FoxDataStringContext.HashFormat.Default, FoxDataStringContext.DataOffsetMode stringOffsetMode = FoxDataStringContext.DataOffsetMode.Relative)
        {
            this.Reader = reader;

            this.Position = position;

            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.HashFormat), stringFormat));
            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.DataOffsetMode), stringOffsetMode));

            this.StringFormat = stringFormat;
            this.StringOffsetMode = stringOffsetMode;
        }

        public bool IsValid() => Position > -1 && Reader != null && Reader.BaseStream.Position > -1;

        public DataType GetDataType()
        {
            Debug.Assert(IsValid());

            Reader.Seek(Position + Offset_Type);

            DataType type = (DataType)Reader.ReadUInt16(); Debug.Assert(System.Enum.IsDefined(typeof(DataType), type));

            return type;
        }

        public short GetNextParameterOffset()
        {
            Debug.Assert(IsValid());

            Reader.Seek(Position + Offset_NextParameterOffset);

            return Reader.ReadInt16();
        }
        public long? GetNextParameterPosition()
        {
            short offset = GetNextParameterOffset();
            return offset == 0 ? null : Position + offset;
        }
        public FoxDataParameterContext? GetNextParameter() => GetNextParameterPosition() is long position ? new FoxDataParameterContext(Reader, position, StringFormat, StringOffsetMode) : null;

        public String GetName()
        {
            Debug.Assert(IsValid());

            return new FoxDataStringContext(Reader, Position + Offset_Name, StringFormat, StringOffsetMode).GetString();
        }

        public uint GetUInt()
        {
            Debug.Assert(GetDataType() == DataType.UInt);

            return Reader.ReadUInt32();
        }

        public String GetString()
        {
            Debug.Assert(GetDataType() == DataType.String);

            return new FoxDataStringContext(Reader, Position + Offset_Value, StringFormat, StringOffsetMode).GetString();
        }

        public float GetFloat() 
        {
            Debug.Assert(GetDataType() == DataType.Float);

            return Reader.ReadSingle();
        }

        public bool NameEquals(String comparand)
        {
            Debug.Assert(IsValid());

            return new FoxDataStringContext(Reader, Position + Offset_Name, StringFormat, StringOffsetMode).TestEquality(comparand);
        }

        public bool NameEquals(StrCode32 comparand)
        {
            Debug.Assert(IsValid());

            return new FoxDataStringContext(Reader, Position + Offset_Name, StringFormat, StringOffsetMode).TestEquality(comparand);
        }

        public FoxDataParameterContext? FindParameter(String name)
        {
            Debug.Assert(IsValid());

            for (FoxDataParameterContext? param = this; param.HasValue; param = GetNextParameter())
            {
                if (param.Value.NameEquals(name))
                    return param;
            }

            return null;
        }
    }
}