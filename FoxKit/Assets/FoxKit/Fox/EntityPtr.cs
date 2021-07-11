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
    public class EntityPtr<T> : IEntityPtr where T : Entity
    {
        public string InspectorTest;

        [SerializeReference]
        private T ptr;

        public T Get()
        {
            return this.ptr;
        }

        public void Reset(T newPtr)
        {
            this.ptr = newPtr;
        }

        public void Reset()
        {
            this.ptr = null;
        }

        public void Reset(Entity newPtr)
        {
            this.ptr = (T)newPtr;
        }

        Entity IEntityPtr.Get()
        {
            return this.ptr;
        }
    }
}
