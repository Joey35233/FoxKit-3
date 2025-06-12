using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Fox.Geox
{
    public partial class GeoxTargetDesc
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            for (int i = 0; i < posArray.Count; i++)
                posArray[i] = Fox.Math.FoxToUnityVector3(posArray[i]);

            for (int i = 0; i < rotArray.Count; i++)
                rotArray[i] = Fox.Math.FoxToUnityQuaternion(rotArray[i]);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            List<Vector3> _posArray = new(posArray);
            for (int i = 0; i < _posArray.Count; i++)
                _posArray[i] = Fox.Math.UnityToFoxVector3(_posArray[i]);
            context.OverrideProperty(nameof(posArray), _posArray);

            List<Quaternion> _rotArray = new(rotArray);
            for (int i = 0; i < _rotArray.Count; i++)
                _rotArray[i] = Fox.Math.UnityToFoxQuaternion(_rotArray[i]);
            context.OverrideProperty(nameof(rotArray), _rotArray);
        }
    }
}
