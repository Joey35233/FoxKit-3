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

        public TerrainMapAsset Read()
        {
            //var header = new FoxDataHeaderContext(Reader, Reader.BaseStream.Position);
            ////header.Validate(version: 4, flags: 0, name: new String("tre2"));
            //Debug.Assert(header.GetVersion() == 3 || header.GetVersion() == 4, $"tre2 header version {header.GetVersion()} unsupported");

            //TerrainMapAsset ret = ScriptableObject.CreateInstance<TerrainMapAsset>();

            //int MapChunkWidthWS = 256;
            //int MapChunkHeightWS = 256;
            //uint ExtraHighSizeWS = 32;
            //int sizeWidth = 128;
            //int sizeHeight = 128;
            //ushort LodCount = 1;

            //for (FoxDataNodeContext? node = header.GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
            //{
            //    FoxDataNodeContext dataNode = node.Value;

            //    string nodeName = dataNode.GetName().CString;

            //    switch (nodeName)
            //    {
            //        case "param":
            //            ret.Width = dataNode.FindParameter(new String("width")).Value.GetUInt();
            //            ret.Height = dataNode.FindParameter(new String("height")).Value.GetUInt();
            //            ret.HighPerLow = dataNode.FindParameter(new String("highPerLow")).Value.GetUInt();
            //            ret.MaxLodLevel = dataNode.FindParameter(new String("maxLodLevel")).Value.GetUInt();
            //            ret.GridDistance = dataNode.FindParameter(new String("gridDistance")).Value.GetFloat();
            //            if (header.GetVersion() == 3)
            //            {
            //                ret.WidthWorldSpace = ret.Width & 0xffffffe0;
            //                ret.HeightWorldSpace = ret.Height & 0xffffffe0;
            //                MapChunkWidthWS = (int)ret.Width / (int)ret.HighPerLow;
            //                MapChunkHeightWS = (int)ret.Height / (int)ret.HighPerLow;
            //                LodCount = (ushort)(ret.MaxLodLevel + 1);
            //            }
            //            if (header.GetVersion() == 4)
            //            {
            //                int cappedLodLevel = (int)(ret.MaxLodLevel & 31);
            //                sizeWidth = ((MapChunkWidthWS << cappedLodLevel) / (int)ExtraHighSizeWS);
            //                sizeHeight = ((MapChunkHeightWS << cappedLodLevel) / (int)ExtraHighSizeWS);
            //            }
            //            break;
            //        case "heightMap":
            //            ret.HeightFormat = dataNode.FindParameter(new String("heightFormat")).Value.GetUInt();
            //            ret.HeightRangeMax = dataNode.FindParameter(new String("heightRangeMax")).Value.GetFloat();
            //            ret.HeightRangeMin = dataNode.FindParameter(new String("heightRangeMin")).Value.GetFloat();
            //            break;
            //        case "comboTexture":
            //            ret.ComboFormat = dataNode.FindParameter(new String("comboFormat")).Value.GetUInt();
            //            break;
            //        case "configrationIds":
            //            FoxDataParameterContext? comboFormatConfig = dataNode.FindParameter(new String("comboFormat")); //??? re comboTexture
            //            if (comboFormatConfig.HasValue)
            //            {
            //                ret.ComboFormat = comboFormatConfig.Value.GetUInt();
            //            }
            //            break;
            //    }

            //    //Payload
            //    if (dataNode.GetDataPosition() is not long dataPosition)
            //        continue;
            //    Reader.Seek(dataPosition);

            //    switch (nodeName)
            //    {
            //        case "param":
            //            //TODO multiple lod maps * LodCount
            //            ret.LodParam = ReadR32G32B32A32Texture("lodParam", sizeWidth, sizeHeight, ret.HeightRangeMin, ret.HeightRangeMax);
            //            break;
            //        case "maxHeight":
            //            ret.MaxHeight = ReadR32Texture("maxHeight", sizeWidth, sizeHeight, ret.HeightRangeMin, ret.HeightRangeMax);
            //            break;
            //        case "minHeight":
            //            ret.MinHeight = ReadR32Texture("minHeight", sizeWidth, sizeHeight, ret.HeightRangeMin, ret.HeightRangeMax);
            //            break;
            //        case "heightMap":
            //            ret.Heightmap = ReadR32TileTexture("heightmap", MapChunkWidthWS, MapChunkHeightWS, ret.HeightRangeMin, ret.HeightRangeMax);
            //            break;
            //        case "comboTexture":
            //            ret.ComboTexture = ReadR8G8B8A8TileTexture("comboTexture", MapChunkWidthWS, MapChunkHeightWS);
            //            break;
            //        case "materialIds":
            //            ret.MaterialIds = ReadR8G8B8A8Texture("materialIds", sizeWidth, sizeHeight);
            //            break;
            //        case "configrationIds":
            //            ret.ConfigrationIds = ReadR8G8B8A8Texture("configrationIds", sizeWidth, sizeHeight);
            //            break;
            //        case "layoutDescription":
            //            Reader.Skip(0x10);
            //            ret.WidthWorldSpace = Reader.ReadUInt32();
            //            ret.HeightWorldSpace = Reader.ReadUInt32();
            //            long offsetToCommonDescription = Reader.BaseStream.Position+Reader.ReadUInt32();
            //            ret.MaxHeightWorldSpace = Reader.ReadSingle();
            //            ret.MinHeightWorldSpace = Reader.ReadSingle();
            //            ret.LayoutDescriptionGridDistance = Reader.ReadSingle();
            //            ret.LayoutDescriptionLodCount = Reader.ReadUInt16();

            //            Reader.BaseStream.Position = offsetToCommonDescription;

            //            uint CommonTileHeightFormat = Reader.ReadUInt32();
            //            float CommonTileMaxHeightWorldSpace = Reader.ReadSingle();
            //            float CommonTileMinHeightWorldSpace = Reader.ReadSingle();
            //            uint CommonTileHeightMapOffset = Reader.ReadUInt32();
            //            uint CommonTileHeightMapSize = Reader.ReadUInt32();
            //            uint CommonTileComboFormat = Reader.ReadUInt32();

            //            uint CommonComboTextureOffset = Reader.ReadUInt32();
            //            uint CommonComboTextureSize = Reader.ReadUInt32();

            //            ulong MatMapTileBaseOffset = Reader.ReadUInt64();
            //            uint MatMapTileMaterialIdsOffset = Reader.ReadUInt32();
            //            uint MatMapTileConfigurationIdsOffset = Reader.ReadUInt32();
            //            uint MatMapTileMaxHeightOffset = Reader.ReadUInt32();
            //            uint MatMapTileMinHeightOffset = Reader.ReadUInt32();
            //            uint MatMapTileParamOffset = Reader.ReadUInt32();

            //            Reader.Align(0x10);

            //            uint CommonUnknown = Reader.ReadUInt32();
            //            MapChunkWidthWS = (int)Reader.ReadUInt32();
            //            MapChunkHeightWS = (int)Reader.ReadUInt32();
            //            ExtraHighSizeWS = Reader.ReadUInt16();
            //            ushort CommonMaxLodLevel = Reader.ReadUInt16();
            //            LodCount = Reader.ReadUInt16();

            //            break;
            //    }
            //}

            //return ret;

            return null;
        }

        public FileStreamReader Reader
        {
            get;
        }
    }
}