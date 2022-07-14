using System;
using UnityEngine;

namespace Fox.Core
{
    public interface IEntityPtr
    {
        Entity Get();
        void Reset(Entity newPtr);
        void Reset();
    }

    [System.Serializable]
    public struct EntityPtr<T> : IEntityPtr where T : Entity
    {
        [SerializeReference]
        private T _ptr;

        public T Get()
        {
            return this._ptr;
        }

        public void Reset(T newPtr)
        {
            this._ptr = newPtr;
        }

        public void Reset()
        {
            this._ptr = null;
        }

        public void Reset(Entity newPtr)
        {
            this._ptr = (T)newPtr;
        }

        Entity IEntityPtr.Get()
        {
            return this._ptr;
        }

        public EntityPtr(T entity)
        {
            this._ptr = entity;
        }
    }
}
