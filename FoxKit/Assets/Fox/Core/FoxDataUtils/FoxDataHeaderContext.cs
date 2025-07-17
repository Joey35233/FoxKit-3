using Fox.Fio;
using Fox;
using System.Diagnostics;

namespace Fox.Core
{
    public struct FoxDataHeaderContext
    {
        public const uint Offset_Version = 0;
        public const uint Offset_NodesOffset = 4;
        public const uint Offset_FileSize = 8;
        public const uint Offset_Name = 12;

        public const uint Offset_Flags = 20;

        public long Position
        {
            get;
        }
        private readonly FileStreamReader Reader;
        private readonly FoxDataStringContext.HashFormat StringFormat;
        private readonly FoxDataStringContext.DataOffsetMode StringOffsetMode;

        public FoxDataHeaderContext(FileStreamReader reader, long position, FoxDataStringContext.HashFormat stringFormat = FoxDataStringContext.HashFormat.Default, FoxDataStringContext.DataOffsetMode stringOffsetMode = FoxDataStringContext.DataOffsetMode.Relative)
        {
            Reader = reader;

            Position = position;

            Debug.Assert(Position > -1);
            Debug.Assert(Reader != null);
            Debug.Assert(Reader.BaseStream.Position > -1);
            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.HashFormat), stringFormat));
            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.DataOffsetMode), stringOffsetMode));

            StringFormat = stringFormat;
            StringOffsetMode = stringOffsetMode;
        }

        public uint GetVersion()
        {
            Reader.Seek(Position + Offset_Version);

            return Reader.ReadUInt32();
        }

        public int GetNodesOffset()
        {
            Reader.Seek(Position + Offset_NodesOffset);

            return Reader.ReadInt32();
        }
        public long? GetNodesPosition()
        {
            int offset = GetNodesOffset();
            return offset == 0 ? null : Position + offset;
        }
        public FoxDataNodeContext? GetFirstNode() => GetNodesPosition() is long position ? new FoxDataNodeContext(Reader, position, StringFormat, StringOffsetMode) : null;

        public uint GetFileSize()
        {
            Reader.Seek(Position + Offset_FileSize);

            return Reader.ReadUInt32();
        }

        public string GetName() => new FoxDataStringContext(Reader, Position + Offset_Name, StringFormat, StringOffsetMode).GetString();

        public uint GetFlags()
        {
            Reader.Seek(Position + Offset_Flags);

            return Reader.ReadUInt32();
        }


        public FoxDataNodeContext? FindNode(string name)
        {
            if (GetNodesPosition() is long)
            {
                for (FoxDataNodeContext? node = GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
                {
                    if (node.Value.NameEquals(name))
                        return node;

                    if (node.Value.GetChildNodePosition() is long childNodePos)
                    {
                        var child = new FoxDataNodeContext(Reader, childNodePos, StringFormat, StringOffsetMode);
                        return child.FindNode(name);
                    }
                }
            }

            return null;
        }

        [Conditional("DEBUG")]
        public void Validate(uint version, uint flags)
        {
            Debug.Assert(GetVersion() == version);
            Debug.Assert(GetFlags() == flags);
        }

        [Conditional("DEBUG")]
        public void Validate(uint version, string name, uint flags)
        {
            Validate(version, flags);

            var nameContext = new FoxDataStringContext(Reader, Position, StringFormat, StringOffsetMode);
            Debug.Assert(name == (string)null ? nameContext.GetHash() == 0 : nameContext.Equals(name));
        }

        [Conditional("DEBUG")]
        public void Validate(uint version, string name, uint flags, uint fileSize)
        {
            Validate(version, flags);

            var nameContext = new FoxDataStringContext(Reader, Position, StringFormat, StringOffsetMode);
            Debug.Assert(name == (string)null ? nameContext.GetHash() == 0 : nameContext.Equals(name));

            Debug.Assert(GetFileSize() == fileSize);
        }
    }
}