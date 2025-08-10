using Fox.Fs;
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
        }
    }
}