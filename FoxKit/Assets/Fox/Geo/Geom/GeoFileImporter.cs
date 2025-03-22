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
                
                FoxDataNode* nodes = header->GetNodes();
                ReadNodes(context, nodes);
            }
        }

        private void ReadNodes(AssetImportContext context, FoxDataNode* nodes)
        {
            for (var node = nodes; node != null; node = node->GetNext())
            {
                FoxDataString name = node->Name;
                uint flags = node->Flags;
                
                for (var subNode = node; subNode != null; subNode = subNode->GetNext())
                {
                    FoxDataString subName = subNode->Name;
                    GeoCommonTemp.GeoPayloadType subFlags = (GeoCommonTemp.GeoPayloadType)subNode->Flags;
                    
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
                            break;
                        case GeoCommonTemp.GeoPayloadType.Group:
                            ReadGroup((GeoCommonTemp.GeoGroup*)subNode->GetData());
                            break;
                    }
                }
            }
        }

        private void ReadGroup(GeoCommonTemp.GeoGroup* data)
        {
            GeoCommonTemp.GeoBlock* block = &data->Blocks;
            while (block->IsFinalEntry != true)
            {
                GeoCommonTemp.GeoMaterialGroup* materialGroup = (GeoCommonTemp.GeoMaterialGroup*)((byte*)block + block->NextSectionOffset);
                GeoCommonTemp.GeoMaterialHeader header = materialGroup->Header;

                GeoCommonTemp.GeoMaterial* materials = (GeoCommonTemp.GeoMaterial*)(&materialGroup->Header + 1);

                // Probably don't want to 
                // for (uint i = header.MaterialsOffsetInEntries; i < header.MaterialsTotalSizeInEntries; i++)
                // {
                //     GeoCommonTemp.GeoMaterial* material = materials + i;
                //     if (material->Name.IsValid())
                //     {
                //         // do stuff
                //     }
                // }
                //
                // for (uint i = header.AuxMaterialsOffsetInEntries; i < header.AuxMaterialsTotalSizeInEntries; i++)
                // {
                //     GeoCommonTemp.GeoMaterial* material = materials + i;
                //     if (material->Name.IsValid())
                //     {
                //         // do stuff
                //     }
                // }
                
                block += 1;
            }
        }
    }
}