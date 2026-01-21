using System.IO;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppPermanentGimmickData : Fox.Core.Data
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            if (partsFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(partsFile));
                //return;
            }

            if (locaterFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(locaterFile));
                //return;
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

            bool hasModel = false;

            switch (locaterAsset)
            {
                case NamedLocatorBinaryArrayAsset namedLocaterAsset:
                    foreach (NamedLocatorBinary locator in namedLocaterAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName()).AddComponent<LocatorBinaryObject>();
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case ScaledLocatorBinaryArrayAsset scaledLocatorAsset:
                    foreach (ScaledLocatorBinary locator in scaledLocatorAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName()).AddComponent<LocatorBinaryObject>();
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case PowerCutAreaLocatorBinaryArrayAsset powerCutAreaLocaterAsset:
                    foreach (PowerCutAreaLocatorBinary locator in powerCutAreaLocaterAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(name).AddComponent<LocatorBinaryObject>();
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                default:
                    logger.AddWarningMissingAsset(locaterFile.path.String);
                    break;
            }
        }
    }
}
