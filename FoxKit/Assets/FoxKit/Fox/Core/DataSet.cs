using System;
using UnityEngine;

namespace Fox.Core
{
    public partial class DataSet : Fox.Core.Data
    {
        public StringMap<EntityHandle> allocatedEntities { get; private set; } = new StringMap<EntityHandle>();

        public EntityPtr<T> AllocateEntity<T>() where T : Entity, new()
        {
            var entity = new T();

            if (entity is Data)
                (entity as Data).SetProperty("dataSet", new Value(EntityHandle.Get(this)));

            return new EntityPtr<T>(entity);
        }
    }
}