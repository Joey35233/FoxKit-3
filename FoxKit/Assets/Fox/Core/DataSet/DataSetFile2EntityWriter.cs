using Fox.Fio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fox.Core
{
    public class DataSetFile2EntityWriter
    {
        private const short HeaderSize = 64;
        private const uint MagicNumber = 0x746e65;

        private IDictionary<Entity, ulong> addresses;
        private List<Kernel.String> strings;


        public void Write(Entity entity, IDictionary<Entity, ulong> addresses, List<Kernel.String> strings, ulong address, ulong id, Stream output)
        {
            this.addresses = addresses;
            this.strings = strings;

            var writer = new BinaryWriter(output, Encoding.Default, true);
            long headerPosition = output.Position;
            output.Position += HeaderSize;

            EntityInfo info = entity.GetClassEntityInfo();
            strings.Add(info.Name);
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
            strings.Add(property.Name);

            Stream output = writer.BaseStream;
            long headerPosition = output.Position;
            output.Position += 32;

            ushort arraySize = (ushort)property.ArraySize;
            if (property.Container == PropertyInfo.ContainerType.StaticArray && property.ArraySize == 1)
            {
                WritePropertyValue(entity, property, writer);
            }
            else if (property.Container == PropertyInfo.ContainerType.StringMap)
            {
                // TODO
                // Cannot figure out how to enumerate StringMap
            }
            else
            {
                arraySize = WriteListProperty(entity, property, writer);
            }

            output.AlignWrite(16, 0x00);
            long endPosition = output.Position;
            ushort size = (ushort)(endPosition - headerPosition);
            output.Position = headerPosition;

            writer.Write(Kernel.HashingBitConverter.StrCodeToUInt64(property.Name.Hash));
            writer.Write((byte)property.Type);
            writer.Write((byte)property.Container);
            writer.Write(arraySize);
            writer.Write((ushort)32);
            writer.Write(size);
            writer.WriteZeros(16);
            output.Position = endPosition;
        }

        private ushort WriteListProperty(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            IList list = entity.GetProperty<IList>(property);
            foreach (object item in list)
            {
                WritePropertyItem(item, property.Type, writer);
            }

            return (ushort)list.Count;
        }

        private void WritePropertyItem(object item, PropertyInfo.PropertyType type, BinaryWriter writer)
        {
            switch (type)
            {
                case PropertyInfo.PropertyType.Int8:
                    writer.Write((sbyte)item);
                    break;
                case PropertyInfo.PropertyType.UInt8:
                    writer.Write((byte)item);
                    break;
                case PropertyInfo.PropertyType.Int16:
                    writer.Write((short)item);
                    break;
                case PropertyInfo.PropertyType.UInt16:
                    writer.Write((ushort)item);
                    break;
                case PropertyInfo.PropertyType.Int32:
                    writer.Write((int)item);
                    break;
                case PropertyInfo.PropertyType.UInt32:
                    writer.Write((uint)item);
                    break;
                case PropertyInfo.PropertyType.Int64:
                    writer.Write((long)item);
                    break;
                case PropertyInfo.PropertyType.UInt64:
                    writer.Write((ulong)item);
                    break;
                case PropertyInfo.PropertyType.Float:
                    writer.Write((float)item);
                    break;
                case PropertyInfo.PropertyType.Double:
                    writer.Write((double)item);
                    break;
                case PropertyInfo.PropertyType.Bool:
                    writer.Write((bool)item);
                    break;
                case PropertyInfo.PropertyType.String:
                    strings.Add(item as Kernel.String);
                    writer.WriteStrCode((item as Kernel.String).Hash);
                    break;
                case PropertyInfo.PropertyType.Path:
                    strings.Add(new Kernel.String((item as Kernel.Path).CString));
                    writer.WritePathFileNameAndExtCode((item as Kernel.Path).Hash);
                    break;
                case PropertyInfo.PropertyType.EntityPtr:
                    writer.WriteEntityPtr((item as IEntityPtr), addresses);
                    break;
                case PropertyInfo.PropertyType.Vector3:
                    writer.Write((UnityEngine.Vector3)item);
                    break;
                case PropertyInfo.PropertyType.Vector4:
                    writer.Write((UnityEngine.Vector4)item);
                    break;
                case PropertyInfo.PropertyType.Quat:
                    writer.Write((UnityEngine.Quaternion)item);
                    break;
                case PropertyInfo.PropertyType.Matrix3:
                    throw new NotImplementedException();
                case PropertyInfo.PropertyType.Matrix4:
                    writer.Write((UnityEngine.Matrix4x4)item);
                    break;
                case PropertyInfo.PropertyType.Color:
                    writer.Write((UnityEngine.Color)item);
                    break;
                case PropertyInfo.PropertyType.FilePtr:
                    strings.Add(new Kernel.String((item as FilePtr).path.CString));
                    writer.Write(item as FilePtr);
                    break;
                case PropertyInfo.PropertyType.EntityHandle:
                    writer.WriteEntityHandle((EntityHandle)item, addresses);
                    break;
                case PropertyInfo.PropertyType.EntityLink:
                    var entityLink = (EntityLink)item;
                    strings.Add(new Kernel.String(entityLink.packagePath.CString));
                    strings.Add(new Kernel.String(entityLink.archivePath.CString));
                    strings.Add(new Kernel.String(entityLink.nameInArchive.CString));
                    writer.WriteEntityLink(entityLink, addresses);
                    break;
            }
        }

        public void WritePropertyValue(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            switch (property.Type)
            {
                case PropertyInfo.PropertyType.Int8:
                    writer.WriteInt8PropertyValue(entity, property);
                    break;
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
                    strings.Add(writer.WriteStringPropertyValue(entity, property));
                    break;
                case PropertyInfo.PropertyType.Path:
                    strings.Add(writer.WritePathPropertyValue(entity, property));
                    break;
                case PropertyInfo.PropertyType.EntityPtr:
                    writer.WriteEntityPtrPropertyValue(entity, property, addresses);
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
                    strings.Add(writer.WriteFilePtrPropertyValue(entity, property));
                    break;
                case PropertyInfo.PropertyType.EntityHandle:
                    writer.WriteEntityHandlePropertyValue(entity, property, addresses);
                    break;
                case PropertyInfo.PropertyType.EntityLink:
                    strings.AddRange(writer.WriteEntityLinkPropertyValue(entity, property, addresses));
                    break;
            }
        }
    }
}
