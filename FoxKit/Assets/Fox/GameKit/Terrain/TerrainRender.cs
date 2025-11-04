using Fox.Core;
using Fox.Core.Utils;
using System;
using System.Collections.Generic;
using Fox.Fs;
using Fox.Gr;
using Fox.Gr.Terrain;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class TerrainRender : Fox.Core.TransformData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            if (filePtr == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(filePtr));
            }
            else
            {
                Fs.FileSystem.TryCopyImportAsset(filePtr.path.String);
            }
        }

        private static List<(string, TerrainRender)> Registry = new List<(string, TerrainRender)>();

        public static void RegisterBlock(string name, TerrainBlock block)
        {
        }
        public static void DeregisterBlock(string name, TerrainBlock block)
        {
        }
        private static int SearchRegistry(string targetName)
        {
            int index = -1;
            for (int i = 0; i < Registry.Count; i++)
            {
                (string entryName, _) = Registry[i];
                
                if (entryName == targetName)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private uint GridWidth;
        private uint GridHeight;

        public unsafe void OnEnable()
        {
            ReadOnlySpan<byte> data = FileSystem.ReadFile(filePtr.path.String);
            if (data == null)
                return;
            
            TerrainFileContext terrainFileContext = new TerrainFileContext();
            fixed (byte* dataPtr = data)
            {
                if (terrainFileContext.TryDeserialize(dataPtr, (uint)data.Length))
                {
                    GridWidth = terrainFileContext.MappedData.BaseLayoutDescription.GridWidth;
                    GridHeight = terrainFileContext.MappedData.BaseLayoutDescription.GridHeight;
                    
                    this.transform.localScale = new Vector3(GridWidth * this.meterPerPixel, 1, GridHeight * this.meterPerPixel);

                    if (SearchRegistry(this.name) == -1)
                        Registry.Add((this.name, this));
                }
                else
                {
                    Debug.Log($"Failed to deserialize TRE2 {filePtr.path.String}");
                    return;
                }
            }
        
            return;
        }
        
        public void OnDisable()
        {
            int registryIndex = SearchRegistry(this.name);
            if (registryIndex == -1)
            {
                Debug.LogError("TerrainRender: OnDisable called but not TerrainRender not in registry");
                return;
            }
            
            Registry.RemoveAt(registryIndex);
        }
    }
}