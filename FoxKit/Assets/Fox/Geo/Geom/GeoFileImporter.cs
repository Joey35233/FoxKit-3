using System;
using Fox.Core;
using UnityEditor.AssetImporters;
using UnityEngine;
using Transform = UnityEngine.Transform;

namespace Fox.Geo
{
    [ScriptedImporter(0, "geoms")]
    public unsafe partial class GeoFileImporter : ScriptedImporter
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
                ReadNodes(context, nodes);

                context.AddObjectToAsset(header->Name.Hash.ToString(), main);
                context.SetMainObject(main);
            }
        }

        private void ReadNodes(AssetImportContext context, FoxDataNode* nodes)
        {
            for (var node = nodes; node != null; node = node->GetNext())
            {
                FoxDataString name = node->Name;
                GeoGeom.NodePayloadType flags = (GeoGeom.NodePayloadType)node->Flags;
                Debug.Assert(flags == GeoGeom.NodePayloadType.Type1 || flags == GeoGeom.NodePayloadType.Type2);
                
                var nodeGameObject = new GameObject(name.Hash.ToString());
                
                for (var subNode = node; subNode != null; subNode = subNode->GetNext())
                {
                    FoxDataString subName = subNode->Name;
                    GeoGeom.NodePayloadType subFlags = (GeoGeom.NodePayloadType)subNode->Flags;

                    var subNodeGameObject = new GameObject(subName.Hash.ToString());
                    subNodeGameObject.transform.parent = nodeGameObject.transform;
                    
                    switch (subFlags)
                    {
                        // NOT VALID FOR GEOM(S)
                        // case GeoGeom.NodePayloadType.Bone:
                        //     GeoGeom.GeoBone* bone = (GeoGeom.GeoBone*)subNode->GetData();
                        //     string boneName = bone->ReadString();
                        //     break;
                        case GeoGeom.NodePayloadType.Group:
                            ReadGroup((GeoGeom.GeoGroup*)subNode->GetData(), subNodeGameObject);
                            break;
                        case GeoGeom.NodePayloadType.Block:
                            ReadBlock((GeoGeom.GeoBlock*)subNode->GetData(), subNodeGameObject);
                            break;
                        default:
                            context.LogImportError("Unknown sub node type");
                            return;
                    }
                    context.AddObjectToAsset(subName.Hash.ToString(), subNodeGameObject);
                }

                context.AddObjectToAsset(name.Hash.ToString(), nodeGameObject);
            }
        }

        private void ReadGroup(GeoGeom.GeoGroup* group, GameObject parent)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.parent = parent.transform;
            
            GeoGeom.GeoBlock* blocks = (GeoGeom.GeoBlock*)((byte*)group + group->BlocksOffset);
            for (uint i = 0; i < group->BlockCount; i++)
            {
                GeoGeom.GeoBlock* block = blocks + i;
                ReadBlock(block, gameObject);
            }
        }

        private void ReadBlock(GeoGeom.GeoBlock* block, GameObject parent)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.parent = parent.transform;
            
            var shapes = (GeoGeom.GeomHeader*)block->HeadersOffset;

            ReadShape(shapes, gameObject);

            GeoGeom.VertexHeader* vertexHeader = (GeoGeom.VertexHeader*)(block + block->VertexBufferOffset);

            GeoGeom.GeoBlockMaterialsHeader* materialsHeader = (GeoGeom.GeoBlockMaterialsHeader*)((byte*)block + block->MaterialsHeaderOffset);

            GeoGeom.GeoMaterial* materials = (GeoGeom.GeoMaterial*)(&materialsHeader + 1);

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

        private void ReadShape(GeoGeom.GeomHeader* root, GameObject rootObject)
        {
            GeoGeom.GeomHeader** stack = stackalloc GeoGeom.GeomHeader*[6];
            Transform[] parentStack = new Transform[6];
            int stackSize = 0;
            
            stack[stackSize++] = root;
            parentStack[stackSize] = rootObject.transform.parent;
            stackSize++;
            
            while (stackSize > 0)
            {
                // Pop from stack
                GeoGeom.GeomHeader* header = stack[stackSize - 1];
                Transform parent = parentStack[stackSize - 1];
                stackSize--;
                
                // Process GeomHeader
                GeoPrimType type = (GeoPrimType)(header->Info & 0xF);
                GeoShapeFlags flags = (GeoShapeFlags)(header->Info >> 4 & 0xFFFFF);
                byte primCount = (byte)(header->Info >> 24 & 0xFF);
                
                GameObject gameObject = new GameObject(type.ToString());
                gameObject.transform.parent = parent;

                if (header->NextHeaderOffset != 0)
                {
                    // Push onto stack
                    stack[stackSize] = (GeoGeom.GeomHeader*)((byte*)header + header->NextHeaderOffset);
                    parentStack[stackSize] = parent;
                    stackSize++;
                }

                if ((header->Info & 0x200) == 0)
                {
                    if (header->ChildHeaderOffset != 0)
                    {
                        // Push onto stack
                        stack[stackSize] = (GeoGeom.GeomHeader*)((byte*)header + header->ChildHeaderOffset);
                        parentStack[stackSize] = gameObject.transform;
                        stackSize++;
                    }
                }
            }
        }
        
        private void ReadPrimAabb(GeoGeom.GeoPrimAabb* prim)
        {

        }
        
        private void ReadPrimQuad(GeoGeom.GeoPrimQuad* prim)
        {
            bool NoUseMaterial = (prim->Info & 0x1) == 0x1;
            bool NoUseAuxMaterial = (prim->Info>>1 & 0x1) == 0x1;
            byte MaterialIndex = (byte)(prim->Info >> 2 & 0x7F);
            byte AuxMaterialIndex = (byte)(prim->Info >> 9 & 0x7F);
        }
    }
}