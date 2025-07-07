using System;
using Fox.Core;
using UnityEngine;

namespace Fox.Gr.Terrain
{
    public struct BaseLayoutDescription
    {
        public uint GridWidth;
        public uint GridHeight;
        public uint LodCount;
        public float MinHeightWS;
        public float MaxHeightWS;
        public float GridDistance;
    }

    public unsafe struct PatchConfiguration
    {
        public uint* Params;
        public uint* ConfigurationIds;
        public uint* MaterialIds;
        public float* MinHeight;
        public float* MaxHeight;
    }

    public unsafe struct Patch
    {
        public uint HeightFormat;
        public float MinHeightWS;
        public float MaxHeightWS;
        public uint* HeightMap;
        public uint HeightMapSize;

        public uint ComboFormat;
        public byte* ComboTexture;
        public uint ComboTextureSize;

        public bool UsePatchConfiguration;
        public PatchConfiguration PatchConfiguration;
        
        public uint Height;
        public uint Width;

        public ushort TileGridSize;
        public ushort MaxLodLevel;
        public ushort LodCount;
    }
    
    public unsafe struct MappedData
    {
        public enum MappedDataType : uint
        {
            BaseLayout = 0,
            Patch = 1,
        }
        
        public MappedDataType Type;
        
        public BaseLayoutDescription BaseLayoutDescription;
        public Patch Patch;
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

        public static bool TryReadTerrainFile(ref MappedData mappedData, byte* data, uint dataSize, DeserializationDescription deserializationDescription)
        {
            switch (deserializationDescription.Type)
            {
                case FileType.BaseLayout:
                    mappedData.Type = MappedData.MappedDataType.BaseLayout;
                    return ReadTerrainBaseLayout(ref mappedData, data, dataSize, deserializationDescription);
                case FileType.Patch:
                    mappedData.Type = MappedData.MappedDataType.Patch;
                    return ReadTerrainPatch(ref mappedData, data, dataSize, deserializationDescription);
                default:
                    return false;
            }
        }

