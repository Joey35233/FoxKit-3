using UnityEngine;
using UnityEditor;
using System.IO;
using Fox.Fio;
using Fox.Core;
using Fox.Core.Utils;
using File = System.IO.File;
using Path = System.IO.Path;
using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

namespace FoxKit.Windows
{
    public class TerrainLoaderWindow : EditorWindow
    {
        private FoxKitSettings settings;
        private const string settingsPath = "Assets/FoxKit/FoxKitSettings.asset";

        [MenuItem("FoxKit/Terrain Loader")]
        public static void ShowWindow()
        {
            GetWindow<TerrainLoaderWindow>("Terrain Loader");
        }

        private void OnEnable()
        {
            // Load the settings asset from a known path
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

            EditorGUILayout.LabelField("Source Assets Path:");
            EditorGUILayout.BeginHorizontal();

            // Show current path
            settings.sourceAssetsPath = EditorGUILayout.TextField(settings.sourceAssetsPath);

            if (GUILayout.Button("Browse", GUILayout.MaxWidth(70)))
            {
                string selectedPath = EditorUtility.OpenFolderPanel("Select the folder that contains the MGSV Assets Folder", "", "");

                if (!string.IsNullOrEmpty(selectedPath))
                {
                    settings.sourceAssetsPath = selectedPath;
                    EditorUtility.SetDirty(settings);
                }
            }

            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Load afgh"))
            {
                LoadMap("afgh");
            }
            else if (GUILayout.Button("Load mafr"))
            {
                LoadMap("mafr");
            }
            else if (GUILayout.Button("Load cypr"))
            {
                LoadMap("cypr");
            }
            else if (GUILayout.Button("Load mbqf"))
            {
                LoadMap("mbqf");
            }
        }


        private void LoadMap(string mapName)
        {
            Debug.Log($"[TerrainLoader] Loading map: {mapName}");

            // Step 1: Build path to the stage.fox2  
            string stagePath = Path.Combine(settings.sourceAssetsPath, "Assets", "tpp", "level", "location", mapName, $"{mapName}_stage.fox2");

            if (!File.Exists(stagePath))
            {
                Debug.LogError("[TerrainLoader] Stage file not found.");
                return;
            }

            // Step 2: Load that fox2  
            var fox2Reader = new DataSetFile2Reader();
            byte[] stageFileData = File.ReadAllBytes(stagePath);
            _ = fox2Reader.Read(stageFileData, new TaskLogger("StageLoader"));

            // Step 3: Find the baseDirectoryPath from StageBlockControllerData  
            string baseDirectoryPath = null;
            if (StageBlockControllerData.Instance != null)
            {
                baseDirectoryPath = StageBlockControllerData.Instance.baseDirectoryPath;

                // Fix the virtual path to real path if needed  
                if (baseDirectoryPath != null && baseDirectoryPath.Contains("/pack/location/"))
                {
                    baseDirectoryPath = baseDirectoryPath.Replace("/pack/location/", "/level/location/");
                    baseDirectoryPath = baseDirectoryPath.Replace("/pack_small", "/block_small");
                }
                else
                {
                    Debug.LogError("[TerrainLoader] Couldn't find or read baseDirectoryPath.");
                    return;
                }
            }

            // Step 4: Turn the virtual path into an actual file path  
            string folderRelative = baseDirectoryPath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
            string fullTerrainFolder = Path.Combine(settings.sourceAssetsPath, folderRelative);

            if (!Directory.Exists(fullTerrainFolder))
            {
                Debug.LogError("[TerrainLoader] Terrain folder doesn't exist: " + fullTerrainFolder);
                return;
            }

            // Step 5: Find only *_terrain.fox2 files  
            string[] terrainFox2Files = Directory.GetFiles(fullTerrainFolder, "*_terrain.fox2", SearchOption.AllDirectories);
            Debug.Log($"[TerrainLoader] Found {terrainFox2Files.Length} terrain tile FOX2 files.");

            // Step 6: Import each terrain tile  
            foreach (string path in terrainFox2Files)
            {
                Debug.Log($"[TerrainLoader] Importing: {path}");

                var logger = new TaskLogger("TileImport");

                UnityEngine.SceneManagement.Scene tileScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                tileScene.name = Path.GetFileNameWithoutExtension(path);

                byte[] tileData = File.ReadAllBytes(path);
                _ = fox2Reader.Read(tileData, logger);

                // Save the scene for this tile  
                string tileScenePath = $"Assets/Scenes/{mapName}_TerrainBlock/{Path.GetFileName(path)}.unity";
                Directory.CreateDirectory(Path.GetDirectoryName(tileScenePath));

                EditorSceneManager.SaveScene(tileScene, tileScenePath);
                Debug.Log($"[TerrainLoader] Saved scene: {tileScenePath}");

                logger.LogToUnityConsole();
            }

            Debug.Log("[TerrainLoader] Done loading all tiles.");
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