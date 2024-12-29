namespace Fox.Core
{
    public partial class DataSet : Fox.Core.Data
    {
        internal void AddData(Data data)
        {
            data.SetDataSet(this);
            dataList.InsertOrUpdate(data.name, data);
        }
        
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);
            context.OverrideProperty("name", string.Empty);
        }
    }
}