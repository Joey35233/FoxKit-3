using Fox.Core;
using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppSharedGimmickData : Fox.Core.Data
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);

            //FIND MODELS

            bool havesModel = true;
            if (modelFile == FilePtr.Empty && breakedModelFile == FilePtr.Empty)
            {
                logger.AddWarningMissingAsset(nameof(modelFile));
                logger.AddWarningMissingAsset(nameof(breakedModelFile));
                havesModel = false;
            }

            if (partsFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(partsFile));
                return;
            }

            //LOCATORS

            if (locaterFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(locaterFile));
                return;
            }

            //PLACE 'EM

            GameObject assetModelFile = AssetManager.LoadAsset<GameObject>(modelFile, out string modelFileUnityPath);
            GameObject assetBreakedModelFile = AssetManager.LoadAsset<GameObject>(breakedModelFile, out string breakedModelFileUnityPath);
            if (assetModelFile == null
                && assetBreakedModelFile == null)
            {
                logger.AddWarningMissingAsset(modelFileUnityPath);
                logger.AddWarningMissingAsset(breakedModelFileUnityPath);
                havesModel = false;
            }

            ScriptableObject locaterAsset = AssetManager.LoadAsset<ScriptableObject>(locaterFile, out string locaterUnityPath);
            if (locaterAsset == null)
            {
                logger.AddWarningMissingAsset(locaterUnityPath);
                return;
            }

            switch (locaterAsset)
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
                    logger.AddWarningMissingAsset(locaterUnityPath);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
