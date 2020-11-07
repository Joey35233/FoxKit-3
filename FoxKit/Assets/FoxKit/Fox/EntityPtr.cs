using UnityEngine;

namespace Fox
{
    [System.Serializable]
    public class EntityPtr<T> where T : Entity
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
    }
}
