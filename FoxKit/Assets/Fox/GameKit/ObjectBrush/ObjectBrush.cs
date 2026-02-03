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
        private const float BlockSize = 128;
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
            
            SetNumBlocks(obrAsset.NumBlocksH, obrAsset.NumBlocksW);
            
            this.OnEnable();
            
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
                    
                    //instance.hideFlags = HideFlags.DontSaveInEditor;
                    Transform instanceTransform = instance.transform;
                    instanceTransform.position = obj.Position;
                    instanceTransform.rotation = obj.Rotation;
                    instanceTransform.localScale = (1.0f + obj.NormalizedScale) * Vector3.one;
                    instanceTransform.SetParent(this.transform, true);
                    TransformUtils.SetConstrainProportions(instanceTransform, true);
                }
            }
        }

        private void SetNumBlocks(uint numBlocksH, uint numBlocksW)
        {
            if (gameObject.TryGetComponent(out DynamicProperty_StaticArray_uint32 numBlocksHComponent))
            {
                foreach (var component in gameObject.GetComponents<DynamicProperty_StaticArray_uint32>())
                {
                    if (component.Name != "numBlocksH") continue;
                    numBlocksHComponent = component;
                    break;
                }
            }
            if (numBlocksHComponent == null)
            {
                numBlocksHComponent = gameObject.AddComponent<DynamicProperty_StaticArray_uint32>();
                numBlocksHComponent.Name = "numBlocksH";
            }
            numBlocksHComponent.SetElement(0,new Value(numBlocksH));
            
            if (gameObject.TryGetComponent(out DynamicProperty_StaticArray_uint32 numBlocksWComponent))
            {
                foreach (var component in gameObject.GetComponents<DynamicProperty_StaticArray_uint32>())
                {
                    if (component.Name != "numBlocksW") continue;
                    numBlocksWComponent = component;
                    break;
                }
            }
            if (numBlocksWComponent == null || numBlocksWComponent.Name != "numBlocksW")
            {
                numBlocksWComponent = gameObject.AddComponent<DynamicProperty_StaticArray_uint32>();
                numBlocksWComponent.Name = "numBlocksW";
            }
            numBlocksWComponent.SetElement(0,new Value(numBlocksW));
        }

        public (uint numBlocksH, uint numBlocksW) GetNumBlocks()
        {
            uint numBlocksH = 0;
            uint numBlocksW = 0;
            
            foreach (var component in gameObject.GetComponents<DynamicProperty_StaticArray_uint32>())
            {
                switch (component.Name)
                {
                    case "numBlocksH":
                        numBlocksH = component.GetElement(0).GetValueAsUInt32();
                        break;
                    case "numBlocksW":
                        numBlocksW = component.GetElement(0).GetValueAsUInt32();
                        break;
                }
            }

            if (numBlocksH != 0 || numBlocksW != 0) return (numBlocksH, numBlocksW);
            
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

            numBlocksH = GetBlockCountFromBoundary(minX) + GetBlockCountFromBoundary(maxX);
            numBlocksW = GetBlockCountFromBoundary(minZ) + GetBlockCountFromBoundary(maxZ);

            return (numBlocksH, numBlocksW);
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
            /*for (int i = this.transform.childCount - 1; i >= 0; i--)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (child.GetComponent<Entity>() && !PrefabUtility.IsAnyPrefabInstanceRoot(child))
                    continue;
                DestroyImmediate(child);
            }*/
            
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
        }

        private void OnDisable()
        {
            Fox.GameKit.FoxGameKitModule.ObjectBrushRegistry.Remove(this.name);
        }
        
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            ObjectBrushFileWriter.WriteObjectBrush(this);
        }

        private static ObjectBrushPlugin GetPlugin(GameObject child)
        {
            return PrefabUtility.GetCorrespondingObjectFromSource(child).GetComponent<ObjectBrushPlugin>();
        }

        private int GetPluginIndex(GameObject child)
        {
            return pluginHandle.IndexOf(GetPlugin(child));
        }

        private bool IsPlugin(GameObject child)
        {
            return pluginHandle.Contains(GetPlugin(child));
        }

        public void DrawGizmo(bool isSelected)
        {
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = Color.green;
            if (!isSelected)
                Gizmos.color/=4;
            
            (uint NumBlocksH, uint NumBlocksW) = GetNumBlocks();
            
            int blockHCenter = (int)(NumBlocksH / 2);
            int blockWCenter = (int)(NumBlocksW / 2);
            for (uint blockH = 0; blockH < NumBlocksH; blockH++)
            {
                float blockHX = (blockH - blockHCenter)*BlockSize+(BlockSize/2);
                for (uint blockW = 0; blockW < NumBlocksW; blockW++)
                {
                    float blockWZ = (blockW - blockWCenter)*BlockSize+(BlockSize/2);
                    Gizmos.DrawWireCube(new Vector3(blockHX,0,blockWZ), new Vector3(BlockSize,0,BlockSize));
                }
            }
        }

        public void OnDrawGizmos() => DrawGizmo(false);

        public void OnDrawGizmosSelected() => DrawGizmo(true);
    }
}
