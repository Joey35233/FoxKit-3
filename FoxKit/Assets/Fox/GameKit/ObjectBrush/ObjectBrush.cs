using System;
using System.Collections.Generic;
using Codice.CM.Common;
using Fox.Core.Utils;
using Fox.Core;
using Fox.Gr;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;
using Transform = UnityEngine.Transform;
using TransformUtils = UnityEditor.TransformUtils;

namespace Fox.GameKit
{
    [ExecuteAlways]
    public partial class ObjectBrush : Fox.Core.TransformData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
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
                ObjectBrushAsset obrAsset = ConvertFile(obrData);
                Fox.Fs.FileSystem.CreateAsset(obrAsset, obrFile.path.String);
                AssetDatabase.SaveAssets();
            }
        }

        public override void OnPostDeserializeEntity(TaskLogger logger)
        {
            base.OnPostDeserializeEntity(logger);

            if (obrFile == FilePtr.Empty)
                return;

            if (pluginHandle.Count > 0)
            {
                string basePath = System.IO.Path.ChangeExtension(obrFile.path.String, null);
                string unityBasePath = Fox.Fs.FileSystem.GetUnityPathFromFoxPath(basePath);
                if (!System.IO.Directory.Exists(unityBasePath))
                    System.IO.Directory.CreateDirectory(unityBasePath);

                for (int i = 0; i < pluginHandle.Count; i++)
                {
                    ObjectBrushPlugin plugin = pluginHandle[i] as ObjectBrushPlugin;
                    if (plugin == null)
                        continue;

                    string prefabPath = System.IO.Path.Combine(basePath, $"{plugin.name}.prefab");
                    ObjectBrushPlugin pluginPrefab = Fox.Fs.FileSystem.CreatePrefabAsset(plugin.gameObject, prefabPath).GetComponent<ObjectBrushPlugin>();
                    pluginHandle[i] = pluginPrefab;
                }
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
                    
                    ObjectBrushPlugin plugin = this.pluginHandle[unit->PluginId] as ObjectBrushPlugin;

                    ObjectBrushObject obj = new ObjectBrushObject
                    {
                        Position = position,
                        Rotation = rotation,
                        NormalizedScale = normalizedScale,
                        Plugin = plugin,
                    };
                    objects[i] = obj;
                }
                
                obrAsset.Objects = objects;
            }
            
            return obrAsset;
        }

        private void OnEnable()
        {
            for (int i = this.transform.childCount - 1; i >= 0; i--)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (child.GetComponent<Entity>() && !PrefabUtility.IsAnyPrefabInstanceRoot(child))
                    continue;
                DestroyImmediate(child);
            }
            
            Fox.GameKit.FoxGameKitModule.ObjectBrushRegistry[this.name] = this;
            
            ObjectBrushAsset obrAsset = Fox.Fs.FileSystem.LoadAsset<ObjectBrushAsset>(obrFile.path.String);
            if (obrAsset != null)
            {
                foreach (ObjectBrushObject obj in obrAsset.Objects)
                {
                    ObjectBrushPlugin plugin = obj.Plugin;
                    if (plugin == null)
                        continue;
                
                    GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(plugin.gameObject);
                    instance.hideFlags = HideFlags.DontSaveInEditor;
                    Transform instanceTransform = instance.transform;
                    instanceTransform.position = obj.Position;
                    instanceTransform.rotation = obj.Rotation;
                    instanceTransform.localScale = (1.0f + obj.NormalizedScale) * Vector3.one;
                    instanceTransform.SetParent(this.transform, true);
                    TransformUtils.SetConstrainProportions(instanceTransform, true);
                }
            }
        }

        private void OnDisable()
        {
            Fox.GameKit.FoxGameKitModule.ObjectBrushRegistry.Remove(this.name);
        }
    }
}
