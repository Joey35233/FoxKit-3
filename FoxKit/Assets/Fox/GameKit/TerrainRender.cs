using Fox.Gr;
using FoxKit.Gr.Terrain;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class TerrainRender : Fox.Core.TransformData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            var transformEntity = this.transform.Get();
            if (transformEntity == null)
            {
                Debug.LogWarning($"{this.name}: transform is null");
                return;
            }

            gameObject.transform.position = transformEntity.translation;
            gameObject.transform.rotation = transformEntity.rotQuat;
            gameObject.transform.localScale = transformEntity.scale;

            var path = this.filePath.CString;

            // Remove leading / and change extension
            var trimmedPath = path.Remove(0, 1).Replace(".tre2", ".asset");
            var asset = AssetDatabase.LoadAssetAtPath<TerrainFileAsset>(trimmedPath);
            if (asset == null)
            {
                Debug.LogWarning($"{this.name}: Unable to find asset at path {trimmedPath}");
                return;
            }

            var heightmapRes = asset.Heightmap.width;

            TerrainData terrainData = new()
            {
                size = new Vector3(asset.Width / 8, asset.HeightRangeMax - asset.HeightRangeMin, asset.Height / 8),
                heightmapResolution = heightmapRes
            };

            var terrain = UnityEngine.Terrain.CreateTerrainGameObject(terrainData);
            terrain.transform.SetParent(gameObject.transform);
            terrain.transform.position = new Vector3(-asset.Width / 2, 0, -asset.Width / 2);

            float[,] heightmap2 = terrainData.GetHeights(0, 0, heightmapRes, heightmapRes);

            for (int y = 0; y < heightmapRes; y++)
            {
                for (int x = 0; x < heightmapRes; x++)
                {
                    var x1 = 1.0f / heightmapRes * x * heightmapRes;
                    var y1 = 1.0f / heightmapRes * y * heightmapRes;

                    var pixel = asset.Heightmap.GetPixel((int)x1, (int)y1);
                    heightmap2[x, y] = pixel.r;
                }
            }

            terrainData.SetHeights(0, 0, heightmap2);
        }
    }
}