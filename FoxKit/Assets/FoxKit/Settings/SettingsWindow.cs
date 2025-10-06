using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit
{
    public class SettingsWindow : EditorWindow
    {
        private string externalBasePath;
        private string gameDirBasePath;

        [MenuItem("FoxKit/Settings")]
        public static void ShowWindow()
        {
            SettingsWindow window = GetWindow<SettingsWindow>(true, "FoxKit Settings", true);
            window.minSize = new Vector2(400, 120);
            
            window.ShowModalUtility();
        }

        private bool ValidateCurrentSettings()
        {
            bool externalValid = !string.IsNullOrEmpty(externalBasePath) && Directory.Exists(externalBasePath);
            bool exeValid = !string.IsNullOrEmpty(gameDirBasePath) && File.Exists(gameDirBasePath);
            return externalValid && exeValid;
        }


        private void OnEnable()
        {
            externalBasePath =  SettingsManager.ExternalBasePath;
            gameDirBasePath = SettingsManager.GameDirBasePath;
            EditorApplication.update += EnforceShowWindow;
        }

        private void OnDisable()
        {
            if (!ValidateCurrentSettings())
            {
                EditorApplication.delayCall += ShowWindow;
            }

            EditorApplication.update -= EnforceShowWindow;
        }
        
        private void EnforceShowWindow()
        {
            if (EditorApplication.isPlaying || !EditorWindow.HasOpenInstances<SettingsWindow>())
            {
                EditorApplication.delayCall += ShowWindow;
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.HelpBox("These property must be set. Circumvention will cause errors.",MessageType.Warning);

            // === External Base Path ===
            EditorGUILayout.LabelField("External Base Path", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            GUI.enabled = false;
            externalBasePath = EditorGUILayout.TextField(externalBasePath);
            GUI.enabled = true;

            if (GUILayout.Button("Browse", GUILayout.MaxWidth(70)))
            {
                string selected = EditorUtility.OpenFolderPanel("Select the folder that contains the /Assets folder", "", "");
                if (!string.IsNullOrEmpty(selected))
                    externalBasePath = selected;
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(8);

            // === Game Executable Path ===
            EditorGUILayout.LabelField("Game Executable Path", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            GUI.enabled = false;
            gameDirBasePath = EditorGUILayout.TextField(gameDirBasePath);
            GUI.enabled = true;

            if (GUILayout.Button("Browse", GUILayout.MaxWidth(70)))
            {
                string selectedExe = EditorUtility.OpenFilePanel("Select the game's executable (MGSV.exe)", "", "exe");
                if (!string.IsNullOrEmpty(selectedExe))
                    gameDirBasePath = selectedExe;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);

            bool settingsValid = ValidateCurrentSettings();
            GUI.enabled = settingsValid;

            if (GUILayout.Button("Submit"))
            {
                SettingsManager.ExternalBasePath = externalBasePath;
                SettingsManager.GameDirBasePath = gameDirBasePath;

                Debug.Log($"[FoxKit] Settings saved:\nExternal: {externalBasePath}\nGameDir: {gameDirBasePath}");
                Debug.Log($"[FoxKit] Settings saved:\nEXE: {gameDirBasePath}\nGameDir: {gameDirBasePath}");
                Close();
            }

            GUI.enabled = true;
        }
    }
}