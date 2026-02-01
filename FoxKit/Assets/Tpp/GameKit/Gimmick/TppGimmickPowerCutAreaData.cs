using Fox.Core;
using Fox.Core.Utils;
using Fox.GameKit;
using UnityEditor;
using UnityEngine;
using File = System.IO.File;

namespace Tpp.GameKit
{
    [ExecuteAlways]
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

            for (uint i = 0; i < locators.Length; i++)
            {
                LocatorEntry locator = locators[i];

                GameObject locatorGameObject = new GameObject
                {
                    name = $"{gameObject.name}{i:0000}"
                };
                locatorGameObject.transform.position = locator.Position;
                locatorGameObject.transform.rotation = locator.Rotation;
                locatorGameObject.transform.SetParent(gameObject.transform);
            }
        }
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);
            
            LocatorFileWriter.Write(Fox.Fs.FileSystem.GetExternalPathFromFoxPath(locaterFile.path.String),gameObject,null,false);
        }

        private void OnDrawGizmos()
        {
            if (transform.childCount < 3)
                return;

            for (int i = 0; i < transform.childCount; i++)
            {
                UnityEngine.Transform current = transform.GetChild(i);
                UnityEngine.Transform next = transform.GetChild((i + 1) % transform.childCount);
        
                Gizmos.DrawLine(current.position, next.position);
            }
        }
    }
}