        private static bool ReadTerrainBaseLayout(ref MappedData mappedData, byte* data, uint dataSize, DeserializationDescription deserializationDescription)
        {
            if (data == null || dataSize < sizeof(FoxDataHeader))
            {
                Debug.Log("Data is empty or length is less than header");
                return false;
            }

            FoxDataHeader* header = (FoxDataHeader*)data;

            if (header->Name.Hash != new StrCode32("tre2"))
            {
                Debug.Log("Header hash isn't tre2");
                return false;
            }

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

        private static bool ReadTerrainBaseLayoutV3(ref MappedData mappedData, FoxDataHeader* header)
        {
            FoxDataNode* nodes = header->GetNodes();
            if (nodes is null) 
                return false;
            
            FoxDataNode* paramNode = nodes->FindNode("param");
            FoxDataNode* maxHeightNode = nodes->FindNode("maxHeight");
            FoxDataNode* minHeightNode = nodes->FindNode("minHeight");
            FoxDataNode* heightMapNode = nodes->FindNode("heightMap");
            FoxDataNode* comboTextureNode = nodes->FindNode("comboTexture");
            FoxDataNode* materialIdsNode = nodes->FindNode("materialIds");
            FoxDataNode* configurationIds = nodes->FindNode("configrationIds");

            if (paramNode is null 
                || maxHeightNode is null 
                || minHeightNode is null 
                || heightMapNode is null 
                || comboTextureNode is null
                || materialIdsNode is null
                || configurationIds is null)
                return false;
            
            FoxDataNodeAttribute* widthParam = paramNode->FindParameter("width");
            FoxDataNodeAttribute* heightParam = paramNode->FindParameter("height");
            FoxDataNodeAttribute* highPerLowParam = paramNode->FindParameter("highPerLow");
            FoxDataNodeAttribute* maxLodLevelParam = paramNode->FindParameter("maxLodLevel");
            FoxDataNodeAttribute* gridDistanceParam = paramNode->FindParameter("gridDistance");

            if (widthParam is null 
                || heightParam is null 
                || highPerLowParam is null 
                || maxLodLevelParam is null
                || gridDistanceParam is null)
                return false;
            
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

            ref Patch patch = ref mappedData.Patch;
            patch.MaxLodLevel = (ushort)maxLodLevel;
            patch.LodCount = (ushort)(patch.MaxLodLevel + 1);
            patch.MaxHeightWS = baseLayoutDesc.MaxHeightWS;
            patch.MinHeightWS = baseLayoutDesc.MinHeightWS;
            patch.Width = width / highPerLow;
            patch.Height = height / highPerLow;
            patch.TileGridSize = CLUSTER_GRID_SIZE;

            uint texelCount = patch.Width * patch.Height;

            patch.HeightFormat = 1;
            patch.HeightMapSize = texelCount * sizeof(uint);
            patch.HeightMap = (uint*)heightMapNode->GetData();

            patch.ComboFormat = 6;
            patch.ComboTextureSize = texelCount * sizeof(uint);
            patch.ComboTexture = comboTextureNode->GetData();

            ref PatchConfiguration patchConfig = ref patch.PatchConfiguration;
            patchConfig.Params = (uint*)paramNode->GetData();
            patchConfig.ConfigurationIds = (uint*)configurationIds->GetData();
            patchConfig.MaterialIds = (uint*)materialIdsNode->GetData();
            patchConfig.MinHeight = (float*)materialIdsNode->GetData();
            patchConfig.MaxHeight = (float*)materialIdsNode->GetData();

            return true;

        }

        private static bool ReadTerrainBaseLayoutV4(ref MappedData mappedData, FoxDataHeader* header)
        {
            FoxDataNode* nodes = header->GetNodes();
            if (nodes is null)
                return false;

            FoxDataNode* paramNode = nodes->FindNode("param");
            FoxDataNode* maxHeightNode = nodes->FindNode("maxHeight");
            FoxDataNode* minHeightNode = nodes->FindNode("minHeight");
            FoxDataNode* heightMapNode = nodes->FindNode("heightMap");
            FoxDataNode* comboTextureNode = nodes->FindNode("comboTexture");
            FoxDataNode* materialIdsNode = nodes->FindNode("materialIds");
            FoxDataNode* configrationIdsNode = nodes->FindNode("configrationIds");
            FoxDataNode* layoutDescriptionNode = nodes->FindNode("layoutDescription");

            if (paramNode is null 
                || maxHeightNode is null 
                || minHeightNode is null 
                || heightMapNode is null 
                || comboTextureNode is null 
                || materialIdsNode is null 
                || configrationIdsNode is null 
                || layoutDescriptionNode is null)
                return false;

            TerrainFileFormat.BaseLayoutDescription* fileBaseLayoutDesc = (TerrainFileFormat.BaseLayoutDescription*)layoutDescriptionNode->GetData();
            if (fileBaseLayoutDesc is null)
                return false;

            if (fileBaseLayoutDesc->PatchOffset == 0)
                return false;
            
            TerrainFileFormat.Patch* filePatch = (TerrainFileFormat.Patch*)((byte*)&fileBaseLayoutDesc->PatchOffset + fileBaseLayoutDesc->PatchOffset);
            
            mappedData.Type = MappedData.MappedDataType.BaseLayout;
            
            ref BaseLayoutDescription baseLayoutDesc = ref mappedData.BaseLayoutDescription;
            baseLayoutDesc.GridWidth = fileBaseLayoutDesc->GridWidth;
            baseLayoutDesc.GridHeight = fileBaseLayoutDesc->GridHeight;
            baseLayoutDesc.LodCount = fileBaseLayoutDesc->LodCount;
            baseLayoutDesc.MinHeightWS = fileBaseLayoutDesc->MinHeightWS;
            baseLayoutDesc.MaxHeightWS = fileBaseLayoutDesc->MaxHeightWS;
            baseLayoutDesc.GridDistance = fileBaseLayoutDesc->GridDistance;
            
            ref Patch patch = ref mappedData.Patch;
            patch.UsePatchConfiguration = true;

            return MapTerrainPatch(ref patch, filePatch);
        }

        private static bool MapTerrainPatch(ref Patch patch, TerrainFileFormat.Patch* filePatch)
        {
            patch.Height = filePatch->Height;
            patch.Width = filePatch->Width;
            patch.TileGridSize = filePatch->ClusterGridSize; // TODO; get a better name for these
            patch.MaxLodLevel = filePatch->MaxLodLevel;
            patch.LodCount = filePatch->LodCount;

            ref PatchConfiguration patchConfig = ref patch.PatchConfiguration;
            TerrainFileFormat.PatchConfiguration* filePatchConfig = &filePatch->PatchConfiguration;
            patchConfig.Params = (uint*)((byte*)&filePatchConfig->ParamOffset + filePatchConfig->ParamOffset);
            patchConfig.ConfigurationIds = (uint*)((byte*)&filePatchConfig->ConfigurationIdsOffset + filePatchConfig->ConfigurationIdsOffset);
            patchConfig.MaterialIds = (uint*)((byte*)&filePatchConfig->MaterialIdsOffset + filePatchConfig->MaterialIdsOffset);
            patchConfig.MinHeight = (float*)((byte*)&filePatchConfig->MinHeightOffset + filePatchConfig->MinHeightOffset);
            patchConfig.MaxHeight = (float*)((byte*)&filePatchConfig->MaxHeightOffset + filePatchConfig->MaxHeightOffset);

            patch.HeightFormat = filePatch->HeightMap.HeightFormat;
            patch.MinHeightWS = filePatch->HeightMap.MinHeightWS;
            patch.MaxHeightWS = filePatch->HeightMap.MaxHeightWS;
            patch.HeightMap = (uint*)((byte*)&filePatch->HeightMap.HeightMapOffset + filePatch->HeightMap.HeightMapOffset);
            patch.HeightMapSize = filePatch->HeightMap.HeightMapSize;

            patch.ComboFormat = filePatch->ComboFormat;
            patch.ComboTexture = (byte*)&filePatch->ComboTextureOffset + filePatch->ComboTextureOffset;
            patch.ComboTextureSize = filePatch->ComboTextureSize;

            if (patch.ComboFormat != 5 && patch.ComboFormat != 6)
                return false;

            return true;
        }

        private static bool ReadTerrainPatch(ref MappedData mappedData, byte* data, uint dataSize, DeserializationDescription deserializationDescription)
        {
            if (data == null || dataSize < sizeof(FoxDataHeader))
            {
                Debug.Log("Data is empty or length is less than header");
                return false;
            }

            var header = (FoxDataHeader*)data;

            if (header->Name.Hash != new StrCode32("terrainHighBlock"))
            {
                Debug.Log("Header hash isn't terrainHighBlock");
                return false;
            }

            switch (header->Version)
            {
                case 2:
                    return ReadTerrainPatchV2(ref mappedData, header);
                case 3:
                    return ReadTerrainPatchV3(ref mappedData, header);
                case 4:
                    return ReadTerrainPatchV4(ref mappedData, header);
                default:
                    Debug.Log("Unknown header version");
                    return false;
            }
        }

        private static bool ReadTerrainPatchV2(ref MappedData mappedData, FoxDataHeader* header)
        {
            FoxDataNode* heightMapNode = header->GetNodes();
            if (heightMapNode is null)
                return false;

            FoxDataNode* comboTextureNode = heightMapNode->GetNext();
            if (comboTextureNode is null)
                return false;
            
            FoxDataNodeAttribute* pitchParam = heightMapNode->FindParameter("pitch");
            if (pitchParam is null || pitchParam->Type != FoxDataNodeAttribute.DataType.UInt)
                return false;
            
            mappedData.Type = MappedData.MappedDataType.Patch;

            uint pitch = pitchParam->GetUIntValue();
            uint size = pitch * CLUSTER_GRID_SIZE;

            ref Patch patch = ref mappedData.Patch;
            patch.Width = size;
            patch.Height = size;
            patch.TileGridSize = CLUSTER_GRID_SIZE;
            patch.MaxLodLevel = 0;
            patch.LodCount = 5;

            patch.HeightFormat = 1;
            patch.MinHeightWS = 0.0f;
            patch.MaxHeightWS = 0.0f;
            patch.HeightMap = (uint*)heightMapNode->GetData();
            
            patch.ComboFormat = 6;
            patch.ComboTexture = comboTextureNode->GetData();
            patch.ComboTextureSize = size * size * sizeof(uint);

            return true;
        }
        
        private static bool ReadTerrainPatchV3(ref MappedData mappedData, FoxDataHeader* header)
        {
            FoxDataNode* firstNode = header->GetNodes();
            if (firstNode is null)
                return false;

            FoxDataNode* heightMapNode = firstNode;

            FoxDataNode* comboTextureNode = heightMapNode->GetNext();
            if (comboTextureNode is null)
                return false;
            
            FoxDataNodeAttribute* pitchParam = heightMapNode->FindParameter("pitch");
            if (pitchParam is null || pitchParam->Type != FoxDataNodeAttribute.DataType.UInt)
                return false;
            
            mappedData.Type = MappedData.MappedDataType.Patch;

            uint pitch = pitchParam->GetUIntValue();
            uint size = pitch * CLUSTER_GRID_SIZE;

            ref Patch patch = ref mappedData.Patch;
            patch.Width = size;
            patch.Height = size;
            patch.TileGridSize = CLUSTER_GRID_SIZE;
            patch.MaxLodLevel = 0;
            patch.LodCount = 5;

            patch.HeightFormat = 1;
            patch.MinHeightWS = 0.0f;
            patch.MaxHeightWS = 0.0f;
            patch.HeightMapSize = size * size * sizeof(float);
            patch.HeightMap = (uint*)heightMapNode->GetData();
            
            patch.ComboFormat = 6;
            patch.ComboTexture = comboTextureNode->GetData();
            patch.ComboTextureSize = size * size * sizeof(uint);

            FoxDataNode* editParamNode = firstNode->FindNode("editParam");
            if (editParamNode is not null)
            {
                patch.UsePatchConfiguration = true;
                ref PatchConfiguration patchConfiguration = ref patch.PatchConfiguration;
            
                FoxDataNode* lodParameterNode = firstNode->FindNode("lodParameter");
                FoxDataNode* maxHeightNode = firstNode->FindNode("maxHeight");
                FoxDataNode* minHeightNode = firstNode->FindNode("minHeight");
                FoxDataNode* materialIdsNode = firstNode->FindNode("materialIds");
                FoxDataNode* configurationIdsNode = firstNode->FindNode("configrationIds");

                if (lodParameterNode is null
                    || maxHeightNode is null
                    || minHeightNode is null
                    || materialIdsNode is null
                    || configurationIdsNode is null)
                    return false;

                FoxDataNodeAttribute* maxLodParam = editParamNode->FindParameter("maxLodLevel");
                if (maxLodParam is null || maxLodParam->Type != FoxDataNodeAttribute.DataType.UInt)
                    return false;
            
                uint maxLod = maxLodParam->GetUIntValue();
                patch.MaxLodLevel = 0;
                patch.LodCount = (ushort)(maxLod + 1);
            
                patchConfiguration.Params = (uint*)lodParameterNode->GetData();
                patchConfiguration.ConfigurationIds = (uint*)configurationIdsNode->GetData();
                patchConfiguration.MaterialIds = (uint*)materialIdsNode->GetData();
                patchConfiguration.MinHeight = (float*)minHeightNode->GetData();
                patchConfiguration.MaxHeight = (float*)maxHeightNode->GetData();
            }
            
            return true;
        }
        
        private static bool ReadTerrainPatchV4(ref MappedData mappedData, FoxDataHeader* header)
        {
            FoxDataNode* nodes = header->GetNodes();
            if (nodes is null)
                return false;

            FoxDataNode* patchDescriptionNode = nodes->FindNode("patchDescription");

            if (patchDescriptionNode is null)
                return false;

            TerrainFileFormat.PatchDescription* filePatchDesc = (TerrainFileFormat.PatchDescription*)patchDescriptionNode->GetData();
            if (filePatchDesc is null)
                return false;

            if (filePatchDesc->PatchOffset == 0)
                return false;
            
            TerrainFileFormat.Patch* filePatch = (TerrainFileFormat.Patch*)((byte*)&filePatchDesc->PatchOffset + filePatchDesc->PatchOffset);
            
            mappedData.Type = MappedData.MappedDataType.Patch;
            ref Patch patch = ref mappedData.Patch;

            patch.UsePatchConfiguration = true;

            return MapTerrainPatch(ref patch, filePatch);
        }
    }
}