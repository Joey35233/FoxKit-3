using System.Collections.Generic;

using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxSpatialGraphDataNode
    {
        public List<Fox.Core.Entity> Inlinks => inlinks;
        public List<Fox.Core.Entity> Outlinks => outlinks;
        public UnityEngine.Vector3 Position { get => position; set => position = value; }

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            position = Fox.Math.FoxToUnityVector3(position);

            transform.localPosition = position;
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(position), Fox.Math.UnityToFoxVector3(transform.localPosition));
        }
    }
}