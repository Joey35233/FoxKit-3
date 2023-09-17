using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppPermanentGimmickData : Fox.Core.Data
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);

            string partsPath = "/Game" + partsFile.path.CString;
            string locatorPath = "/Game" + locaterFile.path.CString;

            // FIXME Commented out 'cuz erroring when file doesn't exist
            /*
            using (var reader = new FileStreamReader(new FileStream(UnityEngine.Application.dataPath + locatorPath, FileMode.Open)))
            {
                LocatorFileReader.ReadLba(reader, "Assets" + locatorPath);
            }*/
            string trimmedLocatorPath = "Assets/" + locatorPath.Remove(0, 1).Replace(".lba", ".asset");

            bool havesModel = false;

            var namedAsset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(trimmedLocatorPath) as NamedLocatorBinaryArrayAsset;

            if (namedAsset != null)
            {
                foreach (NamedLocatorBinary locator in namedAsset.locators)
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
                return;
            }

            var scaledAsset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(trimmedLocatorPath) as ScaledLocatorBinaryArrayAsset;

            if (scaledAsset != null)
            {
                foreach (ScaledLocatorBinary locator in scaledAsset.locators)
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
                return;
            }

            var powerCutAreaAsset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(trimmedLocatorPath) as PowerCutAreaLocatorBinaryArrayAsset;

            if (powerCutAreaAsset != null)
            {
                foreach (PowerCutAreaLocatorBinary locator in powerCutAreaAsset.locators)
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
                return;
            }

            if (namedAsset == null && scaledAsset == null && powerCutAreaAsset == null)
            {
                Debug.LogWarning($"{name}: Unable to find asset at path {trimmedLocatorPath}");
                return;
            }
        }
    }
}
