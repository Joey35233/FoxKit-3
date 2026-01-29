using System;
using System.Collections.Generic;
using System.IO;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.GameKit;
using Fox.GameKit.Locator;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Tpp.GameKit
{
    [ExecuteInEditMode]
    public partial class TppPermanentGimmickData : Fox.Core.Data
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
            
            // Mandatory
            GameObject partsPrefab;
            if (partsFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(partsFile));
                return;
            }
            else
            {
                partsPrefab = (GameObject)DataSetFile2.ImportPrefab(partsFile);
            
                if (!partsPrefab)
                {
                    logger.AddWarningMissingAsset(partsFile.path.String);
                    return;
                }
            }
            
            foreach (LocatorEntry locator in locators)
            {
                GameObject locatorGameObject = (GameObject)PrefabUtility.InstantiatePrefab(partsPrefab, gameObject.transform);
                if (locator.Name != null)
                    locatorGameObject.name = locator.Name;
                
                locatorGameObject.transform.position = locator.Position;
                locatorGameObject.transform.rotation = locator.Rotation;
                locatorGameObject.transform.localScale = locator.Scale;

                locatorGameObject.AddComponent<LocatorGimmick>();
            }
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            var dataSetName = Fox.Fs.FileSystem.GetFoxPathFromExternalPath(AssetDatabase.GetAssetOrScenePath(this));

            LocatorFileWriter.Write(locaterFile.path.String,gameObject,dataSetName,true);
        }
    }
}
