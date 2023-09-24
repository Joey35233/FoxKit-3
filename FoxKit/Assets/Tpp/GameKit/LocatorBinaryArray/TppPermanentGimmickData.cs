using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppPermanentGimmickData : Fox.Core.Data
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            if (partsFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(partsFile));
                return;
            }

            if (locaterFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(locaterFile));
                return;
            }

            ScriptableObject locaterAsset = AssetManager.LoadAsset<ScriptableObject>(locaterFile, out string locaterUnityPath);
            if (locaterAsset == null)
            {
                logger.AddWarningMissingAsset(locaterUnityPath);
                return;
            }

            bool hasModel = false;

            switch (locaterAsset)
            {
                case NamedLocatorBinaryArrayAsset namedLocaterAsset:
                    foreach (NamedLocatorBinary locator in namedLocaterAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName().CString).AddComponent<LocatorBinaryObject>();
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case ScaledLocatorBinaryArrayAsset scaledLocatorAsset:
                    foreach (ScaledLocatorBinary locator in scaledLocatorAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(locator.GetLocatorName().CString).AddComponent<LocatorBinaryObject>();
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                case PowerCutAreaLocatorBinaryArrayAsset powerCutAreaLocaterAsset:
                    foreach (PowerCutAreaLocatorBinary locator in powerCutAreaLocaterAsset.locators)
                    {
                        LocatorBinaryObject locatorGameObject = new GameObject(name.CString).AddComponent<LocatorBinaryObject>();
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.ShouldDrawGizmo = !hasModel;
                        locatorGameObject.transform.SetParent(gameObject.transform);
                    }
                    break;
                default:
                    logger.AddWarningMissingAsset(locaterUnityPath);
                    break;
            }
        }
    }
}
