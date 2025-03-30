//#define EXPORT_ENABLE
#if EXPORT_ENABLE
using System;
using Fox.Core;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Rendering;
using Transform = UnityEngine.Transform;
using static Fox.Geo.GeoGeom;
using Material = UnityEngine.Material;

namespace Fox.Geo
{
    public static class GeoFileExporter
    {
        public static void ExportGeoFile(string path, GameObject rootGameObject)
        {
            // Calculate required buffer size
            int estimatedSize = CalculateRequiredSize(rootGameObject);
            byte[] buffer = new byte[estimatedSize];
            
            unsafe
            {
                fixed (byte* bufferPtr = buffer)
                {
                    byte* currentPtr = bufferPtr;
                    
                    // Write header
                    FoxDataHeader header = new FoxDataHeader
                    {
                        Version = 201406020,
                        NodesOffset = FoxDataHeader.SelfSize,
                        FileSize = 0, // Will be filled later
                        Name = new FoxDataString { Hash = new StrCode32("geoms") },
                        Flags = 0
                    };
                    *(FoxDataHeader*)currentPtr = header;
                    currentPtr += FoxDataHeader.SelfSize;
                    
                    // Write root node
                    FoxDataNode rootNode = new FoxDataNode
                    {
                        Name = new FoxDataString { Hash = new StrCode32("geoms") },
                        Flags = (uint)NodePayloadType.Type1,
                        DataOffset = 0,
                        DataSize = 0,
                        ParentNodeOffset = 0,
                        ChildNodeOffset = FoxDataNode.SelfSize, // Points to first child
                        PreviousNodeOffset = 0,
                        NextNodeOffset = 0,
                        ParametersOffset = 0
                    };
                    *(FoxDataNode*)currentPtr = rootNode;
                    currentPtr += FoxDataNode.SelfSize;
                    
                    // Process all child nodes
                    byte* nodesStartPtr = currentPtr;
                    ExportNodes(rootGameObject.transform, ref currentPtr);
                    
                    // Update header with final file size
                    header.FileSize = (uint)(currentPtr - bufferPtr);
                    *(FoxDataHeader*)bufferPtr = header;
                }
            }
            
            // Write to file
            System.IO.File.WriteAllBytes(path, buffer);
        }
        
        private static unsafe void ExportNodes(Transform parentTransform, ref byte* currentPtr)
        {
            // Process all direct children of the parent transform
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform child = parentTransform.GetChild(i);
                string[] nameParts = child.name.Split(new[] { " | " }, StringSplitOptions.None);
                
                if (nameParts.Length < 2)
                    continue;
                    
                string nodeType = nameParts[1];
                byte* nodeStartPtr = currentPtr;
                
                switch (nodeType)
                {
                    case "NODE":
                        ExportNode(child, ref currentPtr);
                        break;
                        
                    case "GROUP":
                        ExportGroup(child, ref currentPtr);
                        break;
                        
                    case "BLOCK":
                        ExportBlock(child, ref currentPtr);
                        break;
                }
                
                // Update next node offset in previous node
                if (i > 0)
                {
                    FoxDataNode* prevNode = (FoxDataNode*)(nodeStartPtr - FoxDataNode.SelfSize);
                    prevNode->NextNodeOffset = (int)(nodeStartPtr - (byte*)prevNode);
                }
            }
        }
        
        private static unsafe void ExportNode(Transform nodeTransform, ref byte* currentPtr)
        {
            string[] nameParts = nodeTransform.name.Split(new[] { " | " }, StringSplitOptions.None);
            StrCode32 nameHash = new StrCode32(nameParts[2]);
            
            FoxDataNode node = new FoxDataNode
            {
                Name = new FoxDataString { Hash = nameHash },
                Flags = (uint)NodePayloadType.Type1,
                DataOffset = 0,
                DataSize = 0,
                ParentNodeOffset = 0, // Will be filled by parent
                ChildNodeOffset = 0,  // Will be filled if has children
                PreviousNodeOffset = 0,
                NextNodeOffset = 0,   // Will be filled by sibling
                ParametersOffset = 0
            };
            
            *(FoxDataNode*)currentPtr = node;
            currentPtr += FoxDataNode.SelfSize;
            
            // Process children if any
            if (nodeTransform.childCount > 0)
            {
                FoxDataNode* writtenNode = (FoxDataNode*)(currentPtr - FoxDataNode.SelfSize);
                writtenNode->ChildNodeOffset = FoxDataNode.SelfSize;
                
                byte* childStartPtr = currentPtr;
                ExportNodes(nodeTransform, ref currentPtr);
                
                // Update parent offsets in children
                FoxDataNode* childNode = (FoxDataNode*)childStartPtr;
                while (childNode != null)
                {
                    childNode->ParentNodeOffset = (int)((byte*)childNode - (byte*)writtenNode);
                    
                    if (childNode->NextNodeOffset == 0)
                        break;
                        
                    childNode = (FoxDataNode*)((byte*)childNode + childNode->NextNodeOffset);
                }
            }
        }
        
