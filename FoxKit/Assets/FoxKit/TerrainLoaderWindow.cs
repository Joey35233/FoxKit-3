using UnityEngine;
using UnityEditor;
using System.IO;
using Fox.Core;
using Fox.Core.Utils;
using File = System.IO.File;
using Path = System.IO.Path;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace FoxKit.Windows
{
    public class TerrainLoaderWindow : EditorWindow
    {
        private FoxKitSettings settings;
        private const string settingsPath = "Assets/FoxKit/FoxKitSettings.asset";

        [MenuItem("FoxKit/Terrain Loader")]
        public static void ShowWindow()
        {
            var window = GetWindow<TerrainLoaderWindow>();
            window.titleContent = new GUIContent("Terrain Loader");
        }

        private void OnEnable()
        {
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

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Map Selection", EditorStyles.boldLabel);
            selectedMapIndex = EditorGUILayout.Popup("Select Map", selectedMapIndex, mapOptions);

            string mapName = mapOptions[selectedMapIndex];
            string previewPath = $"{settings.sourceAssetsPath}/Assets/tpp/level/location/{mapName}";
            EditorGUILayout.HelpBox($"Target Map Folder:\n{previewPath}", MessageType.Info);
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);

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

        private void TryCreateSceneFile(Scene scene, string path)
        {
            string scenePath = Fox.Fs.FileSystem.ResolvePathname(path);
            
            string directory = Path.GetDirectoryName(scenePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            EditorSceneManager.SaveScene(scene, scenePath);
        }

        // private void TryCreateForDirectory(string path)
        // {
        //     
        // }

        private void LoadMap(string mapName)
        {
            Debug.Log($"[TerrainLoader] Loading map: {mapName}");

            // STAGE 1: Stage
            string stageDataSetName = $"{mapName}_stage.fox2";
            string stagePath = $"/Assets/tpp/level/location/{mapName}/{stageDataSetName}";
            string stageSourcePath = settings.sourceAssetsPath + stagePath;

            if (!File.Exists(stageSourcePath))
            {
                Debug.LogError($"[TerrainLoader] Stage file not found at {stagePath}");
                return;
            }

            var stageScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            stageScene.name = stageDataSetName;

            var fox2Reader = new DataSetFile2Reader();
            byte[] stageFileData = File.ReadAllBytes(stageSourcePath);
            _ = fox2Reader.Read(stageFileData, new TaskLogger(stagePath));

            TryCreateSceneFile(stageScene, stagePath);

            // STAGE 2: Common terrain
            string commonTerrainDataSetName = $"{mapName}_common_terrain.fox2";
            string commonTerrainPath = $"/Assets/tpp/level/location/{mapName}/block_common/{commonTerrainDataSetName}";
            string commonTerrainSourcePath = settings.sourceAssetsPath + commonTerrainPath;

            if (File.Exists(commonTerrainSourcePath))
            {
                Debug.Log($"[TerrainLoader] Importing: {commonTerrainPath}");
                
                var commonTerrainScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                commonTerrainScene.name = commonTerrainDataSetName;

                var commonTerrainData = File.ReadAllBytes(commonTerrainSourcePath);
                _ = fox2Reader.Read(commonTerrainData, new TaskLogger(commonTerrainPath));

                TryCreateSceneFile(commonTerrainScene, commonTerrainPath);
            }
            else
            {
                Debug.LogWarning($"[TerrainLoader] {commonTerrainPath} not found.");
                return;
            }

            // STAGE 2: Terrain directory
            string baseDirectoryPath = null;
            if (StageBlockControllerData.Instance != null)
            {
                baseDirectoryPath = StageBlockControllerData.Instance.baseDirectoryPath;

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
            else
            {
                Debug.LogError("[TerrainLoader] No StageBlockControllerData loaded.");
                return;
            }
            
            string terrainBlockFolder = baseDirectoryPath;
            string sourceTerrainBlockFolder = settings.sourceAssetsPath + terrainBlockFolder;

            if (!Directory.Exists(sourceTerrainBlockFolder))
            {
                Debug.LogError($"[TerrainLoader] {terrainBlockFolder} not found.");
                return;
            }

            // STAGE 3: DataSet files
            string[] terrainFox2Files = Directory.GetFiles(sourceTerrainBlockFolder, "*_terrain.fox2", SearchOption.AllDirectories);

            foreach (string sourceTilePath in terrainFox2Files)
            {
                string tilePath = Fox.Fs.FileSystem.GetRelativeToBasePath(settings.sourceAssetsPath, sourceTilePath);
                
                Debug.Log($"[TerrainLoader] Importing: {tilePath}");

                var logger = new TaskLogger(tilePath);
                string tileDataSetName = Path.GetFileNameWithoutExtension(sourceTilePath);

                Scene tileScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                tileScene.name = tileDataSetName;

                byte[] tileData = File.ReadAllBytes(sourceTilePath);
                _ = fox2Reader.Read(tileData, logger);
                
                TryCreateSceneFile(tileScene, tilePath);

                logger.LogToUnityConsole();
            }

            // STAGE 4: HTRE files
            string[] sourceTerrainHtreFiles = Directory.GetFiles(sourceTerrainBlockFolder, "*_terrain.htre", SearchOption.AllDirectories);
            foreach (string sourceHtrePath in sourceTerrainHtreFiles)
            {
                string htrePath = Fox.Fs.FileSystem.GetRelativeToBasePath(settings.sourceAssetsPath, sourceHtrePath);
                
                Debug.Log($"[TerrainLoader] Importing htre from: {htrePath}");
                
                string resolvedHtrePath = Fox.Fs.FileSystem.ResolvePathname(htrePath);

                string importHtrePathDirectory = Path.GetDirectoryName(resolvedHtrePath);
                Directory.CreateDirectory(importHtrePathDirectory);

                byte[] htreData = File.ReadAllBytes(sourceHtrePath);

                Debug.Log($"[TerrainLoader] Size: {htreData.Length} bytes");
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