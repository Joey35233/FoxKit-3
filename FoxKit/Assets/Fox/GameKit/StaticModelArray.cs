using System;
using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class StaticModelArray : Data
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            if (modelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(modelFile));
                return;
            }
            else
            {
                Fox.Fs.FileSystem.ImportAssetCopy(modelFile.path.String);
            }

            for (int i = 0; i < transforms.Count; i++)
                transforms[i] = Fox.Math.FoxToUnityMatrix(transforms[i]);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            List<Matrix4x4> foxTransforms = new List<Matrix4x4>();
            for (int i = 0; i < foxTransforms.Count; i++)
                foxTransforms[i] = Fox.Math.UnityToFoxMatrix(transforms[i]);
            context.OverrideListProperty(nameof(transforms), foxTransforms);
        }

        private GameObject ModelPrefab;

        private List<GameObject> Instances;

        private void CreateModel(GameObject model, Matrix4x4 matrix)
        {
            Vector3 position = matrix.GetColumn(3);
            Quaternion rotation = Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));
            Vector3 scale = new Vector3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);
            
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(model, gameObject.transform);
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.transform.localPosition = position;
            instance.transform.localRotation = rotation;
            instance.transform.localScale = scale;
            instance.hideFlags = HideFlags.DontSaveInEditor;
            instance.AddComponent<StaticModelArrayInstance>();
        }
        
        public void ReloadFile(TaskLogger logger = null)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                if (child.GetComponent<Entity>() != null)
                    continue;
                DestroyImmediate(child.gameObject);
            }

            if (modelFile != FilePtr.Empty)
            {
                ModelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile.path.String);
                if (ModelPrefab)
                    foreach (Matrix4x4 matrix in transforms)
                        CreateModel(ModelPrefab, matrix);
                else
                    Debug.Log($"Could not find: {modelFile}");
            }
        }

        private void OnEnable()
        {
            ReloadFile();
        }
        
        public override void Reset()
        {
            base.Reset();
            lodFarSize = -1;
            lodNearSize = -1;
            lodPolygonSize = -1;
            drawRejectionLevel = StaticModelArray_DrawRejectionLevel.DEFAULT;
            rejectFarRangeShadowCast = StaticModelArray_RejectFarRangeShadowCast.DEFAULT;
            //TODO: colors[i]=uint.MaxValue; //encoded Color.white
        }
    }
}
