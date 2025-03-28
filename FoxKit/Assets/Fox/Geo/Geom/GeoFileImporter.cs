#define DOUBLE_SIDED

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

            if (fileData.IsEmpty || fileData.Length < sizeof(FoxDataHeader))
            {
                context.LogImportError("Data is empty or length is less than header");
                return;
            }

            fixed (byte* data = fileData)
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

        private void ReadGroup(AssetImportContext context, GeoGroup* group, GameObject parent)
        {
            GameObject gameObject = new GameObject("Group");
            gameObject.transform.parent = parent.transform;
            var tags = gameObject.AddComponent<CollisionTags>();
            tags.tags = group->Tags;


            GeoBlock* blocks = (GeoBlock*)((byte*)group + group->BlocksOffset);
            for (uint i = 0; i < group->BlockCount; i++)
            {
                GeoBlock* block = blocks + i;
                ReadBlock(context, block, gameObject);
            }
        }

        private void ReadBlock(AssetImportContext context, GeoBlock* block, GameObject parent)
        {
            GameObject gameObject = new GameObject("Block");
            gameObject.transform.parent = parent.transform;
            
            var headers = (GeomHeader*)((byte*)block + block->HeadersOffset);

            ReadHeader(context, headers, gameObject);

            PolyVertexHeader* vertexHeader = (PolyVertexHeader*)(block + block->VertexBufferOffset);

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
                        // TEMP
                        if ((flags & GeomHeaderFlags.UseFmdlVertices) != 0)
                            break;

                        bool isDoubleSided = (flags & GeomHeaderFlags.DoubleSided) != 0;
                        
                        GeoPrimPoly* polys = (GeoPrimPoly*)payload;
                        PolyVertexHeader* vertexHeader = (PolyVertexHeader*)((byte*)header + header->VertexBufferOffset * 16);
                        
                        // Technically a hack
                        Vector3[] vertexBuffer = new Vector3[vertexHeader->VertexCount - 1];
                        
                        // TEMP; make faces for each side if double-sided for visualization
                        
                        Mesh mesh = new Mesh();
                        mesh.name = gameObject.name;
                        context.AddObjectToAsset(mesh.name, mesh);

#if DOUBLE_SIDED
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
#else
                        ushort[] flatIndexBuffer = new ushort[primCount * 4];

                        if (isDoubleSided)
                        {
                            for (uint i = 0; i < primCount; i++)
                            {
                                // Opposite winding order of FoxKit
                                GeoPrimPoly* poly = polys + i;
                                flatIndexBuffer[i * 4 + 0] = poly->IndexA;
                                flatIndexBuffer[i * 4 + 1] = poly->IndexB;
                                flatIndexBuffer[i * 4 + 2] = poly->IndexC;
                                flatIndexBuffer[i * 4 + 3] = poly->IndexD;
                            }
                        }
                        else
                        {
                            for (uint i = 0; i < primCount; i++)
                            {
                                // Opposite winding order of FoxKit
                                GeoPrimPoly* poly = polys + i;
                                flatIndexBuffer[i * 4 + 3] = poly->IndexA;
                                flatIndexBuffer[i * 4 + 2] = poly->IndexB;
                                flatIndexBuffer[i * 4 + 1] = poly->IndexC;
                                flatIndexBuffer[i * 4 + 0] = poly->IndexD;
                            }
                        }
#endif
                        
                        Vector4* vectors = (Vector4*)((byte*)vertexHeader + vertexHeader->VertexDataOffset);

                        Vector3 origin = Fox.Math.FoxToUnityVector3(vectors[vertexHeader->OriginIndex]);
                        for (uint i = 0; i < vertexBuffer.Length; i++)
                        {
                            vertexBuffer[i] = Fox.Math.FoxToUnityVector3((Vector3)vectors[i + vertexHeader->VerticesIndexOffset]) + origin;
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
        
        private void ReadPrimAabb(GeoPrimAabb* prim)
        {

        }
        
        private void ReadPrimQuad(GeoPrimPoly* prim)
        {
            bool NoUseMaterial = (prim->Info & 0x1) == 0x1;
            bool NoUseAuxMaterial = (prim->Info>>1 & 0x1) == 0x1;
            byte MaterialIndex = (byte)(prim->Info >> 2 & 0x7F);
            byte AuxMaterialIndex = (byte)(prim->Info >> 9 & 0x7F);
        }
    }
}