using System;
using Fox.Core;
using UnityEditor.AssetImporters;
using UnityEngine;

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
                
                var nodeGo = new GameObject(name.Hash.ToString());
                
                for (var subNode = node; subNode != null; subNode = subNode->GetNext())
                {
                    FoxDataString subName = subNode->Name;
                    GeoGeom.NodePayloadType subFlags = (GeoGeom.NodePayloadType)subNode->Flags;

                    var subNodeGo = new GameObject(subName.Hash.ToString());
                    subNodeGo.transform.SetParent(nodeGo.transform);
                    
                    switch (subFlags)
                    {
                        // NOT VALID FOR GEOM(S)
                        // case GeoGeom.NodePayloadType.Bone:
                        //     GeoGeom.GeoBone* bone = (GeoGeom.GeoBone*)subNode->GetData();
                        //     string boneName = bone->ReadString();
                        //     break;
                        case GeoGeom.NodePayloadType.Group:
                            ReadGroup((GeoGeom.GeoGroup*)subNode->GetData());
                            break;
                        case GeoGeom.NodePayloadType.Block:
                            ReadBlock((GeoGeom.GeoBlock*)subNode->GetData());
                            break;
                        default:
                            context.LogImportError("Unknown sub node type");
                            return;
                    }
                    context.AddObjectToAsset(subName.Hash.ToString(), subNodeGo);
                }

                context.AddObjectToAsset(name.Hash.ToString(), nodeGo);
            }
        }

        private void ReadGroup(GeoGeom.GeoGroup* group)
        {
            GeoGeom.GeoBlock* blocks = (GeoGeom.GeoBlock*)((byte*)group + group->BlocksOffset);
            for (uint i = 0; i < group->BlockCount; i++)
            {
                GeoGeom.GeoBlock* block = blocks + i;
                ReadBlock(block);
            }
        }

        private void ReadBlock(GeoGeom.GeoBlock* block)
        {
            var shapes = (GeoGeom.GeomHeader*)block->HeadersOffset;

            ReadShape(shapes);

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
        
        private void ReadShape(GeoGeom.GeomHeader* geomHeader)
        {
            GeoPrimType type = (GeoPrimType)(geomHeader->Info & 0xF);
            GeoShapeFlags flags = (GeoShapeFlags)(geomHeader->Info >> 4 & 0xFFFFF);
            byte primCount = (byte)(geomHeader->Info >> 24 & 0xFF);

            byte* prim = (byte*)(geomHeader + 1);
            switch (type)
            {
                case GeoPrimType.AABB:
                    for (int i = 0; i < primCount; i++)
                    {
                        ReadPrimAabb((GeoGeom.GeoPrimAabb*)prim + (i * 32));
                    }
                    break;
                case GeoPrimType.Quad:
                    for (int i = 0; i < primCount; i++)
                    {
                        ReadPrimQuad((GeoGeom.GeoPrimQuad*)prim + (i * 12));
                    }
                    break;
            }

            while (geomHeader->ChildHeaderOffset > 0)
            {
                ReadShape(geomHeader + geomHeader->ChildHeaderOffset);
            }

            while (geomHeader->NextHeaderOffset > 0)
            {
                ReadShape(geomHeader + geomHeader->NextHeaderOffset);
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