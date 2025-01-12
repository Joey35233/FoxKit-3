using Fox.Core.Utils;
using Fox.Fio;
using Fox;
using System;
using Debug = UnityEngine.Debug;
using Path = Fox.Path;

namespace Fox.Core.Serialization
{
    public class DataSetFile2PropertyReader
    {
        private readonly Func<StrCode, string> unhashString;
        private readonly RequestSetEntityPtr requestSetEntityPtr;
        private readonly RequestSetEntityHandle requestSetEntityHandle;
        private readonly TaskLogger logger;

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <param name="propertyName">Name of the property whose value to set.</param>
        /// <param name="value">The value to assign to the property.</param>
        public delegate void SetProperty(string propertyName, Value value);

        public delegate Type GetPtrType(string propertyName);

        /// <summary>
        /// Sets the value of an array property at a given index.
        /// </summary>
        /// <param name="propertyName">Name of the property whose value to set.</param>
        /// <param name="index">The array index.</param>
        /// <param name="value">The value to assign to the property.</param>
        public delegate void SetPropertyElementByIndex(string propertyName, ushort index, Value value);

        /// <summary>
        /// Sets the value of a StringMap property at a given key.
        /// </summary>
        /// <param name="propertyName">Name of the property whose value to set.</param>
        /// <param name="key">The StringMap key.</param>
        /// <param name="value">The value to assign to the property.</param>
        public delegate void SetPropertyElementByKey(string propertyName, string key, Value value);

        public delegate void RequestSetEntityPtr(ulong address, Action<Entity> setEntityPtr);
        public delegate void RequestSetEntityHandle(ulong address, Action<Entity> setEntityHandle);

        /// <summary>
        /// Callback to invoke when a property's name has been unhashed.
        /// </summary>
        /// <param name="type">Type of the property.</param>
        /// <param name="name">Unhashed name of the property.</param>
        /// <param name="arraySize">ArraySize of the property. Must be 1 unless a StaticArray.</param>
        /// <param name="container">Container type of the property.</param>
        public delegate void OnPropertyNameUnhashedCallback(PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container);

        public DataSetFile2PropertyReader(
            Func<StrCode, string> unhashString,
            RequestSetEntityPtr requestEntityPtr,
            RequestSetEntityHandle requestEntityHandle,
            TaskLogger logger)
        {
            this.unhashString = unhashString;
            requestSetEntityPtr = requestEntityPtr;
            requestSetEntityHandle = requestEntityHandle;
            this.logger = logger;
        }

        public void Read(
            FileStreamReader reader,
            SetProperty setProperty,
            SetPropertyElementByIndex setPropertyElementByIndex,
            SetPropertyElementByKey setPropertyElementByKey)
        {
            Debug.Assert(reader != null);
            Debug.Assert(setProperty != null);
            Debug.Assert(setPropertyElementByIndex != null);
            Debug.Assert(setPropertyElementByKey != null);

            byte[] headerBytes = reader.ReadBytes(32);
            var nameHash = HashingBitConverter.ToStrCode(headerBytes, 0);
            var dataType = (PropertyInfo.PropertyType)headerBytes[8];
            var containerType = (PropertyInfo.ContainerType)headerBytes[9];
            ushort arraySize = BitConverter.ToUInt16(headerBytes, 10);

            string name = unhashString(nameHash);

            if (containerType == PropertyInfo.ContainerType.StaticArray && arraySize == 1)
            {
                ReadProperty(reader, setProperty, name, dataType);
            }
            else if (containerType == PropertyInfo.ContainerType.StringMap)
            {
                ReadStringMap(reader, setPropertyElementByKey, name, dataType, arraySize);
            }
            else
            {
                ReadArray(reader, setPropertyElementByIndex, name, dataType, arraySize);
            }

            reader.Align(16);
        }
        
