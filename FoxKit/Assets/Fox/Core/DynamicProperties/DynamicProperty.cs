using System;
using UnityEngine;

namespace Fox.Core
{
    public abstract class DynamicProperty : MonoBehaviour
    {
        internal const string NAME_PROPERTY_NAME = nameof(Name);
        public string Name;
        
        internal const string VALUE_PROPERTY_NAME = "Value";

        internal abstract PropertyInfo.ContainerType GetContainerType();
        internal abstract PropertyInfo GetPropertyInfo();
        
        internal virtual void ChangeStaticArraySize(uint newSize) {}
        
        public abstract object GetValue();
        public virtual object GetElement(ushort index) => throw new NotImplementedException();
        public virtual object GetElement(string key) => throw new NotImplementedException();
        public abstract uint GetArraySize();

        public void SetValue(object value)
        {
            if (GetContainerType() == PropertyInfo.ContainerType.StaticArray && GetArraySize() == 1)
                SetElement(0, value);
            else
                throw new NotImplementedException();
        }
        public virtual void SetElement(ushort index, object value) => throw new NotImplementedException();
        public virtual void SetElement(string key, object value) => throw new NotImplementedException();
    }
}