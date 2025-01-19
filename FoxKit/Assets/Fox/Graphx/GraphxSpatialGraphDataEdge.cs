using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataEdge
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);
            if (prevNode is not null)
                transform.parent = prevNode.transform;
        }
    }
}