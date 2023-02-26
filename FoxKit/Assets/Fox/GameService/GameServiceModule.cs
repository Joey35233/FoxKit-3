using Fox.Fio;
using Fox.Kernel;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.GameService
{
    [InitializeOnLoad]
    public static class GameServiceModule
    {
        internal static Dictionary<StrCode32, Func<FileStreamReader, GsRouteDataRouteEvent>> GsRouteDataEventDeserializationMap = new();

        public static void RegisterRouteDataEventDeserializationCallback(StrCode32 id, Func<FileStreamReader, GsRouteDataRouteEvent> deserializeFunc)
        {
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(GsRouteDataEventDeserializationMap.TryAdd(id, deserializeFunc));
        }

        static GameServiceModule()
        {
        }
    }
}
