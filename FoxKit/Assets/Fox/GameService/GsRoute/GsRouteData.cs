using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteData : Fox.Graphx.GraphxSpatialGraphData
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);
            _ = gameObject.AddComponent<GsRouteDataGizmo>();
        }
    }
}