using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using GzsTool.Core.Qar;
using GzsTool.Core.Utility;
using GzsTool.Core.Common;
using GzsTool.Core.Fpk;

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

            string dictPath = Path.Combine(Application.dataPath, "Plugin", "GzsTool", "qar_dictionary.txt");
            if (File.Exists(dictPath))
            {
                try { Hashing.ReadDictionary(dictPath); } catch { }
            }

            List<string> ignoredFiles = new List<string>
            {
                //"chunk0", "chunk1", "chunk2", "chunk3", "chunk4","data1",
                "e2f8e499bc8f3606", "e2f9a1fda590d087", "e2faa449a7e0781d",
                "e2fb02c35da41a21", "e2fbebbd66f86086", "texture0", "texture1",
                "texture2", "texture3", "texture4",
                //"00", "01",
            };
            List<string> ignoredExtensions = new List<string> 
            {
                ".ftex",
                ".fv2",
                ".lng2",
                ".vfx",
                ".vfxlf",
                ".pftxs",
                ".sbp",
                ".fsd",
                ".fsm",
                ".frig",
                ".sand",
                ".sim",
                ".fcnp",
                ".lpsh",
                ".grxla",
                ".frdv",
                ".ladb",
                ".mog",
                ".mtar",
                ".mtar",
                ".trap",
                ".rdf",
                ".wem",
                ".adm",
                ".fnt",
                ".ends",
                ".uigb",
                ".uilb",
                ".uia",
                ".uif",
                ".subp",
                ".nta",
                ".lba",
                ".ph",
                ".tgt",
            };

            string[] datFiles = Directory.GetFiles(masterPath, "*.dat", SearchOption.TopDirectoryOnly);
            foreach (string datFile in datFiles)
            {
                string fileNameOnly = Path.GetFileNameWithoutExtension(datFile);
                if (ignoredFiles.Contains(fileNameOnly)) continue;

                try
                {
                    using (var stream = File.OpenRead(datFile))
                    {
                        if (!QarFile.IsQarFile(stream)) continue;

                        var qar = new QarFile { Name = Path.GetFileName(datFile) };
                        stream.Position = 0;
                        qar.Read(stream);

                        var outputDir = new FileSystemDirectory(DestinationPath);

                        foreach (var file in qar.ExportFiles(stream))
                        {
                            string fullPath = Path.Combine(DestinationPath, file.FileName);
                            string relativePath = fullPath.Replace(Application.dataPath, "Assets");
                            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                            outputDir.WriteFile(file.FileName, file.DataStream);

                            if (extension == ".fpk" || extension == ".fpkd")
                            {
                                using (var fpkStream = File.OpenRead(fullPath))
                                {
                                    var fpk = new FpkFile();
                                    fpk.Read(fpkStream);

                                    var packFileList = ScriptableObject.CreateInstance<PackFileList>();
                                    packFileList.Files = new List<string>();
                                    packFileList.Data = new List<string>();
                                    packFileList.References = new List<string>();

                                    foreach (var entry in fpk.ExportFiles(fpkStream))
                                    {
                                        string entryExt = Path.GetExtension(entry.FileName).ToLowerInvariant();
                                        if (ignoredExtensions.Contains(entryExt))
                                        {
                                            Debug.Log($"[Ignored] {entry.FileName} due to extension {entryExt}");
                                            continue;
                                        }
                                        if (extension == ".fpk")
                                            packFileList.Files.Add(entry.FileName);
                                        else if (extension == ".fpkd")
                                            packFileList.Data.Add(entry.FileName);

                                        // Write extracted file
                                        string extractedPath = Path.Combine(DestinationPath, entry.FileName);
                                        string extractedDir = Path.GetDirectoryName(extractedPath);
                                        if (!Directory.Exists(extractedDir))
                                            Directory.CreateDirectory(extractedDir);

                                        using (var outStream = File.Create(extractedPath))
                                        {
                                            entry.DataStream().CopyTo(outStream);
                                        }

                                        Debug.Log($"[Unpacked {extension.ToUpper()}] {entry.FileName}");
                                    }

                                    string assetPath = Path.ChangeExtension(relativePath, "_List.asset");
                                    AssetDatabase.CreateAsset(packFileList, assetPath);
                                    AssetDatabase.SaveAssets();

                                    Debug.Log($"Created PackFileList asset: {assetPath}");
                                }
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.LogError($"Failed to process {datFile}: {ex.Message}");
                }
            }

            AssetDatabase.Refresh();
            Debug.Log("Finished extracting all .dat QAR files (excluding ignored ones).\n");
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
