using System;
using Fox.Core;
using UnityEditor.AssetImporters;
using UnityEngine;
using Transform = UnityEngine.Transform;
using static Fox.Geo.GeoGeom;

namespace Fox.Geo
{
    [ScriptedImporter(0, "geoms")]
    public unsafe class GeoFileImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext context)
        {
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
                            ReadGroup((GeoGroup*)subNode->GetData(), subNodeGameObject);
                            break;
                        case NodePayloadType.Block:
                            ReadBlock((GeoBlock*)subNode->GetData(), subNodeGameObject);
                            break;
                        default:
                            context.LogImportError("Unknown sub node type");
                            return;
                    }
                }

            }
        }

        private void ReadGroup(GeoGroup* group, GameObject parent)
        {
            GameObject gameObject = new GameObject("Group");
            gameObject.transform.parent = parent.transform;
            
            GeoBlock* blocks = (GeoBlock*)((byte*)group + group->BlocksOffset);
            for (uint i = 0; i < group->BlockCount; i++)
            {
                GeoBlock* block = blocks + i;
                ReadBlock(block, gameObject);
            }
        }

        private void ReadBlock(GeoBlock* block, GameObject parent)
        {
            GameObject gameObject = new GameObject("Block");
            gameObject.transform.parent = parent.transform;
            
            var headers = (GeomHeader*)((byte*)block + block->HeadersOffset);

            ReadHeader(headers, gameObject);

            VertexHeader* vertexHeader = (VertexHeader*)(block + block->VertexBufferOffset);

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

        private void ReadHeader(GeomHeader* root, GameObject rootObject)
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
                
                GameObject gameObject = new GameObject(type.ToString());
                gameObject.transform.parent = parent;

                byte* payload = (byte*)(header + 1);

                switch (type)
                {
                    case GeoPrimType.AABB:
                        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
                        
                        collider.size = Fox.Math.FoxToUnityVector3(*(Vector3*)(payload));
                        collider.center = *(Vector3*)(payload + 16);
                        
                        break;
                }

                if (header->NextHeaderOffset != 0)
                {
                    // Push onto stack
                    stack[stackSize] = (GeomHeader*)((byte*)header + header->NextHeaderOffset * 16);
                    parentStack[stackSize] = parent;
                    stackSize++;
                }

                if ((header->Info & 0x200) == 0)
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