namespace Fox.GameService
{
    public partial class GsRouteDataEventAimPointNoTarget : GsRouteDataEventAimPoint
    {
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static GsRouteDataEventAimPointNoTarget()
        {
            classInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEventAimPointNoTarget"),
                typeof(GsRouteDataEventAimPointNoTarget),
                new Fox.Graphx.GraphxSpatialGraphDataEdge().GetClassEntityInfo(),
                56,
                "Gs",
                0
            );
        }

        // Constructors
        public GsRouteDataEventAimPointNoTarget(ulong id) : base(id) { }
        public GsRouteDataEventAimPointNoTarget() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch (propertyName.CString)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }

        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch (propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }

        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch (propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}
