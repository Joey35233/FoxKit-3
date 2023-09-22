using Fox.Core.Utils;

namespace Fox.Core
{
    public partial class DataElement : Fox.Core.Entity
    {
        public void SetOwner(Data entity) => owner = EntityHandle.Get(entity);

        public override void InitializeGameObject(UnityEngine.GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);

            if (this.owner.Entity == null)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}