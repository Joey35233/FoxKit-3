namespace Fox.Core
{
    public partial class DataElement : Fox.Core.Entity
    {
        public void SetOwner(Data entity) => owner = EntityHandle.Get(entity);
    }
}