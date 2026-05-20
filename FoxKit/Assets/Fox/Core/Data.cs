using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    public partial class Data : Fox.Core.Entity
    {
        private partial string Get_referencePath() => throw new System.NotImplementedException();

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            if (!string.IsNullOrEmpty(name))
                gameObject.name = name;
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);
            
            // context.OverrideProperty(nameof(dataSet), context.DataSet)

            context.OverrideProperty(nameof(name), gameObject.name);
        }

        internal void SetDataSet(DataSet incomingDataSet)
        {
            this.dataSet = incomingDataSet;
        }
    }
}