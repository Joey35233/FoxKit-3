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
            
            this.OnEnable();
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
                    
                    // At this stage, the handles are still Scene objects (pre-OnPostDeserializeEntity)
                    if (instance == null)
                        return;
                    
                    instance.hideFlags = HideFlags.DontSaveInEditor;
                    Transform instanceTransform = instance.transform;
                    instanceTransform.position = obj.Position;
                    instanceTransform.rotation = obj.Rotation;
                    instanceTransform.localScale = (1.0f + obj.NormalizedScale) * Vector3.one;
                    instanceTransform.SetParent(this.transform, true);
                    TransformUtils.SetConstrainProportions(instanceTransform, true);
                }
            }
            
            //test
            
            Debug.Log($"{GetNumBlocks()}");
        }

        private void OnDisable()
        {
            Fox.GameKit.FoxGameKitModule.ObjectBrushRegistry.Remove(this.name);
        }
        
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i).gameObject;

                if (!PrefabUtility.IsAnyPrefabInstanceRoot(child))
                    continue;

                var pluginIndex = GetPluginIndex(child);
            }
        }

        private int GetPluginIndex(GameObject child)
        {
            var prefabTypeGameObject = PrefabUtility.GetCorrespondingObjectFromSource(child).GetComponent<ObjectBrushPlugin>();

            return pluginHandle.IndexOf(prefabTypeGameObject);
        }

        private bool IsPlugin(GameObject child)
        {
            return pluginHandle.Contains(PrefabUtility.GetCorrespondingObjectFromSource(child).GetComponent<ObjectBrushPlugin>());
        }
        private const float BlockSize = 128;

        private (uint numBlocksW, uint numBlocksH) GetNumBlocks()
        {
            float minX = 0;
            float maxX = 0;
            
            float minZ = 0;
            float maxZ = 0;
            
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i).gameObject;

                if (!PrefabUtility.IsAnyPrefabInstanceRoot(child))
                    continue;

                if (!IsPlugin(child))
                    continue;

                var position = child.transform.position;
                
                
                if (position.x < minX)
                    minX = position.x;
                
                if (position.x > maxX)
                    maxX = position.x;
                
                
                if (position.z < minZ)
                    minZ = position.z;
                
                if (position.z > maxZ)
                    maxZ = position.z;

            }

            uint GetBlockCountFromBoundary(float bound)
            {
                var abs = System.Math.Abs(bound);
                return (uint)System.Math.Ceiling(abs / BlockSize);
            }

            var numBlocksH = GetBlockCountFromBoundary(minX) + GetBlockCountFromBoundary(maxX);
            var numBlocksW = GetBlockCountFromBoundary(minZ) + GetBlockCountFromBoundary(maxZ);
            
            return (numBlocksW, numBlocksH);
        }
    }
}
