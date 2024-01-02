using Fox.Core;
using Fox.Core.Utils;
using System;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class TerrainRender : Fox.Core.TransformData
    {
        public Gr.Terrain.TerrainTileAsset Map;

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            if (filePtr == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(filePtr));

                return;
            }

            string unityPath = "Assets/Game" + filePtr.path.CString.Replace("afgh", "gntn") + '.' + "asset";
            Map = AssetDatabase.LoadAssetAtPath<Gr.Terrain.TerrainTileAsset>(unityPath);
            //Map = AssetManager.LoadAssetWithExtensionReplacement<Gr.Terrain.TerrainTileAsset>(filePtr, "asset", out string resolvedPath);
            if (Map == null)
            {
                logger.AddWarningMissingAsset(unityPath);
            }
        }
    }
}