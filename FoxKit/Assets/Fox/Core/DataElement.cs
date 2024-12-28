using Fox.Core.Utils;
using System;
using UnityEngine;

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

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            // TODO: Ownerless DataElements
            Entity ownerData = transform.parent.GetComponent<Data>();
            if (ownerData == null)
            {
                Debug.Log($"{this.name} in {this.gameObject.scene} has no direct parent.");
                return;
            }
            context.OverrideProperty(nameof(owner), ownerData);
        }
    }
}