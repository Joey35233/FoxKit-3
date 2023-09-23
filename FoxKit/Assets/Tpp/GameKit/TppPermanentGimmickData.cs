using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppPermanentGimmickData : Fox.Core.Data
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);

            if (partsFile == FilePtr.Empty())
            {
                logger.AddWarningEmptyPath(nameof(partsFile));
                return;
            }

            if (locaterFile == FilePtr.Empty())
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

            bool havesModel = false;

            switch (locaterAsset)
            {
                case NamedLocatorBinaryArrayAsset namedLocaterAsset:
                    foreach (NamedLocatorBinary locator in namedLocaterAsset.locators)
                    {
                        var locatorGameObject = new GameObject() { name = locator.GetLocatorName().CString };
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
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
                case ScaledLocatorBinaryArrayAsset scaledLocatorAsset:
                    foreach (ScaledLocatorBinary locator in scaledLocatorAsset.locators)
                    {
                        var locatorGameObject = new GameObject() { name = locator.GetLocatorName().CString };
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
                        locatorGameObject.transform.localScale = locator.GetScale();
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
                case PowerCutAreaLocatorBinaryArrayAsset powerCutAreaLocaterAsset:
                    foreach (PowerCutAreaLocatorBinary locator in powerCutAreaLocaterAsset.locators)
                    {
                        var locatorGameObject = new GameObject() { name = name.CString };
                        locatorGameObject.transform.position = locator.GetTranslation();
                        locatorGameObject.transform.rotation = locator.GetRotation();
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
                default:
                    logger.AddWarningMissingAsset(locaterUnityPath);
                    break;
            }
        }
    }
}
