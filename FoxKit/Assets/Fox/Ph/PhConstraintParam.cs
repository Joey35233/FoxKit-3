﻿using Fox.Core;
using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhConstraintParam : Fox.Core.Entity
    {
        internal UnityEngine.Vector3 GetDefaultPosition() => defaultPosition;
        internal void SetDefaultPosition(UnityEngine.Vector3 value) => defaultPosition = value;

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            defaultPosition = Fox.Math.FoxToUnityVector3(defaultPosition);

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            context.OverrideProperty("defaultPosition", Fox.Math.UnityToFoxVector3(defaultPosition));

            base.OverridePropertiesForExport(context);
        }

        public virtual void DrawGizmos()
        {

        }
    }
}
