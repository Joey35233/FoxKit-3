using System;
using System.Collections.Generic;

namespace Fox.GameKit
{
    public partial class ObjectBrushPlugin
    {
        [NonSerialized]
        public List<ObrObject> Objects = new();
        public void RegisterObject(ObrObject obj)
        {
            Objects.Add(obj);
        }
    }
}