using System;
using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
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
                Fox.Fs.FileSystem.TryCopyImportAsset(modelFile.path.String);
            }
            
            // foreach (Matrix4x4 foxTransform in transforms)
            // {
            //     Matrix4x4 transform = Fox.Math.FoxToUnityMatrix(foxTransform);
            //     
            //     GameObject instance = GameObject.Instantiate(asset, gameObject.transform, false);
            //     Matrix4x4 unityTransform = Fox.Math.FoxToUnityMatrix(transform);
            //     instance.transform.position = unityTransform.GetPosition();
            //     //instance.transform.rotation = unityTransform.rotation;
            //     //instance.transform.position = Fox.Math.FoxToUnityVector3(transform.GetPosition());
            //     instance.transform.rotation = Fox.Math.FoxToUnityQuaternion(transform.rotation);
            //     instance.transform.localScale = transform.lossyScale;
            // }
            
            // TODO: HACK
            ReloadFile(logger);
        }

        private GameObject ModelHandle;

        private List<GameObject> Instances;

        private void CreateModel(GameObject model, Matrix4x4 matrix)
        {
            matrix = Fox.Math.FoxToUnityMatrix(matrix);
            
            Vector3 position = matrix.GetColumn(3);
            Quaternion rotation = Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));
            Vector3 scale = new Vector3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);

            GameObject instance = GameObject.Instantiate(model, position, rotation);
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.transform.localScale = scale;
            instance.transform.SetParent(this.transform);
            instance.hideFlags = HideFlags.DontSaveInEditor;
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
                ModelHandle = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile.path.String);
                if (ModelHandle)
                    foreach (Matrix4x4 matrix in transforms)
                        CreateModel(ModelHandle, matrix);
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
