using System;
using System.IO;
using System.Text;

namespace Fox.Core
{
    public class DataSetFile2EntityWriter
    {
        private const short HeaderSize = 64;
        private const uint MagicNumber = 0x746e65;

        public void Write(Entity entity, ulong address, ulong id, Stream output)
        {
            var writer = new BinaryWriter(output, Encoding.Default, true);
            var headerPosition = output.Position;
            output.Position += HeaderSize;

            var info = entity.GetClassEntityInfo();
            foreach (var staticProperty in info.StaticProperties)
            {
                WriteProperty(entity, staticProperty.Value, writer);
            }

            var staticDataSize = (uint)(output.Position - headerPosition);
            /**
             * TODO
             * foreach (var dynamicProperty in entity.DynamicProperties)
            {
                dynamicProperty.Write(output);
            }*/

            var endPosition = output.Position;
            var dataSize = (uint)(endPosition - headerPosition);
            output.Position = headerPosition;

            writer.Write(HeaderSize);
            writer.Write(info.Id);
            writer.WriteZeros(2); // padding1
            writer.Write(MagicNumber);
            writer.Write(address);
            writer.Write(id);
            writer.Write(info.Version);

            writer.Write(Kernel.HashingBitConverter.StrCodeToUInt64(info.Name.Hash));
            writer.Write(Convert.ToUInt16(info.StaticProperties.Count));
            writer.Write(Convert.ToUInt16(0)); // TODO DynamicProperties count
            writer.Write((int)HeaderSize);
            writer.Write(staticDataSize);
            writer.Write(dataSize);
            output.AlignWrite(16, 0x00);
            output.Position = endPosition;
        }

        public void WriteProperty(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            var output = writer.BaseStream;
            long headerPosition = output.Position;
            output.Position += 32;

            WritePropertyValues(entity, property, writer);

            output.AlignWrite(16, 0x00);
            var endPosition = output.Position;
            var size = (ushort)(endPosition - headerPosition);
            output.Position = headerPosition;

            writer.Write(Kernel.HashingBitConverter.StrCodeToUInt64(property.Name.Hash));
            writer.Write((byte)property.Type);
            writer.Write((byte)property.Container);
            writer.Write((ushort)property.ArraySize);
            writer.Write((ushort)32);
            writer.Write(size);
            writer.WriteZeros(16);
            output.Position = endPosition;
        }

        public void WritePropertyValues(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            for(var i = 0; i < property.ArraySize; i++)
            {
                // TODO
            }
        }
    }
}
