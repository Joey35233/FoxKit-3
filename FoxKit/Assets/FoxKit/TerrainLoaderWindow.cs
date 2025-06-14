using UnityEngine;
using UnityEditor;
using System.IO;
using Fox.Core;
using Fox.Core.Utils;
using File = System.IO.File;
using Path = System.IO.Path;
using UnityEditor.SceneManagement;

namespace FoxKit.Windows
{
    public class TerrainLoaderWindow : EditorWindow
    {
        private FoxKitSettings settings;
        private const string settingsPath = "Assets/FoxKit/FoxKitSettings.asset";

        private bool importFox2Tiles = true;
        private bool importHtreTiles = true;

        [MenuItem("FoxKit/Terrain Loader")]
        public static void ShowWindow()
        {
            var window = GetWindow<TerrainLoaderWindow>();
            window.titleContent = new GUIContent("Terrain Loader");
        }

        private void OnEnable()
        {
            // Load the settings asset from a known path
            settings = AssetDatabase.LoadAssetAtPath<FoxKitSettings>(settingsPath);
        }

        private int selectedMapIndex = 0;
        private readonly string[] mapOptions = new string[] { "afgh", "mafr", "cypr", "mbqf" };

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

            // === Source Assets Path ===
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Source Assets Path", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();

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
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);

            // === Map Selection ===
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Map Selection", EditorStyles.boldLabel);
            selectedMapIndex = EditorGUILayout.Popup("Select Map", selectedMapIndex, mapOptions);

            // Show preview of selected map path
            string mapName = mapOptions[selectedMapIndex];
            string previewPath = Path.Combine(settings.sourceAssetsPath, "Assets", "tpp", "level", "location", mapName);
            EditorGUILayout.HelpBox($"Target Map Folder:\n{previewPath}", MessageType.Info);
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);

            // === Import Options ===
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Import Options", EditorStyles.boldLabel);
            importFox2Tiles = EditorGUILayout.Toggle("Import *.fox2 Tiles", importFox2Tiles);
            importHtreTiles = EditorGUILayout.Toggle("Import *.htre Files", importHtreTiles);
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);

            // === Action Buttons ===
            GUI.enabled = !string.IsNullOrEmpty(settings.sourceAssetsPath) && Directory.Exists(settings.sourceAssetsPath);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Load Map", GUILayout.Height(30)))
            {
                bool confirmed = EditorUtility.DisplayDialog(
                    "Confirm Load",
                    "This might take a while, are you sure?",
                    "Yes",
                    "No"
                );

                if (confirmed)
                {
                    LoadMap(mapName);
                }
            }

            if (GUILayout.Button("Open Output Folder", GUILayout.Height(30)))
            {
                EditorUtility.RevealInFinder("Assets/Game");
            }

            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;
        }




        private void LoadMap(string mapName)
        {
            Debug.Log($"[TerrainLoader] Loading map: {mapName}");

            // Build path to the stage.fox2  
            string stagePath = Path.Combine(settings.sourceAssetsPath, "Assets", "tpp", "level", "location", mapName, $"{mapName}_stage.fox2");

            if (!File.Exists(stagePath))
            {
                Debug.LogError("[TerrainLoader] Stage file not found.");
                return;
            }

            var stageScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            stageScene.name = $"{mapName}_stage.fox2";
            
            var fox2Reader = new DataSetFile2Reader();
            byte[] stageFileData = File.ReadAllBytes(stagePath);
            
            _ = fox2Reader.Read(stageFileData, new TaskLogger("StageLoader"));
            
            string stageScenePath = $"Assets/Scenes/{mapName}_Terrain/{mapName}_Stage.unity";
            
            string directory = Path.GetDirectoryName(stageScenePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            EditorSceneManager.SaveScene(stageScene, stageScenePath);


            // Find the baseDirectoryPath from StageBlockControllerData  
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

            // Turn the virtual path into an actual file path  
            string folderRelative = baseDirectoryPath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
            string fullTerrainFolder = Path.Combine(settings.sourceAssetsPath, folderRelative);

            Debug.Log($"[TerrainLoader] Importing: {folderRelative}");

            if (!Directory.Exists(fullTerrainFolder))
            {
                Debug.LogError("[TerrainLoader] Terrain folder doesn't exist: " + fullTerrainFolder);
                return;
            }
            
            // Import {location}_common_terrain.fox2
            string commonTerrainPath = Path.Combine(settings.sourceAssetsPath, "Assets", "tpp", "level", "location", $"{mapName}", "block_common", $"{mapName}_common_terrain.fox2");
            Debug.Log($"[TerrainLoader] Importing: {commonTerrainPath}");
            
            if (File.Exists(commonTerrainPath))
            {
                var commonTerrainScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                commonTerrainScene.name = $"{mapName}_CommonTerrain";
            
                var commonTerrainData = File.ReadAllBytes(commonTerrainPath);
                _ = fox2Reader.Read(commonTerrainData, new TaskLogger("CommonTerrainLoader"));
            
                string commonTerrainScenePath = $"Assets/Scenes/{mapName}/{mapName}_CommonTerrain.unity";
                EditorSceneManager.SaveScene(commonTerrainScene, commonTerrainScenePath);
            }
            
            else
            {
                Debug.LogWarning("[TerrainLoader] Common terrain file not found.");
            }
            
            // Find only *_terrain.fox2 files  
            string[] terrainFox2Files = Directory.GetFiles(fullTerrainFolder, "*_terrain.fox2", SearchOption.AllDirectories);
            
            Debug.Log($"[TerrainLoader] Found {fullTerrainFolder}");
            Debug.Log($"[TerrainLoader] Found {terrainFox2Files.Length} terrain tile FOX2 files.");

            // Import each terrain fox2 tile  
            if (importFox2Tiles)
            {
                foreach (string path in terrainFox2Files)
                {
                    Debug.Log($"[TerrainLoader] Importing: {path}");

                    var logger = new TaskLogger("TileImport");

                    var tileScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                    tileScene.name = Path.GetFileNameWithoutExtension(path);

                    byte[] tileData = File.ReadAllBytes(path);
                    _ = fox2Reader.Read(tileData, logger);

                    string tileScenePath = $"Assets/Scenes/{mapName}_Terrain/{Path.GetFileNameWithoutExtension(path)}.unity";
                    Directory.CreateDirectory(Path.GetDirectoryName(tileScenePath));

                    EditorSceneManager.SaveScene(tileScene, tileScenePath);
                    Debug.Log($"[TerrainLoader] Saved scene: {tileScenePath}");

                    logger.LogToUnityConsole();
                }
            }

            if (importHtreTiles)
            {
                string[] terrainHtreFiles = Directory.GetFiles(fullTerrainFolder, "*_terrain.htre", SearchOption.AllDirectories);
                foreach (string sourcePath in terrainHtreFiles)
                {
                    Debug.Log($"[TerrainLoader] Importing htre from: {sourcePath}");

                    // Find relative path from "Assets\tpp"
                    string relativePath = sourcePath.Substring(sourcePath.IndexOf("Assets\\tpp"));

                    // Build the destination path
                    string destinationPath = Path.Combine(@"Assets/Game", relativePath);

                    // Ensure destination directory exists
                    string destinationDir = Path.GetDirectoryName(destinationPath);
                    Directory.CreateDirectory(destinationDir);

                    // Copy the file
                    File.Copy(sourcePath, destinationPath, overwrite: true);

                    Debug.Log($"[TerrainLoader] Pasted at: {destinationPath}");
                }
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