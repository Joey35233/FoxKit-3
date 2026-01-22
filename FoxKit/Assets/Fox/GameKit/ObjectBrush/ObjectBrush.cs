using Fox.Core.Utils;
using Fox.Fio;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class ObjectBrush : Fox.Core.TransformData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            if (System.String.IsNullOrEmpty(obrFile.path.String))
            {
                Debug.LogWarning($"{name}: obrFile is null");
                return;
            }
            
            string readPath = "Assets/Game" + obrFile.path.String;

            if (!System.IO.File.Exists(readPath))
            {
                Debug.LogError($"{readPath} does not exist");
                return;
            }

            ObjectBrushAsset asset = ObjectBrushReader.Read(new FileStreamReader(new FileStream(readPath, FileMode.Open)));

            if (!asset)
            {
                Debug.LogWarning($"{name}: asset could not be created");
                return;
            }

            string trimmedPath = readPath.Remove(0, 1).Replace(".obr", ".asset");

            AssetDatabase.CreateAsset(asset, $"{trimmedPath}.asset");

            AssetDatabase.SaveAssets();

            List<ObrObject> ObrObjects = new();

            foreach (var obj in asset.objects)
            {
                ObjectBrushPlugin obrPlugin = pluginHandle[obj.GetPluginBrushIndex()] as ObjectBrushPlugin;

                if (!obrPlugin) continue;

                ObrObject obrObj = new()
                {
                    Position = Math.FoxToUnityVector3(GetPositionFWSFromPositionEWS(obj,asset)),
                    Rotation = Math.FoxToUnityQuaternion(obj.GetRotation()),
                    Scale = (float)obj.GetNormalizedScale() / System.Byte.MaxValue,
                    Plugin = obrPlugin
                };

                obrPlugin.RegisterObject(obrObj);
                
                ObrObjects.Add(obrObj);

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
        //joey func, but perhaps pointlessly dynamic!
        private const ushort OBR_MAGIC = 32640;
        private static Vector3 GetPositionFWSFromPositionEWS(ObjectBrushObjectBinary obj, ObjectBrushAsset asset)
        {
            ushort blockIndex = obj.GetBlockIndex();

            uint numBlocksW = asset.numBlocksW;
            uint numBlocksH = asset.numBlocksH;

            ushort METERS_PER_BLOCK_X = (ushort)(asset.blockSizeH / 1);
            ushort METERS_PER_BLOCK_Z = (ushort)(asset.blockSizeW / 1);
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)(blockIndex % numBlocksH);
            ushort blockZ = (ushort)Mathf.Floor(blockIndex / numBlocksW);

            // block center position
            float blockCenterXFWS = METERS_PER_BLOCK_X * (blockX + 0.5f - (0.5f * numBlocksH));
            float blockCenterZFWS = METERS_PER_BLOCK_Z * (blockZ + 0.5f - (0.5f * numBlocksW));

            // output position FWS
            float OBR_POSITION_DECODE_X = METERS_PER_BLOCK_X / (float)OBR_MAGIC;
            float OBR_POSITION_DECODE_Z = METERS_PER_BLOCK_Z / (float)OBR_MAGIC;
            float xFWS = blockCenterXFWS + (OBR_POSITION_DECODE_X * obj.GetXPosition());
            float zFWS = blockCenterZFWS + (OBR_POSITION_DECODE_Z * obj.GetZPosition());

            return new Vector3(xFWS, obj.GetYPosition(), zFWS);
        }
        private static GameObject MakeStaticModelGameObject(Fox.Core.Transform transform, string modelFilePath, GameObject gameObject)
        {
            string trimmedModelFilePath = modelFilePath.Remove(0, 1);
            if (AssetDatabase.LoadAssetAtPath<GameObject>(trimmedModelFilePath) is GameObject modelFileAsset)
            {
                var modelFileInstance = GameObject.Instantiate(modelFileAsset);
                modelFileInstance.transform.position = transform.translation;
                modelFileInstance.transform.rotation = transform.rotation_quat;
                modelFileInstance.transform.localScale = transform.scale;
                modelFileInstance.transform.SetParent(gameObject.transform, false);
                return modelFileInstance;
            }
            else
            {
                Debug.LogWarning($"Unable to find asset at path {trimmedModelFilePath}");
            }
            return null;
        }
    }
}
