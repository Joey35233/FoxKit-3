﻿using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhActionParam
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            defaultPosition = Fox.Math.FoxToUnityVector3(defaultPosition);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(defaultPosition), Fox.Math.UnityToFoxVector3(defaultPosition));
        }
    }
}
