using Fox.Core.Serialization;
using Fox.Core.Utils;
using Fox.Fio;
using Fox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using static Fox.Core.Serialization.DataSetFile2PropertyReader;

namespace Fox.Core
{
    public struct AddressedEntity
    {
        public ulong Address;
        public Entity Entity;
    }

    public class DataSetFile2AddressedEntityReader
    {
        private readonly RequestSetEntityPtr requestSetEntityPtr;
        private readonly RequestSetEntityHandle requestSetEntityHandle;
        private readonly IDictionary<TransformData, TransformData> childToParentTransformDataMap;
        private readonly TaskLogger logger;

        public DataSetFile2AddressedEntityReader(RequestSetEntityPtr requestSetEntityPtr,
            RequestSetEntityHandle requestSetEntityHandle,
            IDictionary<TransformData, TransformData> childToParentTransformDataMap,
            TaskLogger logger)
        {
            this.requestSetEntityPtr = requestSetEntityPtr ?? throw new ArgumentNullException(nameof(requestSetEntityPtr));
            this.requestSetEntityHandle = requestSetEntityHandle ?? throw new ArgumentNullException(nameof(requestSetEntityHandle));
            this.childToParentTransformDataMap = childToParentTransformDataMap;
            this.logger = logger;
        }

        public AddressedEntity Read(FileStreamReader reader, UnityEngine.GameObject gameObject, Func<StrCode, string> unhashString)
        {
            ushort headerSize = reader.ReadUInt16();
            Debug.Assert(headerSize == 0x40);
            reader.BaseStream.Position -= 2;

            byte[] headerBytes = reader.ReadBytes(headerSize);
            int classId = BitConverter.ToInt32(headerBytes, 4);
            uint ent_cString = BitConverter.ToUInt32(headerBytes, 6);
            Debug.Assert(ent_cString == 0x00746E65); // "ent\0"
            ulong address = BitConverter.ToUInt64(headerBytes, 10);
            ulong id = BitConverter.ToUInt64(headerBytes, 18);
            ushort version = BitConverter.ToUInt16(headerBytes, 26);
            var classNameHash = Fox.HashingBitConverter.ToStrCode(headerBytes, 28);
            ushort staticPropertyCount = BitConverter.ToUInt16(headerBytes, 36);
            ushort dynamicPropertyCount = BitConverter.ToUInt16(headerBytes, 38);

            var entityInfo = EntityInfo.GetEntityInfo(classNameHash.ToString());
            var entity = gameObject.AddComponent(entityInfo.Type) as Entity;
            
            SetProperty setProperty = (propertyName, val) => SetProperty(entity, propertyName, val);
            SetPropertyElementByIndex setPropertyElementByIndex = entity.SetPropertyElement;
            SetPropertyElementByKey setPropertyElementByKey = entity.SetPropertyElement;

            var propertyReader = new DataSetFile2PropertyReader(unhashString, requestSetEntityPtr, requestSetEntityHandle, logger);
            for (int i = 0; i < staticPropertyCount; i++)
            {
                propertyReader.Read(reader,
                    setProperty,
                    setPropertyElementByIndex,
                    setPropertyElementByKey);
            }

            for (int i = 0; i < dynamicPropertyCount; i++)
            {
                propertyReader.ReadDynamic(reader,
                    setPropertyElementByIndex,
                    setPropertyElementByKey,
                    (type, name, arraySize, container) => OnPropertyNameUnhashed(type, name, arraySize, container, entity));
            }

            return new AddressedEntity { Address = address, Entity = entity };
        }

        private void SetProperty(Entity entity, string propertyName, Value val)
        {
            entity.SetProperty(propertyName, val);

            // Handle special cases
            if (entity is not TransformData)
            {
                return;
            }

            if (propertyName == "parent")
            {
                if (val is null)
                {
                    return;
                }

                TransformData parentEntity = val.GetValueAsEntityPtr<TransformData>();
                if (parentEntity is null)
                {
                    return;
                }

                childToParentTransformDataMap.Add(entity as TransformData, parentEntity);
            }
        }

        private static DynamicProperty OnPropertyNameUnhashed(PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container, Entity entity)
        {
            return entity.AddDynamicProperty(type, name, arraySize, container);
        }
    }
}