        public void ReadDynamic(
            FileStreamReader reader,
            SetPropertyElementByIndex setPropertyElementByIndex,
            SetPropertyElementByKey setPropertyElementByKey,
            OnPropertyNameUnhashedCallback onPropertyNameUnhashed)
        {
            Debug.Assert(reader != null);
            Debug.Assert(setPropertyElementByIndex != null);
            Debug.Assert(setPropertyElementByKey != null);
            Debug.Assert(onPropertyNameUnhashed != null);

            byte[] headerBytes = reader.ReadBytes(32);
            var nameHash = HashingBitConverter.ToStrCode(headerBytes, 0);
            var dataType = (PropertyInfo.PropertyType)headerBytes[8];
            var containerType = (PropertyInfo.ContainerType)headerBytes[9];
            ushort arraySize = BitConverter.ToUInt16(headerBytes, 10);

            string name = unhashString(nameHash);
            onPropertyNameUnhashed(dataType, name, arraySize, containerType);

            if (containerType == PropertyInfo.ContainerType.StringMap)
            {
                ReadStringMap(reader, setPropertyElementByKey, name, dataType, arraySize);
            }
            else
            {
                ReadArray(reader, setPropertyElementByIndex, name, dataType, arraySize);
            }

            reader.Align(16);
        }

