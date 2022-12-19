using UnityEngine;
using Fox.Kernel;
using Fox.Fio;

namespace Fox.Core
{
    public struct FoxDataStringContext
    {
        public enum DataOffsetMode
        {
            Relative,
            Absolute,
        }

        public enum HashFormat
        {
            Default,
            NoHash,
        }

        public long Position { get; }
        private FileStreamReader Reader;
        private HashFormat Format;
        private DataOffsetMode OffsetMode;

        public const uint Offset_Hash = 0;
        public const uint Offset_StringOffset = 4;

        public FoxDataStringContext(FileStreamReader reader, long position, HashFormat format, DataOffsetMode offsetMode)
        {
            this.Reader = reader;

            this.Position = position;

            Debug.Assert(System.Enum.IsDefined(typeof(DataOffsetMode), offsetMode));
            Debug.Assert(System.Enum.IsDefined(typeof(HashFormat), format));

            this.Format = format;
            this.OffsetMode = offsetMode;
        }

        public bool IsValid() => Position > -1 && Reader != null && Reader.BaseStream.Position > -1;

        public StrCode32 GetHash()
        {
            Debug.Assert(IsValid());

            Reader.Seek(Position + Offset_Hash);

            return Reader.ReadStrCode32();
        }

        public int GetStringOffset()
        {
            Debug.Assert(IsValid());

            Reader.Seek(Position + Offset_StringOffset);

            return Reader.ReadInt32();
        }
        public long? GetStringPosition()
        {
            if (Format == HashFormat.NoHash)
                Debug.Assert(GetHash().Equals(0));

            int offset = GetStringOffset();

            if (offset == 0)
            {
                return null;
            }
            else
            {
                switch (OffsetMode) 
                {
                    case DataOffsetMode.Relative:
                        return Position + offset;
                    case DataOffsetMode.Absolute:
                        return offset;
                    default:
                        return null;
                }
            }
        }

        public String GetString()
        {
            long? stringPosition = GetStringPosition();
            
            if (stringPosition is long realPosition)
            {
                Reader.Seek(realPosition);
                return Reader.ReadNullTerminatedString();
            }
            else
            {
                return null;
            }
        }

        public bool TestEquality(String comparand) => GetString() == comparand;
        public bool TestEquality(StrCode32 comparand) => GetHash() == comparand;
    }
}