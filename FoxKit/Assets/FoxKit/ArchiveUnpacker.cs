using UnityEngine;
using UnityEditor;
using System.IO;
using Path = System.IO.Path;
using System.Collections.Generic;

using GzsTool.Core.Qar;
using GzsTool.Core.Utility;
using GzsTool.Core.Common;

namespace FoxKit.Windows
{
    public class ArchiveTransferrerWindow : EditorWindow
    {
        private FoxKitSettings settings;
        private const string settingsPath = "Assets/FoxKit/FoxKitSettings.asset";

        private string exePath;
        private string gameDir;

        private readonly string DestinationPath = Path.Combine(Application.dataPath, "Game");

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

            if (GUILayout.Button("Transfer Archive"))
            {
                TransferArchive();
                Debug.Log("Unpacking...");
            }
        }

        private void TransferArchive()
        {
            if (string.IsNullOrEmpty(gameDir))
            {
                Debug.LogError("Game directory not set. Please browse to the executable first.");
                return;
            }

            string masterPath = Path.Combine(gameDir, "master");
            if (!Directory.Exists(masterPath))
            {
                Debug.LogError($"Master folder not found at: {masterPath}");
                return;
            }

            // Load QAR dictionary for readable filenames
            string dictPath = Path.Combine(Application.dataPath, "Plugin", "GzsTool", "qar_dictionary.txt");
            if (File.Exists(dictPath))
            {
                try
                {
                    Hashing.ReadDictionary(dictPath);
                    Debug.Log("qar_dictionary.txt loaded successfully.");
                }
                catch
                {
                    Debug.LogWarning("Failed to read qar_dictionary.txt. Filenames may be hashes.");
                }
            }
            else
            {
                Debug.LogWarning("qar_dictionary.txt not found. Filenames will be hashes.");
            }

            // Add .dat filenames here that you want to ignore (no extension)
            List<string> ignoredFiles = new List<string>
    {
        "data1",
        "e2f8e499bc8f3606",
        "e2f9a1fda590d087",
        "e2faa449a7e0781d",
        "e2fb02c35da41a21",
        "e2fbebbd66f86086",
        "texture0",
        "texture1",
        "texture2",
        "texture3",
        "texture4",
    };

            string[] datFiles = Directory.GetFiles(masterPath, "*.dat", SearchOption.TopDirectoryOnly);
            if (datFiles.Length == 0)
            {
                Debug.LogError("No .dat files found in the master directory.");
                return;
            }

            Directory.CreateDirectory(DestinationPath);
            var outputDir = new FileSystemDirectory(DestinationPath);

            foreach (string datFile in datFiles)
            {
                string fileNameOnly = Path.GetFileNameWithoutExtension(datFile);
                if (ignoredFiles.Contains(fileNameOnly))
                {
                    Debug.Log($"Skipping ignored file: {fileNameOnly}.dat");
                    continue;
                }

                Debug.Log($"Processing: {datFile}");

                try
                {
                    string extension = Path.GetExtension(datFile).TrimStart('.');
                    string xmlPath = Path.Combine(DestinationPath, $"{fileNameOnly}.{extension}.xml");

                    using (var stream = File.OpenRead(datFile))
                    {
                        if (!QarFile.IsQarFile(stream))
                        {
                            Debug.LogWarning($"Not a valid QAR file: {datFile}");
                            continue;
                        }

                        var qar = new QarFile { Name = Path.GetFileName(datFile) };
                        stream.Position = 0;
                        qar.Read(stream);

                        foreach (var file in qar.ExportFiles(stream))
                        {
                            outputDir.WriteFile(file.FileName, file.DataStream);
                        }

                        using (var xmlStream = File.Create(xmlPath))
                        {
                            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(QarFile));
                            serializer.Serialize(xmlStream, qar);
                        }

                        Debug.Log($"Extracted and wrote XML for: {fileNameOnly}.dat");
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.LogError($"Failed to process {datFile}: {ex.Message}");
                }
            }

            Debug.Log("Finished extracting all .dat QAR files (excluding ignored ones).");
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
