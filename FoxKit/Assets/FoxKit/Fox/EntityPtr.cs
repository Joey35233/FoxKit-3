using UnityEngine;

namespace Fox
{
    public interface IEntityPtr
    {
        Entity Get();
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

        Entity IEntityPtr.Get()
        {
            return this.ptr;
        }
    }
}
