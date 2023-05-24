using Fox.Core;
using Fox.Fio;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppSharedGimmickData : Fox.Core.Data
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);

            //FIND MODELS

            string modelFilePath = "/Assets/Game" + modelFile.path.CString;
            string breakedModelFilePath = "/Assets/Game" + breakedModelFile.path.CString;

            bool havesModel = true;
            if (global::System.String.IsNullOrEmpty(modelFilePath)
                &&global::System.String.IsNullOrEmpty(breakedModelFilePath))
            {
                Debug.LogWarning($"{name}: modelFile and breakedModelFile are null, not using model");
                havesModel = false;
            }

            string partsPath = "/Game" + partsFile.path.CString;

            //LOCATORS

            string locatorPath = "/Game" + locaterFile.path.CString;

            using (var reader = new FileStreamReader(new FileStream(UnityEngine.Application.dataPath + locatorPath, FileMode.Open)))
            {
                LocatorFileReader.ReadLba(reader, "Assets"+locatorPath);
            }
            string trimmedLocatorPath = "Assets/" + locatorPath.Remove(0, 1).Replace(".lba", ".asset");

            //PLACE 'EM

            string trimmedPathModelFile = modelFilePath.Remove(0, 1);
            string trimmedPathBreakedModelFile = breakedModelFilePath.Remove(0, 1);
            GameObject assetModelFile = AssetDatabase.LoadAssetAtPath<GameObject>(trimmedPathModelFile);
            GameObject assetBreakedModelFile = AssetDatabase.LoadAssetAtPath<GameObject>(trimmedPathBreakedModelFile);
            if (assetModelFile == null
                && assetBreakedModelFile == null)
            {
                Debug.LogWarning($"{name}: Unable to find asset at path {trimmedPathModelFile} or {trimmedPathBreakedModelFile}; not using model");
                havesModel = false;
            }

            switch (AssetDatabase.LoadAssetAtPath<ScriptableObject>(trimmedLocatorPath))
            {
                case NamedLocatorBinaryArrayAsset namedAsset:
                    foreach (NamedLocatorBinary locator in namedAsset.locators)
                    {
                        var locatorGameObject = new GameObject() { name = locator.GetLocatorName().CString };
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        if (assetModelFile != null)
                        {
                            var instance = GameObject.Instantiate(assetModelFile);
                            instance.transform.SetParent(locatorGameObject.transform, false);
                        }
                        if (assetBreakedModelFile != null)
                        {
                            var instance = GameObject.Instantiate(assetBreakedModelFile);
                            instance.transform.SetParent(locatorGameObject.transform, false);
                        }
                        if (havesModel == false)
                        {
                            PointGizmo gizmo = locatorGameObject.AddComponent<PointGizmo>();
                            gizmo.Color = Color.cyan;
                            gizmo.DrawLabel = true;
                            gizmo.Scale = Vector3.one;
                            gizmo.ScaleMode = PointGizmo.GizmoScaleMode.Explicit;
                        }
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case ScaledLocatorBinaryArrayAsset scaledAsset:
                    foreach (ScaledLocatorBinary locator in scaledAsset.locators)
                    {
                        var locatorGameObject = new GameObject() { name = locator.GetLocatorName().CString };
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.transform.localScale = locator.GetScale();
                        if (assetModelFile != null)
                        {
                            var instance = GameObject.Instantiate(assetModelFile);
                            instance.transform.SetParent(locatorGameObject.transform, false);
                        }
                        if (assetBreakedModelFile != null)
                        {
                            var instance = GameObject.Instantiate(assetBreakedModelFile);
                            instance.transform.SetParent(locatorGameObject.transform, false);
                        }
                        if (havesModel == false)
                        {
                            PointGizmo gizmo = locatorGameObject.AddComponent<PointGizmo>();
                            gizmo.Color = Color.cyan;
                            gizmo.DrawLabel = true;
                            gizmo.Scale = Vector3.one;
                            gizmo.ScaleMode = PointGizmo.GizmoScaleMode.Explicit;
                        }
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case PowerCutAreaLocatorBinaryArrayAsset powerCutAreaAsset:
                    foreach (PowerCutAreaLocatorBinary locator in powerCutAreaAsset.locators)
                    {
                        var locatorGameObject = new GameObject() { name = name.CString };
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        if (assetModelFile != null)
                        {
                            var instance = GameObject.Instantiate(assetModelFile);
                            instance.transform.SetParent(locatorGameObject.transform, false);
                        }
                        if (assetBreakedModelFile != null)
                        {
                            var instance = GameObject.Instantiate(assetBreakedModelFile);
                            instance.transform.SetParent(locatorGameObject.transform, false);
                        }
                        if (havesModel == false)
                        {
                            PointGizmo gizmo = locatorGameObject.AddComponent<PointGizmo>();
                            gizmo.Color = Color.cyan;
                            gizmo.DrawLabel = true;
                            gizmo.Scale = Vector3.one;
                            gizmo.ScaleMode = PointGizmo.GizmoScaleMode.Explicit;
                        }
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case null:
                    Debug.LogWarning($"{name}: Unable to find asset at path {trimmedLocatorPath}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
