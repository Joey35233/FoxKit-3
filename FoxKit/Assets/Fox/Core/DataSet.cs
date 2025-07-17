namespace Fox.Core
{
    public partial class DataSet : Fox.Core.Data
    {
        internal void ClearDataList()
        {
            dataList.Clear();
        }
        
        internal void AddData(Data data)
        {
            data.SetDataSet(this);
            if (dataList.ContainsKey(data.name))
                dataList[data.name] = data;
            else
                dataList.Insert(data.name, data);
        }
        
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);
            context.OverrideProperty(nameof(name), string.Empty);
        }
    }
}