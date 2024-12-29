using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    public partial class Data : Fox.Core.Entity
    {
        private partial string Get_referencePath() => throw new System.NotImplementedException();

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            if (!string.IsNullOrEmpty(name))
                gameObject.name = name;

            base.OnDeserializeEntity(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(name), gameObject.name);
        }
    }
}