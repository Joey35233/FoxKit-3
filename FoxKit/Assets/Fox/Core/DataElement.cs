using Fox.Core.Utils;
using System;

namespace Fox.Core
{
    public partial class DataElement : Fox.Core.Entity
    {
        public void SetOwner(Data entity)
        {
            owner = entity;

            this.transform.SetParent(entity.transform);
        }

        public override void OnDeserializeEntity(UnityEngine.GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            if (this.owner == null)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}