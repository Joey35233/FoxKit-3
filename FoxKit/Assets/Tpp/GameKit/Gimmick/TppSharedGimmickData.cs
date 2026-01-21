using Fox.Core;
using Fox.Core.Utils;
using System;
using System.IO;
using Fox.Fio;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppSharedGimmickData : Fox.Core.Data
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            //FIND MODELS

            bool hasModel = true;
            if (modelFile == FilePtr.Empty && breakedModelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(modelFile));
                logger.AddWarningEmptyPath(nameof(breakedModelFile));
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
            string locaterPath = "/Game" + locaterFile.path.String;

            string readPath = "Assets" + locaterPath;
            
            ScriptableObject locaterAsset = AssetManager.LoadAssetWithExtensionReplacement<ScriptableObject>(locaterFile, "asset", out string unityPath);

            if (locaterAsset == null)
            {
                locaterAsset=LocatorFileReader.Read(new FileStreamReader(new FileStream(readPath, FileMode.Open)));
            
                AssetDatabase.CreateAsset(locaterAsset,  unityPath);
            }
            
            AssetDatabase.SaveAssets();

            switch (locaterAsset)
            {
                case NamedLocatorBinaryArrayAsset namedAsset:
                    foreach (NamedLocatorBinary locator in namedAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName()).AddComponent<LocatorBinaryObject>();
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
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName()).AddComponent<LocatorBinaryObject>();
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
                        LocatorBinaryObject locatorGameObject = new GameObject(name).AddComponent<LocatorBinaryObject>();
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
                    logger.AddWarningMissingAsset(locaterFile.path.String);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
