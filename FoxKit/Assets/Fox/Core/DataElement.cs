using Fox.Core.Utils;
using System;

namespace Fox.Core
{
    public partial class DataElement : Fox.Core.Entity
    {
        public void SetOwner(Data entity)
        {
            this.transform.SetParent(entity.transform);
        }

        public override void OnDeserializeEntity(UnityEngine.GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            if (this.owner is not { } owner )
            {
                this.gameObject.SetActive(false);
            }
            else if (owner is not Data data)
            {
                logger.AddError("Invalid DataElement owner.");
            }
            else
            {
                this.SetOwner(data);
            }
        }
    }
}