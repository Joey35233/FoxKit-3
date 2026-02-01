using System;
using Codice.CM.Common.Merge;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Gr;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;
using Transform = UnityEngine.Transform;
using TransformUtils = UnityEditor.TransformUtils;

namespace Fox.GameKit
{
    [ExecuteAlways]
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

                if (!Fox.GameKit.FoxGameKitModule.ObjectBrushRegistry.TryGetValue(this.objectBrushName,
                        out ObjectBrush objectBrush))
                    return null;
                
                ObjectBrushAsset obrAsset = Fox.Fs.FileSystem.LoadAsset<ObjectBrushAsset>(objectBrush.obrFile.path.String);
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
                ObjectBrushObject[] objects = new ObjectBrushObject[objectCount];
                for (uint i = 0; i < objectCount; i++, unit++)
                {
                    float posX = unit->PositionX / (float)byte.MaxValue + blockCenterX;
                    float posZ = unit->PositionZ / (float)byte.MaxValue + blockCenterZ;
                    
                    Vector3 position = new Vector3(posX, unit->PositionY, posZ);
                    position = Fox.Math.FoxToUnityVector3(position);
                    
                    Quaternion rotation = new Quaternion(unit->RotationX, unit->RotationY, unit->RotationZ, unit->RotationW);
                    rotation = Fox.Math.FoxToUnityQuaternion(rotation);

                    float normalizedScale = unit->NormalizedScale / (float)byte.MaxValue;
                    
                    ObjectBrushPlugin plugin = objectBrush.pluginHandle[unit->PluginId] as ObjectBrushPlugin;

                    ObjectBrushObject obj = new ObjectBrushObject
                    {
                        Position = position,
                        Rotation = rotation,
                        NormalizedScale = normalizedScale,
                        Plugin = plugin,
                    };
                    objects[i] = obj;
                }
                
                obrbAsset.Objects = objects;
            }
            
            return obrbAsset;
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
            
            ObjectBrushBlockAsset obrbAsset = Fox.Fs.FileSystem.LoadAsset<ObjectBrushBlockAsset>(obrbFile.path.String);
            if (obrbAsset != null)
            {
                foreach (ObjectBrushObject obj in obrbAsset.Objects)
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
            for (int i = this.transform.childCount - 1; i >= 0; i--)
            {
                var child = this.transform.GetChild(i).gameObject;
                if (child.GetComponent<Entity>() && !PrefabUtility.IsAnyPrefabInstanceRoot(child))
                    continue;
                DestroyImmediate(child);
            }
        }
    }
}