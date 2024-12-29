using Fox.Core;
using Fox.Fio;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox.Gr.Terrain
{
    public enum FileType
    {
        TRE2 = 1,
        HTRE = 2,
    }

    public enum TerrainType
    {
        Map = 0,
        Tile = 1,
    }

    public unsafe class TerrainTileAsset : ScriptableObject
    {
        public TerrainType Type;

        public uint HeightFormat;
        public float MinHeightWS;
        public float MaxHeightWS;

        public Texture2DArray HeightMap;

        public uint ComboFormat;
        public Texture2DArray ComboTexture;

        public uint Height;
        public uint Width;

        public ushort ClusterGridSize;
        public ushort MaxLodLevel;
        public ushort LodCount;

        public struct TerrainMapLocatorDesc
        {
            public uint TotalGridWidth;
            public uint TotalGridHeight;
            public uint LodCount;
            public float MinHeightWS;
            public float MaxHeightWS;
            public float GridDistance;
        }

        private TerrainMapLocatorDesc LocatorDesc;
        public TerrainMapLocatorDesc? MapLocatorDesc => Type == TerrainType.Map ? LocatorDesc : null;

        public Texture2D Params;
        public Texture2D ConfigurationIds;
        public Texture2D MaterialIds;
        public Texture2D MinHeight;
        public Texture2D MaxHeight;

        public void Awake()
        {
            Debug.Log("Awake called");
        }

        public void OnEnable()
        {
            Debug.Log("OnEnable called");
        }

        public void OnDisable()
        {
            Debug.Log("OnDisable called");
        }

        public static bool TryReadTerrainFile(TerrainTileAsset control, ReadOnlySpan<byte> data, FileType fileType)
        {
            if (fileType == FileType.TRE2)
            {
                control.Type = TerrainType.Map;
                return TryReadTRE2(control, data);
            }

            // if (fileType == TerrainFileType.HTRE)
            //     return TryReadHTRE(control, data);

            return false;
        }

        private static bool TryReadTRE2(TerrainTileAsset control, ReadOnlySpan<byte> data)
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
                        return TryReadTRE2V2or3(control, data, header);
                    case 4:
                        return TryReadTRE2V4(control, data, header);
                    default:
                        Debug.Log("Unknown header version");
                        return false;
                }
            }
        }

        private static bool TryReadTRE2V2or3(TerrainTileAsset control, ReadOnlySpan<byte> data, FoxDataHeader* header)
        {
            FoxDataNode* nodes = header->GetNodes();
            if (nodes is not null)
            {
                FoxDataNode* paramNode = nodes->FindNode(new String("param"));
                FoxDataNode* maxHeightNode = nodes->FindNode(new String("maxHeight"));
                FoxDataNode* minHeightNode = nodes->FindNode(new String("minHeight"));
                FoxDataNode* heightMapNode = nodes->FindNode(new String("heightMap"));
                FoxDataNode* comboTextureNode = nodes->FindNode(new String("comboTexture"));
                FoxDataNode* materialIdsNode = nodes->FindNode(new String("materialIds"));
                FoxDataNode* configrationIdsNode = nodes->FindNode(new String("configrationIds"));

                if (paramNode is not null &&
                    maxHeightNode is not null &&
                    minHeightNode is not null &&
                    heightMapNode is not null &&
                    comboTextureNode is not null &&
                    materialIdsNode is not null &&
                    configrationIdsNode is not null)
                {
                    FoxDataParameter* widthParam = paramNode->FindParameter(new String("width"));
                    FoxDataParameter* heightParam = paramNode->FindParameter(new String("height"));
                    FoxDataParameter* highPerLowParam = paramNode->FindParameter(new String("highPerLow"));
                    FoxDataParameter* maxLodLevelParam = paramNode->FindParameter(new String("maxLodLevel"));
                    FoxDataParameter* gridDistanceParam = paramNode->FindParameter(new String("gridDistance"));

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

                        ref TerrainMapLocatorDesc locatorDesc = ref control.LocatorDesc;
                        locatorDesc.GridDistance = gridDistance;
                        locatorDesc.MinHeightWS = -50;
                        locatorDesc.MaxHeightWS = 200;

                        // Round down to nearest multiple of 32. 31 -> 0, 33 -> 32, etc.
                        locatorDesc.TotalGridWidth = (uint)(width & -TerrainFile.CLUSTER_GRID_SIZE);
                        locatorDesc.TotalGridHeight = (uint)(height & -TerrainFile.CLUSTER_GRID_SIZE);

                        locatorDesc.LodCount = maxLodLevel + 1;

                        control.MaxLodLevel = (ushort)maxLodLevel;
                        control.LodCount = (ushort)(control.MaxLodLevel + 1);
                        control.MaxHeightWS = locatorDesc.MaxHeightWS;
                        control.MinHeightWS = locatorDesc.MinHeightWS;
                        control.Width = width / highPerLow;
                        control.Height = height / highPerLow;
                        control.ClusterGridSize = 32;
                        control.ComboFormat = 6;

                        uint texelCount = control.Width * control.Height;

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

                        control.HeightFormat = 1;

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

        private static bool TryReadHTRE(TerrainTileAsset control, ReadOnlySpan<byte> data, FoxDataHeader* header)
        {
            return false;
        }

        private static bool TryReadTRE2V4(TerrainTileAsset control, ReadOnlySpan<byte> data, FoxDataHeader* header)
        {
            FoxDataNode* nodes = header->GetNodes();
            if (nodes is null)
            {
                return false;
            }

            FoxDataNode* paramNode = nodes->FindNode(new String("param"));
            FoxDataNode* maxHeightNode = nodes->FindNode(new String("maxHeight"));
            FoxDataNode* minHeightNode = nodes->FindNode(new String("minHeight"));
            FoxDataNode* heightMapNode = nodes->FindNode(new String("heightMap"));
            FoxDataNode* comboTextureNode = nodes->FindNode(new String("comboTexture"));
            FoxDataNode* materialIdsNode = nodes->FindNode(new String("materialIds"));
            FoxDataNode* configrationIdsNode = nodes->FindNode(new String("configrationIds"));
            FoxDataNode* layoutDescriptionNode = nodes->FindNode(new String("layoutDescription"));

            return true;
        }
    }
}