using Fox.Core;
using System;
using System.Collections.Generic;

namespace Fox.EdGameCore
{
    public struct GameObjectEditorInfo
    {
        public List<string> Presets;

        public uint groupId;
        public uint totalCount;
        public uint realizedCount;

        public bool canCreateLocator;

        public Func<string, DataElement> CreateParameterFunc;
        public Func<string, DataElement> CreateLocatorParameterFunc;
    }

    public class EdGameCoreModule : Module
    {
        public static EdGameCoreModule Instance { get; private set; }

        public static List<string> GameObjectTypeList = new();
        private static Dictionary<string, GameObjectEditorInfo> GameObjectEditorInfoMap = new();

        public EdGameCoreModule() : base("Fox.EdGameCore")
        {
            Instance = this;
        }

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
