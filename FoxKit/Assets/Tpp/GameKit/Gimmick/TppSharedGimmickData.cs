using Fox.Core;
using Fox.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using Fox.Fio;
using Fox.GameKit;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Tpp.GameKit
{
    [ExecuteInEditMode]
    public partial class TppSharedGimmickData : Fox.Core.Data
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            // Mandatory
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

            // Optional
            GameObject modelFilePrefab = null;
            if (modelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(modelFile));
            }
            else
            {
                Fox.Fs.FileSystem.ImportAssetCopy(modelFile.path.String);
                modelFilePrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile.path.String);
            }

            // Optional
            GameObject breakedModelPrefab = null;
            if (breakedModelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(breakedModelFile));
            }
            else
            {
                Fox.Fs.FileSystem.ImportAssetCopy(breakedModelFile.path.String);
                breakedModelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(breakedModelFile.path.String);
            }
            
            foreach (LocatorEntry locator in locators)
            {
                GameObject locatorGameObject = new GameObject();
                if (locator.Name != null)
                    locatorGameObject.name = locator.Name;
                
                GameObject.Instantiate(partsPrefab, locatorGameObject.transform, false);
                
                locatorGameObject.transform.position = locator.Position;
                locatorGameObject.transform.rotation = locator.Rotation;
                locatorGameObject.transform.localScale = locator.Scale;
                locatorGameObject.transform.SetParent(gameObject.transform);
                
                // if (modelFilePrefab is not null)
                // {
                //     GameObject.Instantiate(modelFilePrefab, locatorGameObject.transform, false);
                //     
                //     if (breakedModelPrefab is not null)
                //     {
                //         GameObject.Instantiate(breakedModelPrefab, locatorGameObject.transform, false);
                //     }
                // }
            }
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            var dataSetName = Fox.Fs.FileSystem.GetFoxPathFromExternalPath(AssetDatabase.GetAssetOrScenePath(this));

            LocatorFileWriter.Write(locaterFile.path.String,gameObject,dataSetName,false);
        }
    }
}
