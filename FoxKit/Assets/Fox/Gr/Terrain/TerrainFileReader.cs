using Fox.Core;
using Fox.Fio;
using Fox.Kernel;
using System.Linq;
using UnityEngine;

namespace Fox.Gr
{
    public class TerrainFileReader
    {
        public TerrainFileReader(FileStreamReader reader)
        {
            Reader = reader;
        }

        public TerrainFileAsset Read()
        {
            var header = new FoxDataHeaderContext(Reader, Reader.BaseStream.Position);
            header.Validate(version: 4, flags: 0, name: new String("tre2"));

            TerrainFileAsset ret = ScriptableObject.CreateInstance<TerrainFileAsset>();

            for (FoxDataNodeContext? node = header.GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
            {
                FoxDataNodeContext dataNode = node.Value;

                switch (dataNode.GetName().CString)
                {
                    case "param":
                        ret.Width = dataNode.FindParameter(new String("width")).Value.GetUInt();
                        ret.Height = dataNode.FindParameter(new String("height")).Value.GetUInt();
                        ret.HighPerLow = dataNode.FindParameter(new String("highPerLow")).Value.GetUInt();
                        ret.MaxLodLevel = dataNode.FindParameter(new String("maxLodLevel")).Value.GetUInt();
                        ret.GridDistance = dataNode.FindParameter(new String("gridDistance")).Value.GetFloat();
                        break;
                    case "heightMap":
                        ret.HeightFormat = dataNode.FindParameter(new String("heightFormat")).Value.GetUInt();
                        ret.HeightRangeMax = dataNode.FindParameter(new String("heightRangeMax")).Value.GetFloat();
                        ret.HeightRangeMin = dataNode.FindParameter(new String("heightRangeMin")).Value.GetFloat();
                        break;
                    case "comboTexture":
                        ret.ComboFormat = dataNode.FindParameter(new String("comboFormat")).Value.GetUInt();
                        break;
                    case "configrationIds":
                        FoxDataParameterContext? comboFormatConfig = dataNode.FindParameter(new String("comboFormat")); //??? re comboTexture
                        if (comboFormatConfig.HasValue)
                        {
                            ret.ComboFormat = comboFormatConfig.Value.GetUInt();
                        }
                        break;
                }

                //Payload
                if (dataNode.GetDataPosition() is not long dataPosition)
                    continue;

                switch (dataNode.GetName().CString)
                {
                    case "param":
                        Reader.Seek(dataPosition);
                        ret.LodParam = ReadR32G32B32A32Texture("lodParam", 128, 128, 0, 10);
                        break;
                    case "maxHeight":
                        Reader.Seek(dataPosition);
                        ret.MaxHeight = ReadR32Texture("maxHeight", 128, 128, ret.HeightRangeMin, ret.HeightRangeMax);
                        break;
                    case "minHeight":
                        Reader.Seek(dataPosition);
                        ret.MinHeight = ReadR32Texture("minHeight", 128, 128, ret.HeightRangeMin, ret.HeightRangeMax);
                        break;
                    case "heightMap":
                        Reader.Seek(dataPosition);
                        ret.Heightmap = ReadR32TileTexture("heightmap", 256, 256, ret.HeightRangeMin, ret.HeightRangeMax);
                        break;
                    case "comboTexture":
                        Reader.Seek(dataPosition);
                        ret.ComboTexture = ReadR8G8B8A8TileTexture("comboTexture", 256, 256);
                        break;
                    case "materialIds":
                        Reader.Seek(dataPosition);
                        ret.MaterialIds = ReadR8G8B8A8Texture("materialIds", 128, 128);
                        break;
                    case "configrationIds":
                        Reader.Seek(dataPosition);
                        ret.ConfigrationIds = ReadR8G8B8A8Texture("configrationIds", 128, 128);
                        break;
                    case "layoutDescription":
                        Reader.Seek(dataPosition);
                        Reader.Skip(0x10);
                        ret.WidthWorldSpace = Reader.ReadUInt32();
                        ret.HeightWorldSpace = Reader.ReadUInt32();
                        Reader.Skip(4);
                        ret.MaxHeightWorldSpace = Reader.ReadSingle();
                        ret.MinHeightWorldSpace = Reader.ReadSingle();
                        ret.LayoutDescriptionGridDistance = Reader.ReadSingle();
                        ret.LayoutDescriptionUnknown2 = Reader.ReadUInt16();
                        ret.LayoutDescriptionUnknown3 = Reader.ReadUInt16();
                        ret.LayoutDescriptionUnknown4 = Reader.ReadUInt32();
                        break;
                }
            }

            return ret;
        }

        private Texture2D ReadR32G32B32A32Texture(string name, int width, int height, float minHeight, float maxHeight)
        {
            var ret = new Texture2D(width, height, TextureFormat.RGBAFloat, true)
            {
                name = name
            };

            var pixels = new Color[height * width];

            for (int i = 0; i < height * width; i++)
            {
                float r = (Reader.ReadSingle() - minHeight) / (maxHeight - minHeight);
                float g = (Reader.ReadSingle() - minHeight) / (maxHeight - minHeight);
                float b = (Reader.ReadSingle() - minHeight) / (maxHeight - minHeight);
                float a = (Reader.ReadSingle() - minHeight) / (maxHeight - minHeight);

                pixels[i].r = r;
                pixels[i].g = g;
                pixels[i].b = b;
                pixels[i].a = a;
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }

        private Texture2D ReadR32Texture(string name, int width, int height, float minHeight, float maxHeight)
        {
            var ret = new Texture2D(width, height, TextureFormat.RFloat, true)
            {
                name = name
            };
            var pixels = new Color[height * width];

            for (int i = 0; i < height * width; i++)
            {
                float r = Reader.ReadSingle();
                pixels[i].r = (r - minHeight) / (maxHeight - minHeight);
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }
        private Texture2D ReadR8G8B8A8Texture(string name, int width, int height)
        {
            var ret = new Texture2D(width, height, TextureFormat.RGBA32, true)
            {
                name = name
            };

            var pixels = new Color[height * width];

            for (int i = 0; i < height * width; i++)
            {
                float r = Reader.ReadByte() / 255.0f;
                float g = Reader.ReadByte() / 255.0f;
                float b = Reader.ReadByte() / 255.0f;
                float a = Reader.ReadByte() / 255.0f;

                pixels[i] = new Color(r, g, b, a);
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }

        private Texture2D ReadR32TileTexture(string name, int width, int height, float minHeight, float maxHeight)
        {
            Debug.Log($"@{Reader.BaseStream.Position} ReadR32TileTexture");
            var ret = new Texture2D(width, height, TextureFormat.RFloat, true)
            {
                name = name
            };
            var pixels = new Color[height * width];

            float[] data = new float[height * width];
            for (int i = 0; i < height * width; i++)
            {
                Debug.Log($"@{Reader.BaseStream.Position} {i} ReadSingle");
                data[i] = Reader.ReadSingle();
            }

            const uint numTerrainBlocksW = 8;
            const uint numTerrainBlocksH = 8;
            const uint heightMapPitchInBlocks = 8;
            const uint terrainBlockPitchInTexels = 32;
            const uint heightMapPitchInTexels = heightMapPitchInBlocks * terrainBlockPitchInTexels;
            const uint terrainBlockSizeInBytes = 0x1000;

            for (int blockZ = 0; blockZ < numTerrainBlocksH; blockZ++)
            {
                for (int blockX = 0; blockX < numTerrainBlocksW; blockX++)
                {
                    float[] sourceHeightmapBlockData = data.Skip((int)(((blockX * heightMapPitchInBlocks) + blockZ) * terrainBlockSizeInBytes) / sizeof(float)).ToArray();

                    for (int x = 0; x < terrainBlockPitchInTexels; x++)
                    {
                        for (int z = 0; z < terrainBlockPitchInTexels; z++)
                        {
                            float heightTexelUNORM = (sourceHeightmapBlockData[z] - minHeight) / (maxHeight - minHeight);

                            uint outX = (uint)((blockZ * terrainBlockPitchInTexels) + z);
                            uint outY = (uint)((blockX * terrainBlockPitchInTexels) + x);
                            uint pixelIdx = (outY * heightMapPitchInTexels) + outX;
                            pixels[pixelIdx] = new Color(heightTexelUNORM, 0, 0);
                        }

                        sourceHeightmapBlockData = sourceHeightmapBlockData.Skip((int)terrainBlockPitchInTexels).ToArray();
                    }
                }
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }

        private Texture2D ReadR8G8B8A8TileTexture(string name, int width, int height)
        {
            var ret = new Texture2D(width, height, TextureFormat.RGBA32, true)
            {
                name = name
            };
            var pixels = new Color[height * width];

            var data = new Color[height * width];
            for (int i = 0; i < height * width; i++)
            {
                data[i].r = Reader.ReadByte() / 255.0f;
                data[i].g = Reader.ReadByte() / 255.0f;
                data[i].b = Reader.ReadByte() / 255.0f;
                data[i].a = Reader.ReadByte() / 255.0f;
            }

            const uint numTerrainBlocksW = 8;
            const uint numTerrainBlocksH = 8;
            const uint heightMapPitchInBlocks = 8;
            const uint terrainBlockPitchInTexels = 32;
            const uint heightMapPitchInTexels = heightMapPitchInBlocks * terrainBlockPitchInTexels;
            const uint terrainBlockSizeInBytes = 0x1000;

            for (int blockZ = 0; blockZ < numTerrainBlocksH; blockZ++)
            {
                for (int blockX = 0; blockX < numTerrainBlocksW; blockX++)
                {
                    Color[] sourceHeightmapBlockData = data.Skip((int)(((blockX * heightMapPitchInBlocks) + blockZ) * terrainBlockSizeInBytes) / sizeof(float)).ToArray();

                    for (int x = 0; x < terrainBlockPitchInTexels; x++)
                    {
                        for (int z = 0; z < terrainBlockPitchInTexels; z++)
                        {
                            uint outX = (uint)((blockZ * terrainBlockPitchInTexels) + z);
                            uint outY = (uint)((blockX * terrainBlockPitchInTexels) + x);
                            uint pixelIdx = (outY * heightMapPitchInTexels) + outX;
                            pixels[pixelIdx] = sourceHeightmapBlockData[z];
                        }

                        sourceHeightmapBlockData = sourceHeightmapBlockData.Skip((int)terrainBlockPitchInTexels).ToArray();
                    }
                }
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }

        public FileStreamReader Reader
        {
            get;
        }
    }
}