namespace Fox.Core
{
    public partial class DataElement : Fox.Core.Entity
    {
        public void SetOwner(Data entity) => owner = EntityHandle.Get(entity);

        public override void InitializeGameObject(UnityEngine.GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);

            if (this.owner.Entity == null)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}