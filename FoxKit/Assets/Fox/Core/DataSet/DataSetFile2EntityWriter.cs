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
            long headerPosition = output.Position;
            output.Position += HeaderSize;

            EntityInfo info = entity.GetClassEntityInfo();
            foreach (System.Collections.Generic.KeyValuePair<Kernel.String, PropertyInfo> staticProperty in info.StaticProperties)
            {
                WriteProperty(entity, staticProperty.Value, writer);
            }

            uint staticDataSize = (uint)(output.Position - headerPosition);
            /**
             * TODO
             * foreach (var dynamicProperty in entity.DynamicProperties)
            {
                dynamicProperty.Write(output);
            }*/

            long endPosition = output.Position;
            uint dataSize = (uint)(endPosition - headerPosition);
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

        private void WriteProperty(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            Stream output = writer.BaseStream;
            long headerPosition = output.Position;
            output.Position += 32;

            // TODO Handle arrays, stringmaps
            WriteProperty(entity, property, writer);

            output.AlignWrite(16, 0x00);
            long endPosition = output.Position;
            ushort size = (ushort)(endPosition - headerPosition);
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

        public void WritePropertyValue(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            switch (property.Type)
            {
                case PropertyInfo.PropertyType.UInt8:
                    writer.WriteUInt8PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Int16:
                    writer.WriteInt16PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.UInt16:
                    writer.WriteUInt16PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Int32:
                    writer.WriteInt32PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.UInt32:
                    writer.WriteUInt32PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Int64:
                    writer.WriteInt64PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.UInt64:
                    writer.WriteUInt64PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Float:
                    writer.WriteFloatPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Double:
                    writer.WriteDoublePropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Bool:
                    writer.WriteBoolPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.String:
                    writer.WriteStringPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Path:
                    writer.WritePathPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.EntityPtr:
                    writer.WriteEntityPtrPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Vector3:
                    writer.WriteVector3PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Vector4:
                    writer.WriteVector4PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Quat:
                    writer.WriteQuatPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Matrix3:
                    writer.WriteMatrix3PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Matrix4:
                    writer.WriteMatrix4PropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.Color:
                    writer.WriteColorPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.FilePtr:
                    writer.WriteFilePtrPropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.EntityHandle:
                    writer.WriteEntityHandlePropertyValue(entity, property);
                    break;
                case PropertyInfo.PropertyType.EntityLink:
                    writer.WriteEntityLinkPropertyValue(entity, property);
                    break;
            }
        }
    }
}
