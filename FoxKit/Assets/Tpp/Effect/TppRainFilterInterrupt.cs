﻿using Fox.Core;
using Fox.Core.Utils;
using Fox.Kernel;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppRainFilterInterrupt
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < planeMatrices.Count; i++)
            {
                planeMatrices[i] = Fox.Kernel.Math.FoxToUnityMatrix(planeMatrices[i]);
            }
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            var convertedMatrices = new DynamicArray<Matrix4x4>(planeMatrices);
            for (int i = 0; i < convertedMatrices.Count; i++)
            {
                convertedMatrices[i] = Fox.Kernel.Math.UnityToFoxMatrix(convertedMatrices[i]);
            }

            context.OverrideProperty(nameof(planeMatrices), convertedMatrices);
        }

        public void OnDrawGizmos()
        {
            foreach (Matrix4x4 mat in planeMatrices)
            {
                Gizmos.matrix = transform.localToWorldMatrix * mat;

                Gizmos.DrawCube(Vector3.zero, new Vector3(1, 0, 1));
            }
        }
    }
}