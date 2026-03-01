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
        private const float InitBlockSize = 128;
        private const uint InitBlockCount = 1;
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            if (obrFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(obrFile));
            }
        }

        // TODO: Does this need to be its own special function?
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

            if (!TryConvertFile(obrData, out ObjectBrushDesc obrDesc))
            {
                logger.AddError("OBR file invalid.");
                return;
            }
            
            DynamicProperty_StaticArray_uint32 numBlocksHProperty = (DynamicProperty_StaticArray_uint32)this.AddDynamicProperty(PropertyInfo.PropertyType.UInt32, "numBlocksH", 1, PropertyInfo.ContainerType.StaticArray);
            numBlocksHProperty.Value[0] = obrDesc.NumBlocksH;
            
            DynamicProperty_StaticArray_uint32 numBlocksWProperty = (DynamicProperty_StaticArray_uint32)this.AddDynamicProperty(PropertyInfo.PropertyType.UInt32, "numBlocksW", 1, PropertyInfo.ContainerType.StaticArray);
            numBlocksWProperty.Value[0] = obrDesc.NumBlocksW;
            
            // TODO: What happens if the file is invalid but it's called later anyway?
            this.OnEnable();
            
            foreach (ObjectBrushObjectDesc obj in obrDesc.Objects)
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

        public (uint numBlocksH, uint numBlocksW) GetNumBlocks()
        {
            DynamicProperty_StaticArray_uint32 numBlocksHProperty = null;
            DynamicProperty_StaticArray_uint32 numBlocksWProperty = null;
            foreach (var component in gameObject.GetComponents<DynamicProperty_StaticArray_uint32>())
            {
                switch (component.Name)
                {
                    case "numBlocksH":
                        numBlocksHProperty = component;
                        break;
                    case "numBlocksW":
                        numBlocksWProperty = component;
                        break;
                }

                if (numBlocksHProperty != null && numBlocksWProperty != null)
                    break;
            }
            
            uint numBlocksH = numBlocksHProperty == null ? InitBlockCount : numBlocksHProperty.Value[0];
            uint numBlocksW = numBlocksWProperty == null ? InitBlockCount : numBlocksWProperty.Value[0];
            
            return (numBlocksH, numBlocksW);
        }

        private unsafe bool TryConvertFile(byte[] file, out ObjectBrushDesc desc)
        {
            desc = new ObjectBrushDesc();
            
            fixed (byte* data = file)
            {
                FoxDataHeader* header = (FoxDataHeader*)data;
                if (header->Version != 3)
                    return false;
                
                FoxDataNode* node = header->GetNodes();
                if (node->Flags != 1)
                    return false;
                    
                FoxDataNodeAttribute* blockSizeWAttrib = node->FindAttribute("blockSizeW");
                FoxDataNodeAttribute* blockSizeHAttrib = node->FindAttribute("blockSizeH");
                FoxDataNodeAttribute* numBlocksWAttrib = node->FindAttribute("numBlocksW");
                FoxDataNodeAttribute* numBlocksHAttrib = node->FindAttribute("numBlocksH");
                FoxDataNodeAttribute* numObjectsAttrib = node->FindAttribute("numObjects");

                if (blockSizeWAttrib == null || blockSizeHAttrib == null || numBlocksWAttrib == null || numBlocksHAttrib == null || numObjectsAttrib == null)
                    return false;
                
                float blockSizeW = blockSizeWAttrib->GetFloatValue();
                float blockSizeH = blockSizeHAttrib->GetFloatValue();
                uint numBlocksW = numBlocksWAttrib->GetUIntValue();
                uint numBlocksH = numBlocksHAttrib->GetUIntValue();

                desc.BlockSizeW = blockSizeW;
                desc.BlockSizeH = blockSizeH;
                desc.NumBlocksW = numBlocksW;
                desc.NumBlocksH = numBlocksH;

                uint objectCount = numObjectsAttrib->GetUIntValue();
                DataUnit* unit = (DataUnit*)node->GetData();
                ObjectBrushObjectDesc[] objects = new ObjectBrushObjectDesc[objectCount];
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

                    ObjectBrushObjectDesc obj = new ObjectBrushObjectDesc
                    {
                        Position = position,
                        Rotation = rotation,
                        NormalizedScale = normalizedScale,
                        Plugin = plugin,
                    };
                    objects[i] = obj;
                }
                
                desc.Objects = objects;
            }
            
            return true;
        }

        private void OnEnable()
        {
            Fox.GameKit.FoxGameKitModule.ObjectBrushRegistry[this.name] = this;
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

        private bool IsPlugin(GameObject child)
        {
            return pluginHandle.Contains(GetPlugin(child));
        }
        
        public (uint numBlocksH, uint numBlocksW) CalculateNumBlocks()
        {
            uint numBlocksH = 0;
            uint numBlocksW = 0;
            
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

            uint getBlockCountFromBoundary(float bound) => (uint)Mathf.Ceil(Mathf.Abs(bound) / InitBlockSize);

            numBlocksH = getBlockCountFromBoundary(minX) + getBlockCountFromBoundary(maxX);
            numBlocksW = getBlockCountFromBoundary(minZ) + getBlockCountFromBoundary(maxZ);

            return (numBlocksH, numBlocksW);
        }

        private void DrawGizmo(bool isSelected)
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
                float blockHX = (blockH - blockHCenter)*InitBlockSize+(InitBlockSize/2);
                for (uint blockW = 0; blockW < NumBlocksW; blockW++)
                {
                    float blockWZ = (blockW - blockWCenter)*InitBlockSize+(InitBlockSize/2);
                    Gizmos.DrawWireCube(new Vector3(blockHX,0,blockWZ), new Vector3(InitBlockSize,0,InitBlockSize));
                }
            }
        }

        private void OnDrawGizmos() => DrawGizmo(false);

        private void OnDrawGizmosSelected() => DrawGizmo(true);
    }
}
