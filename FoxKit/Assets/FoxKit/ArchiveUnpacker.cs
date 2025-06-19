using UnityEngine;
using UnityEditor;
using System.IO; // For Path
using Path = System.IO.Path;

namespace FoxKit.Windows
{
    public class ArchiveTransferrerWindow : EditorWindow
    {
        private FoxKitSettings settings;
        private const string settingsPath = "Assets/FoxKit/FoxKitSettings.asset";

        private string exePath;
        private string gameDir;

        // Dynamically get the destination path relative to the project root
        private string DestinationPath => Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Game");

        [MenuItem("FoxKit/Archive Transferrer", false, 100)]
        public static void ShowWindow()
        {
            GetWindow<ArchiveTransferrerWindow>("Archive Transferrer");
        }

        private void OnEnable()
        {
            settings = AssetDatabase.LoadAssetAtPath<FoxKitSettings>(settingsPath);
        }

        private void OnGUI()
        {
            if (settings == null)
            {
                EditorGUILayout.HelpBox("FoxKitSettings.asset not found.", MessageType.Warning);

                if (GUILayout.Button("Create New Settings"))
                {
                    CreateSettingsAsset();
                }

                return;
            }

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("MGSV.exe Path", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();

            settings.sourceAssetsPath = EditorGUILayout.TextField(settings.sourceAssetsPath);

            if (GUILayout.Button("Browse", GUILayout.MaxWidth(70)))
            {
                exePath = EditorUtility.OpenFilePanel("Select the MGSV executable", "", "exe");

                if (!string.IsNullOrEmpty(exePath))
                {
                    gameDir = Path.GetDirectoryName(exePath);
                    settings.sourceAssetsPath = exePath;

                    EditorUtility.SetDirty(settings);
                    AssetDatabase.SaveAssets();

                    Debug.Log($"Executable path: {exePath}");
                    Debug.Log($"Game directory: {gameDir}");
                    Debug.Log($"Destination path: {DestinationPath}");
                }
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

            // Optional: Save button if you want explicit user action
            if (GUILayout.Button("Transfer Archive"))
            {
                Debug.Log("Unpacking...");
            }
        }

        private void CreateSettingsAsset()
        {
            var asset = ScriptableObject.CreateInstance<FoxKitSettings>();
            AssetDatabase.CreateAsset(asset, settingsPath);
            AssetDatabase.SaveAssets();
            settings = asset;
            Selection.activeObject = asset;
        }
    }
}
