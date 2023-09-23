using Fox.Core;
using Fox.Core.Utils;
using Fox.Gr;
using Fox.Kernel;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class TerrainRender : Fox.Core.TransformData
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);

            if (filePtr == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(filePtr));

                return;
            }

            TerrainMapAsset asset = AssetManager.LoadAssetAtPath<TerrainMapAsset>(new Path(filePtr.path.CString + ".asset"), out string resolvedPath);
            if (asset == null)
            {
                logger.AddWarningMissingAsset(resolvedPath);

                // using var reader = new FileStreamReader(System.IO.File.OpenRead(path.CString));
                // var tre2Reader = new Fox.Gr.TerrainFileReader(reader);
                // asset = tre2Reader.Read();
                // AssetDatabase.CreateAsset(asset, ".asset");
            }

            //int heightmapRes = asset.Heightmap.width;

            //TerrainData terrainData = new()
            //{
            //    size = new Vector3(asset.Width / 4, asset.HeightRangeMax - asset.HeightRangeMin, asset.Height / 4),
            //    heightmapResolution = heightmapRes,
            //};

            //GameObject terrain = UnityEngine.Terrain.CreateTerrainGameObject(terrainData);
            //terrain.transform.SetParent(gameObject.transform);
            //terrain.transform.position = new Vector3(-asset.Width, asset.MinHeightWorldSpace, -asset.Width);

            //float[,] heightmap2 = terrainData.GetHeights(0, 0, heightmapRes, heightmapRes);

            //for (int z = 0; z < heightmapRes; z++)
            //{
            //    for (int x = 0; x < heightmapRes; x++)
            //    {
            //        float x1 = 1.0f / heightmapRes * x * heightmapRes;
            //        float z1 = 1.0f / heightmapRes * (heightmapRes - 1 - z) * heightmapRes;

            //        Color pixel = asset.Heightmap.GetPixel((int)z1, (int)x1);
            //        heightmap2[x, z] = pixel.r;
            //    }
            //}

            //terrainData.SetHeights(0, 0, heightmap2);
        }
    }
}