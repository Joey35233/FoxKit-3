using Fox.FoxCore.Serialization;
using System;
using System.IO;
using static Fox.FoxCore.Serialization.DataSetFile2PropertyReader;

namespace Fox.Core
{
    public class DataSetFile2EntityReader
    {
        private RequestEntityPtr requestEntityPtr;
        private RequestEntityHandle requestEntityHandle;
        private RequestFilePtr requestFilePtr;
        private RequestEntityLink requestEntityLink;

        public DataSetFile2EntityReader(RequestEntityPtr requestEntityPtr, RequestEntityHandle requestEntityHandle, RequestFilePtr requestFilePtr, RequestEntityLink requestEntityLink)
        {
            this.requestEntityPtr = requestEntityPtr ?? throw new ArgumentNullException(nameof(requestEntityPtr));
            this.requestEntityHandle = requestEntityHandle ?? throw new ArgumentNullException(nameof(requestEntityHandle));
            this.requestFilePtr = requestFilePtr ?? throw new ArgumentNullException(nameof(requestFilePtr));
            this.requestEntityLink = requestEntityLink ?? throw new ArgumentNullException(nameof(requestEntityLink));
        }

        public Entity Read(BinaryReader reader, Func<ulong, ulong, ushort, ushort, ushort, Entity> createEntity, Func<ulong, string> unhashString)
        {
            var headerBytes = reader.ReadBytes(64);
            var classId = BitConverter.ToInt16(headerBytes, 2);
            var address = BitConverter.ToUInt64(headerBytes, 10);
            var idA = BitConverter.ToUInt16(headerBytes, 18);
            var idB = BitConverter.ToUInt16(headerBytes, 20);
            var version = BitConverter.ToUInt16(headerBytes, 26);
            var classNameHash = BitConverter.ToUInt64(headerBytes, 28);
            var staticPropertyCount = BitConverter.ToUInt16(headerBytes, 36);
            var dynamicPropertyCount = BitConverter.ToUInt16(headerBytes, 38);

            var entity = createEntity(classNameHash, address, version, idA, idB);
            var isReadingDynamicProperty = false;

            SetProperty setProperty = entity.SetProperty;
            SetPropertyElementByIndex setPropertyElementByIndex = entity.SetPropertyElement;
            SetPropertyElementByKey setPropertyElementByKey = entity.SetPropertyElement;

            var propertyReader = new DataSetFile2PropertyReader(unhashString, requestEntityPtr, requestEntityHandle, requestFilePtr, requestEntityLink);
            for (var i = 0; i < staticPropertyCount; i++)
            {
                propertyReader.Read(reader, (PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container) => OnPropertyNameUnhashed(type, name, arraySize, container, entity, isReadingDynamicProperty), setProperty, setPropertyElementByIndex, setPropertyElementByKey);
            }

            isReadingDynamicProperty = true;
            for (var i = 0; i < dynamicPropertyCount; i++)
            {
                propertyReader.Read(reader, (PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container) => OnPropertyNameUnhashed(type, name, arraySize, container, entity, isReadingDynamicProperty), setProperty, setPropertyElementByIndex, setPropertyElementByKey);
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
    }
}
