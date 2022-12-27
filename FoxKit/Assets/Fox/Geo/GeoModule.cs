using Fox.Kernel;
using Fox.Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using Fox.Fio;
using UnityEditor;

namespace Fox.Geo
{
    [InitializeOnLoad]
    public static class GeoModule
    {
        internal static Dictionary<GeoPrimType, Func<GeomHeaderContext, TransformData>> GeoPrimDeserializationMap = new();

        public static void RegisterGeomHeaderDeserializationCallback(GeoPrimType type, Func<GeomHeaderContext, TransformData> deserializeFunc)
        {
            Debug.Assert(Enum.IsDefined(typeof(GeoPrimType), type));
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(GeoPrimDeserializationMap.TryAdd(type, deserializeFunc));
        }

        static GeoModule()
        {
        }
    }
}
