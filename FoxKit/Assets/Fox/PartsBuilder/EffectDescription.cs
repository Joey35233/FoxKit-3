using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using CsSystem = System;

namespace Fox.PartsBuilder
{
    public partial class EffectDescription
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < offsetSkelPositions.Count; i++)
                offsetSkelPositions[i] = Fox.Math.FoxToUnityVector3(offsetSkelPositions[i]);

            for (int i = 0; i < offsetCnpPositions.Count; i++)
                offsetCnpPositions[i] = Fox.Math.FoxToUnityVector3(offsetCnpPositions[i]);

            //rlc TODO generalSkelParameters and generalCnpParameters
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            CsSystem.Collections.Generic.List<Vector3> _offsetSkelPositions = offsetSkelPositions;
            for (int i = 0; i < _offsetSkelPositions.Count; i++)
                _offsetSkelPositions[i] = Fox.Math.UnityToFoxVector3(_offsetSkelPositions[i]);
            context.OverrideProperty(nameof(offsetSkelPositions), _offsetSkelPositions);

            CsSystem.Collections.Generic.List<Vector3> _offsetCnpPositions = offsetCnpPositions;
            for (int i = 0; i < _offsetCnpPositions.Count; i++)
                _offsetCnpPositions[i] = Fox.Math.UnityToFoxVector3(_offsetCnpPositions[i]);
            context.OverrideProperty(nameof(offsetCnpPositions), _offsetCnpPositions);

            //rlc TODO generalSkelParameters and generalCnpParameters
        }
    }
}
