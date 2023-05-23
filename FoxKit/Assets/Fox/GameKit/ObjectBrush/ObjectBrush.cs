using Fox.Core;
using Fox.Fio;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class ObjectBrush : Fox.Core.TransformData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);

            string obrPath = "/Game" + obrFile.path.CString;
            if (System.String.IsNullOrEmpty(obrPath))
            {
                Debug.LogWarning($"{name}: obrFile is null");
                return;
            }

            ObjectBrushAsset asset = ObjectBrushReader.Read(new FileStreamReader(new FileStream("Assets" + obrPath, FileMode.Open)));

            if (asset == null)
            {
                Debug.LogWarning($"{name}: asset could not be created");
                return;
            }

            string trimmedPath = "Assets/" + obrPath.Remove(0, 1).Replace(".obr", ".asset");

            AssetDatabase.CreateAsset(asset, $"{trimmedPath}.asset");

            AssetDatabase.SaveAssets();

            foreach (ObjectBrushObjectBinary obj in asset.objects)
            {
                var locatorGameObject = new GameObject();
                locatorGameObject.name = gameObject.name + "Brush" + obj.GetPluginBrushIndex().ToString("d4") + "Object" + asset.objects.IndexOf(obj).ToString("d4");

                var pluginEntity = pluginHandle[obj.GetPluginBrushIndex()].Entity as ObjectBrushPlugin;
                if (pluginEntity!=null)
                    locatorGameObject.name = pluginEntity.name + asset.objects.IndexOf(obj).ToString("d4");

                Vector3 foxPosition = GetPositionFWSFromPositionEWS(
                    obj.GetXPosition(),obj.GetYPosition(),obj.GetZPosition(),obj.GetBlockIndex(),
                    asset.numBlocksW, asset.numBlocksH, asset.blockSizeW,asset.blockSizeH);
                locatorGameObject.transform.position = Kernel.Math.FoxToUnityVector3(foxPosition);
                locatorGameObject.transform.rotation = Kernel.Math.FoxToUnityQuaternion(obj.GetRotation());

                var pluginCloneEntity = pluginHandle[obj.GetPluginBrushIndex()].Entity as ObjectBrushPluginClone;

                if (pluginCloneEntity!=null)
                    locatorGameObject.transform.localScale = Vector3.one * Mathf.Lerp(pluginCloneEntity.minSize, pluginCloneEntity.maxSize, (float)obj.GetNormalizedScale() / System.Byte.MaxValue);

                if (pluginCloneEntity != null)
                {
                    string modelFilePath = "/Assets/Game" + pluginCloneEntity.modelFile.path.CString;

                    string trimmedModelFilePath = modelFilePath.Remove(0, 1);
                    GameObject modelFileAsset = AssetDatabase.LoadAssetAtPath<GameObject>(trimmedModelFilePath);
                    if (modelFileAsset == null)
                    {
                        Debug.LogWarning($"{name}: Unable to find asset at path {trimmedModelFilePath}");
                    }
                    else
                    {
                        var modelFileInstance = GameObject.Instantiate(modelFileAsset);
                        modelFileInstance.transform.SetParent(locatorGameObject.transform, false);
                    }
                }

                if (pluginCloneEntity==null)
                {
                    PointGizmo gizmo = locatorGameObject.AddComponent<PointGizmo>();
                    gizmo.Color = Color.green;
                    gizmo.Scale = Vector3.one;
                    gizmo.ScaleMode = PointGizmo.GizmoScaleMode.Explicit;
                }

                locatorGameObject.transform.SetParent(gameObject.transform);
            }
        }
        //joey func, but perhaps pointlessly dynamic!
        private const ushort OBR_MAGIC = 32640;
        private static Vector3 GetPositionFWSFromPositionEWS(short xEOS, float yFWS, short zEOS, ushort blockIndex, uint numBlocksW, uint numBlocksH, float blockSizeW, float blockSizeH)
        {
            ushort METERS_PER_BLOCK_X = (ushort)(blockSizeH / 1);
            ushort METERS_PER_BLOCK_Z = (ushort)(blockSizeW / 1);
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)(blockIndex % numBlocksH);
            ushort blockZ = (ushort)Mathf.Floor(blockIndex / numBlocksW);

            // block center position
            float blockCenterXFWS = METERS_PER_BLOCK_X * (blockX + 0.5f - (0.5f * numBlocksH));
            float blockCenterZFWS = METERS_PER_BLOCK_Z * (blockZ + 0.5f - (0.5f * numBlocksW));

            // output position FWS
            float OBR_POSITION_DECODE_X = METERS_PER_BLOCK_X / (float)OBR_MAGIC;
            float OBR_POSITION_DECODE_Z = METERS_PER_BLOCK_Z / (float)OBR_MAGIC;
            float xFWS = blockCenterXFWS + (OBR_POSITION_DECODE_X * xEOS);
            float zFWS = blockCenterZFWS + (OBR_POSITION_DECODE_Z * zEOS);

            return new Vector3(xFWS, yFWS, zFWS);
        }
    }
}
