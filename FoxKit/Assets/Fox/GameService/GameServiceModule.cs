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
        internal static Dictionary<StrCode32, Type> RouteEdgeEventMap = new();
        internal static Dictionary<StrCode32, Type> RouteNodeEventMap = new();

        internal static StringId32Map RouteIdMap = null;

        public static void RegisterRouteEdgeEvent(StrCode32 id, Type type)
        {
            Debug.Assert(RouteEdgeEventMap.TryAdd(id, type));
        }

        public static void RegisterRouteNodeEvent(StrCode32 id, Type type)
        {
            Debug.Assert(RouteNodeEventMap.TryAdd(id, type));
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
