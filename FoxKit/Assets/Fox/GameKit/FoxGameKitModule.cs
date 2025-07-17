using Fox.Fio;
using Fox;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    [InitializeOnLoad]
    public static class FoxGameKitModule
    {
        internal static Dictionary<StrCode32, Func<FileStreamReader, ObjectBrushPlugin>> ObjBrushPluginDeserializationMap = new();

        public static void RegisterObjBrushPluginDeserializationCallback(StrCode32 name, Func<FileStreamReader, ObjectBrushPlugin> deserializeFunc)
        {
            Debug.Assert(name != null);
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(ObjBrushPluginDeserializationMap.TryAdd(name, deserializeFunc));
        }

        static FoxGameKitModule()
        {
        }
    }
}
