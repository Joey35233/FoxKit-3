using System.Collections.Generic;
using System.IO;
using Fox.Core.Utils;
using Fox.Fio;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class ObjectBrushBlock
    {
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            if (System.String.IsNullOrEmpty(obrbFile.path.String))
            {
                Debug.LogWarning($"{name}: obrbFile is null");
                return;
            }
            
            string locaterPath = "/Game" + obrbFile.path.String;

            string readPath = "Assets" + locaterPath;

            ObjectBrushAsset asset = ObjectBrushReader.Read(new FileStreamReader(new FileStream(readPath, FileMode.Open)));

            if (!asset)
            {
                Debug.LogWarning($"{name}: asset could not be created");
                return;
            }

            string trimmedPath = readPath.Replace(".obrb", ".asset");

            AssetDatabase.CreateAsset(asset, $"{trimmedPath}");

            AssetDatabase.SaveAssets();

            if (!System.IO.File.Exists(readPath))
            {
                Debug.LogError($"{readPath} does not exist");
                return;
            }
            
            ObjectBrush objectBrush = FoxGameKitModule.ObjectBrushRegistry[this.objectBrushName];

            var assetMain = AssetDatabase.LoadAssetAtPath<ObjectBrushAsset>(("Assets" + ("/Game" + objectBrush.obrFile.path.String)).Replace(".obr", ".asset"));

            if (!asset)
            {
                Debug.LogWarning($"{name}: asset could not be created");
                return;
            }
            
            List<ObrObject> ObrObjects = new();

            foreach (var obj in asset.objects)
            {
                ObjectBrushPlugin obrPlugin = objectBrush.pluginHandle[obj.GetPluginBrushIndex()] as ObjectBrushPlugin;
                
                if (!obrPlugin) continue;

                ObrObject obrObj = new()
                {
                    Position = Math.FoxToUnityVector3(GetPositionFWSFromPositionEWS(obj,assetMain,(ushort)blockId)),
                    Rotation = Math.FoxToUnityQuaternion(obj.GetRotation()),
                    Scale = (float)obj.GetNormalizedScale() / System.Byte.MaxValue,
                    Plugin = obrPlugin
                };

                obrPlugin.RegisterObject(obrObj);
                
                ObrObjects.Add(obrObj);
            }
        }
        //joey func, but perhaps pointlessly dynamic!
        private const ushort OBR_MAGIC = 32640;
        private static Vector3 GetPositionFWSFromPositionEWS(ObjectBrushObjectBinary obj, ObjectBrushAsset asset, ushort blockId)
        {
            ushort blockIndex =  blockId;

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