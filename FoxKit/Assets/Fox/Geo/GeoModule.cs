using Fox.Core;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.Geo
{
    [InitializeOnLoad]
    public static class GeoModule
    {
        internal static Dictionary<GeoGeom.GeoPrimType, Func<GeomHeaderContext, TransformData>> GeoPrimDeserializationMap = new();

        public static void RegisterGeomHeaderDeserializationCallback(GeoGeom.GeoPrimType type, Func<GeomHeaderContext, TransformData> deserializeFunc)
        {
            Debug.Assert(Enum.IsDefined(typeof(GeoGeom.GeoPrimType), type));
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(GeoPrimDeserializationMap.TryAdd(type, deserializeFunc));
        }

        static GeoModule()
        {
        }
    }
}
