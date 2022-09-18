using Fox.Gr;
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
                size = new Vector3(asset.Width / 4, asset.HeightRangeMax - asset.HeightRangeMin, asset.Height / 4),
                heightmapResolution = heightmapRes,
            };

            var terrain = UnityEngine.Terrain.CreateTerrainGameObject(terrainData);
            terrain.transform.SetParent(gameObject.transform);
            terrain.transform.position = new Vector3(-asset.Width, asset.MinHeightWorldSpace, -asset.Width);

            float[,] heightmap2 = terrainData.GetHeights(0, 0, heightmapRes, heightmapRes);

            for (int z = 0; z < heightmapRes; z++)
            {
                for (int x = 0; x < heightmapRes; x++)
                {
                    var x1 = 1.0f / heightmapRes * x * heightmapRes;
                    var z1 = 1.0f / heightmapRes * (heightmapRes - 1 - z) * heightmapRes;

                    var pixel = asset.Heightmap.GetPixel((int)z1, (int)x1);
                    heightmap2[x, z] = pixel.r;
                }
            }

            terrainData.SetHeights(0, 0, heightmap2);
        }
    }
}