using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using Fox.Core;
using Fox.Core.Utils;
using Path = System.IO.Path;
using UnityEditor.SceneManagement;
using UnityEditor.UIElements;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace FoxKit.Windows
{
    public class TerrainLoaderWindow : EditorWindow
    {
        [MenuItem("FoxKit/Terrain Loader")]
        public static void ShowWindow()
        {
            var window = GetWindow<TerrainLoaderWindow>();
            window.titleContent = new GUIContent("Terrain Loader");
        }

        private int selectedMapIndex = 0;
        private readonly string[] mapOptions = new string[] { "afgh", "mafr", "cypr", "mbqf" };

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Map Selection", EditorStyles.boldLabel);
            selectedMapIndex = EditorGUILayout.Popup("Select Map", selectedMapIndex, mapOptions);
        
            string mapName = mapOptions[selectedMapIndex];
            string previewPath = Fox.Fs.FileSystem.GetExternalPathFromVirtualPath($"/Assets/tpp/level/location/{mapName}");
            EditorGUILayout.HelpBox($"Target Map Folder:\n{previewPath}", MessageType.Info);
            EditorGUILayout.EndVertical();
        
            GUILayout.Space(10);
        
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
                    TaskLogger logger = new TaskLogger("TerrainLoader");
                    LoadMap(mapName, logger);
                    logger.LogToUnityConsole();
                }
            }
        
            if (GUILayout.Button("Open Unity Folder", GUILayout.Height(30)))
            {
                Fox.Fs.FileSystem.OpenUnityFolder();
            }
        
            EditorGUILayout.EndHorizontal();
        }

        private void LoadMap(string mapName, TaskLogger logger)
        {
            // STAGE 1: Stage
            string stageDataSetPath = $"/Assets/tpp/level/location/{mapName}/{mapName}_stage.fox2";

            ReadOnlySpan<byte> stageFileData = Fox.Fs.FileSystem.ReadExternalFile(stageDataSetPath);
            Scene stageScene = DataSetFile2.Read(stageFileData, DataSetFile2.SceneLoadMode.ForceSingle, logger);
            Fox.Fs.FileSystem.TryImportAsset(stageScene, stageDataSetPath);

            // STAGE 2: Common terrain
            string commonTerrainDataSetPath = $"/Assets/tpp/level/location/{mapName}/block_common/{mapName}_common_terrain.fox2";

            ReadOnlySpan<byte> commonTerrainFileData = Fox.Fs.FileSystem.ReadExternalFile(stageDataSetPath);
            Scene commonTerrainScene = DataSetFile2.Read(commonTerrainFileData, DataSetFile2.SceneLoadMode.Additive, logger);
            Fox.Fs.FileSystem.TryImportAsset(commonTerrainScene, commonTerrainDataSetPath);

            // STAGE 2: Terrain directory
            string baseDirectoryPath = null;
            if (StageBlockControllerData.Instance != null)
            {
                baseDirectoryPath = StageBlockControllerData.Instance.baseDirectoryPath;

                if (!string.IsNullOrEmpty(baseDirectoryPath) && baseDirectoryPath.Contains("/pack/location/"))
                {
                    baseDirectoryPath = baseDirectoryPath.Replace("/pack/location/", "/level/location/");
                    baseDirectoryPath = baseDirectoryPath.Replace("/pack_small", "/block_small");
                }
                else
                {
                    logger.AddError("Couldn't find or read baseDirectoryPath.");
                    return;
                }
            }
            else
            {
                logger.AddError("No StageBlockControllerData loaded.");
                return;
            }

            string baseDirectoryExternalPath = Fox.Fs.FileSystem.GetExternalPathFromVirtualPath(baseDirectoryPath);

            if (!Directory.Exists(baseDirectoryExternalPath))
            {
                logger.AddError($"{baseDirectoryPath} not found.");
                return;
            }

            // STAGE 3: DataSet files
            string[] terrainBlockDataSetExternalPaths = Directory.GetFiles(baseDirectoryExternalPath, "*_terrain.fox2", SearchOption.AllDirectories);

            foreach (string terrainBlockExternalPath in terrainBlockDataSetExternalPaths)
            {
                string terrainBlockDataSetPath = Fox.Fs.FileSystem.GetVirtualPathFromExternalPath(terrainBlockExternalPath);

                ReadOnlySpan<byte> terrainBlockFileData = Fox.Fs.FileSystem.ReadExternalFile(terrainBlockDataSetPath);
                Scene terrainBlockScene = DataSetFile2.Read(terrainBlockFileData, DataSetFile2.SceneLoadMode.Additive, logger);
                Fox.Fs.FileSystem.TryImportAsset(terrainBlockScene, terrainBlockDataSetPath);
            }

            // // STAGE 4: HTRE files
            // string[] externalTerrainBlockFiles = Directory.GetFiles(terrainBlockFolderExternal, "*_terrain.htre", SearchOption.AllDirectories);
            // foreach (string externalTerrainBlockPath in externalTerrainBlockFiles)
            // {
            //     string terrainBlockPath = Fox.Fs.FileSystem.GetFoxPathFromExternalPath(externalTerrainBlockPath);
            //
            //     Debug.Log($"[TerrainLoader] Importing htre from: {terrainBlockPath}");
            //
            //     string resolvedHtrePath = Fox.Fs.FileSystem.ResolvePathname(terrainBlockPath);
            //
            //     string importHtrePathDirectory = Path.GetDirectoryName(resolvedHtrePath);
            //     Directory.CreateDirectory(importHtrePathDirectory);
            //
            //     ReadOnlySpan<byte> tileData = Fox.Fs.FileSystem.ReadExternalFile(terrainBlockPath);
            //
            //     Debug.Log($"[TerrainLoader] Size: {tileData.Length} bytes");
            // }
        }
    }
}