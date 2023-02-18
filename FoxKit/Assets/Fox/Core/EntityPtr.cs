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

        public T Get() => _ptr;

        public void Reset(T newPtr) => _ptr = newPtr;

        public void Reset() => _ptr = null;

        public void Reset(Entity newPtr) => _ptr = (T)newPtr;

        public bool IsNull() => _ptr == null;

        Entity IEntityPtr.Get() => _ptr;

        public EntityPtr(T entity)
        {
            _ptr = entity;
        }
    }
}
