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
    [ScriptedImporter(0, "geoms")]
    public unsafe class GeoFileImporter : ScriptedImporter
    {
        private Material VisualizerMaterial;
        
        public override void OnImportAsset(AssetImportContext context)
        {
            // Init globals
            VisualizerMaterial = AssetDatabase.LoadAssetAtPath<Material>("Assets/Fox/Geo/Geom/GeomVisualizer.mat");

            string name = System.IO.Path.GetFileName(context.assetPath);
        
            ReadOnlySpan<byte> fileData = System.IO.File.ReadAllBytes(assetPath);
            
            string fmdlPath = System.IO.Path.ChangeExtension(context.assetPath, ".fmdl");
            ReadOnlySpan<byte> fmdlFileData = System.IO.File.Exists(fmdlPath) ? System.IO.File.ReadAllBytes(fmdlPath) : null;

            if (fileData.IsEmpty || fileData.Length < sizeof(FoxDataHeader))
            {
                context.LogImportError("Data is empty or length is less than header");
                return;
            }

            fixed (byte* data = fileData, fmdlData = fmdlFileData)
            {
                var header = (FoxDataHeader*)data;

                // TODO: what is the hash here?
                // if (header->Name.Hash != new StrCode32("geoms"))
                // {
                //     context.LogImportError("Header hash isn't tre2");
                //     return;
                // }

                if (header->Version != 201406020)
                {
                    context.LogImportError($"Version is {header->Version}");
                    return;
                }

                var main = new GameObject(header->Name.Hash.ToString());

                FoxDataNode* nodes = header->GetNodes();
                
                if (fmdlFileData != null)
                    TrySetVertexBuffer(nodes, fmdlData);
                
                ReadNodes(context, nodes, main);

                context.AddObjectToAsset(header->Name.Hash.ToString(), main);
                context.SetMainObject(main);
            }
        }

        private void ReadNodes(AssetImportContext context, FoxDataNode* nodes, GameObject parent)
        {
            for (var node = nodes; node != null; node = node->GetNext())
            {
                FoxDataString name = node->Name;
                NodePayloadType flags = (NodePayloadType)node->Flags;
                Debug.Assert(flags == NodePayloadType.Type1 || flags == NodePayloadType.Type2);
                
                var nodeGameObject = new GameObject(name.Hash.ToString());
                nodeGameObject.transform.parent = parent.transform;
                
                for (var subNode = node->GetChildren(); subNode != null; subNode = subNode->GetNext())
                {
                    FoxDataString subName = subNode->Name;
                    NodePayloadType subFlags = (NodePayloadType)subNode->Flags;

                    var subNodeGameObject = new GameObject(subName.Hash.ToString());
                    subNodeGameObject.transform.parent = nodeGameObject.transform;
                    
                    switch (subFlags)
                    {
                        // NOT VALID FOR GEOM(S)
                        // case GeoGeom.NodePayloadType.Bone:
                        //     GeoGeom.GeoBone* bone = (GeoGeom.GeoBone*)subNode->GetData();
                        //     string boneName = bone->ReadString();
                        //     break;
                        case NodePayloadType.Group:
                            ReadGroup(context, (GeoGroup*)subNode->GetData(), subNodeGameObject);
                            break;
                        case NodePayloadType.Block:
                            ReadBlock(context, (GeoBlock*)subNode->GetData(), subNodeGameObject);
                            break;
                        default:
                            context.LogImportError("Unknown sub node type");
                            return;
                    }
                }

            }
        }

        private void TrySetVertexBuffer(FoxDataNode* nodes, byte* fmdlData)
        {
            byte* buffer = GetModelVertexBuffer(fmdlData);
            if (buffer == null)
                return;
            
            for (var node = nodes; node != null; node = node->GetNext())
            {
                NodePayloadType flags = (NodePayloadType)node->Flags;
                if (flags != NodePayloadType.Type2)
                    continue;;
                
                for (var subNode = node->GetChildren(); subNode != null; subNode = subNode->GetNext())
                {
                    NodePayloadType subFlags = (NodePayloadType)subNode->Flags;
                    
                    switch (subFlags)
                    {
                        case NodePayloadType.Group:
                            GroupSetVertexBuffer((GeoGroup*)subNode->GetData(), buffer);
                            break;
                        case NodePayloadType.Block:
                            BlockSetVertexBuffer((GeoBlock*)subNode->GetData(), buffer);
                            break;
                    }
                }

            }
        }

        private byte* GetModelVertexBuffer(byte* data)
        {
            uint featureTypes = *(uint*)(data + 0x10);
            uint bufferTypes = *(uint*)(data + 0x18);
            if ((featureTypes & (1 << 0xE)) != 0 && (bufferTypes & 0x4) != 0)
            {
                uint featureCount = *(uint*)(data + 0x20);
                uint descOffset = *(uint*)(data + 0x8);
                uint featuresDataOffset = *(uint*)(data + 0x28);
                uint buffersDataOffset = *(uint*)(data + 0x30);
                byte* features = data + descOffset;
                
                // Get buffer info
                uint bufferHeaderIndex = 0;
                bufferHeaderIndex += (bufferTypes & 0x1) != 0 ? 1u : 0u;
                bufferHeaderIndex += (bufferTypes & 0x2) != 0 ? 1u : 0u;
                
                uint* bufferHeader = (uint*)(features + featureCount * 8);
                bufferHeader += bufferHeaderIndex * 3;

                uint vertexBufferDataOffset = bufferHeader[1];

                byte* buffersData = data + buffersDataOffset;

                // Feature search
                byte* targetFeature = null;
                for (uint i = 0; i < featureCount; i++)
                {
                    byte* feature = (byte*)(features + i * 8);
                    if (feature[0] == 0xe)
                    {
                        targetFeature = feature;
                        break;
                    }
                }
                if (targetFeature == null)
                    return null;

                uint entryCount = *(ushort*)(targetFeature + 0x2) + *(targetFeature + 0x1) * 0x10000u;
                byte* featuresData = data + featuresDataOffset + *(uint*)(targetFeature + 0x4);
                byte* targetFeatureData = null;
                for (uint i = 0; i < entryCount; i++)
                {
                    byte* featureData = featuresData + i * 16;
                    if (*(ushort*)featureData == 0)
                    {
                        targetFeatureData = featureData;
                        break;
                    }
                }
                if (targetFeatureData == null)
                    return null;
                
                byte* bufferData = buffersData + vertexBufferDataOffset + *(uint*)(targetFeatureData + 8);
                return bufferData;
            }

            return null;
        }

        private void GroupSetVertexBuffer(GeoGroup* group, byte* buffer)
        {
            GeoBlock* blocks = (GeoBlock*)((byte*)group + group->BlocksOffset);
            for (uint i = 0; i < group->BlockCount; i++)
            {
                GeoBlock* block = blocks + i;
                BlockSetVertexBuffer(block, buffer);
            }
        }
        
        private void BlockSetVertexBuffer(GeoBlock* block, byte* buffer)
        {
            do
            {
                PolyVertexHeader* vertexHeader = (PolyVertexHeader*)((byte*)block + block->VertexBufferOffset);

                vertexHeader->VertexDataOffset = vertexHeader->FmdlVertexBufferOffset + (long)buffer - (long)vertexHeader;
                
                block += 1;
            } while (block->IsFinalEntry == false);
        }

        private void ReadGroup(AssetImportContext context, GeoGroup* group, GameObject parent)
        {
            GameObject gameObject = new GameObject("Group");
            gameObject.transform.parent = parent.transform;
            CollisionTags tagsComp = gameObject.AddComponent<CollisionTags>();
            GeoCollisionTags tagsFile = group->Tags;
            foreach (GeoCollisionTags tag in (GeoCollisionTags[])Enum.GetValues(typeof(GeoCollisionTags)))
            {
                string propertyName = Enum.GetName(typeof(GeoCollisionTags), tag);
                typeof(CollisionTags).GetProperty(propertyName).SetValue(tagsComp, tagsFile.HasFlag(tag));
            }


            GeoBlock* blocks = (GeoBlock*)((byte*)group + group->BlocksOffset);
            for (uint i = 0; i < group->BlockCount; i++)
            {
                GeoBlock* block = blocks + i;
                ReadBlock(context, block, gameObject);
            }
        }

        private void ReadBlock(AssetImportContext context, GeoBlock* block, GameObject parent)
        {
            // TODO: How does traversal work here???
            GameObject gameObject = new GameObject("Block");
            gameObject.transform.parent = parent.transform;
            
            var headers = (GeomHeader*)((byte*)block + block->HeadersOffset);

            ReadHeader(context, headers, gameObject);

            PolyVertexHeader* vertexHeader = (PolyVertexHeader*)((byte*)block + block->VertexBufferOffset);

            GeoBlockMaterialsHeader* materialsHeader = (GeoBlockMaterialsHeader*)((byte*)block + block->MaterialsHeaderOffset);

            GeoMaterial* materials = (GeoMaterial*)(&materialsHeader + 1);

            // for (uint i = 0; i < materialsHeader->MaterialsCount; i++)
            // {
            //     GeoCommonTemp.GeoMaterial* material = materials + materialsHeader->MaterialsIndexOffset + i;
            //     if (material->Name.IsValid())
            //     {
            //         // do stuff
            //     }
            // }
            //
            // for (uint i = 0; i < materialsHeader->AuxMaterialsCount; i++)
            // {
            //     GeoCommonTemp.GeoMaterial* material = materials + materialsHeader->AuxMaterialsIndexOffset + i;
            //     if (material->Name.IsValid())
            //     {
            //         // do stuff
            //     }
            // }
        }

        private void ReadHeader(AssetImportContext context, GeomHeader* root, GameObject rootObject)
        {
            GeomHeader** stack = stackalloc GeomHeader*[6];
            Transform[] parentStack = new Transform[6];
            int stackSize = 0;
            
            stack[stackSize] = root;
            parentStack[stackSize] = rootObject.transform;
            stackSize++;
            
            while (stackSize > 0)
            {
                // Pop from stack
                GeomHeader* header = stack[stackSize - 1];
                Transform parent = parentStack[stackSize - 1];
                stackSize--;
                
                // Process GeomHeader
                GeoPrimType type = (GeoPrimType)(header->Info & 0xF);
                GeomHeaderFlags flags = (GeomHeaderFlags)(header->Info >> 4 & 0xFFFFF);
                byte primCount = (byte)(header->Info >> 24 & 0xFF);
                
                GameObject gameObject = new GameObject($"{((ulong)header)} | {type.ToString()}{(flags.HasFlag(GeomHeaderFlags.DoubleSided) ? " | DoubleSided" : "")}");
                gameObject.transform.parent = parent;

                byte* payload = (byte*)(header + 1);

                switch (type)
                {
                    case GeoPrimType.AABB:
                        BoxCollider collider = gameObject.AddComponent<BoxCollider>();

                        GeoPrimAabb* aabb = (GeoPrimAabb*)payload;
                        
                        collider.center = Fox.Math.FoxToUnityVector3(aabb->BoundingBoxCenter);
                        collider.size = 2 * aabb->BoundingBoxRadii;
                        
                        break;
                    case GeoPrimType.Poly:
                        bool isDoubleSided = (flags & GeomHeaderFlags.DoubleSided) != 0;
                        Debug.Assert(isDoubleSided == header->Tags.HasFlag(GeoCollisionTags.DOUBLE_SIDE));
                        
                        GeoPrimPoly* polys = (GeoPrimPoly*)payload;
                        PolyVertexHeader* vertexHeader = (PolyVertexHeader*)((byte*)header + header->VertexBufferOffset * 16);
                        
                        // Hack
                        Vector3[] vertexBuffer;
                        if ((flags & GeomHeaderFlags.UseFmdlVertices) == 0)
                            vertexBuffer = new Vector3[vertexHeader->VertexCount - 1];
                        else
                            vertexBuffer = new Vector3[vertexHeader->VertexCount];
                        
                        // TEMP; make faces for each side if double-sided for visualization
                        
                        Mesh mesh = new Mesh();
                        mesh.name = gameObject.name;
                        context.AddObjectToAsset(mesh.name, mesh);

                        ushort[] flatIndexBuffer = !isDoubleSided ? new ushort[primCount * 4] : new ushort[2 * primCount * 4];
                        for (uint i = 0; i < primCount; i++)
                        {
                            // Opposite winding order of FoxKit
                            GeoPrimPoly* poly = polys + i;
                            flatIndexBuffer[i * 4 + 3] = poly->IndexA;
                            flatIndexBuffer[i * 4 + 2] = poly->IndexB;
                            flatIndexBuffer[i * 4 + 1] = poly->IndexC;
                            flatIndexBuffer[i * 4 + 0] = poly->IndexD;
                        }

                        // TEMP; make faces for each side if double-sided for visualization
                        if (isDoubleSided)
                        {
                            for (uint i = 0; i < primCount; i++)
                            {
                                // Opposite winding order of FoxKit
                                GeoPrimPoly* poly = polys + i;
                                flatIndexBuffer[flatIndexBuffer.Length / 2 + i * 4 + 0] = poly->IndexA;
                                flatIndexBuffer[flatIndexBuffer.Length / 2 + i * 4 + 1] = poly->IndexB;
                                flatIndexBuffer[flatIndexBuffer.Length / 2 + i * 4 + 2] = poly->IndexC;
                                flatIndexBuffer[flatIndexBuffer.Length / 2 + i * 4 + 3] = poly->IndexD;
                            }
                        }
                        
                        Vector4* vectors = (Vector4*)((byte*)vertexHeader + vertexHeader->VertexDataOffset);

                        // TEMP
                        if ((flags & GeomHeaderFlags.UseFmdlVertices) == 0)
                        {
                            Vector3 origin = Fox.Math.FoxToUnityVector3(vectors[vertexHeader->OriginIndex]);
                            for (uint i = 0; i < vertexBuffer.Length; i++)
                            {
                                vertexBuffer[i] = Fox.Math.FoxToUnityVector3((Vector3)vectors[i + vertexHeader->VerticesIndexOffset]) + origin;
                            }
                        }
                        else if (vertexHeader->VertexDataOffset != 0)
                        {
                            float* buffer = (float*)((byte*)vertexHeader + vertexHeader->VertexDataOffset);
                            for (uint i = 0; i < vertexBuffer.Length; i++)
                            {
                                Vector3 vector = *(Vector3*)(buffer + i * 12);
                                vertexBuffer[i] = Fox.Math.FoxToUnityVector3(vector);
                            }
                        }
                        
                        mesh.SetVertices(vertexBuffer, 0, vertexBuffer.Length, MeshUpdateFlags.DontRecalculateBounds | MeshUpdateFlags.DontValidateIndices);
                        mesh.SetIndices(flatIndexBuffer, MeshTopology.Quads, 0, false);
                        mesh.UploadMeshData(true);
                        Collider parentCollider = parent.GetComponent<BoxCollider>();
                        if (parentCollider != null)
                            mesh.bounds = parentCollider.bounds;

                        gameObject.AddComponent<MeshRenderer>().material = VisualizerMaterial;
                        gameObject.AddComponent<MeshFilter>().mesh = mesh;
                        
                        break;
                }

                if (header->NextHeaderOffset != 0)
                {
                    // Push onto stack
                    stack[stackSize] = (GeomHeader*)((byte*)header + header->NextHeaderOffset * 16);
                    parentStack[stackSize] = parent;
                    stackSize++;
                }

                if ((flags & GeomHeaderFlags.NoChild) == 0)
                {
                    if (header->ChildHeaderOffset != 0)
                    {
                        // Push onto stack
                        stack[stackSize] = (GeomHeader*)((byte*)header + header->ChildHeaderOffset * 16);
                        parentStack[stackSize] = gameObject.transform;
                        stackSize++;
                    }
                }
            }
        }
    }
}