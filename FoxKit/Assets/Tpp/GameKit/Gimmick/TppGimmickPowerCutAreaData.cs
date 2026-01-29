using System;
using Fox.Core;
using Fox.Core.Utils;
using Fox.GameKit;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Tpp.GameKit
{
    public partial class TppGimmickPowerCutAreaData
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            LocatorEntry[] locators;
            if (locaterFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(locaterFile));
                return;
            }
            else
            {
                string lbaExternalPath = Fox.Fs.FileSystem.GetExternalPathFromFoxPath(locaterFile.path.String);
                if (!File.Exists(lbaExternalPath))
                {
                    logger.AddWarningMissingAsset(locaterFile.path.String);
                    return;
                }
                
                byte[] lbaData = File.ReadAllBytes(lbaExternalPath);
                locators = LocatorBinaryArrayFile.Convert(lbaData);

                LocatorArrayAsset locatorArrayAsset = ScriptableObject.CreateInstance<LocatorArrayAsset>();
                locatorArrayAsset.Locators = locators;
                Fox.Fs.FileSystem.CreateAsset(locatorArrayAsset, locaterFile.path.String);
                AssetDatabase.SaveAssets();
            }
            
            foreach (LocatorEntry locator in locators)
            {
                GameObject locatorGameObject = new GameObject();
                    
                locatorGameObject.name = gameObject.name+Array.IndexOf(locators,locator).ToString("0000");
                
                locatorGameObject.transform.position = locator.Position;
                locatorGameObject.transform.rotation = locator.Rotation;
                locatorGameObject.transform.SetParent(gameObject.transform);
            }
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);
            
            LocatorFileWriter.Write(Fox.Fs.FileSystem.GetExternalPathFromFoxPath(locaterFile.path.String),gameObject,null,false);
        }

    }
}