        private static unsafe void ExportGroup(Transform groupTransform, ref byte* currentPtr)
        {
            CollisionTags tags = groupTransform.GetComponent<CollisionTags>();
            
            GeoGroup group = new GeoGroup
            {
                BoundingBoxCorner = Vector3.zero, // Will need to calculate this
                GridTotalDataSize = 0, // Will calculate later
                BlockCount = 0, // Will count blocks
                BoundingBoxExtents = Vector3.zero, // Will calculate
                BlocksOffset = 0, // Will set after writing blocks
                GridSize = Vector3.one, // Default
                CellCountX = 1,
                CellCountY = 1,
                CellCountZ = 1,
                Tags = tags != null ? tags.GetTags() : 0
            };
            
            // Write group header
            *(GeoGroup*)currentPtr = group;
            currentPtr += Marshal.SizeOf<GeoGroup>();
            
            // Write blocks
            byte* blocksStartPtr = currentPtr;
            uint blockCount = 0;
            
            for (int i = 0; i < groupTransform.childCount; i++)
            {
                Transform child = groupTransform.GetChild(i);
                if (child.name.Contains(" | BLOCK | "))
                {
                    ExportBlock(child, ref currentPtr);
                    blockCount++;
                }
            }
            
            // Update group with block info
            GeoGroup* writtenGroup = (GeoGroup*)(currentPtr - Marshal.SizeOf<GeoGroup>() - (currentPtr - blocksStartPtr));
            writtenGroup->BlockCount = (ushort)blockCount;
            writtenGroup->BlocksOffset = (uint)(blocksStartPtr - (byte*)writtenGroup);
            
            // TODO: Calculate proper bounding box and grid info
        }
        
        private static unsafe void ExportBlock(Transform blockTransform, ref byte* currentPtr)
        {
            CollisionTags tags = blockTransform.GetComponent<CollisionTags>();
            
            GeoBlock block = new GeoBlock
            {
                IsFinalEntry = false, // Will set properly when we know
                HeaderCount = 0, // Will count headers
                HeadersDataSize = 0, // Will calculate
                VertexBufferOffset_Unused = 0,
                HeadersOffset_Unused = 0,
                VertexBufferOffset = 0, // Will set after writing vertex data
                HeadersOffset = 0, // Will set after writing headers
                MaterialsHeaderOffset = 0, // Will set after writing materials
                Tags = tags != null ? tags.GetTags() : 0
            };
            
            // Write block header
            *(GeoBlock*)currentPtr = block;
            byte* blockStartPtr = currentPtr;
            currentPtr += Marshal.SizeOf<GeoBlock>();
            
            // Write materials header and materials
            GeoBlockMaterialsHeader materialsHeader = new GeoBlockMaterialsHeader
            {
                MaterialsIndexOffset = 0,
                MaterialsCount = 0,
                AuxMaterialsIndexOffset = 0,
                AuxMaterialsCount = 0
            };
            
            *(GeoBlockMaterialsHeader*)currentPtr = materialsHeader;
            currentPtr += Marshal.SizeOf<GeoBlockMaterialsHeader>();
            
            // Update block with materials offset
            GeoBlock* writtenBlock = (GeoBlock*)blockStartPtr;
            writtenBlock->MaterialsHeaderOffset = (uint)((byte*)&materialsHeader - blockStartPtr);
            
            // Write headers
            byte* headersStartPtr = currentPtr;
            uint headerCount = 0;
            
            // Process all geometry headers under this block
            ExportGeometryHeaders(blockTransform, ref currentPtr, ref headerCount);
            
            // Update block with header info
            writtenBlock->HeaderCount = (byte)headerCount;
            writtenBlock->HeadersOffset = (uint)(headersStartPtr - blockStartPtr);
            
            // Write vertex data
            byte* vertexDataStartPtr = currentPtr;
            ExportVertexData(blockTransform, ref currentPtr);
            
            // Update block with vertex data info
            writtenBlock->VertexBufferOffset = (uint)(vertexDataStartPtr - blockStartPtr);
            
            // Set final entry flag if this is the last block in the group
            if (blockTransform.GetSiblingIndex() == blockTransform.parent.childCount - 1)
            {
                writtenBlock->IsFinalEntry = true;
            }
        }
        
