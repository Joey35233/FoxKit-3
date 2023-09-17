using Fox.Core;
using Fox.Fio;
using Fox.Kernel;
using System.Linq;
using UnityEngine;

namespace Fox.Gr
{
    public enum TerrainFileType
    {
        TRE2 = 0,
        HTRE = 1,
    }

    public class TerrainMapAsset : ScriptableObject
    {
        public bool IsHTRE;

        public TerrainTileLocatorControl LocatorControl;

        public TerrainTileDataControl DataControl;

        public TerrainTileMatMapControl MatMapControl;

        public static bool TryReadTerrainFile(TerrainMapAsset data, FileStreamReader reader, TerrainFileType fileType)
        {
            if (fileType == TerrainFileType.TRE2)
                return TryReadTRE2(data, reader);
            else if (fileType == TerrainFileType.HTRE)
                return TryReadHTRE(data, reader);
            else
                return false;
        }

        private static bool ValidateTerrainHeader(FoxDataHeaderContext header)
        {
            return header.GetVersion() != 0;
        }

        private static bool TryReadTRE2(TerrainMapAsset data, FileStreamReader reader)
        {
            var header = new FoxDataHeaderContext(reader, 0);

            if (!ValidateTerrainHeader(header))
                return false;

            if (header.GetVersion() == 2 || header.GetVersion() == 3)
                return TryReadTRE2V2or3(data, reader, header);

            if (header.GetVersion() == 4)
                return TryReadTRE2V4(data, reader, header);

            return true;
        }

        private static bool TryReadTRE2V2or3(TerrainMapAsset data, FileStreamReader reader, FoxDataHeaderContext header)
        {
            if (header.GetFirstNode() is FoxDataNodeContext rootNode)
            {
                if (rootNode.FindNode(new String("param")) is FoxDataNodeContext paramNode &&
                    rootNode.FindNode(new String("maxHeight")) is FoxDataNodeContext maxHeightNode &&
                    rootNode.FindNode(new String("minHeight")) is FoxDataNodeContext minHeightNode &&
                    rootNode.FindNode(new String("heightMap")) is FoxDataNodeContext heightMapNode &&
                    rootNode.FindNode(new String("comboTexture")) is FoxDataNodeContext comboTextureNode &&
                    rootNode.FindNode(new String("materialIds")) is FoxDataNodeContext materialIdsNode &&
                    rootNode.FindNode(new String("configrationIds")) is FoxDataNodeContext configrationIdsNode)
                {

                    if (paramNode.FindParameter(new String("width")) is FoxDataParameterContext widthParam &&
                        paramNode.FindParameter(new String("height")) is FoxDataParameterContext heightParam &&
                        paramNode.FindParameter(new String("highPerLow")) is FoxDataParameterContext highPerLowParam &&
                        paramNode.FindParameter(new String("maxLodLevel")) is FoxDataParameterContext maxLodLevelParam &&
                        paramNode.FindParameter(new String("gridDistance")) is FoxDataParameterContext gridDistanceParam)
                    {
                        uint width = widthParam.GetUInt();
                        uint height = heightParam.GetUInt();
                        uint highPerLow = highPerLowParam.GetUInt();
                        uint maxLodLevel = maxLodLevelParam.GetUInt();
                        float gridDistance = gridDistanceParam.GetFloat();

                        ref TerrainTileLocatorControl locatorControl = ref data.LocatorControl;
                        locatorControl.GridDistance = gridDistance;
                        locatorControl.UnknownU64_0 = 0;
                        locatorControl.UnknownU64_1 = 0;
                        locatorControl.MinHeightWS = -50;
                        locatorControl.MaxHeightWS = 200;

                        // Round down to nearest multiple of 32. 31 -> 0, 33 -> 32, etc.
                        locatorControl.WidthWS = width & 0xffffffe0;
                        locatorControl.HeightWS = height & 0xffffffe0;

                        locatorControl.LodCount = maxLodLevel + 1;

                        ref TerrainTileDataControl dataControl = ref data.DataControl;
                        dataControl.MaxLodLevel = (ushort)maxLodLevel;
                        dataControl.LodCount = (ushort)(dataControl.MaxLodLevel + 1);
                        dataControl.MaxHeightWS = locatorControl.MaxHeightWS;
                        dataControl.MinHeightWS = locatorControl.MinHeightWS;
                        dataControl.MapChunkWidthWS = width / highPerLow;
                        dataControl.MapChunkHeightWS = height / highPerLow;
                        dataControl.ExtraHighSizeWS = 32;
                        dataControl.ComboFormat = 6;

                        uint heightMapSizeInTexels = dataControl.MapChunkWidthWS * dataControl.MapChunkHeightWS;

                        if (comboTextureNode.GetDataPosition() is not null)
                        {
                            //dataControl.ComboTexture = new Texture2D((int)dataControl.MapChunkWidthWS, (int)dataControl.MapChunkHeightWS, TextureFormat.RGBA32, false, true);
                            reader.Seek(comboTextureNode.GetDataPosition().Value);

                            //dataControl.ComboTexture.LoadRawTextureData(reader.ReadBytes((int)heightMapSizeInTexels * 4));
                            //dataControl.ComboTexture.Apply();

                            dataControl.ComboTexture = ReadRGBA32TileTexture(reader, dataControl.MapChunkWidthWS, dataControl.MapChunkHeightWS);
                        }

                        if (heightMapNode.GetDataPosition() is not null)
                        {
                            //dataControl.HeightMap = new Texture2D((int)dataControl.MapChunkWidthWS, (int)dataControl.MapChunkHeightWS, TextureFormat.R16, false, true);
                            reader.Seek(heightMapNode.GetDataPosition().Value);

                            //dataControl.HeightMap.LoadRawTextureData(reader.ReadBytes((int)heightMapSizeInTexels * 4));
                            //dataControl.HeightMap.Apply();

                            dataControl.HeightMap = ReadRFloatTileTexture(reader, dataControl.MapChunkWidthWS, dataControl.MapChunkHeightWS, dataControl.MinHeightWS, dataControl.MaxHeightWS);
                        }

                        //ref TerrainTileMatMapControl matMapControl = ref data.MatMapControl;

                        //if (paramNode.GetDataPosition() is not null)
                        //{
                        //    matMapControl.Params = new Texture2D((int)dataControl.MapChunkWidthWS, (int)dataControl.MapChunkHeightWS, TextureFormat.R16, false, true);
                        //    reader.Seek(paramNode.GetDataPosition().Value);

                        //    matMapControl.Params.LoadRawTextureData(reader.ReadBytes((int)paramNode.GetDataSize()));
                        //    matMapControl.Params.Apply();
                        //}

                        return true;
                    }
                }
            }

            return false;
        }

