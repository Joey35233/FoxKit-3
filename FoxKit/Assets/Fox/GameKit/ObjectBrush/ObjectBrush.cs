using Fox.Core.Utils;
using Fox.Core;
using Fox.Gr;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Fox.GameKit
{
    [ExecuteAlways]
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

            foreach (ObjectBrushObject obj in obrAsset.Objects)
            {
                // obrPlugin.RegisterObject(obj);

                // if (!instantiated)
                // {
                //     instanceGameObject = new GameObject();
                //     instanceGameObject.transform.position = transform.translation;
                //     instanceGameObject.transform.rotation = transform.rotation_quat;
                //     instanceGameObject.transform.localScale = transform.scale;
                //     instanceGameObject.transform.SetParent(gameObject.transform, false);
                //     PointGizmo gizmo = instanceGameObject.AddComponent<PointGizmo>();
                //     gizmo.Color = Color.green;
                //     gizmo.Scale = Vector3.one;
                // }
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
                for (uint i = 0; i < objectCount; i++, unit++)
                {
                    uint blockId = unit->BlockId;
                    
                    // Block indices [0,32) x [0,32)
                    ushort blockX = (ushort)(blockId % numBlocksH);
                    ushort blockZ = (ushort)(blockId / numBlocksW);

                    // Block center position
                    float blockCenterX = blockSizeH * (blockX + 0.5f - (0.5f * numBlocksH));
                    float blockCenterZ = blockSizeW * (blockZ + 0.5f - (0.5f * numBlocksW));

                    float posX = blockCenterX + (unit->PositionX / (float)byte.MaxValue);
                    float posZ = blockCenterZ + (unit->PositionZ / (float)byte.MaxValue);
                    
                    Vector3 position = new Vector3(posX, unit->PositionY, posZ);
                    position = Fox.Math.FoxToUnityVector3(position);
                    
                    Quaternion rotation = Quaternion.identity;
                    rotation = Fox.Math.FoxToUnityQuaternion(rotation);

                    float normalizedScale = unit->NormalizedScale / (float)byte.MaxValue;
                    
                    ObjectBrushPlugin plugin = this.pluginHandle[unit->PluginIndex] as ObjectBrushPlugin;
                }
            }
            
            return obrAsset;
        }

        private void OnEnable()
        {
            FoxGameKitModule.ObjectBrushRegistry.Add(this.name, this);
        }

        private void OnDisable()
        {
            FoxGameKitModule.ObjectBrushRegistry.Remove(this.name);
        }
    }
}
