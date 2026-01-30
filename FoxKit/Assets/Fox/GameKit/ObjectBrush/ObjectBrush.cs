using System;
using System.Collections.Generic;
using Fox.Core.Utils;
using Fox.Core;
using Fox.Gr;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Fox.GameKit
{
    [ExecuteAlways]
    [DefaultExecutionOrder(-100)] // Enables the registry to be populated before the blocks
    public partial class ObjectBrush : Fox.Core.TransformData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            ObjectBrushAsset obrAsset;
            if (obrFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(obrFile));
                return;
            }
            else
            {
                string obrExternalPath = Fox.Fs.FileSystem.GetExternalPathFromFoxPath(obrFile.path.String);
                if (!File.Exists(obrExternalPath))
                {
                    logger.AddWarningMissingAsset(obrFile.path.String);
                    return;
                }
                
                byte[] obrData = File.ReadAllBytes(obrExternalPath);
                obrAsset = ConvertFile(obrData);
                Fox.Fs.FileSystem.CreateAsset(obrAsset, obrFile.path.String);
                AssetDatabase.SaveAssets();
            }
        }
        
        public unsafe ObjectBrushAsset ConvertFile(byte[] file)
        {
            // TODO: What happens with this if I return null later?
            ObjectBrushAsset obrAsset = ScriptableObject.CreateInstance<ObjectBrushAsset>();
            
            fixed (byte* data = file)
            {
                FoxDataHeader* header = (FoxDataHeader*)data;
                if (header->Version != 3)
                    return null;
                
                FoxDataNode* node = header->GetNodes();
                if (node->Flags != 1)
                    return null;
                    
                FoxDataNodeAttribute* blockSizeWAttrib = node->FindAttribute("blockSizeW");
                FoxDataNodeAttribute* blockSizeHAttrib = node->FindAttribute("blockSizeH");
                FoxDataNodeAttribute* numBlocksWAttrib = node->FindAttribute("numBlocksW");
                FoxDataNodeAttribute* numBlocksHAttrib = node->FindAttribute("numBlocksH");
                FoxDataNodeAttribute* numObjectsAttrib = node->FindAttribute("numObjects");

                if (blockSizeWAttrib == null || blockSizeHAttrib == null || numBlocksWAttrib == null ||
                    numBlocksHAttrib == null || numObjectsAttrib == null)
                    return null;
                
                float blockSizeW = blockSizeWAttrib->GetFloatValue();
                float blockSizeH = blockSizeHAttrib->GetFloatValue();
                uint numBlocksW = numBlocksWAttrib->GetUIntValue();
                uint numBlocksH = numBlocksHAttrib->GetUIntValue();

                obrAsset.BlockSizeW = blockSizeW;
                obrAsset.BlockSizeH = blockSizeH;
                obrAsset.NumBlocksW = numBlocksW;
                obrAsset.NumBlocksH = numBlocksH;

                uint objectCount = numObjectsAttrib->GetUIntValue();
                DataUnit* unit = (DataUnit*)node->GetData();
                ObjectBrushObject[] objects = new ObjectBrushObject[objectCount];
                for (uint i = 0; i < objectCount; i++, unit++)
                {
                    uint blockId = unit->BlockId;
                    
                    ushort blockX = (ushort)(blockId % numBlocksH);
                    ushort blockZ = (ushort)(blockId / numBlocksW);

                    float blockCenterX = blockSizeH * (blockX + 0.5f - (0.5f * numBlocksH));
                    float blockCenterZ = blockSizeW * (blockZ + 0.5f - (0.5f * numBlocksW));

                    float posX = unit->PositionX / (float)byte.MaxValue + blockCenterX;
                    float posZ = unit->PositionZ / (float)byte.MaxValue + blockCenterZ;
                    
                    Vector3 position = new Vector3(posX, unit->PositionY, posZ);
                    position = Fox.Math.FoxToUnityVector3(position);
                    
                    Quaternion rotation = new Quaternion(unit->RotationX, unit->RotationY, unit->RotationZ, unit->RotationW);
                    rotation = Fox.Math.FoxToUnityQuaternion(rotation);

                    float normalizedScale = unit->NormalizedScale / (float)byte.MaxValue;
                    
                    ObjectBrushPlugin plugin = this.pluginHandle[unit->PluginIndex] as ObjectBrushPlugin;

                    ObjectBrushObject obj = new ObjectBrushObject
                    {
                        Position = position,
                        Rotation = rotation,
                        NormalizedScale = normalizedScale,
                        Plugin = plugin.name,
                    };
                    objects[i] = obj;
                }
                
                obrAsset.Objects = objects;
            }
            
            return obrAsset;
        }

        private float BlockSizeW;
        private float BlockSizeH;
        private uint BlockCountW;
        private uint BlockCountH;

        private List<ObjectBrushBlock> Blocks;

        private void OnEnable()
        {
            ObjectBrushAsset obrAsset = Fox.Fs.FileSystem.LoadAsset<ObjectBrushAsset>(obrFile.path.String);
            BlockSizeW = obrAsset.BlockSizeW;
            BlockSizeH = obrAsset.BlockSizeH;
            BlockCountW = obrAsset.NumBlocksW;
            BlockCountH = obrAsset.NumBlocksH;
            
            Debug.Assert(numBlocks == BlockCountW * BlockCountH);
            Blocks = new List<ObjectBrushBlock>((int)numBlocks);
            for (int i = 0; i < numBlocks; i++)
                Blocks.Add(null);
            
            FoxGameKitModule.ObjectBrushRegistry.Add(this.name, this);
            
            InstantiateObjects(this.transform, obrAsset.Objects);
        }

        private void InstantiateObjects(UnityEngine.Transform parent, ObjectBrushObject[] objects)
        {
            StringMap<ObjectBrushPlugin> pluginMap = new StringMap<ObjectBrushPlugin>();
            foreach (ObjectBrushPlugin plugin in pluginHandle)
                if (plugin)
                    pluginMap[plugin.name] = plugin;
            
            foreach (ObjectBrushObject obj in objects)
            {
                ObjectBrushPlugin plugin = pluginMap[obj.Plugin];
                
                if (!plugin)
                    continue;
                
                GameObject instance = plugin.GetModelInstance(obj);
                instance.transform.SetParent(parent);
            }
        }

        public void RegisterBlock(ObjectBrushBlock block)
        {
            Debug.Assert(numBlocks == Blocks.Count);
            if (block.blockId >= Blocks.Count)
                return;

            Blocks[(int)block.blockId] = block;
            
            ObjectBrushBlockAsset blockAsset = Fox.Fs.FileSystem.LoadAsset<ObjectBrushBlockAsset>(block.obrbFile.path.String);
            
            InstantiateObjects(block.transform, blockAsset.Objects);
        }

        public void DeregisterBlock(ObjectBrushBlock block)
        {
            Debug.Assert(numBlocks == Blocks.Count);
            if (block.blockId >= Blocks.Count)
                return;

            Blocks[(int)block.blockId] = null;
        }

        private void OnDisable()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                ObjectBrushBlock block = Blocks[i];
                if (block != null)
                {
                    DeregisterBlock(block);

                    block.Cleanup();
                }
            }
            
            FoxGameKitModule.ObjectBrushRegistry.Remove(this.name);
        }
    }
}
