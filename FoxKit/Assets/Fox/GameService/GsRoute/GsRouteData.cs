using UnityEngine;

namespace Fox.GameService
{
    public partial class GsRouteData : Fox.Graphx.GraphxSpatialGraphData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);
            _ = gameObject.AddComponent<GsRouteDataGizmo>();
        }
    }
}