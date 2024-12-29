namespace Fox.Core
{
    public partial class DataSet : Fox.Core.Data
    {
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);
            context.OverrideProperty("name", string.Empty);
        }
    }
}