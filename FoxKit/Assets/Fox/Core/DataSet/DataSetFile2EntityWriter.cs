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

        internal bool OverridesProperty(string propertyName) => propertyOverrides.ContainsKey(propertyName);
        internal object GetOverriddenProperty(string propertyName) => propertyOverrides[propertyName];
    }

    public class DataSetFile2EntityWriter
    {
        private const short HeaderSize = 64;
        private const uint MagicNumber = 0x746e65;

        private IDictionary<Entity, ulong> addresses;
        private HashSet<Kernel.String> strings;

        public void Write(Entity entity, EntityExportContext exportContext, IDictionary<Entity, ulong> addresses, HashSet<Kernel.String> strings, ulong address, ulong id, Stream output)
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
                foreach (System.Collections.Generic.KeyValuePair<Kernel.String, PropertyInfo> staticProperty in @class.StaticProperties)
                {
                    if (staticProperty.Value.Offset == 0)
                    {
                        continue;
                    }

                    staticPropertyCount++;
                    WriteProperty(entity, exportContext, staticProperty.Value, writer);
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
            writer.Write(Convert.ToUInt16(0)); // TODO: DynamicProperties count
            writer.Write((int)HeaderSize);
            writer.Write(staticDataSize);
            writer.Write(dataSize);
            writer.AlignWrite(16, 0x00);
            output.Position = endPosition;
        }

        private void WriteProperty(Entity entity, EntityExportContext exportContext, PropertyInfo property, BinaryWriter writer)
        {
            _ = strings.Add(property.Name);

            Stream output = writer.BaseStream;
            long headerPosition = output.Position;
            output.Position += 32;

            ushort arraySize = (ushort)property.ArraySize;
            if (property.Container == PropertyInfo.ContainerType.StaticArray && property.ArraySize == 1)
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

            writer.Write(HashingBitConverter.StrCodeToUInt64(property.Name.Hash));
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
            List<KeyValuePair<Kernel.String, object>> list = exportContext.OverridesProperty(property.Name.CString)
                   ? ((IStringMap)exportContext.GetOverriddenProperty(property.Name.CString)).ToList()
                   : entity.GetProperty(property.Name).GetValueAsIStringMap().ToList();

            int skippedKeyCount = 0;
            foreach (KeyValuePair<Kernel.String, object> item in list)
            {
                // TODO Are empty keys allowed?
                if (System.String.IsNullOrEmpty(item.Key.CString))
                {
                    skippedKeyCount++;
                    continue;
                }

                _ = strings.Add(item.Key);
                writer.Write(HashingBitConverter.StrCodeToUInt64(item.Key.Hash));
                WriteCollectionItem(writer, item.Value, property.Type);
                writer.AlignWrite(16, 0x00);
            }

            return (ushort)(list.Count - skippedKeyCount);
        }

        private ushort WriteListProperty(Entity entity, EntityExportContext exportContext, PropertyInfo property, BinaryWriter writer)
        {
            IList list = exportContext.OverridesProperty(property.Name.CString)
                   ? (IList)exportContext.GetOverriddenProperty(property.Name.CString)
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
                        var str = (Kernel.String)item;
                        _ = strings.Add(str);
                        writer.WriteStrCode(str.Hash);
                    }
                    break;
                case PropertyInfo.PropertyType.Path:
                    {
                        var str = new Kernel.String(((Kernel.Path)item).CString);
                        _ = strings.Add(str);
                        writer.WriteStrCode(str.Hash);
                    }
                    break;
                case PropertyInfo.PropertyType.EntityPtr:
                    {
                        Entity entity = ((IEntityPtr)item).Get();

                        ulong address = 0;
                        if (entity != null)
                        {
                            address = addresses[entity];
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
                        var str = new Kernel.String(ptr.path.CString);
                        _ = strings.Add(str);
                        writer.WriteStrCode(str.Hash);
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
                        _ = strings.Add(new Kernel.String(entityLink.packagePath.CString));
                        _ = strings.Add(new Kernel.String(entityLink.archivePath.CString));
                        _ = strings.Add(new Kernel.String(entityLink.nameInArchive.CString));

                        writer.WriteStrCode(new Kernel.String(entityLink.packagePath.CString).Hash);
                        writer.WriteStrCode(new Kernel.String(entityLink.archivePath.CString).Hash);
                        writer.WriteStrCode(entityLink.nameInArchive.Hash);

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
            object value = exportContext.OverridesProperty(property.Name.CString)
                ? exportContext.GetOverriddenProperty(property.Name.CString)
                : entity.GetProperty(property.Name).GetValueAsBoxedObject();

            WritePropertyItem(value, property.Type, writer);
        }

        public void WriteCollectionItem(BinaryWriter writer, object item, PropertyInfo.PropertyType type)
        {
            WritePropertyItem(item, type, writer);
        }
    }
}
