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
            return unityBasePathValid && externalBasePathValid;
        }

        public static void ShowSettingsWindow()
        {
            // When creating code, ChatGPT suggested this delayCall - the logic is presumably that the editor will be entirely black otherwise
            EditorApplication.delayCall += SettingsWindow.ShowWindow;
        }
    }
}