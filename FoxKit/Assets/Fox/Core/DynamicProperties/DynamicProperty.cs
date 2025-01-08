using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Core
{
    public abstract class DynamicProperty : MonoBehaviour

    {
        internal const string NAME_PROPERTY_NAME = nameof(Name);
        public string Name;

        internal abstract PropertyInfo GetPropertyInfo();
        internal virtual bool IsStaticArrayOverride() => false;
        internal virtual void ChangeStaticArraySize(uint newSize) {}
        
        internal const string VALUE_PROPERTY_NAME = "SerializedField";
        public abstract Value GetValue();
    }
}