        private static unsafe void ExportGeometryHeaders(Transform blockTransform, ref byte* currentPtr, ref uint headerCount)
        {
            // This would traverse the hierarchy of geometry headers and write them
            // Similar to how the importer reads them, but in reverse
            
            // For each geometry object under this block
            for (int i = 0; i < blockTransform.childCount; i++)
            {
                Transform geomTransform = blockTransform.GetChild(i);
                string[] nameParts = geomTransform.name.Split(new[] { " | " }, StringSplitOptions.None);
                
                if (nameParts.Length < 3)
                    continue;
                    
                string geomType = nameParts[2];
                byte* headerStartPtr = currentPtr;
                
                CollisionTags tags = geomTransform.GetComponent<CollisionTags>();
                GeomHeaderFlags flags = 0;
                
                // Set flags based on components
                if (geomTransform.GetComponent<MeshRenderer>() != null)
                {
                    flags |= GeomHeaderFlags.DoubleSided;
                }
                
                // Create header
                GeomHeader header = new GeomHeader
                {
                    Info = 0, // Will set type and flags
                    NextHeaderOffset = 0, // Will set if has next
                    PreviousHeaderOffset = 0,
                    ChildHeaderOffset = 0, // Will set if has children
                    Tags = tags != null ? tags.GetTags() : 0,
                    Name = new StrCode32(geomTransform.name),
                    VertexBufferOffset = 0 // Will set after writing vertex data
                };
                
                // Set type and flags in info
                GeoPrimType type = GeoPrimType.Poly; // Default, would detect from components
                if (geomTransform.GetComponent<BoxCollider>() != null)
                {
                    type = GeoPrimType.AABB;
                }
                
                header.Info = (uint)type | ((uint)flags << 4);
                
                *(GeomHeader*)currentPtr = header;
                currentPtr += Marshal.SizeOf<GeomHeader>();
                headerCount++;
                
                // Write payload based on type
                switch (type)
                {
                    case GeoPrimType.AABB:
                        BoxCollider collider = geomTransform.GetComponent<BoxCollider>();
                        GeoPrimAabb aabb = new GeoPrimAabb
                        {
                            BoundingBoxRadii = collider.size * 0.5f,
                            BoundingBoxCenter = Math.UnityToFoxVector3(collider.center)
                        };
                        *(GeoPrimAabb*)currentPtr = aabb;
                        currentPtr += Marshal.SizeOf<GeoPrimAabb>();
                        break;
                        
                    case GeoPrimType.Poly:
                        MeshFilter meshFilter = geomTransform.GetComponent<MeshFilter>();
                        if (meshFilter != null && meshFilter.sharedMesh != null)
                        {
                            ExportPolyData(meshFilter.sharedMesh, ref currentPtr);
                        }
                        break;
                }
                
                // Process children if any
                if (geomTransform.childCount > 0)
                {
                    GeomHeader* writtenHeader = (GeomHeader*)headerStartPtr;
                    writtenHeader->ChildHeaderOffset = (uint)(currentPtr - (byte*)writtenHeader) / 16;
                    
                    uint childHeaderCount = 0;
                    ExportGeometryHeaders(geomTransform, ref currentPtr, ref childHeaderCount);
                }
                
                // Set next header offset if there is a next sibling
                if (i < blockTransform.childCount - 1)
                {
                    GeomHeader* writtenHeader = (GeomHeader*)headerStartPtr;
                    writtenHeader->NextHeaderOffset = (uint)(currentPtr - (byte*)writtenHeader) / 16;
                }
            }
        }
        
        private static unsafe void ExportPolyData(Mesh mesh, ref byte* currentPtr)
        {
            // Convert mesh data to FoxEngine's poly format
            // This is simplified - actual implementation would need to handle:
            // - Converting quads to the expected format
            // - Handling vertex buffers
            // - Handling indices
            
            // For now, just write placeholder data
            GeoPrimPoly poly = new GeoPrimPoly
            {
                IndexA = 0,
                IndexB = 1,
                IndexC = 2,
                IndexD = 3,
                Info = 0
            };
            
            *(GeoPrimPoly*)currentPtr = poly;
            currentPtr += Marshal.SizeOf<GeoPrimPoly>();
        }
        
        private static unsafe void ExportVertexData(Transform blockTransform, ref byte* currentPtr)
        {
            // This would collect all vertex data from the block's geometry and write it
            
            // For now, just write a placeholder vertex header
            PolyVertexHeader vertexHeader = new PolyVertexHeader
            {
                VertexCount = 0,
                VerticesIndexOffset = 0,
                Unknown0or1 = 0,
                OriginIndex = 0,
                VertexDataOffset = 0,
                FmdlVertexBufferOffset = 0
            };
            
            *(PolyVertexHeader*)currentPtr = vertexHeader;
            currentPtr += Marshal.SizeOf<PolyVertexHeader>();
        }
        
        private static int CalculateRequiredSize(GameObject rootGameObject)
        {
            // This would traverse the hierarchy and calculate the required buffer size
            // For now, return a large enough estimate
            return 1024 * 1024; // 1MB should be enough for most cases
        }
    }

    public static class Math
    {
        public static Vector3 UnityToFoxVector3(Vector3 unityVector)
        {
            return new Vector3(unityVector.x, unityVector.z, unityVector.y);
        }
    }

    [CustomEditor(typeof(GeoFileExporter))]
    public class GeoFileExporterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Export GEO File"))
            {
                string path = EditorUtility.SaveFilePanel("Export GEO File", "", "exported.geom", "geom");
                if (!string.IsNullOrEmpty(path))
                {
                    GeoFileExporter.ExportGeoFile(path, (target as GeoFileExporter).gameObject);
                }
            }
        }
    }
}
#endif