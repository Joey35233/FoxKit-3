using System.Collections.Generic;
using Fox.Core.Utils;
using Fox.Fs;
using UnityEditor;
using UnityEngine;

namespace Fox.Gr
{
    internal class ModelTexturePostprocessor : AssetPostprocessor
    {
        private const string ModelExtension = ".fmdl";
        private const string ProgressTitle = "Copy Model Textures";
        private const string ColorTexturePropertyName = "m_sRGBTexture";

        private struct TextureSettings
        {
            public bool IsColorTexture;
            public FilterMode FilterMode;
            public TextureWrapMode WrapMode;
        }

        private static readonly Dictionary<string, TextureSettings> pendingSettings = new Dictionary<string, TextureSettings>();

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            var modelPaths = new List<string>();
            foreach (string assetPath in importedAssets)
            {
                if (assetPath.EndsWith(ModelExtension))
                    modelPaths.Add(assetPath);
            }

            if (modelPaths.Count > 0)
                CopyTextures(modelPaths);
        }

        private static void CopyTextures(List<string> modelPaths)
        {
            var logger = new TaskLogger(ProgressTitle);
            var changedModelPaths = new List<string>();

            AssetDatabase.StartAssetEditing();
            try
            {
                for (int i = 0; i < modelPaths.Count; i++)
                {
                    if (EditorUtility.DisplayCancelableProgressBar(ProgressTitle, modelPaths[i], (float)i / modelPaths.Count))
                        break;

                    if (CopyTexturesOfModel(modelPaths[i], logger))
                        changedModelPaths.Add(modelPaths[i]);
                }
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                EditorUtility.ClearProgressBar();
            }

            AssetDatabase.StartAssetEditing();
            try
            {
                foreach (string modelPath in changedModelPaths)
                    AssetDatabase.ImportAsset(modelPath, ImportAssetOptions.ForceUpdate);
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
            }

            logger.LogToUnityConsole();
        }

        private static bool CopyTexturesOfModel(string modelPath, TaskLogger logger)
        {
            bool copiedAny = false;
            foreach (ulong pathCode in ModelFileImporter.ReadTexturePathCodes(modelPath))
            {
                string foxPath = FtexPathIndex.GetFoxPath(pathCode);
                if (foxPath == null)
                {
                    logger.AddWarning($"{modelPath}: no .ftex in the game folder for path code 0x{pathCode:X16}.");
                    continue;
                }

                try
                {
                    if (CopyTexture(foxPath, logger))
                        copiedAny = true;
                }
                catch (System.Exception exception)
                {
                    logger.AddError($"{foxPath}: {exception.Message}");
                }
            }

            return copiedAny;
        }

        private static bool CopyTexture(string foxPath, TaskLogger logger)
        {
            string ddsPath = System.IO.Path.ChangeExtension(FileSystem.GetUnityPathFromFoxPath(foxPath), ".dds");
            if (System.IO.File.Exists(ddsPath))
                return false;

            string ftexPath = FileSystem.GetExternalPathFromFoxPath(foxPath);
            byte[] ftexData = System.IO.File.ReadAllBytes(ftexPath);
            string ftexPathWithoutExtension = System.IO.Path.ChangeExtension(ftexPath, null);
            System.Func<int, System.IO.BinaryReader> ftexsProvider = (fileNumber) =>
            {
                return new System.IO.BinaryReader(System.IO.File.OpenRead($"{ftexPathWithoutExtension}.{fileNumber}.ftexs"));
            };

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(ddsPath));
            if (!FtexFile.ConvertToDds(ftexData, ftexsProvider, logger, ddsPath))
                return false;

            pendingSettings[ddsPath] = ReadTextureSettings(ftexData);
            AssetDatabase.ImportAsset(ddsPath);
            return true;
        }

        private static TextureSettings ReadTextureSettings(byte[] ftexData)
        {
            TextureSettings settings;
            settings.IsColorTexture = FtexFile.IsColorTexture(ftexData);
            settings.FilterMode = FtexFile.GetFilterMode(ftexData);
            settings.WrapMode = FtexFile.GetWrapMode(ftexData);
            return settings;
        }

        private void OnPreprocessAsset()
        {
            if (!pendingSettings.TryGetValue(assetPath, out TextureSettings settings))
                return;

            pendingSettings.Remove(assetPath);
            if (assetImporter is not IHVImageFormatImporter importer)
                return;

            using var serializedImporter = new SerializedObject(importer);
            serializedImporter.FindProperty(ColorTexturePropertyName).boolValue = settings.IsColorTexture;
            serializedImporter.ApplyModifiedPropertiesWithoutUndo();
            importer.filterMode = settings.FilterMode;
            importer.wrapMode = settings.WrapMode;
        }
    }
}
