using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Tpp.GameCore
{
    public partial class TppBirdLocatorParameter2
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            for (int i = 0; i < grounds.Count; i++)
                grounds[i] = Fox.Math.FoxToUnityVector3(grounds[i]);

            for (int i = 0; i < perchPoints.Count; i++)
                perchPoints[i] = Fox.Math.FoxToUnityVector3(perchPoints[i]);
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            List<Vector3> _grounds = new(grounds);
            for (int i = 0; i < _grounds.Count; i++)
                _grounds[i] = Fox.Math.UnityToFoxVector3(_grounds[i]);
            context.OverrideProperty(nameof(grounds), _grounds);

            List<Vector3> _perchPoints = new(perchPoints);
            for (int i = 0; i < _perchPoints.Count; i++)
                _perchPoints[i] = Fox.Math.UnityToFoxVector3(_perchPoints[i]);
            context.OverrideProperty(nameof(perchPoints), _perchPoints);
        }
    }
}
