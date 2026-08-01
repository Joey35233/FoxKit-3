using System;
using UnityEngine;

namespace Fox.Core
{
    public abstract class DynamicProperty : MonoBehaviour
    {
        internal const string NAME_PROPERTY_NAME = nameof(Name);
        public string Name;
        
        internal const string VALUE_PROPERTY_NAME = "SerializedField";

        internal abstract PropertyInfo.ContainerType GetContainerType();
        internal abstract PropertyInfo GetPropertyInfo();
        
        internal virtual void ChangeStaticArraySize(uint newSize) {}
        
        public abstract Value GetValue();
        public virtual Value GetElement(int index) => throw new NotImplementedException();
        public virtual Value GetElement(string key) => throw new NotImplementedException();
        
        public virtual void SetElement(int index, Value value) => throw new NotImplementedException();
        public virtual void SetElement(string key, Value value) => throw new NotImplementedException();
        public virtual void AddElement(int index, Value value) => throw new NotImplementedException();
        public virtual void AddElement(string key, Value value) => throw new NotImplementedException();
        public virtual void RemoveElement(int index) => throw new NotImplementedException();
        public virtual void RemoveElement(string key) => throw new NotImplementedException();
    }
}