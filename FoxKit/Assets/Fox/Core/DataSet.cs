namespace Fox.Core
{
    public partial class DataSet : Fox.Core.Data
    {
        public void AddData(Kernel.String key, EntityPtr<Data> data) => this.dataList.Insert(key, data);
    }
}