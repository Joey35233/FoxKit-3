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

        private static readonly Dictionary<StrCode32, string> StringTable = new();

        public static void RegisterRouteDataEventDeserializationCallback(StrCode32 id, Func<GameObject, uint[], GsRouteDataRouteEvent> deserializeFunc)
        {
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(GsRouteDataEventDeserializationMap.TryAdd(id, deserializeFunc));
        }

        public static void RegisterString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return;

            StringTable[new StrCode32(str)] = str;
        }

        public static bool IsStringKnown(StrCode32 hash) => StringTable.ContainsKey(hash);

        public static string Resolve(StrCode32 hash)
        {
            if (StringTable.TryGetValue(hash, out string str))
                return str;

            return hash.ToString();
        }

        static GameServiceModule()
        {
        }
    }
}
