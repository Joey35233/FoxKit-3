using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit
{
    public class SettingsWindow : EditorWindow
    {
        private string externalBasePath;
        
        [MenuItem("FoxKit/Settings")]
        public static void ShowWindow()
        {
            SettingsWindow window = GetWindow<SettingsWindow>(true, "FoxKit Settings", true);
            window.minSize = new Vector2(400, 120);
            
            window.ShowModalUtility();
        }

        private bool ValidateCurrentSettings() => Directory.Exists(externalBasePath);

        private void OnEnable()
        {
            externalBasePath =  SettingsManager.ExternalBasePath;
            
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
            EditorGUILayout.LabelField("External Base Path", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("This property must be set. Circumvention will cause errors.", MessageType.Error);
            
            EditorGUILayout.BeginHorizontal();
            GUI.enabled = false;
            externalBasePath = EditorGUILayout.TextField(externalBasePath);
            GUI.enabled = true;
        
            if (GUILayout.Button("Browse", GUILayout.MaxWidth(70)))
            {
                externalBasePath = EditorUtility.OpenFolderPanel("Select the folder that contains the /Assets folder", "", "");
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

            if (ValidateCurrentSettings())
            {
                bool shouldSubmit = GUILayout.Button("Submit");
                if (shouldSubmit)
                {
                    SettingsManager.ExternalBasePath = externalBasePath;
                    
                    Close();
                }
            }
        }
    }
}