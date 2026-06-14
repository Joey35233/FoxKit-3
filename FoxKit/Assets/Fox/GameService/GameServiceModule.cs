using Fox.Fio;
using Fox;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.GameService
{
    [InitializeOnLoad]
    public static class GameServiceModule
    {
        internal static Dictionary<StrCode32, Func<GameObject, uint[], GsRouteDataRouteEvent>> GsRouteDataEventDeserializationMap = new();

        internal static StringId32Map RouteIdMap = null;

        public static void RegisterRouteDataEventDeserializationCallback(StrCode32 id, Func<GameObject, uint[], GsRouteDataRouteEvent> deserializeFunc)
        {
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(GsRouteDataEventDeserializationMap.TryAdd(id, deserializeFunc));
        }

        public static void RegisterRouteIdMap(string dictionaryPath)
        {
            RouteIdMap = new StringId32Map(dictionaryPath);
        }

        static GameServiceModule()
        {
        }
    }
}
