using System.IO;
using System.Linq;
using UnityEngine;

namespace Fox.Gr
{
    public class TerrainFileReader
    {
        public TerrainFileReader(BinaryReader reader)
        {
            Reader = reader;
        }

        public TerrainFileAsset Read()
        {
            TerrainFileAsset ret = ScriptableObject.CreateInstance<TerrainFileAsset>();

            _ = Reader.BaseStream.Seek(80, SeekOrigin.Begin);
            ret.Width = ReadUintParam();
            ret.Height = ReadUintParam();
            ret.HighPerLow = ReadUintParam();
            ret.MaxLodLevel = ReadUintParam();
            ret.GridDistance = ReadFloatParam();

            _ = Reader.BaseStream.Seek(208, SeekOrigin.Begin);
            ret.HeightFormat = ReadUintParam();
            ret.HeightRangeMax = ReadFloatParam();
            ret.HeightRangeMin = ReadFloatParam();

            _ = Reader.BaseStream.Seek(304, SeekOrigin.Begin);
            ret.ComboFormat = ReadUintParam();

            _ = Reader.BaseStream.Seek(576, SeekOrigin.Begin);
            ret.WidthWorldSpace = Reader.ReadUInt32();
            ret.HeightWorldSpace = Reader.ReadUInt32();

            _ = Reader.BaseStream.Seek(4, SeekOrigin.Current);
            ret.MaxHeightWorldSpace = Reader.ReadSingle();
            ret.MinHeightWorldSpace = Reader.ReadSingle();

            _ = Reader.BaseStream.Seek(596, SeekOrigin.Begin);
            ret.LayoutDescriptionGridDistance = Reader.ReadSingle();
            ret.LayoutDescriptionUnknown2 = Reader.ReadUInt16();
            ret.LayoutDescriptionUnknown3 = Reader.ReadUInt16();
            ret.LayoutDescriptionUnknown4 = Reader.ReadUInt32();

            _ = Reader.BaseStream.Seek(704, SeekOrigin.Begin);
            ret.LodParam = ReadR32G32B32A32Texture("lodParam", 128, 128, 0, 10);
            ret.MaxHeight = ReadR32Texture("maxHeight", 128, 128, ret.HeightRangeMin, ret.HeightRangeMax);
            ret.MinHeight = ReadR32Texture("minHeight", 128, 128, ret.HeightRangeMin, ret.HeightRangeMax);
            ret.Heightmap = ReadR32TileTexture("heightmap", 256, 256, ret.HeightRangeMin, ret.HeightRangeMax);
            ret.ComboTexture = ReadR8G8B8A8TileTexture("comboTexture", 256, 256);

            _ = Reader.BaseStream.Seek(918208, SeekOrigin.Begin);
            ret.MaterialIds = ReadR8G8B8A8Texture("materialIds", 128, 128);
            ret.ConfigrationIds = ReadR8G8B8A8Texture("configrationIds", 128, 128);

            return ret;
        }

        private uint ReadUintParam()
        {
            _ = Reader.BaseStream.Seek(12, SeekOrigin.Current);
            return Reader.ReadUInt32();
        }
        private float ReadFloatParam()
        {
            _ = Reader.BaseStream.Seek(12, SeekOrigin.Current);
            return Reader.ReadSingle();
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
            var ret = new Texture2D(width, height, TextureFormat.RFloat, true)
            {
                name = name
            };
            var pixels = new Color[height * width];

            float[] data = new float[height * width];
            for (int i = 0; i < height * width; i++)
            {
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

        public BinaryReader Reader
        {
            get;
        }
    }
}