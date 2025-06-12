﻿using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppBushManager
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            cameraPos = Fox.Math.FoxToUnityVector3(cameraPos);
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(cameraPos), Fox.Math.UnityToFoxVector3(cameraPos));
        }
    }
}
