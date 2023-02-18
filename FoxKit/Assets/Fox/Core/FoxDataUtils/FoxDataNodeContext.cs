using Fox.Fio;
using Fox.Kernel;
using System.Diagnostics;

namespace Fox.Core
{
    public struct FoxDataNodeContext
    {
        public long Position
        {
            get;
        }
        private readonly FileStreamReader Reader;
        private readonly FoxDataStringContext.HashFormat StringFormat;
        private readonly FoxDataStringContext.DataOffsetMode StringOffsetMode;

        public const uint Offset_Name = 0;
        public const uint Offset_Flags = 8;
        public const uint Offset_DataOffset = 12;

        public const uint Offset_DataSize = 16;
        public const uint Offset_ParentNodeOffset = 20;
        public const uint Offset_ChildNodeOffset = 24;
        public const uint Offset_PreviousNodeOffset = 28;

        public const uint Offset_NextNodeOffset = 32;
        public const uint Offset_ParametersOffset = 36;

        public FoxDataNodeContext(FileStreamReader reader, long position, FoxDataStringContext.HashFormat stringFormat = FoxDataStringContext.HashFormat.Default, FoxDataStringContext.DataOffsetMode stringOffsetMode = FoxDataStringContext.DataOffsetMode.Relative)
        {
            Reader = reader;

            Position = position;

            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.HashFormat), stringFormat));
            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.DataOffsetMode), stringOffsetMode));

            StringFormat = stringFormat;
            StringOffsetMode = stringOffsetMode;
        }

        public String GetName() => new FoxDataStringContext(Reader, Position + Offset_Name, StringFormat, StringOffsetMode).GetString();

        public uint GetFlags()
        {
            Reader.Seek(Position + Offset_Flags);

            return Reader.ReadUInt32();
        }

        public int GetDataOffset()
        {
            Reader.Seek(Position + Offset_DataOffset);

            return Reader.ReadInt32();
        }
        public long? GetDataPosition()
        {
            int offset = GetDataOffset();
            return offset == 0 ? null : Position + offset;
        }

        public uint GetDataSize()
        {
            Reader.Seek(Position + Offset_DataSize);

            return Reader.ReadUInt32();
        }

        public int GetParentNodeOffset()
        {
            Reader.Seek(Position + Offset_ParentNodeOffset);

            return Reader.ReadInt32();
        }
        public long? GetParentNodePosition()
        {
            int offset = GetParentNodeOffset();
            return offset == 0 ? null : Position + offset;
        }
        public FoxDataNodeContext? GetParentNode() => GetParentNodePosition() is long position ? new FoxDataNodeContext(Reader, position, StringFormat, StringOffsetMode) : null;

        public int GetChildNodeOffset()
        {
            Reader.Seek(Position + Offset_ChildNodeOffset);

            return Reader.ReadInt32();
        }
        public long? GetChildNodePosition()
        {
            int offset = GetChildNodeOffset();
            return offset == 0 ? null : Position + offset;
        }
        public FoxDataNodeContext? GetChildNode() => GetChildNodePosition() is long position ? new FoxDataNodeContext(Reader, position, StringFormat, StringOffsetMode) : null;

        public int GetPreviousNodeOffset()
        {
            Reader.Seek(Position + Offset_PreviousNodeOffset);

            return Reader.ReadInt32();
        }
        public long? GetPreviousNodePosition()
        {
            int offset = GetPreviousNodeOffset();
            return offset == 0 ? null : Position + offset;
        }
        public FoxDataNodeContext? GetPreviousNode() => GetPreviousNodePosition() is long position ? new FoxDataNodeContext(Reader, position, StringFormat, StringOffsetMode) : null;

        public int GetNextNodeOffset()
        {
            Reader.Seek(Position + Offset_NextNodeOffset);

            return Reader.ReadInt32();
        }
        public long? GetNextNodePosition()
        {
            int offset = GetNextNodeOffset();
            return offset == 0 ? null : Position + offset;
        }
        public FoxDataNodeContext? GetNextNode() => GetNextNodePosition() is long position ? new FoxDataNodeContext(Reader, position, StringFormat, StringOffsetMode) : null;

        public int GetParametersOffset()
        {
            Reader.Seek(Position + Offset_ParametersOffset);

            return Reader.ReadInt32();
        }
        public long? GetParametersPosition()
        {
            int offset = GetParametersOffset();
            return offset == 0 ? null : Position + offset;
        }
        public FoxDataParameterContext? GetFirstParameter() => GetParametersPosition() is long position ? new FoxDataParameterContext(Reader, position, StringFormat, StringOffsetMode) : null;

        public FoxDataParameterContext? FindParameter(String name)
        {
            for (FoxDataParameterContext? param = GetFirstParameter(); param.HasValue; param = param.Value.GetNextParameter())
            {
                if (param.Value.NameEquals(name))
                    return param;
            }

            return null;
        }

        public bool NameEquals(String comparand) => new FoxDataStringContext(Reader, Position + Offset_Name, StringFormat, StringOffsetMode).Equals(comparand);

        public FoxDataNodeContext? FindNode(String name)
        {
            for (FoxDataNodeContext? node = this; node.HasValue; node = GetNextNode())
            {
                if (node.Value.NameEquals(name))
                    return node;

                if (node.Value.GetChildNodePosition() is long childNodePos)
                {
                    var child = new FoxDataNodeContext(Reader, childNodePos, StringFormat, StringOffsetMode);
                    return child.FindNode(name);
                }
            }

            return null;
        }
    }
}