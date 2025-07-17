using UnityEditor;
using UnityEngine;

namespace FoxKit
{
    public static class FoxKitModule
    {
        [InitializeOnLoadMethod]
        private static void RegisterConfig()
        {
            Fox.Fs.FsConfig fsConfig = AssetDatabase.LoadAssetAtPath<Fox.Fs.FsConfig>("Assets/FoxKit/Settings/FsConfig.asset");
            Fox.Fs.FsModule.RegisterFsConfigAsset(fsConfig);
        }
    }
}