using System.IO;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppGimmickPowerCutAreaData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            string locaterPath = "/Game" + locaterFile.path.String;

            string readPath = "Assets" + locaterPath;
            
            var locaterAsset = AssetManager.LoadAssetWithExtensionReplacement<PowerCutAreaLocatorBinaryArrayAsset>(locaterFile, "asset", out string unityPath);

            if (locaterAsset == null)
            {
                locaterAsset=(PowerCutAreaLocatorBinaryArrayAsset)LocatorFileReader.Read(new FileStreamReader(new FileStream(readPath, FileMode.Open)));
            
                AssetDatabase.CreateAsset(locaterAsset,  unityPath);
            }
            
            AssetDatabase.SaveAssets();

            foreach (PowerCutAreaLocatorBinary locator in locaterAsset.locators)
            {
                LocatorBinaryObject locatorGameObject = new GameObject(name).AddComponent<LocatorBinaryObject>();
                        
                locatorGameObject.transform.position = locator.GetTranslation();
                locatorGameObject.transform.rotation = locator.GetRotation();
                locatorGameObject.transform.SetParent(gameObject.transform);
                locatorGameObject.ShouldDrawGizmo = true;
            }
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);
            
            LocatorFileWriter.Write(locaterFile.path.String,gameObject,null,true);
        }

    }
}