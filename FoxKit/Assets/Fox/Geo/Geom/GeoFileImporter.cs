using System;
using Fox.Core;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Fox.Geo
{
    [ScriptedImporter(1, "geoms")]
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
                uint flags = node->Flags;

                var nodeGo = new GameObject(name.Hash.ToString());

                for (var subNode = node; subNode != null; subNode = subNode->GetNext())
                {
                    FoxDataString subName = subNode->Name;
                    GeoCommonTemp.GeoPayloadType subFlags = (GeoCommonTemp.GeoPayloadType)subNode->Flags;

                    var subNodeGo = new GameObject(subName.Hash.ToString());
                    subNodeGo.transform.SetParent(nodeGo.transform);

                    switch (subFlags)
                    {
                        case GeoCommonTemp.GeoPayloadType.Type1:
                        case GeoCommonTemp.GeoPayloadType.Type2:
                            break;
                        case GeoCommonTemp.GeoPayloadType.Bone:
                            GeoCommonTemp.GeoBone* bone = (GeoCommonTemp.GeoBone*)subNode->GetData();
                            string boneName = bone->ReadString();
                            break;
                        case GeoCommonTemp.GeoPayloadType.BoundingGroup:
                            ReadBoundingGroup((GeoCommonTemp.BoundingVolume*)subNode->GetData());
                            break;
                        case GeoCommonTemp.GeoPayloadType.Group:
                            ReadGroup((GeoCommonTemp.GeoGroup*)subNode->GetData());
                            break;
                    }
                    context.AddObjectToAsset(subName.Hash.ToString(), subNodeGo);
                }

                context.AddObjectToAsset(name.Hash.ToString(), nodeGo);
            }
        }
        private void ReadBoundingGroup(GeoCommonTemp.BoundingVolume* data)
        {
            ReadGroup((GeoCommonTemp.GeoGroup*)data+data->NextSectionOffset);
        }
        private void ReadGroup(GeoCommonTemp.GeoGroup* data)
        {
            GeoCommonTemp.GeoBlock* block = &data->Blocks;
            while (block->IsFinalEntry != true)
            {
                var shapes = (GeoCommonTemp.GeoGeomHeader*)block->FirstHeaderOffsetMaybe;

                ReadShape(shapes);

                GeoCommonTemp.VertexHeader* vertexHeader = (GeoCommonTemp.VertexHeader*)(block + block->VertexBufferOffset);

                block += 1;
            }

            GeoCommonTemp.GeoMaterialGroup* materialGroup = (GeoCommonTemp.GeoMaterialGroup*)((byte*)block + block->NextSectionOffset);
            GeoCommonTemp.GeoMaterialHeader header = materialGroup->Header;
            // do stuff

            GeoCommonTemp.GeoMaterial* materials = (GeoCommonTemp.GeoMaterial*)(&materialGroup->Header + 1);
            
            for (uint i = header.MaterialsOffsetInEntries; i < header.MaterialsTotalSizeInEntries; i++)
            {
                GeoCommonTemp.GeoMaterial* material = materials + i;
                if (material->Name.IsValid())
                {
                    // do stuff
                }
            }
            
            for (uint i = header.AuxMaterialsOffsetInEntries; i < header.AuxMaterialsTotalSizeInEntries; i++)
            {
                GeoCommonTemp.GeoMaterial* material = materials + i;
                if (material->Name.IsValid())
                {
                    // do stuff
                }
            }
        }
        private void ReadShape(GeoCommonTemp.GeoGeomHeader* geoGeomHeader)
        {
            GeoPrimType type = (GeoPrimType)(geoGeomHeader->Info & 0xF);
            GeoShapeFlags flags = (GeoShapeFlags)(geoGeomHeader->Info >> 4 & 0xFFFFF);
            byte primCount = (byte)(geoGeomHeader->Info >> 24 & 0xFF);

            byte* prim = (byte*)(geoGeomHeader + 32);
            switch (type)
            {
                case GeoPrimType.AABB:
                    for (int i = 0; i < primCount; i++)
                    {
                        ReadPrimAabb((GeoCommonTemp.GeoPrimAabb*)prim + (i * 32));
                    }
                    break;
                case GeoPrimType.Quad:
                    for (int i = 0; i < primCount; i++)
                    {
                        ReadPrimQuad((GeoCommonTemp.GeoPrimQuad*)prim + (i * 12));
                    }
                    break;
            }


            while (geoGeomHeader->ChildHeaderOffset > 0)
            {
                ReadShape(geoGeomHeader + geoGeomHeader->ChildHeaderOffset);
            }

            while (geoGeomHeader->NextHeaderOffset > 0)
            {
                ReadShape(geoGeomHeader + geoGeomHeader->NextHeaderOffset);
            }
        }
        private void ReadPrimAabb(GeoCommonTemp.GeoPrimAabb* prim)
        {

        }
        private void ReadPrimQuad(GeoCommonTemp.GeoPrimQuad* prim)
        {
            bool NoUseMaterial = (prim->Info & 0x1) == 0x1;
            bool NoUseAuxMaterial = (prim->Info>>1 & 0x1) == 0x1;
            byte MaterialIndex = (byte)(prim->Info >> 2 & 0x7F);
            byte AuxMaterialIndex = (byte)(prim->Info >> 9 & 0x7F);
        }
    }
}