        private static bool TryReadTRE2V4(TerrainMapAsset data, FileStreamReader reader, FoxDataHeaderContext header)
        {
            return false;
        }

        private static bool TryReadHTRE(TerrainMapAsset data, FileStreamReader reader)
        {
            return false;
        }

        private static Texture2D ReadRFloatTileTexture(FileStreamReader reader, uint width, uint height, float minHeight, float maxHeight)
        {
            var ret = new Texture2D((int)width, (int)height, TextureFormat.RFloat, false, true);
            float[] pixels = new float[height * width];

            float[] data = new float[height * width];
            for (int i = 0; i < height * width; i++)
            {
                data[i] = reader.ReadSingle();
            }

            const uint blockDimInTexels = 32;

            uint numTerrainBlocksW = width / blockDimInTexels;
            uint numTerrainBlocksH = height / blockDimInTexels;

            float[] sourceHeightmapBlockData = data;
            for (int blockZ = 0; blockZ < numTerrainBlocksH; blockZ++)
            {
                for (int blockX = 0; blockX < numTerrainBlocksW; blockX++)
                {
                    for (int x = 0; x < blockDimInTexels; x++)
                    {
                        for (int z = 0; z < blockDimInTexels; z++)
                        {
                            uint outX = (uint)((blockX * blockDimInTexels) + z);
                            uint outY = (uint)((blockZ * blockDimInTexels) + x);
                            uint pixelIdx = (outY * width) + outX;
                            pixels[pixelIdx] = (sourceHeightmapBlockData[z] - minHeight) / (maxHeight - minHeight);
                        }

                        sourceHeightmapBlockData = sourceHeightmapBlockData.Skip((int)blockDimInTexels).ToArray();
                    }
                }
            }

            ret.SetPixelData(pixels, 0);
            ret.Apply();
            return ret;
        }

        private static Texture2D ReadRGBA32TileTexture(FileStreamReader reader, uint width, uint height)
        {
            var ret = new Texture2D((int)width, (int)height, TextureFormat.RGBA32, false, true);
            var pixels = new Color32[height * width];

            var data = new Color32[height * width];
            for (int i = 0; i < height * width; i++)
            {
                data[i].r = reader.ReadByte();
                data[i].g = reader.ReadByte();
                data[i].b = reader.ReadByte();
                data[i].a = reader.ReadByte();
            }

            const uint blockDimInTexels = 32;

            uint numTerrainBlocksW = width / blockDimInTexels;
            uint numTerrainBlocksH = height / blockDimInTexels;

            Color32[] sourceHeightmapBlockData = data;
            for (int blockZ = 0; blockZ < numTerrainBlocksH; blockZ++)
            {
                for (int blockX = 0; blockX < numTerrainBlocksW; blockX++)
                {
                    for (int x = 0; x < blockDimInTexels; x++)
                    {
                        for (int z = 0; z < blockDimInTexels; z++)
                        {
                            uint outX = (uint)((blockX * blockDimInTexels) + z);
                            uint outY = (uint)((blockZ * blockDimInTexels) + x);
                            uint pixelIdx = (outY * width) + outX;
                            pixels[pixelIdx] = sourceHeightmapBlockData[z];
                        }

                        sourceHeightmapBlockData = sourceHeightmapBlockData.Skip((int)blockDimInTexels).ToArray();
                    }
                }
            }

            ret.SetPixels32(pixels);
            ret.Apply();
            return ret;
        }
    }
}