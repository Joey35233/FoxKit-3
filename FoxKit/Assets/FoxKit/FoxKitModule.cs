using System.Collections.Generic;
using System.IO;
using Fox;
using Fox.Fs;
using Fox.GameService;
using UnityEditor;
using UnityEngine;

namespace FoxKit
{
    public static class FoxKitModule
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            FsModule.UnityBasePath = SettingsManager.UnityBasePath;
            FsModule.ExternalBasePath = SettingsManager.ExternalBasePath;
            FsModule.LooseBasePath = SettingsManager.LooseBasePath;
            
            RegisterDictionaries();
        }

        private static void RegisterDictionaries()
        {
            GameServiceModule.RegisterRouteIdMap("Assets/FoxKit/Dictionaries/route_ids");
        }
    }
}