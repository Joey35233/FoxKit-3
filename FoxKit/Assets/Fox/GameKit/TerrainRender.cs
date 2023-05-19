using Fox.Gr;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class TerrainRender : Fox.Core.TransformData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            Core.TransformEntity transformEntity = transform.Get();
            if (transformEntity == null)
            {
                Debug.LogWarning($"{name}: transform is null");
                return;
            }

            gameObject.transform.position = transformEntity.translation;
            gameObject.transform.rotation = transformEntity.rotQuat;
            gameObject.transform.localScale = transformEntity.scale;

            string path = "/Game" + filePath.CString;

            // Remove leading / and change extension
            string trimmedPath = path.Remove(0, 1).Replace(".tre2", ".asset");
            TerrainFileAsset asset = AssetDatabase.LoadAssetAtPath<TerrainFileAsset>(trimmedPath);
            if (asset == null)
            {
                using var reader = new BinaryReader(System.IO.File.OpenRead(Application.dataPath+path));
                var tre2Reader = new Fox.Gr.TerrainFileReader(reader);
                asset = tre2Reader.Read();
                AssetDatabase.CreateAsset(asset, $"Assets{Path.GetDirectoryName(path)+ Path.GetFileNameWithoutExtension(path)}.asset");
            }

            int heightmapRes = asset.Heightmap.width;

            TerrainData terrainData = new()
            {
                size = new Vector3(asset.Width / 4, asset.HeightRangeMax - asset.HeightRangeMin, asset.Height / 4),
                heightmapResolution = heightmapRes,
            };

            GameObject terrain = UnityEngine.Terrain.CreateTerrainGameObject(terrainData);
            terrain.transform.SetParent(gameObject.transform);
            terrain.transform.position = new Vector3(-asset.Width, asset.MinHeightWorldSpace, -asset.Width);

            float[,] heightmap2 = terrainData.GetHeights(0, 0, heightmapRes, heightmapRes);

            for (int z = 0; z < heightmapRes; z++)
            {
                for (int x = 0; x < heightmapRes; x++)
                {
                    float x1 = 1.0f / heightmapRes * x * heightmapRes;
                    float z1 = 1.0f / heightmapRes * (heightmapRes - 1 - z) * heightmapRes;

                    Color pixel = asset.Heightmap.GetPixel((int)z1, (int)x1);
                    heightmap2[x, z] = pixel.r;
                }
            }

            terrainData.SetHeights(0, 0, heightmap2);
        }
    }
}