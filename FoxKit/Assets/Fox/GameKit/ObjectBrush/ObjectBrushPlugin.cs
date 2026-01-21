using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class ObjectBrushPlugin
    {
        [NonSerialized]
        public List<ObrObject> Objects = new();

        void OnEnable()
        {
            
        }

        public void RegisterObject(ObrObject obj)
        {
            Objects.Add(obj);
        }

        void OnDisable()
        {
            
        }
    }
}