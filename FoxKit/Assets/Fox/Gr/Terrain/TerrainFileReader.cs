using System;
using Fox.Core;
using UnityEngine;

namespace Fox.Gr.Terrain
{
    internal struct BaseLayoutDescription
    {
        public uint GridWidth;
        public uint GridHeight;
        public uint LodCount;
        public float MinHeightWS;
        public float MaxHeightWS;
        public float GridDistance;
    }

    internal unsafe struct PatchConfiguration
    {
        public uint* Params;
        public uint* ConfigurationIds;
        public uint* MaterialIds;
        public float* MinHeight;
        public float* MaxHeight;
    }

    internal unsafe struct Patch
    {
        public uint HeightFormat;
        public float MinHeightWS;
        public float MaxHeightWS;

        public uint* HeightMap;
        public uint HeightMapSize;

        public uint ComboFormat;
        public uint* ComboTexture;
        public uint ComboTextureSize;

        public PatchConfiguration PatchConfiguration;

        public uint Height;
        public uint Width;

        public ushort ClusterGridSize;
        public ushort MaxLodLevel;
        public ushort LodCount;
    }
    
    internal unsafe struct MappedData
    {
        public ref BaseLayoutDescription BaseLayoutDescription => ref BaseLayoutDescription;
        
        public ref Patch BaseLayoutPatch => ref _Patch;
        public ref Patch PatchPatch => ref _Patch;
        
        public enum MappedDataType : uint
        {
            BaseLayout = 0,
            Patch = 1,
        }
        
        public MappedDataType Type;
        
        // Backings
        private BaseLayoutDescription _BaseLayoutDescription;
        private Patch _Patch;
        public ref PatchConfiguration PatchConfiguration => ref _Patch.PatchConfiguration;
    }
    
    internal static unsafe class TerrainFileReader
    {
        // TODO: MOVE
        internal const int CLUSTER_GRID_SIZE = 32;
        
        public enum FileType
        {
            BaseLayout = 1,
            Patch = 2,
        }

        public struct DeserializationDescription
        {
            public FileType Type;
        }

        public static bool TryReadTerrainFile(ref MappedData mappedData, ReadOnlySpan<byte> data, DeserializationDescription deserializationDescription)
        {
            switch (deserializationDescription.Type)
            {
                case FileType.BaseLayout:
                    mappedData.Type = MappedData.MappedDataType.BaseLayout;
                    return ReadTerrainBaseLayout(ref mappedData, data, deserializationDescription);
                case FileType.Patch:
                    mappedData.Type = MappedData.MappedDataType.Patch;
                    return ReadTerrainPatch(ref mappedData, data, deserializationDescription);
                default:
                    return false;
            }
        }

        private static bool ReadTerrainBaseLayout(ref MappedData mappedData, ReadOnlySpan<byte> data, DeserializationDescription deserializationDescription)
        {
            if (data.IsEmpty || data.Length < sizeof(FoxDataHeader))
            {
                Debug.Log("Data is empty or length is less than header");
                return false;
            }

            fixed (byte* dataPtr = data)
            {
                var header = (FoxDataHeader*)dataPtr;

                if (header->Name.Hash != new StrCode32("tre2"))
                {
                    Debug.Log("Header hash isn't tre2");
                    return false;
                }

                Debug.Log($"Version is {header->Version}");

                switch (header->Version)
                {
                    case 2:
                    case 3:
                        return ReadTerrainBaseLayoutV3(ref mappedData, header);
                    case 4:
                        return ReadTerrainBaseLayoutV4(ref mappedData, header);
                    default:
                        Debug.Log("Unknown header version");
                        return false;
                }
            }
        }

