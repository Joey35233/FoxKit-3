using Fox.Core;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox.EdGameCore
{
    public struct GameObjectEditorInfo
    {
        public List<string> Presets;
        public Func<string, DataElement> CreateParameterFunc;
    }
        
    [InitializeOnLoad]
    public class EdGameCoreModule
    {
        public static List<string> GameObjectTypeList = new();
        private static Dictionary<string, GameObjectEditorInfo> GameObjectEditorInfoMap = new();
        
        public static void RegisterGameObjectEditorInfo(string type, GameObjectEditorInfo info)
        {
            GameObjectTypeList.Add(type);
            GameObjectEditorInfoMap.Add(type, info);
        }

        public static bool TryGetEditorInfoForGameObjectType(string type, out GameObjectEditorInfo info)
        {
            return GameObjectEditorInfoMap.TryGetValue(type, out info);
        }
    }
}
