using Fox.Core.Utils;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    public partial class Data : Fox.Core.Entity
    {
        protected partial String Get_referencePath() => throw new System.NotImplementedException();

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            if (name != (String)null)
                gameObject.name = name.CString;

            base.OnDeserializeEntity(gameObject, logger);
        }

        public void SetDataSet(EntityHandle dataSet)
        {
            this.dataSet = dataSet;
        }
    }
}