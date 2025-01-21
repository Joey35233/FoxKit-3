﻿using System;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Graphx
{
    public partial class GraphxPathVolume
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            topPos = Fox.Math.FoxToUnityVector3(topPos);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(topPos), Fox.Math.UnityToFoxVector3(topPos));
        }
        public override Type GetNodeType() => typeof(GraphxSpatialGraphDataNode);
    }
}
