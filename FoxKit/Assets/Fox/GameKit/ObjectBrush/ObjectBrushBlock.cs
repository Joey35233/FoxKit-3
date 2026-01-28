using Fox.Core;
using Fox.Core.Utils;
using Fox.Gr;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Fox.GameKit
{
    public partial class ObjectBrushBlock
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            ObjectBrushBlockAsset obrbAsset;
            if (obrbFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(obrbFile));
                return;
            }
            else
            {
                string obrbExternalPath = Fox.Fs.FileSystem.GetExternalPathFromFoxPath(obrbFile.path.String);
                if (!File.Exists(obrbExternalPath))
                {
                    logger.AddWarningMissingAsset(obrbFile.path.String);
                    return;
                }
                
                byte[] obrbData = File.ReadAllBytes(obrbExternalPath);
                obrbAsset = ConvertFile(obrbData);
                Fox.Fs.FileSystem.CreateAsset(obrbAsset, obrbFile.path.String);
                AssetDatabase.SaveAssets();
            }

            foreach (ObjectBrushObject obj in obrbAsset.Objects)
            {
                ObjectBrushPlugin plugin = obj.Plugin;
                
                if (!plugin)
                    continue;

                plugin.RegisterObject(obj);
            }
        }
        
        public unsafe ObjectBrushBlockAsset ConvertFile(byte[] file)
        {
            // TODO: What happens with this if I return null later?
            ObjectBrushBlockAsset obrbAsset = ScriptableObject.CreateInstance<ObjectBrushBlockAsset>();
            
            fixed (byte* data = file)
            {
                FoxDataHeader* header = (FoxDataHeader*)data;
                if (header->Version != 2)
                    return null;
                
                FoxDataNode* node = header->GetNodes();
                if (node->Flags != 0)
                    return null;
                    
                FoxDataNodeAttribute* blockIdAttrib = node->FindAttribute("blockId");
                FoxDataNodeAttribute* numObjectsAttrib = node->FindAttribute("numObjects");
                FoxDataNodeAttribute* flagsAttrib = node->FindAttribute("flags");

                if (blockIdAttrib == null || numObjectsAttrib == null || flagsAttrib == null)
                    return null;
                
                uint flags = flagsAttrib->GetUIntValue();
                Debug.Assert(flags == 1);

                ObjectBrush objectBrush = Fox.GameKit.FoxGameKitModule.ObjectBrushRegistry[this.objectBrushName];
                if (!objectBrush)
                    return null;
                
                ObjectBrushAsset obrAsset = AssetDatabase.LoadAssetAtPath<ObjectBrushAsset>(objectBrush.obrFile.path.String);
                float blockSizeW = obrAsset.BlockSizeW;
                float blockSizeH = obrAsset.BlockSizeH;
                uint numBlocksW = obrAsset.NumBlocksW;
                uint numBlocksH = obrAsset.NumBlocksH;

                uint fileBlockId = blockIdAttrib->GetUIntValue();
                uint objectCount = numObjectsAttrib->GetUIntValue();
                
                // Block indices [0,32) x [0,32)
                ushort blockX = (ushort)(fileBlockId % numBlocksH);
                ushort blockZ = (ushort)(fileBlockId / numBlocksW);

                // Block center position
                float blockCenterX = blockSizeH * (blockX + 0.5f - (0.5f * numBlocksH));
                float blockCenterZ = blockSizeW * (blockZ + 0.5f - (0.5f * numBlocksW));
                
                DataUnit* unit = (DataUnit*)node->GetData();
                for (uint i = 0; i < objectCount; i++, unit++)
                {
                    Debug.Assert(unit->BlockId == fileBlockId && unit->BlockId == this.blockId);

                    float posX = blockCenterX + (unit->PositionX / (float)byte.MaxValue);
                    float posZ = blockCenterZ + (unit->PositionZ / (float)byte.MaxValue);
                    
                    Vector3 position = new Vector3(posX, unit->PositionY, posZ);
                    position = Fox.Math.FoxToUnityVector3(position);
                    
                    Quaternion rotation = Quaternion.identity;
                    rotation = Fox.Math.FoxToUnityQuaternion(rotation);

                    float normalizedScale = unit->NormalizedScale / (float)byte.MaxValue;
                    
                    ObjectBrushPlugin plugin = objectBrush.pluginHandle[unit->PluginIndex] as ObjectBrushPlugin;
                }
            }
            
            return obrbAsset;
        }
    }
}