using Fox.Kernel;
using Fox.Fio;
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

        public long Position { get; }
        private FileStreamReader Reader;
        private FoxDataStringContext.HashFormat StringFormat;
        private FoxDataStringContext.DataOffsetMode StringOffsetMode;

        public FoxDataHeaderContext(FileStreamReader reader, long position, FoxDataStringContext.HashFormat stringFormat = FoxDataStringContext.HashFormat.Default, FoxDataStringContext.DataOffsetMode stringOffsetMode = FoxDataStringContext.DataOffsetMode.Relative)
        {
            this.Reader = reader;

            this.Position = position;

            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.HashFormat), stringFormat));
            Debug.Assert(System.Enum.IsDefined(typeof(FoxDataStringContext.DataOffsetMode), stringOffsetMode));

            this.StringFormat = stringFormat;
            this.StringOffsetMode = stringOffsetMode;
        }

        public bool IsValid() => Position > -1 && Reader != null && Reader.BaseStream.Position > -1;

        public uint GetVersion()
        {
            Debug.Assert(IsValid());

            Reader.Seek(Position + Offset_Version);

            return Reader.ReadUInt32();
        }

        public int GetNodesOffset()
        {
            Debug.Assert(IsValid());

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
            Debug.Assert(IsValid());

            Reader.Seek(Position + Offset_FileSize);

            return Reader.ReadUInt32();
        }

        public String GetName()
        {
            Debug.Assert(IsValid());

            return new FoxDataStringContext(Reader, Position + Offset_Name, StringFormat, StringOffsetMode).GetString();
        }

        public uint GetFlags()
        {
            Debug.Assert(IsValid());

            Reader.Seek(Position + Offset_Flags);

            return Reader.ReadUInt32();
        }


        public FoxDataNodeContext? FindNode(String name)
        {
            Debug.Assert(IsValid());

            if (GetNodesPosition() is long nodesPosition)
            {
                for (FoxDataNodeContext? node = GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
                {
                    if (node.Value.NameEquals(name))
                        return node;

                    if (node.Value.GetChildNodePosition() is long childNodePos)
                    {
                        FoxDataNodeContext child = new FoxDataNodeContext(Reader, childNodePos, StringFormat, StringOffsetMode);
                        return child.FindNode(name);
                    }
                }
            }
            
            return null;
        }

        [Conditional("DEBUG")]
        public void Validate(uint version, uint flags)
        {
            Debug.Assert(IsValid());

            Debug.Assert(GetVersion() == version);
            Debug.Assert(GetFlags() == flags);
        }

        [Conditional("DEBUG")]
        public void Validate(uint version, String name, uint flags, uint fileSize)
        {
            Debug.Assert(IsValid());

            Debug.Assert(GetVersion() == version);

            FoxDataStringContext nameContext = new FoxDataStringContext(Reader, Position, StringFormat, StringOffsetMode);
            Debug.Assert(name == (String)null ? nameContext.GetHash() == 0 : nameContext.Equals(name));

            Debug.Assert(GetFlags() == flags);
            Debug.Assert(GetFileSize() == fileSize);
        }
    }
}