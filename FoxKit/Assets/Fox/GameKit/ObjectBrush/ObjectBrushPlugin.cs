using System;
using System.Collections.Generic;

namespace Fox.GameKit
{
    public partial class ObjectBrushPlugin
    {
        [NonSerialized]
        public List<ObjectBrushObject> Objects = new();
        
        public void RegisterObject(ObjectBrushObject obj)
        {
            Objects.Add(obj);
        }
    }
}