        private void ReadArray(FileStreamReader reader, SetPropertyElementByIndex setPropertyElementByIndex, string name, PropertyInfo.PropertyType dataType, ushort arraySize)
        {
            for (ushort i = 0; i < arraySize; i++)
            {
                // Entity references can't be resolved until the referenced Entity is loaded.
                // Register a callback to assign the property value once the Entity has been loaded.
                ushort index = i;
                void setProperty(string name, Value val)
                {
                    setPropertyElementByIndex(name, index, val);
                }

                if (dataType == PropertyInfo.PropertyType.EntityPtr)
                {
                    ReadEntityPtr(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityHandle)
                {
                    ReadEntityHandle(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityLink)
                {
                    ReadEntityLink(reader, setProperty, name);
                }
                else
                {
                    Value value = ReadPropertyValue(reader, dataType);
                    setPropertyElementByIndex(name, index, value);
                }
            }
        }

        private void ReadStringMap(FileStreamReader reader, SetPropertyElementByKey setPropertyElementByKey, string name, PropertyInfo.PropertyType dataType, ushort arraySize)
        {
            for (int i = 0; i < arraySize; i++)
            {
                StrCode keyHash = reader.ReadStrCode();
                string key = unhashString(keyHash);

                // Entity references can't be resolved until the referenced Entity is loaded.
                // Register a callback to assign the property value once the Entity has been loaded.
                void setProperty(string name, Value val)
                {
                    setPropertyElementByKey(name, key, val);
                }

                if (dataType == PropertyInfo.PropertyType.EntityPtr)
                {
                    ReadEntityPtr(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityHandle)
                {
                    ReadEntityHandle(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityLink)
                {
                    ReadEntityLink(reader, setProperty, name);
                }
                else
                {
                    Value value = ReadPropertyValue(reader, dataType);
                    setPropertyElementByKey(name, key, value);
                }

                reader.Align(16);
            }
        }

        private void ReadProperty(FileStreamReader reader, SetProperty setProperty, string name, PropertyInfo.PropertyType dataType)
        {
            // Entity references can't be resolved until the referenced Entity is loaded.
            // Register a callback to assign the property value once the Entity has been loaded.
            if (dataType == PropertyInfo.PropertyType.EntityPtr)
            {
                ReadEntityPtr(reader, setProperty, name);
            }
            else if (dataType == PropertyInfo.PropertyType.EntityHandle)
            {
                ReadEntityHandle(reader, setProperty, name);
            }
            else if (dataType == PropertyInfo.PropertyType.EntityLink)
            {
                ReadEntityLink(reader, setProperty, name);
            }
            else
            {
                Value value = ReadPropertyValue(reader, dataType);
                setProperty(name, value);
            }
        }

        private void ReadEntityLink(FileStreamReader reader, SetProperty setProperty, string name)
        {
            byte[] bytes = reader.ReadBytes(32);
            var packagePathHash = HashingBitConverter.ToStrCode(bytes, 0);
            var archivePathHash = HashingBitConverter.ToStrCode(bytes, 8);
            var nameInArchiveHash = HashingBitConverter.ToStrCode(bytes, 16);
            ulong address = BitConverter.ToUInt64(bytes, 24);

            var entityLink = new EntityLink
            {
                packagePath = new Path(unhashString(packagePathHash)),
                archivePath = new Path(unhashString(archivePathHash)),
                nameInArchive = unhashString(nameInArchiveHash),
                handle = null,
            };

            setProperty(name, new Value(entityLink));

            requestSetEntityHandle(address, (Entity ptr) =>
            {
                entityLink.handle = ptr;
                setProperty(name, new Value(entityLink));
            });
        }

        private void ReadEntityHandle(FileStreamReader reader, SetProperty setProperty, string name)
        {
            ulong address = reader.ReadUInt64();
            requestSetEntityHandle(address, (Entity ptr) => setProperty(name, new Value(ptr)));
        }

        private void ReadEntityPtr(FileStreamReader reader, SetProperty setProperty, string name)
        {
            ulong address = reader.ReadUInt64();
            requestSetEntityPtr(address, (Entity ptr) => setProperty(name, new Value(ptr)));
        }

        private Value ReadPropertyValue(FileStreamReader reader, PropertyInfo.PropertyType type)
        {
            switch (type)
            {
                case PropertyInfo.PropertyType.Int8:
                    return new Value(reader.ReadSByte());
                case PropertyInfo.PropertyType.UInt8:
                    return new Value(reader.ReadByte());
                case PropertyInfo.PropertyType.Int16:
                    return new Value(reader.ReadInt16());
                case PropertyInfo.PropertyType.UInt16:
                    return new Value(reader.ReadUInt16());
                case PropertyInfo.PropertyType.Int32:
                    return new Value(reader.ReadInt32());
                case PropertyInfo.PropertyType.UInt32:
                    return new Value(reader.ReadUInt32());
                case PropertyInfo.PropertyType.Int64:
                    return new Value(reader.ReadInt64());
                case PropertyInfo.PropertyType.UInt64:
                    return new Value(reader.ReadUInt64());
                case PropertyInfo.PropertyType.Float:
                    return new Value(reader.ReadSingle());
                case PropertyInfo.PropertyType.Double:
                    return new Value(reader.ReadDouble());
                case PropertyInfo.PropertyType.Bool:
                    return new Value(reader.ReadBoolean());
                case PropertyInfo.PropertyType.String:
                    return new Value(unhashString(reader.ReadStrCode()));
                case PropertyInfo.PropertyType.Path:
                    return new Value(new Path(unhashString(reader.ReadStrCode())));
                case PropertyInfo.PropertyType.FilePtr:
                    return new Value(new FilePtr(new Path(unhashString(reader.ReadStrCode()))));
                case PropertyInfo.PropertyType.Vector3:
                    return new Value(reader.ReadPaddedVector3());
                case PropertyInfo.PropertyType.Vector4:
                    return new Value(reader.ReadVector4());
                case PropertyInfo.PropertyType.Quat:
                    return new Value(reader.ReadQuaternion());
                case PropertyInfo.PropertyType.Matrix4:
                    return new Value(reader.ReadMatrix4());
                case PropertyInfo.PropertyType.Color:
                    return new Value(reader.ReadColor());
                case PropertyInfo.PropertyType.Matrix3:
                case PropertyInfo.PropertyType.PropertyInfo:
                case PropertyInfo.PropertyType.WideVector3:
                    throw new NotImplementedException();
                default:
                    logger.AddError($"Unexpected property type: {type}.");
                    throw new InvalidOperationException();
            }
        }
    }
}