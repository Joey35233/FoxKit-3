using UnityEditor;
using UnityEngine;

namespace FoxKit
{
    [InitializeOnLoad]
    public static class SettingsManager
    {
        // Properties
        public static string UnityBasePath = "Assets/Game";
        public static string ExternalBasePath { get => EditorPrefs.GetString("FoxKit.ExternalBasePath"); internal set => EditorPrefs.SetString("FoxKit.ExternalBasePath", value); }
        public static string GameDirBasePath { get => EditorPrefs.GetString("FoxKit.GameDirBasePath"); internal set => EditorPrefs.SetString("FoxKit.GameDirBasePath", value); }
        public static string LooseBasePath = "Assets/GameTest";

        static SettingsManager()
        {
            EditorApplication.update += ValidateSettingsOnEditorReload;
        }

        private static void ValidateSettingsOnEditorReload()
        {
            EditorApplication.update -= ValidateSettingsOnEditorReload;

            if (!ValidateSettings())
            {
                ShowSettingsWindow();
            }
        }

        public static bool ValidateSettings()
        {
            string unityBasePath = UnityBasePath;
            bool unityBasePathValid = System.IO.Directory.Exists(unityBasePath);
            bool externalBasePathValid = System.IO.Directory.Exists(ExternalBasePath);
            bool gameDirBasePathValid = System.IO.Directory.Exists(GameDirBasePath);
            bool looseBasePathValid = System.IO.Directory.Exists(LooseBasePath);
            return unityBasePathValid && externalBasePathValid && looseBasePathValid;
        }

        public static void ShowSettingsWindow()
        {
            // When creating code, ChatGPT suggested this delayCall - the logic is presumably that the editor will be entirely black otherwise
            EditorApplication.delayCall += SettingsWindow.ShowWindow;
        }
    }
}