using Fox.Core;
using Fox.Core.Utils;
using System;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class TerrainRender : Fox.Core.TransformData
    {
        public Gr.Terrain.TerrainTileAsset Map;

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            if (filePtr == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(filePtr));

                return;
            }

            string unityPath = "Assets/Game" + filePtr.path.String;
            Map = ScriptableObject.CreateInstance<Fox.Gr.Terrain.TerrainTileAsset>();
            if (!System.IO.File.Exists(unityPath))
            {
                logger.AddWarningMissingAsset(unityPath);
                return;
            }

            if (Fox.Gr.TerrainFile.TryDeserialize(Map, System.IO.File.ReadAllBytes(unityPath)))
            {
                //Map = AssetManager.LoadAssetWithExtensionReplacement<Gr.Terrain.TerrainTileAsset>(filePtr, "asset", out string resolvedPath);
                if (Map == null)
                {
                    logger.AddWarningMissingAsset(unityPath);
                }
            }
        }
    }
}