using Fox.Core;
using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppSharedGimmickData : Fox.Core.Data
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            //FIND MODELS

            bool hasModel = true;
            if (modelFile == FilePtr.Empty && breakedModelFile == FilePtr.Empty)
            {
                logger.AddWarningMissingAsset(nameof(modelFile));
                logger.AddWarningMissingAsset(nameof(breakedModelFile));
                hasModel = false;
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
                hasModel = false;
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
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName().CString).AddComponent<LocatorBinaryObject>();
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
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case ScaledLocatorBinaryArrayAsset scaledAsset:
                    foreach (ScaledLocatorBinary locator in scaledAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName().CString).AddComponent<LocatorBinaryObject>();
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
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case PowerCutAreaLocatorBinaryArrayAsset powerCutAreaAsset:
                    foreach (PowerCutAreaLocatorBinary locator in powerCutAreaAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(name.CString).AddComponent<LocatorBinaryObject>();
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
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
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
