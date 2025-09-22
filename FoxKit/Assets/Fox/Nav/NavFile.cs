using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;
using System.IO;

namespace Fox.Nav
{
    public unsafe class NavFile : MonoBehaviour
    {
        #region Properties
        
        [HideInInspector]
        public byte[] Data;

        [Header("Visualization Options")]
        public bool ShowText = true;
        
        [Space]
        [Header("Navigation Graph")]
        public bool ShowNavigationGraph = true;
        public Color NavigationGraphNodeColor = new Color(0.3f, 0.3f, 1.0f, 1.0f);
        public Color NavigationGraphEdgeColor = new Color(0.2f, 0.2f, 0.8f, 0.8f);
        public float NavigationGraphNodeSize = 0.2f;
        
        [Space]
        [Header("Navmesh")]
        public bool ShowNavmesh = true;
        public Color NavmeshTriangleColor = new Color(1.0f, 1.0f, 0.3f, 0.5f);
        public Color NavmeshWireframeColor = new Color(0.8f, 0.8f, 0.2f, 1.0f);
        
        [Space]
        [Header("Segment Graph")]
        public bool ShowSegmentGraph = true;
        public Color SegmentGraphNodeColor = new Color(1.0f, 0.3f, 0.3f, 1.0f);
        public Color SegmentGraphLinkColor = new Color(0.8f, 0.2f, 0.2f, 0.8f);
        public float SegmentGraphNodeSize = 0.3f;
        
        [Space]
        [Header("Segments")]
        public bool ShowSegments = true;
        public Color SegmentBoundsColor = new Color(0.9f, 0.5f, 0.1f, 0.4f);
        public Color SegmentBoundsWireColor = new Color(0.9f, 0.5f, 0.1f, 0.8f);
        
        [Space]
        [Header("Node Connections")]
        public bool ShowNavigationGraphToSegmentLinks = true;
        public Color NavigationGraphToSegmentLinkColor = new Color(0.6f, 0.6f, 0.6f, 0.3f);
        
        [Space]
        [Header("Island Graph")]
        public bool ShowIslandGraph = true;
        public Color IslandGraphNodeColor = new Color(0.3f, 1.0f, 0.3f, 1.0f);
        public Color IslandGraphLinkColor = new Color(0.2f, 0.8f, 0.2f, 0.8f);
        public float IslandGraphNodeSize = 0.5f;
        
        [Space]
        [Header("Search Space")]
        public bool ShowSearchSpace = true;
        public Color SearchSpaceBucketColor = new Color(1.0f, 0.3f, 1.0f, 0.3f);
        public Color SearchSpaceOriginColor = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        public float SearchSpaceOriginSize = 1.0f;
        
        #endregion
        
        #region Definitions

        [Flags]
        public enum Nav2FeatureFlags : byte
        {
            A = 1 << 0,
            B = 1 << 1,
            C = 1 << 2,
            D = 1 << 7
        }
        