        private static bool ReadTerrainBaseLayoutV3(ref MappedData mappedData, FoxDataHeader* header)
        {
            FoxDataNode* nodes = header->GetNodes();
            if (nodes is not null)
            {
                FoxDataNode* paramNode = nodes->FindNode("param");
                FoxDataNode* maxHeightNode = nodes->FindNode("maxHeight");
                FoxDataNode* minHeightNode = nodes->FindNode("minHeight");
                FoxDataNode* heightMapNode = nodes->FindNode("heightMap");
                FoxDataNode* comboTextureNode = nodes->FindNode("comboTexture");
                FoxDataNode* materialIdsNode = nodes->FindNode("materialIds");
                FoxDataNode* configurationIds = nodes->FindNode("configrationIds");

                if (paramNode is not null &&
                    maxHeightNode is not null &&
                    minHeightNode is not null &&
                    heightMapNode is not null &&
                    comboTextureNode is not null &&
                    materialIdsNode is not null &&
                    configurationIds is not null)
                {
                    FoxDataParameter* widthParam = paramNode->FindParameter("width");
                    FoxDataParameter* heightParam = paramNode->FindParameter("height");
                    FoxDataParameter* highPerLowParam = paramNode->FindParameter("highPerLow");
                    FoxDataParameter* maxLodLevelParam = paramNode->FindParameter("maxLodLevel");
                    FoxDataParameter* gridDistanceParam = paramNode->FindParameter("gridDistance");

                    if (widthParam is not null &&
                        heightParam is not null &&
                        highPerLowParam is not null &&
                        maxLodLevelParam is not null &&
                        gridDistanceParam is not null)
                    {
                        uint width = widthParam->GetUIntValue();
                        uint height = heightParam->GetUIntValue();
                        uint highPerLow = highPerLowParam->GetUIntValue();
                        uint maxLodLevel = maxLodLevelParam->GetUIntValue();
                        float gridDistance = gridDistanceParam->GetFloatValue();

                        mappedData.Type = MappedData.MappedDataType.BaseLayout;
                        ref BaseLayoutDescription baseLayoutDesc = ref mappedData.BaseLayoutDescription;
                        baseLayoutDesc.GridDistance = gridDistance;
                        baseLayoutDesc.MinHeightWS = -50;
                        baseLayoutDesc.MaxHeightWS = 200;

                        // Round down to nearest multiple of 32. 31 -> 0, 33 -> 32, etc.
                        baseLayoutDesc.GridWidth = (uint)(width & -CLUSTER_GRID_SIZE);
                        baseLayoutDesc.GridHeight = (uint)(height & -CLUSTER_GRID_SIZE);

                        baseLayoutDesc.LodCount = maxLodLevel + 1;

                        ref Patch patch = ref mappedData.BaseLayoutPatch;
                        patch.MaxLodLevel = (ushort)maxLodLevel;
                        patch.LodCount = (ushort)(patch.MaxLodLevel + 1);
                        patch.MaxHeightWS = baseLayoutDesc.MaxHeightWS;
                        patch.MinHeightWS = baseLayoutDesc.MinHeightWS;
                        patch.Width = width / highPerLow;
                        patch.Height = height / highPerLow;
                        patch.ClusterGridSize = CLUSTER_GRID_SIZE;

                        uint texelCount = patch.Width * patch.Height;

                        patch.ComboFormat = 6;
                        patch.ComboTextureSize = texelCount * sizeof(uint);
                        patch.ComboTexture = (uint*)comboTextureNode->GetData();
                        // if (comboTextureNode->GetData() is not null)
                        // {
                        //     def.ComboTexture = new Texture2D((int)dataControl.MapChunkWidthWS, (int)dataControl.MapChunkHeightWS, TextureFormat.RGBA32, false, true);
                        //     reader.Seek(comboTextureNode.GetDataPosition().Value);
                        //
                        //     //dataControl.ComboTexture.LoadRawTextureData(reader.ReadBytes((int)heightMapSizeInTexels * 4));
                        //     //dataControl.ComboTexture.Apply();
                        //
                        //     def.ComboTexture = ReadRGBA32TileTexture(reader, def.MapChunkWidthWS, def.MapChunkHeightWS);
                        // }

                        patch.HeightFormat = 1;
                        patch.HeightMapSize = texelCount * sizeof(uint);
                        patch.HeightMap = (uint*)heightMapNode->GetData();

                        //
                        // if (heightMapNode->GetData() is not null)
                        // {
                        //     //dataControl.HeightMap = new Texture2D((int)dataControl.MapChunkWidthWS, (int)dataControl.MapChunkHeightWS, TextureFormat.R16, false, true);
                        //     reader.Seek(heightMapNode.GetDataPosition().Value);
                        //
                        //     //dataControl.HeightMap.LoadRawTextureData(reader.ReadBytes((int)heightMapSizeInTexels * 4));
                        //     //dataControl.HeightMap.Apply();
                        //
                        //     def.HeightMap = ReadRFloatTileTexture(reader, def.MapChunkWidthWS, def.MapChunkHeightWS, def.MinHeightWS, def.MaxHeightWS);
                        // }

                        ref PatchConfiguration patchConfig = ref patch.PatchConfiguration;
                        patchConfig.Params = (uint*)paramNode->GetData();
                        patchConfig.ConfigurationIds = (uint*)configurationIds->GetData();
                        patchConfig.MaterialIds = (uint*)materialIdsNode->GetData();
                        patchConfig.MinHeight = (float*)materialIdsNode->GetData();
                        patchConfig.MaxHeight = (float*)materialIdsNode->GetData();

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

        private static bool ReadTerrainBaseLayoutV4(ref MappedData control, FoxDataHeader* header)
        {
            FoxDataNode* nodes = header->GetNodes();
            if (nodes is null)
            {
                return false;
            }

            FoxDataNode* paramNode = nodes->FindNode("param");
            FoxDataNode* maxHeightNode = nodes->FindNode("maxHeight");
            FoxDataNode* minHeightNode = nodes->FindNode("minHeight");
            FoxDataNode* heightMapNode = nodes->FindNode("heightMap");
            FoxDataNode* comboTextureNode = nodes->FindNode("comboTexture");
            FoxDataNode* materialIdsNode = nodes->FindNode("materialIds");
            FoxDataNode* configrationIdsNode = nodes->FindNode("configrationIds");
            FoxDataNode* layoutDescriptionNode = nodes->FindNode("layoutDescription");

            return true;
        }

        private static bool ReadTerrainPatch(ref MappedData control, ReadOnlySpan<byte> data, DeserializationDescription deserializationDescription)
        {
            return false;
        }
    }
}