using Fox.Fio;
using Fox;
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

        internal bool OverridesProperty(string propertyName) => propertyOverrides.ContainsKey(propertyName);
        internal object GetOverriddenProperty(string propertyName) => propertyOverrides[propertyName];
    }

    public class DataSetFile2EntityWriter
    {
        private const short HeaderSize = 64;
        private const uint MagicNumber = 0x746e65;

        private IDictionary<Entity, ulong> addresses;
        private HashSet<string> strings;

        public void Write(Entity entity, EntityExportContext exportContext, IDictionary<Entity, ulong> addresses, HashSet<string> strings, ulong address, ulong id, Stream output)
        {
            this.addresses = addresses;
            this.strings = strings;

            var writer = new BinaryWriter(output, Encoding.Default, true);
            long headerPosition = output.Position;
            output.Position += HeaderSize;

            EntityInfo info = entity.GetClassEntityInfo();
            _ = strings.Add(info.Name);

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
                foreach (PropertyInfo staticProperty in @class.OrderedStaticProperties)
                {
                    if (staticProperty.Offset == 0)
                    {
                        continue;
                    }

                    staticPropertyCount++;
                    WriteProperty(entity, exportContext, staticProperty, writer);
                }
            }

            uint staticDataSize = (uint)(output.Position - headerPosition);

            uint dynamicPropertyCount = 0;
            foreach (var dynamicProperty in entity.GetComponents<DynamicProperty>())
            {
                WriteProperty(entity, exportContext, dynamicProperty.GetPropertyInfo(), writer, true);
                dynamicPropertyCount++;
            }

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

            writer.Write(Fox.HashingBitConverter.StrCodeToUInt64(new StrCode(info.Name)));
            writer.Write(Convert.ToUInt16(staticPropertyCount));
            writer.Write(Convert.ToUInt16(dynamicPropertyCount));
            writer.Write((int)HeaderSize);
            writer.Write(staticDataSize);
            writer.Write(dataSize);
            writer.AlignWrite(16, 0x00);
            output.Position = endPosition;
        }

        private void WriteProperty(Entity entity, EntityExportContext exportContext, PropertyInfo property, BinaryWriter writer, bool isWritingDynamicProperty = false)
        {
            _ = strings.Add(property.Name);

            Stream output = writer.BaseStream;
            long headerPosition = output.Position;
            output.Position += 32;

            ushort arraySize = (ushort)property.ArraySize;
            if (property.Container == PropertyInfo.ContainerType.StaticArray && property.ArraySize == 1 && !isWritingDynamicProperty)
            {
                WriteSingleValue(writer, entity, exportContext, property);
            }
            else if (property.Container == PropertyInfo.ContainerType.StringMap)
            {
                arraySize = WriteStringMapProperty(entity, exportContext, property, writer);
            }
            else
            {
                arraySize = WriteListProperty(entity, exportContext, property, writer);
            }

            writer.AlignWrite(16, 0x00);
            long endPosition = output.Position;
            ushort size = (ushort)(endPosition - headerPosition);
            output.Position = headerPosition;

            writer.Write(HashingBitConverter.StrCodeToUInt64(new StrCode(property.Name)));
            writer.Write((byte)property.Type);
            writer.Write((byte)property.Container);
            writer.Write(arraySize);
            writer.Write((ushort)32);
            writer.Write(size);
            writer.WriteZeros(16);
            output.Position = endPosition;
        }

        private ushort WriteStringMapProperty(Entity entity, EntityExportContext exportContext, PropertyInfo property, BinaryWriter writer)
        {
            List<KeyValuePair<string, object>> list = exportContext.OverridesProperty(property.Name)
                   ? ((IStringMap)exportContext.GetOverriddenProperty(property.Name)).ToList()
                   : entity.GetProperty(property.Name).GetValueAsIStringMap().ToList();

            int skippedKeyCount = 0;
            foreach (KeyValuePair<string, object> item in list)
            {
                // TODO Are empty keys allowed?
                if (System.String.IsNullOrEmpty(item.Key))
                {
                    skippedKeyCount++;
                    continue;
                }

                _ = strings.Add(item.Key);
                writer.Write(HashingBitConverter.StrCodeToUInt64(new StrCode(item.Key)));
                WriteCollectionItem(writer, item.Value, property.Type);
                writer.AlignWrite(16, 0x00);
            }

            return (ushort)(list.Count - skippedKeyCount);
        }

        private ushort WriteListProperty(Entity entity, EntityExportContext exportContext, PropertyInfo property, BinaryWriter writer)
        {
            IList list = exportContext.OverridesProperty(property.Name)
                   ? (IList)exportContext.GetOverriddenProperty(property.Name)
                   : entity.GetProperty(property.Name).GetValueAsIList();

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
                    {
                        var str = (string)item;
                        str = str ?? string.Empty;
                        _ = strings.Add(str);
                        writer.WriteStrCode(new StrCode(str));
                    }
                    break;
                case PropertyInfo.PropertyType.Path:
                    {
                        var str = ((Fox.Path)item).String;
                        _ = strings.Add(str);
                        writer.WriteStrCode(new StrCode(str));
                    }
                    break;
                case PropertyInfo.PropertyType.EntityPtr:
                    {
                        ulong address = 0;
                        if ((Entity)item != null)
                        {
                            address = addresses[(Entity)item];
                        }

                        writer.Write(address);
                    }
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
                    {
                        var ptr = (FilePtr)item;
                        var str = ptr.path.String;
                        _ = strings.Add(str);
                        writer.WriteStrCode(new StrCode(str));
                    }
                    break;
                case PropertyInfo.PropertyType.EntityHandle:
                    {
                        ulong address = 0;
                        if ((Entity)item != null)
                        {
                            address = addresses[(Entity)item];
                        }

                        writer.Write(address);
                    }
                    break;
                case PropertyInfo.PropertyType.EntityLink:
                    {
                        var entityLink = (EntityLink)item;
                        _ = strings.Add(entityLink.packagePath.String);
                        _ = strings.Add(entityLink.archivePath.String);
                        _ = strings.Add(entityLink.nameInArchive);

                        writer.WriteStrCode(new StrCode(entityLink.packagePath.String));
                        writer.WriteStrCode(new StrCode(entityLink.archivePath.String));
                        writer.WriteStrCode(new StrCode(entityLink.nameInArchive));

                        ulong address = 0;
                        if (entityLink.handle != null)
                        {
                            address = addresses[entityLink.handle];
                        }

                        writer.Write(address);
                    }
                    break;
            }
        }

        private void WriteSingleValue(BinaryWriter writer, Entity entity, EntityExportContext exportContext, PropertyInfo property)
        {
            object value = exportContext.OverridesProperty(property.Name)
                ? exportContext.GetOverriddenProperty(property.Name)
                : entity.GetProperty(property.Name).GetValueAsBoxedObject();

            WritePropertyItem(value, property.Type, writer);
        }

        public void WriteCollectionItem(BinaryWriter writer, object item, PropertyInfo.PropertyType type)
        {
            WritePropertyItem(item, type, writer);
        }
    }
}
