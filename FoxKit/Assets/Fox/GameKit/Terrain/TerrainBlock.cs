using System;
using Codice.CM.Common.Merge;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Fs;
using Fox.Gr;
using Fox.Gr.Terrain;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using Material = UnityEngine.Material;

namespace Fox.GameKit
{
    [ExecuteAlways]
    public partial class TerrainBlock
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            pos = Fox.Math.FoxToUnityVector3(pos);

            if (filePtr == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(filePtr));
            }
            else
            {
                Fs.FileSystem.ImportAssetCopy(filePtr.path.String);
            }
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(pos), Fox.Math.UnityToFoxVector3(pos));
        }

        public unsafe void OnEnable()
        {
            return;
            string idStr = this.name.Substring("TerrainBlock_".Length);
            int parsedId = int.Parse(idStr);
            if (parsedId is < 2250 or > 2300)
                return;
            
            ReadOnlySpan<byte> data = FileSystem.ReadFile(filePtr.path.String);
            if (data == null)
                return;
            
            TerrainTileFileContext terrainFileContext = new TerrainTileFileContext();
            fixed (byte* dataPtr = data)
            {
                if (terrainFileContext.TryDeserialize(dataPtr, (uint)data.Length))
                {
                    Gr.Terrain.Patch patch = terrainFileContext.MappedData.Patch;
                    if (patch.UsePatchConfiguration == false)
                        return;

                    Gr.Terrain.PatchConfiguration patchConfig = patch.PatchConfiguration;

                    uint pitch = patch.Width / patch.TileGridSize;
                    for (uint i = 0; i < pitch; i++)
                    {
                        for (uint j = 0; j < pitch; j++)
                        {
                            uint flatIndex = j * pitch + i;
                            float minHeight = patchConfig.MinHeight[flatIndex];
                            float maxHeight = patchConfig.MaxHeight[flatIndex];
                            
                            // Other formulations of min/max
                            float heightRange = maxHeight - minHeight;

                            float xShift = ((int)i - 1) * patch.TileGridSize * 2.0f;
                            float zShift = ((int)j - 1) * patch.TileGridSize * 2.0f;

                            TerrainData unityTerrainData = new TerrainData();
                            
                            // Prepare heightmap data
                            int heightmapSizeTexels = patch.TileGridSize * patch.TileGridSize;
                            int heightmapSizeBytes = heightmapSizeTexels * sizeof(float);
                            Debug.Assert(heightmapSizeBytes == patch.HeightMapSize / 4);
                            float* heightmapData = (float*)patch.HeightMap + flatIndex * heightmapSizeTexels;
                            
                            Texture2D heightmapTexture = new Texture2D(patch.TileGridSize, patch.TileGridSize, GraphicsFormat.R32_SFloat, TextureCreationFlags.DontInitializePixels | TextureCreationFlags.DontUploadUponCreate);
                            heightmapTexture.LoadRawTextureData((IntPtr)heightmapData, heightmapSizeBytes);
                            heightmapTexture.Apply(false, false);
                            CopyTextureToTerrainHeight(unityTerrainData, heightmapTexture, Vector2Int.zero, patch.TileGridSize, 1, minHeight, heightRange);
                            
                            // float[,] heightsArray = new float[patch.TileGridSize, patch.TileGridSize];
                            // fixed (float* destHeightsData = heightsArray)
                            // {
                            //     for (int k = 0; k < patch.TileGridSize; k++)
                            //     {
                            //         for (int h = 0; h < patch.TileGridSize; h++)
                            //         {
                            //             int sourceIndex = k * patch.TileGridSize + (patch.TileGridSize - h - 1);
                            //             int destIndex = k * patch.TileGridSize + h;
                            //             
                            //             float sourceHeight = heightmapData[sourceIndex];
                            //             float destHeight = (sourceHeight - minHeight) / heightRange;
                            //             destHeightsData[destIndex] = destHeight;
                            //         }
                            //     }
                            // }
                            // unityTerrainData.SetHeights(0, 0, heightsArray);
                            
                            unityTerrainData.size = new Vector3(patch.TileGridSize * 2.0f, heightRange, patch.TileGridSize * 2.0f);
                            
                            Vector3 positionWS = pos + Fox.Math.FoxToUnityVector3(new Vector3(xShift, minHeight, zShift));
                            
                            GameObject unityTerrainGameObject = UnityEngine.Terrain.CreateTerrainGameObject(unityTerrainData);
                            UnityEngine.Terrain unityTerrain = unityTerrainGameObject.GetComponent<UnityEngine.Terrain>();
                            unityTerrain.name = $"Terrain_{this.name}_{i}_{j}";
                            unityTerrain.transform.position = positionWS - new Vector3(patch.TileGridSize * 2.0f / 2.0f, 0.0f, patch.TileGridSize * 2.0f / 2.0f);
                            unityTerrain.transform.SetParent(this.transform);

                            unityTerrain.reflectionProbeUsage = ReflectionProbeUsage.Off;
                            unityTerrain.heightmapMinimumLODSimplification = 0;
                            unityTerrain.shadowCastingMode = ShadowCastingMode.Off;
                            unityTerrain.heightmapPixelError = 20;
                            unityTerrain.drawInstanced = true;
                            unityTerrain.enableHeightmapRayTracing = false;
                            unityTerrain.drawTreesAndFoliage = false;
                            unityTerrain.allowAutoConnect = true;
                            unityTerrain.groupingID = 255;
                        }
                    }
                    
                    TerrainRender.RegisterBlock(terrainName, this);
                }
                else
                {
                    Debug.Log($"Failed to deserialize HTRE {filePtr.path.String}");
                    return;
                }
            }
        
            return;
        }
        
        public static Material GetHeightBlitMaterial()
        {
            return new Material(Shader.Find("Hidden/TerrainTools/HeightBlit"));
        }
        
        private static float kNormalizedHeightScale => 32766.0f / 65535.0f;
        public static void CopyTextureToTerrainHeight(TerrainData terrainData, Texture2D heightmap, Vector2Int indexOffset, int resolution, int numTiles, float baseLevel, float remap)
        {
            terrainData.heightmapResolution = resolution + 1;

            float hWidth = heightmap.height;
            float div = hWidth / numTiles;

            float scale = ((resolution / (resolution + 1.0f)) * (div + 1)) / hWidth;
            float offset = ((resolution / (resolution + 1.0f)) * div) / hWidth;

            Vector2 scaleV = new Vector2(scale, scale);
            Vector2 offsetV = new Vector2(offset * indexOffset.x, offset * indexOffset.y);

            scaleV = new Vector2(-1f, 1f);
            offsetV = new Vector2(1.0f, 0.0f);

            Material blitMaterial = GetHeightBlitMaterial();
            blitMaterial.SetFloat("_Height_Offset", -baseLevel/remap * kNormalizedHeightScale);
            blitMaterial.SetFloat("_Height_Scale", 1.0f/remap * kNormalizedHeightScale);
            RenderTexture heightmapRT = RenderTexture.GetTemporary(terrainData.heightmapTexture.descriptor);
            Graphics.Blit(heightmap, heightmapRT, blitMaterial);

            Graphics.Blit(heightmapRT, terrainData.heightmapTexture, scaleV, offsetV);

            terrainData.DirtyHeightmapRegion(new RectInt(0, 0, terrainData.heightmapTexture.width, terrainData.heightmapTexture.height), TerrainHeightmapSyncControl.HeightAndLod);
            RenderTexture.ReleaseTemporary(heightmapRT);
        }
        
        public void OnDisable()
        {
            // Temporary, to destroy cube
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                DestroyImmediate(child.gameObject);
            }
            
            TerrainRender.DeregisterBlock(terrainName, this);
        }
    }
}
