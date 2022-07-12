using Fox.FoxCore.Serialization;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Messaging;
using static Fox.FoxCore.Serialization.DataSetFile2PropertyReader;

namespace Fox.Core
{
    public class DataSetFile2EntityReader
    {
        private RequestEntityPtr requestEntityPtr;
        private RequestEntityHandle requestEntityHandle;

        public DataSetFile2EntityReader(RequestEntityPtr requestEntityPtr, RequestEntityHandle requestEntityHandle)
        {
            this.requestEntityPtr = requestEntityPtr ?? throw new ArgumentNullException(nameof(requestEntityPtr));
            this.requestEntityHandle = requestEntityHandle ?? throw new ArgumentNullException(nameof(requestEntityHandle));
        }

        public Entity Read(BinaryReader reader, Func<ulong, ulong, ushort, ulong, Entity> createEntity, Func<ulong, string> unhashString)
        {
            var headerSize = reader.ReadUInt16(); Debug.Assert(headerSize == 0x40);
            reader.BaseStream.Position -= 2;

            var headerBytes = reader.ReadBytes(headerSize);
            var classId = BitConverter.ToInt32(headerBytes, 4);
            var ent_cString = BitConverter.ToUInt32(headerBytes, 6); Debug.Assert(ent_cString == 0x00746E65); // "ent\0"
            var address = BitConverter.ToUInt64(headerBytes, 10);
            var id = BitConverter.ToUInt64(headerBytes, 18);
            var version = BitConverter.ToUInt16(headerBytes, 26);
            var classNameHash = BitConverter.ToUInt64(headerBytes, 28);
            var staticPropertyCount = BitConverter.ToUInt16(headerBytes, 36);
            var dynamicPropertyCount = BitConverter.ToUInt16(headerBytes, 38);

            var entity = createEntity(classNameHash, address, version, id);
            var isReadingDynamicProperty = false;

            SetProperty setProperty = entity.SetProperty;
            SetPropertyElementByIndex setPropertyElementByIndex = entity.SetPropertyElement;
            SetPropertyElementByKey setPropertyElementByKey = entity.SetPropertyElement;

            var propertyReader = new DataSetFile2PropertyReader(unhashString, requestEntityPtr, requestEntityHandle);
            for (var i = 0; i < staticPropertyCount; i++)
            {
                propertyReader.Read(reader, 
                    (PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container) => OnPropertyNameUnhashed(type, name, arraySize, container, entity, isReadingDynamicProperty),
                    (propertyName) => GetPtrType(entity, propertyName),
                    setProperty, 
                    setPropertyElementByIndex, 
                    setPropertyElementByKey);
            }

            isReadingDynamicProperty = true;
            for (var i = 0; i < dynamicPropertyCount; i++)
            {
                propertyReader.Read(reader, (PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container) => OnPropertyNameUnhashed(type, name, arraySize, container, entity, isReadingDynamicProperty), 
                    (propertyName) => typeof(Entity),
                    setProperty, 
                    setPropertyElementByIndex, 
                    setPropertyElementByKey);
            }

            return entity;
        }

        private static void OnPropertyNameUnhashed(PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container, Entity entity, bool isReadingDynamicProperty)
        {
            if (isReadingDynamicProperty)
            {
                entity.AddDynamicProperty(type, name, arraySize, container);
            }
        }

        private Type GetPtrType(Entity entity, string propertyName)
        {
            var foxStr = new String(propertyName);
            var classInfo = entity.GetClassEntityInfo();
            while (classInfo != null)
            {
                var properties = classInfo.StaticProperties;
                if (properties.ContainsKey(foxStr))
                {
                    return properties[foxStr].PtrType;
                }

                classInfo = classInfo.Super;
            }

            UnityEngine.Debug.LogError("Unable to find property " + propertyName);
            return null;
        }
    }
}
