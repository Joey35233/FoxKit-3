using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using CsSystem = System;

namespace Tpp.GameCore
{
    public partial class TppBirdLocatorParameter2
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < grounds.Count; i++)
                grounds[i] = Fox.Math.FoxToUnityVector3(grounds[i]);

            for (int i = 0; i < perchPoints.Count; i++)
                perchPoints[i] = Fox.Math.FoxToUnityVector3(perchPoints[i]);
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            CsSystem.Collections.Generic.List<Vector3> _grounds
                = grounds;
            for (int i = 0; i < grounds.Count; i++)
                _grounds[i] = Fox.Math.UnityToFoxVector3(grounds[i]);
            context.OverrideProperty(nameof(grounds), _grounds);

            CsSystem.Collections.Generic.List<Vector3> _perchPoints
                = perchPoints;
            for (int i = 0; i < perchPoints.Count; i++)
                _perchPoints[i] = Fox.Math.UnityToFoxVector3(perchPoints[i]);
            context.OverrideProperty(nameof(perchPoints), _perchPoints);
        }
    }
}
