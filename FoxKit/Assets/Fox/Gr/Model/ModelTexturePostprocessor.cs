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

        private static readonly List<string> queuedModelPaths = new List<string>();

        private static bool textureCopyScheduled;

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (string assetPath in importedAssets)
            {
                if (assetPath.EndsWith(ModelExtension) && !queuedModelPaths.Contains(assetPath))
                    queuedModelPaths.Add(assetPath);
            }

            if (queuedModelPaths.Count > 0 && !textureCopyScheduled)
            {
                textureCopyScheduled = true;
                EditorApplication.delayCall += CopyQueuedTextures;
            }
        }

        private static void CopyQueuedTextures()
        {
            textureCopyScheduled = false;
            var modelPaths = new List<string>(queuedModelPaths);
            queuedModelPaths.Clear();
            CopyTextures(modelPaths);
        }

        private static void CopyTextures(List<string> modelPaths)
        {
            var logger = new TaskLogger(ProgressTitle);

            AssetDatabase.StartAssetEditing();
            try
            {
                for (int i = 0; i < modelPaths.Count; i++)
                {
                    if (EditorUtility.DisplayCancelableProgressBar(ProgressTitle, modelPaths[i], (float)i / modelPaths.Count))
                        break;

                    CopyTexturesOfModel(modelPaths[i], logger);
                }
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                EditorUtility.ClearProgressBar();
            }

            logger.LogToUnityConsole();
        }

        private static void CopyTexturesOfModel(string modelPath, TaskLogger logger)
        {
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
                    CopyTexture(foxPath, logger);
                }
                catch (System.Exception exception)
                {
                    logger.AddError($"{foxPath}: {exception.Message}");
                }
            }
        }

        private static void CopyTexture(string foxPath, TaskLogger logger)
        {
            string ddsPath = System.IO.Path.ChangeExtension(FileSystem.GetUnityPathFromFoxPath(foxPath), ".dds");
            if (System.IO.File.Exists(ddsPath))
                return;

            string ftexPath = FileSystem.GetExternalPathFromFoxPath(foxPath);
            byte[] ftexData = System.IO.File.ReadAllBytes(ftexPath);
            string ftexPathWithoutExtension = System.IO.Path.ChangeExtension(ftexPath, null);
            System.Func<int, System.IO.BinaryReader> ftexsProvider = (fileNumber) =>
            {
                return new System.IO.BinaryReader(System.IO.File.OpenRead($"{ftexPathWithoutExtension}.{fileNumber}.ftexs"));
            };

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(ddsPath));
            if (!FtexFile.ConvertToDds(ftexData, ftexsProvider, logger, ddsPath))
                return;

            pendingSettings[ddsPath] = ReadTextureSettings(ftexData);
            AssetDatabase.ImportAsset(ddsPath);
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
