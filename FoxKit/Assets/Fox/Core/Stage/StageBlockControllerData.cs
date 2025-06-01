using System;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    [ExecuteAlways]
    public partial class StageBlockControllerData
    {
        public static StageBlockControllerData Instance;

        public override void OnDeserializeEntity(UnityEngine.GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            if (!this.enable)
            {
                this.gameObject.SetActive(false);
            }
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(enable), isActiveAndEnabled);
        }

        private void OnEnable()
        {
            Instance = this;
        }
    }
}