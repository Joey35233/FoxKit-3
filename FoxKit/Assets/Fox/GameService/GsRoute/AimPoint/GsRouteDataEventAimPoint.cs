namespace Fox.GameService
{
    public enum GsRouteDataEventAimPointType : byte
    {
        ROUTE_AIM_NO_TARGET = 0,
        ROUTE_AIM_STATIC_POINT = 1,
        ROUTE_AIM_CHARACTER = 2,
        ROUTE_AIM_ROUTE_AS_SIGHT_MOVE_PATH = 3,
        ROUTE_AIM_ROUTE_AS_OBJECT = 4,
    }

    public partial class GsRouteDataEventAimPoint : Fox.Core.DataElement
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
        static GsRouteDataEventAimPoint()
        {
            classInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEventAimPoint"),
                typeof(GsRouteDataEventAimPoint),
                new Fox.Graphx.GraphxSpatialGraphDataEdge().GetClassEntityInfo(),
                56,
                "Gs",
                0
            );
        }

        // Constructors
        public GsRouteDataEventAimPoint(ulong id) : base(id) { }
        public GsRouteDataEventAimPoint() : base() { }

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
