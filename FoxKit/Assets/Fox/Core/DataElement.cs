using Fox.Core.Utils;
using System;

namespace Fox.Core
{
    public partial class DataElement : Fox.Core.Entity
    {
        public void SetOwner(Data entity)
        {
            owner = EntityHandle.Get(entity);

            this.transform.SetParent(entity.transform);
        }

        public override void InitializeGameObject(UnityEngine.GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);

            if (this.owner.Entity == null)
            {
                this.gameObject.SetActive(false);
            }
        }

        // protected void Awake()
        // {
        //     Data parentData = this.transform.parent.gameObject.GetComponent<Data>();
        //     if (parentData is null)
        //         throw new InvalidCastException($"Parent of DataElement {this} must be Data. Is {this.transform.parent.gameObject}");
        //
        //     SetOwner(parentData);
        // }
    }
}