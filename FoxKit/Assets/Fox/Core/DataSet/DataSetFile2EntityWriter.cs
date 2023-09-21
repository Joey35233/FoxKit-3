using Fox.Fio;
using Fox.Kernel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fox.Core
{
    public class EntityExportContext
    {
        private readonly IDictionary<string, object> propertyOverrides = new Dictionary<string, object>();

        /// <summary>
        /// Export a different value instead of the current value of a property.
        /// </summary>
        /// <remarks>
        /// Use this for non-array, non-StringMap properties. For type safety reasons,
        /// use OverrideListProperty and OverrideStringMapProperty in other cases.
        /// </remarks>
        /// <param name="propertyName">Name of the property to override.</param>
        /// <param name="valueToExport">Value to export.</param>
        public void OverrideProperty(string propertyName, object valueToExport)
        {
            propertyOverrides[propertyName] = valueToExport;
        }

        /// <summary>
        /// Export a different value instead of the current value of a property.
        /// Use this for StaticArray, DynamicArray, and List properties.
        /// </summary>
        /// <param name="propertyName">Name of the property to override.</param>
        /// <param name="listToExport">List of values to export.</param>
        public void OverrideListProperty(string propertyName, IList listToExport)
        {
            OverrideProperty(propertyName, listToExport);
        }

        /// <summary>
        /// Export a different value instead of the current value of a property.
        /// Use this for StringMap properties.
        /// </summary>
        /// <param name="propertyName">Name of the property to override.</param>
        /// <param name="stringMapToExport">StringMap of valuse to export.</param>
        public void OverrideStringMapProperty(string propertyName, IStringMap stringMapToExport)
        {
            OverrideProperty(propertyName, stringMapToExport);
        }
    }

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

            EntityInfo current = info;
            var superClasses = new List<EntityInfo>();
            superClasses.Add(info);
            while (true)
            {
                if (current.Super == null)
                {
                    break;
                }

                superClasses.Add(current.Super);
                current = current.Super;
            }

            superClasses.Reverse();
            uint staticPropertyCount = 0;

            foreach (EntityInfo @class in superClasses)
            {
                foreach (System.Collections.Generic.KeyValuePair<Kernel.String, PropertyInfo> staticProperty in @class.StaticProperties)
                {
                    if (staticProperty.Value.Offset == 0)
                    {
                        continue;
                    }

                    staticPropertyCount++;
                    WriteProperty(entity, staticProperty.Value, writer);
                }
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
            writer.Write(Convert.ToUInt16(staticPropertyCount));
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
                WriteSingleValue(writer, entity, property);
            }
            else if (property.Container == PropertyInfo.ContainerType.StringMap)
            {
                arraySize = WriteStringMapProperty(entity, property, writer);
            }
            else
            {
                arraySize = WriteListProperty(entity, property, writer);
            }

            output.AlignWrite(16, 0x00);
            long endPosition = output.Position;
            ushort size = (ushort)(endPosition - headerPosition);
            output.Position = headerPosition;

            writer.Write(HashingBitConverter.StrCodeToUInt64(property.Name.Hash));
            writer.Write((byte)property.Type);
            writer.Write((byte)property.Container);
            writer.Write(arraySize);
            writer.Write((ushort)32);
            writer.Write(size);
            writer.WriteZeros(16);
            output.Position = endPosition;
        }

        private ushort WriteStringMapProperty(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            var list = entity.GetProperty<IStringMap>(property).ToList();

            int skippedKeyCount = 0;
            foreach (KeyValuePair<Kernel.String, object> item in list)
            {
                // TODO Are empty keys allowed?
                if (System.String.IsNullOrEmpty(item.Key.CString))
                {
                    skippedKeyCount++;
                    continue;
                }

                strings.Add(item.Key);
                writer.Write(HashingBitConverter.StrCodeToUInt64(item.Key.Hash));
                WriteCollectionItem(writer, item, property.Type);
                writer.BaseStream.AlignWrite(16, 0x00);
            }

            return (ushort)(list.Count - skippedKeyCount);
        }

        private ushort WriteListProperty(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            IList list = entity.GetProperty<IList>(property);
            foreach (object item in list)
            {
                WriteCollectionItem(writer, item, property.Type);
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
                {
                    var str = new Kernel.String((item as Kernel.Path).CString);
                    strings.Add(str);
                    writer.WriteStrCode(str.Hash);
                }
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

        private void WriteSingleValue(BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            object value = entity.GetProperty<object>(property);
            WritePropertyItem(value, property.Type, writer);
        }

        public void WriteCollectionItem(BinaryWriter writer, object item, PropertyInfo.PropertyType type)
        {
            WritePropertyItem(item, type, writer);
        }
    }
}
