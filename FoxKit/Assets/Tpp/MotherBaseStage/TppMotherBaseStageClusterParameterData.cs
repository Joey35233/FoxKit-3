using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.MotherBaseStage
{
    public partial class TppMotherBaseStageClusterParameterData
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < clusterPositions.Length; i++)
                clusterPositions[i] = Fox.Math.FoxToUnityVector3(clusterPositions[i]);
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            Vector3[] _clusterPositions = clusterPositions;
            for (int i = 0; i < clusterPositions.Length; i++)
                _clusterPositions[i] = Fox.Math.UnityToFoxVector3(clusterPositions[i]);

            context.OverrideProperty(nameof(clusterPositions), _clusterPositions);
        }
    }
}
