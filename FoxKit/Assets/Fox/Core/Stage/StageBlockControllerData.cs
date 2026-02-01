using System;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    [ExecuteAlways]
    public partial class StageBlockControllerData
    {
        public static StageBlockControllerData Instance;

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            if (!this.enable)
            {
                this.gameObject.SetActive(false);
            }
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(enable), isActiveAndEnabled);
        }

        private void OnEnable()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            Instance = null;
        }
    }
}