        // Fixed point types
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FixedDenominator3
        {
            public ushort x;
            public ushort y;
            public ushort z;
            
            public Vector3 ToVector3(FixedDenominator3 denominator)
            {
                return new Vector3(
                    (float)x / denominator.x,
                    (float)y / denominator.y,
                    (float)z / denominator.z
                );
            }
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FixedScalar
        {
            public ushort x;
            
            public float ToFloat(FixedScalar denominator)
            {
                return (float)x / denominator.x;
            }
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BoundingDesc
        {
            public FixedDenominator3 Min;
            public FixedDenominator3 Max;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FileUid
        {
            private uint packed;
            
            public uint Index => packed & 0x7FFF; // 15 bits
            public uint TileId => (packed >> 15) & 0xFFFF; // 16 bits
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DataChunkUid
        {
            private uint packed;
            
            public uint Index => packed & 0x7FFF; // 15 bits
            public uint TileId => (packed >> 15) & 0xFFFF; // 16 bits
        }
        
        // Enums from the template
        public enum ChunkType : uint
        {
            NavigationGraph = 0,
            NavmeshChunk = 1,
            SegmentGraph = 3,
            SegmentChunk = 4
        }
        
        public enum NavigationGraphKind : uint
        {
            Static = 0,
            Dynamic = 1
        }
        
        public enum NavmeshNeighborType : uint
        {
            Inside = 0,
            CrossingDataChunk = 1,
            CrossingTile = 2,
            Dynamic = 3,
            Invalid = 0xF
        }
        
        public enum IslandGraphConnectSideIndex : uint
        {
            Side0 = 0,
            Side1 = 1,
            Side2 = 2,
            Side3 = 3
        }
        
        // Main file header
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FileHeader
        {
            public uint Version;
            public uint FileSize;
            public uint ChunksOffset;
            public uint ChunkCount;
            public uint SearchSpaceOffset;
            public FileUid _FileUid;
            public uint IslandGraphsOffset;
            public uint Unknown_CrossingTileLinkRelated;
            public Vector3 Origin;
            public uint ConnectTileInfosOffset;
            public uint Padding0;
            public uint ChunkDescsOffset;
            public uint ChunkDescsDataSize;
            public uint Padding1;
            public uint Padding2;
            public FixedDenominator3 Denominator;
            public FixedScalar WeightDenominator;
            public Nav2FeatureFlags FeatureFlags;
            public byte IslandGraphCount;
            public byte Pre2014_UnknownIndex;
            public byte Padding3;
        }
        
        // Chunk structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ChunkHeader
        {
            public ChunkType Type;
            public uint NextChunkOffset;
            public uint DataOffset;
            public DataChunkUid _DataChunkUid;
        }
        
        // Navigation Graph structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NavigationGraphChunkHeader
        {
            public uint PositionsOffset;
            public uint NodesOffset;
            public uint EdgesOffset;
            public uint LinkDataOffset;
            public uint Padding0;
            public uint Padding1;
            public uint AttributesOffset;
            public uint Padding2;
            public uint NavmeshIndicesOffset;
            public ushort NodeCount;
            public ushort EdgeCount;
            public uint Padding3;
            public ushort Padding4;
            public ushort AttributeCount;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NavigationGraphNodeDesc
        {
            public ushort LinkDataOffset;
            private ushort packed1;
            public byte InsideLinkCount;
            private byte packed2;
            
            public ushort SegmentIndex => (ushort)(packed1 & 0x0FFF); // 12 bits
            public ushort LinkDataOffsetUpper => (ushort)((packed1 >> 12) & 0xF); // 4 bits
            public bool HasCrossingSegmentLink => (packed2 & 0x01) != 0;
            public bool HasCrossingDataChunkLink => (packed2 & 0x02) != 0;
            public bool HasCrossingTileLink => (packed2 & 0x04) != 0;
            public NavigationGraphKind Kind => (NavigationGraphKind)((packed2 >> 3) & 0x3); // 2 bits
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct NavigationGraphInsideLinkDesc
        {
            public ushort NodeIndex;
            public ushort EdgeIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct NavigationGraphCrossingSegmentLinkDesc
        {
            public ushort NodeIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct NavigationGraphCrossingDataChunkLinkDesc
        {
            public ushort DataChunkId;
            public ushort NodeIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct NavigationGraphCrossingTileLinkDesc
        {
            public ushort TileId;
            public ushort DataChunkId;
            public ushort NodeIndex; // Should be 0xFFFF for unresolved tile links
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NavigationGraphEdgeDesc
        {
            public FixedScalar Weight;
            private ushort packed;
            public byte NodeIndex0;
            public byte NodeIndex1;
            
            public ushort SegmentIndex => (ushort)(packed & 0x0FFF); // 12 bits
            public NavigationGraphKind Kind => (NavigationGraphKind)((packed >> 12) & 0x3); // 2 bits
        }
        
        // Navmesh structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NavmeshChunkHeader
        {
            public uint PositionsOffset;
            public uint MeshesOffset;
            public uint MeshDataOffset;
            public ulong Padding0;
            public uint Padding1;
            public ushort MeshCount;
            public ushort PositionCount;
            public uint Padding2;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NavmeshDesc
        {
            private uint packed;
            
            public uint DataOffset => packed & 0x3FFFF; // 18 bits
            public bool Use4NeighborInfos => ((packed >> 18) & 0x1) == 1; // 1 bit
            public bool Use4NavigationGraphNodes => ((packed >> 19) & 0x1) == 1; // 1 bit
            public uint SegmentIndex => (packed >> 20) & 0xFFF; // 12 bits
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NeighborNavmeshInfo
        {
            private ushort packed;
            
            public ushort NavmeshIndex => (ushort)(packed & 0x3FFF); // 14 bits
            public NavmeshNeighborType Type => (NavmeshNeighborType)((packed >> 14) & 0x3); // 2 bits
        }
        
        // Segment Graph structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentGraphChunkHeader
        {
            public uint PositionsOffset;
            public uint NodesOffset;
            public uint LinkDataOffset;
            public uint Padding0;
            public uint SelfSize;
            public ushort NodeCount;
            public uint Padding1;
            public ushort TotalNavigationGraphNodeIndexCount;
            public uint Padding2;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentGraphNodeDesc
        {
            private uint packed;
            public ushort IslandGraphNodeIndex0;
            public ushort IslandGraphNodeIndex1;
            public ushort IslandGraphNodeIndex2;
            public byte CrossingDataChunkLinkCount;
            public byte CrossingTileLinkCount;
            
            public uint LinkDataOffset => packed & 0xFFFFF; // 20 bits
            public uint Unknown => (packed >> 20) & 0xF; // 4 bits
            public uint InsideLinkCount => (packed >> 24) & 0xFF; // 8 bits
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentGraphInsideLinkDesc
        {
            public FixedScalar Weight;
            public ushort NodeIndex;
            public byte NavigationGraphNodeIndexCount;
            public byte LinkIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentGraphCrossingDataChunkLinkDesc
        {
            public ushort DataChunkId;
            public FixedScalar Weight;
            public ushort NodeIndex;
            public byte NavigationGraphNodeIndexCount;
            public byte LinkIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentGraphCrossingTileLinkDesc
        {
            public ushort TileId;
            public ushort DataChunkId;
            public FixedScalar Weight;
            public ushort NodeIndex; // Should be 0xFFF for unresolved tile links
            public byte NavigationGraphNodeIndexCount;
            public byte LinkIndex;
        }
        
        // Segment structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentChunkHeader
        {
            public uint BoundsOffset;
            public uint SegmentsOffset;
            public uint SelfSize;
            public uint SegmentCount;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentDesc
        {
            public ushort BaseNavmeshPositionIndex;
            public ushort BaseNavmeshIndex;
            public ushort BaseNavigationGraphEdgeIndex;
            public ushort BaseNavigationGraphNodeIndex;
            public byte NavmeshPositionCount;
            public byte NavmeshCount;
            public byte NavigationGraphEdgeCount;
            public byte NavigationGraphNodeCount;
        }
        
        // Island graph structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphHeader
        {
            public ushort NextGraphOffset;
            public ushort NodesOffset;
            public ushort NodeCount;
            public ushort LinkDataOffset;
            public ushort LowGraphNodeHandlesOffset;
            public ushort SegmentCountsOffset;
            public ushort ConnectSideInfoGroupsOffset;
            public ushort ConnectSideInfosOffset;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphNodeDesc
        {
            public FixedDenominator3 Position;
            public ushort Attributes;
            public ushort LinkDataOffset;
            public ushort CrossingTileLinkCount;
            public byte InsideLinkCount;
            public byte CrossingDataChunkLinkCount;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphCrossingDataChunkLinkDesc
        {
            public DataChunkUid _DataChunkUid;
            public FixedScalar Weight;
            public ushort NodeIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphInsideLinkDesc
        {
            public FixedScalar Weight;
            public ushort NodeIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphCrossingTileLinkDesc
        {
            private ushort packed;
            
            public ushort ConnectSideInfoIndex => (ushort)(packed & 0x3FFF); // 14 bits
            public IslandGraphConnectSideIndex ConnectSideIndex => (IslandGraphConnectSideIndex)((packed >> 14) & 0x3); // 2 bits
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphLowGraphNodeHandle
        {
            public DataChunkUid _DataChunkUid;
            public ushort SegmentGraphNodeIndex;
            public ushort NavigationGraphNodeIndex;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphConnectSideInfoGroupDesc
        {
            public ushort TileId;
            public ushort StartIndex;
            public ushort Count;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IslandGraphConnectSideInfoDesc
        {
            public FixedScalar Weight;
            public ushort NodeIndex;
        }
        
        // Search Space structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SearchSpaceHeader
        {
            public Vector3 Origin;
            public FixedScalar RangeY;
            public ushort Padding0;
            public uint BlockCountX;
            public uint BlockCountY;
            public uint BlockCountZ;
            public uint BlockSizeXZ;
            public uint BlockSizeY;
            public uint BucketDescsOffset;
            public uint BucketEntriesOffset;
            public uint SelfSize;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SearchBucketDesc
        {
            public uint StartOffset;
            public ushort Count;
            public byte MinY;
            public byte MaxY;
        }
        
        #endregion
        
        public void OnDrawGizmos()
        {
            if (Data == null || Data.Length < sizeof(FileHeader))
                return;
            
            fixed (byte* ptr = Data)
            {
                FileHeader* fileHeader = (FileHeader*)ptr;
                    
                DrawChunks(fileHeader);
                
                if (ShowIslandGraph && fileHeader->IslandGraphsOffset != 0)
                    DrawIslandGraphs(fileHeader);
                    
                if (ShowSearchSpace && fileHeader->SearchSpaceOffset != 0)
                    DrawSearchSpace(fileHeader);
            }
        }

        public struct DataChunk
        {
            public NavigationGraphChunkHeader* NavigationGraph;
            public NavmeshChunkHeader* NavmeshChunk;
            public SegmentGraphChunkHeader* SegmentGraph;
            public SegmentChunkHeader* SegmentChunk;
        }
        
        void DrawChunks(FileHeader* fileHeader)
        {
            byte* dataPtr = (byte*)fileHeader;
            
            byte* chunkPtr = dataPtr + fileHeader->ChunksOffset;

            // First pass: populate DataChunk structures
            DataChunk* dataChunks = stackalloc DataChunk[5];
            byte* tempChunkPtr = chunkPtr;
            for (int i = 0; i < fileHeader->ChunkCount; i++)
            {
                ChunkHeader* chunkHeader = (ChunkHeader*)tempChunkPtr;
            
                uint dataChunkId = chunkHeader->_DataChunkUid.Index;

                if (dataChunkId > 4)
                {
                    Debug.LogWarning("Unknown DataChunkId detected.");
                    return;
                }
                
                byte* chunkDataPtr = tempChunkPtr + chunkHeader->DataOffset;
                switch (chunkHeader->Type)
                {
                    case ChunkType.NavigationGraph:
                        dataChunks[dataChunkId].NavigationGraph = (NavigationGraphChunkHeader*)chunkDataPtr;
                        break;
                    case ChunkType.NavmeshChunk:
                        dataChunks[dataChunkId].NavmeshChunk = (NavmeshChunkHeader*)chunkDataPtr;
                        break;
                    case ChunkType.SegmentGraph:
                        dataChunks[dataChunkId].SegmentGraph = (SegmentGraphChunkHeader*)chunkDataPtr;
                        break;
                    case ChunkType.SegmentChunk:
                        dataChunks[dataChunkId].SegmentChunk = (SegmentChunkHeader*)chunkDataPtr;
                        break;
                }
                
                tempChunkPtr += chunkHeader->NextChunkOffset;
            }

            // Second pass: draw with proper DataChunk references
            tempChunkPtr = chunkPtr;
            for (int i = 0; i < fileHeader->ChunkCount; i++)
            {
                ChunkHeader* chunkHeader = (ChunkHeader*)tempChunkPtr;
                
                uint dataChunkId = chunkHeader->_DataChunkUid.Index;
                byte* chunkDataPtr = tempChunkPtr + chunkHeader->DataOffset;
                switch (chunkHeader->Type)
                {
                    case ChunkType.NavigationGraph:
                        if (ShowNavigationGraph)
                            DrawNavigationGraph(fileHeader, dataChunks + dataChunkId, chunkDataPtr);
                        break;
                    case ChunkType.NavmeshChunk:
                        if (ShowNavmesh)
                            DrawNavmeshChunk(fileHeader, dataChunks + dataChunkId, chunkDataPtr);
                        break;
                    case ChunkType.SegmentGraph:
                        if (ShowSegmentGraph)
                            DrawSegmentGraph(fileHeader, dataChunks + dataChunkId, chunkDataPtr);
                        break;
                    case ChunkType.SegmentChunk:
                        if (ShowSegments)
                            DrawSegmentChunk(fileHeader, dataChunks + dataChunkId, chunkDataPtr);
                        break;
                }
                
                tempChunkPtr += chunkHeader->NextChunkOffset;
            }
        }
        
        void DrawNavigationGraph(FileHeader* fileHeader, DataChunk* dataChunk, byte* chunkDataPtr)
        {
            NavigationGraphChunkHeader* navGraphHeader = (NavigationGraphChunkHeader*)chunkDataPtr;
            
            // Get positions, nodes and edges
            FixedDenominator3* positions = (FixedDenominator3*)(chunkDataPtr + navGraphHeader->PositionsOffset);
            NavigationGraphNodeDesc* nodes = (NavigationGraphNodeDesc*)(chunkDataPtr + navGraphHeader->NodesOffset);
            NavigationGraphEdgeDesc* edges = (NavigationGraphEdgeDesc*)(chunkDataPtr + navGraphHeader->EdgesOffset);
            
            // Get segment descriptions for base index lookups
            SegmentDesc* segments = (SegmentDesc*)((byte*)dataChunk->SegmentChunk + dataChunk->SegmentChunk->SegmentsOffset);
            SegmentGraphChunkHeader* segmentGraphHeader = dataChunk->SegmentGraph;
            FixedDenominator3* segmentPositions = (FixedDenominator3*)((byte*)segmentGraphHeader + segmentGraphHeader->PositionsOffset);
            
            // Draw nodes
            for (uint i = 0; i < navGraphHeader->NodeCount; i++)
            {
                NavigationGraphNodeDesc* node = nodes + i;
                
                Gizmos.color = NavigationGraphNodeColor;
                Vector3 worldPos = fileHeader->Origin + positions[i].ToVector3(fileHeader->Denominator);
                Gizmos.DrawWireSphere(worldPos, NavigationGraphNodeSize);
                
                // Now draw all the links for this node
                byte* linkDataBasePtr = chunkDataPtr + navGraphHeader->LinkDataOffset;
                byte* nodeLinkDataPtr = linkDataBasePtr + (node->LinkDataOffsetUpper * 16 + node->LinkDataOffset * 2);
                
                nodeLinkDataPtr += node->InsideLinkCount * sizeof(NavigationGraphInsideLinkDesc);

                // Skip crossing unsupported links
                if (node->HasCrossingSegmentLink)
                {
                    nodeLinkDataPtr += sizeof(NavigationGraphCrossingSegmentLinkDesc);
                }

                if (node->HasCrossingDataChunkLink)
                {
                    nodeLinkDataPtr += sizeof(NavigationGraphCrossingDataChunkLinkDesc);
                }

                if (node->HasCrossingTileLink)
                {
                }
                
                // Optional: Draw connection to segment
                if (ShowNavigationGraphToSegmentLinks)
                {
                    uint segmentIndex = node->SegmentIndex;
                    
                    // Draw weak connection
                    Vector3 segmentWorldPos = fileHeader->Origin + segmentPositions[segmentIndex].ToVector3(fileHeader->Denominator);
                                        
                    Gizmos.color = NavigationGraphToSegmentLinkColor;
                    Gizmos.DrawLine(worldPos, segmentWorldPos);
                }
            }
            
            // Draw edges
            for (uint i = 0; i < navGraphHeader->EdgeCount; i++)
            {
                Gizmos.color = NavigationGraphEdgeColor;
                NavigationGraphEdgeDesc* edge = edges + i;
                
                // Calculate actual node indices using segment base indices
                SegmentDesc* segment = segments + edge->SegmentIndex;
                uint actualNodeIndex0 = (uint)segment->BaseNavigationGraphNodeIndex + edge->NodeIndex0;
                uint actualNodeIndex1 = (uint)segment->BaseNavigationGraphNodeIndex + edge->NodeIndex1;
                
                Vector3 pos0 = fileHeader->Origin + positions[actualNodeIndex0].ToVector3(fileHeader->Denominator);
                Vector3 pos1 = fileHeader->Origin + positions[actualNodeIndex1].ToVector3(fileHeader->Denominator);
                
                Gizmos.DrawLine(pos0, pos1);
                
                if (ShowText)
                {
                    float weight = edge->Weight.ToFloat(fileHeader->WeightDenominator);
                    DrawLabel((pos0 + pos1) * 0.5f, $"{weight:F2}");
                }
            }
        }
        
        void DrawNavmeshChunk(FileHeader* fileHeader, DataChunk* dataChunk, byte* chunkDataPtr)
        {
            NavmeshChunkHeader* navmeshHeader = (NavmeshChunkHeader*)chunkDataPtr;
            
            // Get positions and meshes
            FixedDenominator3* positions = (FixedDenominator3*)(chunkDataPtr + navmeshHeader->PositionsOffset);
            NavmeshDesc* meshes = (NavmeshDesc*)(chunkDataPtr + navmeshHeader->MeshesOffset);
            
            // Get segment descriptions for base index lookups
            SegmentDesc* segments = (SegmentDesc*)((byte*)dataChunk->SegmentChunk + dataChunk->SegmentChunk->SegmentsOffset);
            
            for (uint meshIndex = 0; meshIndex < navmeshHeader->MeshCount; meshIndex++)
            {
                NavmeshDesc* mesh = meshes + meshIndex;
                
                // Get mesh data
                byte* meshDataPtr = chunkDataPtr + navmeshHeader->MeshDataOffset + mesh->DataOffset * 2;
                NeighborNavmeshInfo* neighborInfos = (NeighborNavmeshInfo*)meshDataPtr;
                
                // Skip neighbor infos to get to position indices
                uint neighborCount = mesh->Use4NeighborInfos ? 4u : 3u;
                byte* positionIndicesPtr = meshDataPtr + (neighborCount * sizeof(NeighborNavmeshInfo));
                
                // Calculate actual mesh index using segment base indices
                SegmentDesc* segment = segments + mesh->SegmentIndex;
                
                // Draw wireframe
                Gizmos.color = NavmeshWireframeColor;
                for (uint i = 0; i < neighborCount; i++)
                {
                    long nextI = (i + 1) % neighborCount;
                    Vector3 vertex = fileHeader->Origin + positions[(uint)segment->BaseNavmeshPositionIndex + positionIndicesPtr[i]].ToVector3(fileHeader->Denominator);
                    Vector3 nextVertex = fileHeader->Origin + positions[(uint)segment->BaseNavmeshPositionIndex + positionIndicesPtr[nextI]].ToVector3(fileHeader->Denominator);
                    Gizmos.DrawLine(vertex, nextVertex);
                }
            }
        }
        
        void DrawSegmentGraph(FileHeader* fileHeader, DataChunk* dataChunk, byte* chunkDataPtr)
        {
            SegmentGraphChunkHeader* segmentGraphHeader = (SegmentGraphChunkHeader*)chunkDataPtr;
            
            // Get positions and nodes
            FixedDenominator3* positions = (FixedDenominator3*)(chunkDataPtr + segmentGraphHeader->PositionsOffset);
            SegmentGraphNodeDesc* nodes = (SegmentGraphNodeDesc*)(chunkDataPtr + segmentGraphHeader->NodesOffset);
            
            // Draw nodes
            for (uint nodeIndex = 0; nodeIndex < segmentGraphHeader->NodeCount; nodeIndex++)
            {
                SegmentGraphNodeDesc* node = nodes + nodeIndex;
                
                Gizmos.color = SegmentGraphNodeColor;
                Vector3 worldPos = fileHeader->Origin + positions[nodeIndex].ToVector3(fileHeader->Denominator);
                Gizmos.DrawWireCube(worldPos, Vector3.one * SegmentGraphNodeSize);
                
                // Now draw all the links for this node
                byte* linkDataBasePtr = chunkDataPtr + segmentGraphHeader->LinkDataOffset;
                byte* nodeLinkDataPtr = linkDataBasePtr + (node->LinkDataOffset * 2);
            
                Vector3 fromPos = worldPos;
            
                // Draw inside links
                SegmentGraphInsideLinkDesc* insideLinks = (SegmentGraphInsideLinkDesc*)nodeLinkDataPtr;
            
                Gizmos.color = SegmentGraphLinkColor;
                for (uint linkIndex = 0; linkIndex < node->InsideLinkCount; linkIndex++)
                {
                    SegmentGraphInsideLinkDesc* link = insideLinks + linkIndex;
                
                    Vector3 toPos = fileHeader->Origin + positions[link->NodeIndex].ToVector3(fileHeader->Denominator);
                    Gizmos.DrawLine(fromPos, toPos);
                
                    if (ShowText)
                    {
                        float weight = link->Weight.ToFloat(fileHeader->WeightDenominator);
                        DrawLabel((fromPos + toPos) * 0.5f, $"{weight:F2}");
                    }
                }
            }
        }
        
        void DrawSegmentChunk(FileHeader* fileHeader, DataChunk* dataChunk, byte* chunkDataPtr)
        {
            SegmentChunkHeader* segmentChunkHeader = (SegmentChunkHeader*)chunkDataPtr;
            
            // Get bounding boxes and segment descriptions
            BoundingDesc* bounds = (BoundingDesc*)(chunkDataPtr + segmentChunkHeader->BoundsOffset);
            SegmentDesc* segments = (SegmentDesc*)(chunkDataPtr + segmentChunkHeader->SegmentsOffset);
            
            for (uint segmentIndex = 0; segmentIndex < segmentChunkHeader->SegmentCount; segmentIndex++)
            {
                BoundingDesc* bound = bounds + segmentIndex;
                SegmentDesc* segment = segments + segmentIndex;
                
                // Convert fixed point bounds to world space
                Vector3 minBounds = fileHeader->Origin + bound->Min.ToVector3(fileHeader->Denominator);
                Vector3 maxBounds = fileHeader->Origin + bound->Max.ToVector3(fileHeader->Denominator);
                
                Vector3 center = (minBounds + maxBounds) * 0.5f;
                Vector3 size = maxBounds - minBounds;
                
                // Draw filled bounding box
                Gizmos.color = SegmentBoundsColor;
                Gizmos.DrawCube(center, size);
                
                // Draw wireframe outline
                Gizmos.color = SegmentBoundsWireColor;
                Gizmos.DrawWireCube(center, size);
            }
        }
        
        void DrawIslandGraphs(FileHeader* fileHeader)
        {
            byte* dataPtr = (byte*)fileHeader;
            
            IslandGraphHeader* islandGraphHeader = (IslandGraphHeader*)(dataPtr + fileHeader->IslandGraphsOffset);
            for (uint i = 0; i < fileHeader->IslandGraphCount; i++)
            {
                // Get nodes array
                IslandGraphNodeDesc* nodes = (IslandGraphNodeDesc*)((byte*)islandGraphHeader + islandGraphHeader->NodesOffset);
                
                // Draw nodes
                Gizmos.color = IslandGraphNodeColor;
                for (uint j = 0; j < islandGraphHeader->NodeCount; j++)
                {
                    IslandGraphNodeDesc* node = nodes + j;
                    Vector3 worldPos = fileHeader->Origin + node->Position.ToVector3(fileHeader->Denominator);
                    Gizmos.DrawWireSphere(worldPos, IslandGraphNodeSize);
                }
                
                // Draw inside links
                Gizmos.color = IslandGraphLinkColor;
                for (uint nodeIndex = 0; nodeIndex < islandGraphHeader->NodeCount; nodeIndex++)
                {
                    IslandGraphNodeDesc* node = nodes + nodeIndex;
                    if (node->InsideLinkCount == 0)
                        continue;
                    
                    // Navigate to this node's link data
                    byte* linkDataPtr = (byte*)islandGraphHeader + islandGraphHeader->LinkDataOffset + node->LinkDataOffset;
                    
                    // Skip crossing data chunk links first
                    linkDataPtr += node->CrossingDataChunkLinkCount * sizeof(IslandGraphCrossingDataChunkLinkDesc);
                    
                    // Now we're at the inside links
                    IslandGraphInsideLinkDesc* links = (IslandGraphInsideLinkDesc*)linkDataPtr;
                    
                    Vector3 fromPos = fileHeader->Origin + node->Position.ToVector3(fileHeader->Denominator);
                    
                    for (uint linkIndex = 0; linkIndex < node->InsideLinkCount; linkIndex++)
                    {
                        IslandGraphInsideLinkDesc* link = links + linkIndex;
                        
                        IslandGraphNodeDesc* toNode = nodes + link->NodeIndex;
                        Vector3 toPos = fileHeader->Origin + toNode->Position.ToVector3(fileHeader->Denominator);
                        
                        Gizmos.DrawLine(fromPos, toPos);
                        
                        float weight = link->Weight.ToFloat(fileHeader->WeightDenominator);
                        DrawLabel((fromPos + toPos) * 0.5f, $"{weight:F2}");
                    }
                }
                
                if (islandGraphHeader->NextGraphOffset != 0)
                    islandGraphHeader = (IslandGraphHeader*)((byte*)islandGraphHeader + islandGraphHeader->NextGraphOffset);
            }
        }
        
        void DrawSearchSpace(FileHeader* fileHeader)
        {
            byte* dataPtr = (byte*)fileHeader;
            
            SearchSpaceHeader* searchSpace = (SearchSpaceHeader*)(dataPtr + fileHeader->SearchSpaceOffset);
            
            // Draw search space origin
            Gizmos.color = SearchSpaceOriginColor;
            Gizmos.DrawWireSphere(searchSpace->Origin, SearchSpaceOriginSize);
            
            DrawLabel(searchSpace->Origin + Vector3.up * (SearchSpaceOriginSize + 0.2f), "SearchSpace Origin");
            
            // Draw search space bounds
            Gizmos.color = SearchSpaceBucketColor;
            
            float blockSizeXZ = searchSpace->BlockSizeXZ;
            float blockSizeY = searchSpace->BlockSizeY;
            
            Vector3 searchSpaceSize = new Vector3(
                searchSpace->BlockCountX * blockSizeXZ,
                searchSpace->BlockCountY * blockSizeY,
                searchSpace->BlockCountZ * blockSizeXZ
            );
            
            Vector3 searchSpaceCenter = searchSpace->Origin + searchSpaceSize * 0.5f;
            Gizmos.DrawWireCube(searchSpaceCenter, searchSpaceSize);
            
            // Optionally draw individual buckets (can be expensive for large search spaces)
            SearchBucketDesc* buckets = (SearchBucketDesc*)(dataPtr + fileHeader->SearchSpaceOffset + searchSpace->BucketDescsOffset);
            
            uint bucketIndex = 0;
            for (uint z = 0; z < searchSpace->BlockCountZ; z++)
            {
                for (uint y = 0; y < searchSpace->BlockCountY; y++)
                {
                    for (uint x = 0; x < searchSpace->BlockCountX; x++)
                    {
                        SearchBucketDesc* bucket = buckets + bucketIndex;
                        if (bucket->Count > 0)
                        {
                            float minY = 256.0f * bucket->MinY / fileHeader->Denominator.y + fileHeader->Origin.y;
                            float maxY = 256.0f * bucket->MaxY  / fileHeader->Denominator.y + (256.0f / fileHeader->Denominator.y + fileHeader->Origin.y);

                            float yMidpoint = (minY + maxY) / 2.0f;
                            float yRange = maxY - minY;
                            
                            Vector3 actualBucketPos = new Vector3((x + 0.5f) * blockSizeXZ + searchSpace->Origin.x, yMidpoint, (z + 0.5f) * blockSizeXZ + searchSpace->Origin.z);
                            Vector3 actualBucketSize = new Vector3(blockSizeXZ, yRange, blockSizeXZ);
                            
                            Gizmos.color = SearchSpaceBucketColor;
                            Gizmos.DrawWireCube(actualBucketPos, actualBucketSize);
                        }
                        
                        bucketIndex++;
                    }
                }
            }
        }

        private void DrawLabel(Vector3 position, string label)
        {
#if UNITY_EDITOR
            if (ShowText)
                UnityEditor.Handles.Label(position, label);
#endif
        }
    }
}