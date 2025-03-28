using Fox.Core;
using Fox.Fio;
using Fox;
using static Fox.Geo.GeoGeom;
using System;
using System.Diagnostics;

namespace Fox.Geo
{
    //[StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct GeomHeaderContext
    {
        public enum OffsetSize
        {
            Bytes,
            Lines,
        }

        public static TransformData Deserialize(GeomHeaderContext header) => GeoModule.GeoPrimDeserializationMap.TryGetValue(header.Type, out Func<GeomHeaderContext, TransformData> func) ? func(header) : null;

        public long Position
        {
            get;
        }
        public FileStreamReader Reader;
        private readonly OffsetSize _OffsetSize;

        public const uint Offset_Info = 0;
        public const uint Offset_NextHeaderOffset = 4;
        public const uint Offset_PreviousHeaderOffset = 8;
        public const uint Offset_ChildHeaderOffset = 12;

        public const uint Offset_Tags = 16;
        public const uint Offset_Name = 24;
        public const uint Offset_VertexBufferOffset = 28;

        public const uint Size = 32;

        public GeomHeaderContext(FileStreamReader reader, long position, OffsetSize offsetSize) : this()
        {
            Debug.Assert(Enum.IsDefined(typeof(OffsetSize), offsetSize));
            Reader = reader;
            Position = position;
            _OffsetSize = offsetSize;

            Debug.Assert(PrimCount == 0);
            Debug.Assert((Type & ~(GeoPrimType.Poly | GeoPrimType.Box | GeoPrimType.AABB | GeoPrimType.Path | GeoPrimType.AreaPath)) == 0);
            Debug.Assert(System.Enum.IsDefined(typeof(GeomHeaderFlags), Flags));

            if (_OffsetSize == OffsetSize.Lines)
            {
                Debug.Assert((NextHeaderOffset & 0xF0000000) == 0);
                Debug.Assert((PreviousHeaderOffset & 0xF0000000) == 0);
                Debug.Assert((ChildHeaderOffset & 0xF0000000) == 0);
                Debug.Assert((VertexBufferOffset & 0xF0000000) == 0);
            }
        }

        public bool IsValid() => Position > -1 && Reader != null && Reader.BaseStream.Position > -1;

        //[FieldOffset(0)] private uint _Info;
        public GeoPrimType Type
        {
            get
            {
                Reader.Seek(Position + Offset_Info);
                return (GeoPrimType)((Reader.ReadUInt32() >> 0) & 0xF);
            }
        }
        public GeomHeaderFlags Flags
        {
            get
            {
                Reader.Seek(Position + Offset_Info);
                return (GeomHeaderFlags)((Reader.ReadUInt32() >> 4) & 0xFFFFF);
            }
        }
        public byte PrimCount
        {
            get
            {
                Reader.Seek(Position + Offset_Info);
                return (byte)((Reader.ReadUInt32() >> 24) & 0xFF);
            }
        }

        //[FieldOffset(4)] private int _NextHeaderOffset;
        public int NextHeaderOffset
        {
            get
            {
                Reader.Seek(Position + Offset_NextHeaderOffset);
                return _OffsetSize == OffsetSize.Lines ? Reader.ReadInt32() << 4 : Reader.ReadInt32();
            }
        }

        //[FieldOffset(4)] private int _PreviousHeaderOffset;
        public int PreviousHeaderOffset
        {
            get
            {
                Reader.Seek(Position + Offset_PreviousHeaderOffset);
                return _OffsetSize == OffsetSize.Lines ? Reader.ReadInt32() << 4 : Reader.ReadInt32();
            }
        }

        //[FieldOffset(12)] private int _ChildHeaderOffset;
        public int ChildHeaderOffset
        {
            get
            {
                Reader.Seek(Position + Offset_ChildHeaderOffset);
                return _OffsetSize == OffsetSize.Lines ? Reader.ReadInt32() << 4 : Reader.ReadInt32();
            }
        }

        //[FieldOffset(16)] private ulong _Tags;
        public T GetTags<T>() where T : struct, System.Enum
        {
            Reader.Seek(Position + Offset_Tags);
            return (T)System.Enum.ToObject(typeof(T), Reader.ReadUInt64());
        }

        //[FieldOffset(24)] private StrCode32 _Name;
        public StrCode32 Name
        {
            get
            {
                Reader.Seek(Position + Offset_Name);
                return Reader.ReadStrCode32();
            }
        }

        //[FieldOffset(28)] private int _VertexBufferOffset;
        public int VertexBufferOffset
        {
            get
            {
                Reader.Seek(Position + Offset_VertexBufferOffset);
                return _OffsetSize == OffsetSize.Lines ? Reader.ReadInt32() << 4 : Reader.ReadInt32();
            }
        }

        public long GetDataPosition() => Position + Size;
    }
}