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
            this.transform.SetLocalPositionAndRotation(UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity);
        }

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

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

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

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