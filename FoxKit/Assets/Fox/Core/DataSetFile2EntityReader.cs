using Fox.FoxCore.Serialization;
using Fox.Kernel;
using String = Fox.Kernel.String;
using Path = Fox.Kernel.Path;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Messaging;
using static Fox.FoxCore.Serialization.DataSetFile2PropertyReader;

namespace Fox.Core
{
    public struct AddressedEntity
    {
        public ulong Address;
        public Entity Entity;
    }

    public class DataSetFile2AddressedEntityReader
    {
        private RequestSetEntityPtr requestSetEntityPtr;
        private RequestSetEntityHandle requestSetEntityHandle;

        public DataSetFile2AddressedEntityReader(RequestSetEntityPtr requestSetEntityPtr, RequestSetEntityHandle requestSetEntityHandle)
        {
            this.requestSetEntityPtr = requestSetEntityPtr ?? throw new ArgumentNullException(nameof(requestSetEntityPtr));
            this.requestSetEntityHandle = requestSetEntityHandle ?? throw new ArgumentNullException(nameof(requestSetEntityHandle));
        }

        public AddressedEntity Read(BinaryReader reader, Func<StrCode, String> unhashString)
        {
            var headerSize = reader.ReadUInt16(); Debug.Assert(headerSize == 0x40);
            reader.BaseStream.Position -= 2;

            byte[] headerBytes = reader.ReadBytes(headerSize);
            int classId = BitConverter.ToInt32(headerBytes, 4);
            uint ent_cString = BitConverter.ToUInt32(headerBytes, 6); Debug.Assert(ent_cString == 0x00746E65); // "ent\0"
            ulong address = BitConverter.ToUInt64(headerBytes, 10);
            ulong id = BitConverter.ToUInt64(headerBytes, 18);
            ushort version = BitConverter.ToUInt16(headerBytes, 26);
            Kernel.StrCode classNameHash = Kernel.HashingBitConverter.ToStrCode(headerBytes, 28);
            ushort staticPropertyCount = BitConverter.ToUInt16(headerBytes, 36);
            ushort dynamicPropertyCount = BitConverter.ToUInt16(headerBytes, 38);

            var entity = EntityInfo.ConstructEntity(new String(classNameHash));
            var isReadingDynamicProperty = false;

            SetProperty setProperty = entity.SetProperty;
            SetPropertyElementByIndex setPropertyElementByIndex = entity.SetPropertyElement;
            SetPropertyElementByKey setPropertyElementByKey = entity.SetPropertyElement;

            var propertyReader = new DataSetFile2PropertyReader(unhashString, requestSetEntityPtr, requestSetEntityHandle);
            for (var i = 0; i < staticPropertyCount; i++)
            {
                propertyReader.Read(reader, 
                    (PropertyInfo.PropertyType type, String name, ushort arraySize, PropertyInfo.ContainerType container) => OnPropertyNameUnhashed(type, name, arraySize, container, entity, isReadingDynamicProperty),
                    (propertyName) => GetPtrType(entity, propertyName),
                    setProperty, 
                    setPropertyElementByIndex, 
                    setPropertyElementByKey);
            }

            isReadingDynamicProperty = true;
            for (var i = 0; i < dynamicPropertyCount; i++)
            {
                propertyReader.Read(reader, (PropertyInfo.PropertyType type, String name, ushort arraySize, PropertyInfo.ContainerType container) => OnPropertyNameUnhashed(type, name, arraySize, container, entity, isReadingDynamicProperty), 
                    (propertyName) => typeof(Entity),
                    setProperty, 
                    setPropertyElementByIndex, 
                    setPropertyElementByKey);
            }

            return new AddressedEntity { Address = address, Entity = entity };
        }

        private static void OnPropertyNameUnhashed(PropertyInfo.PropertyType type, String name, ushort arraySize, PropertyInfo.ContainerType container, Entity entity, bool isReadingDynamicProperty)
        {
            if (isReadingDynamicProperty)
            {
                entity.AddDynamicProperty(type, name, arraySize, container);
            }
        }

        private Type GetPtrType(Entity entity, String propertyName)
        {
            var classInfo = entity.GetClassEntityInfo();
            while (classInfo != null)
            {
                var properties = classInfo.StaticProperties;
                if (properties.ContainsKey(propertyName))
                {
                    return properties[propertyName].PtrType;
                }

                classInfo = classInfo.Super;
            }

            UnityEngine.Debug.LogError("Unable to find property " + propertyName);
            return null;
        }
    }
}
