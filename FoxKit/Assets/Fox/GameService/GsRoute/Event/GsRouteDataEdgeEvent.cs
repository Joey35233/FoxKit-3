namespace Fox.GameService
{
    public partial class GsRouteDataEdgeEvent : GsRouteDataEvent
    {
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get;
            private set;
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo() => ClassInfo;
        static GsRouteDataEdgeEvent()
        {
            ClassInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEdgeEvent"),
                typeof(GsRouteDataEdgeEvent),
                new Fox.GameService.GsRouteDataEvent().GetClassEntityInfo(),
                56,
                "Gs",
                0
            );
        }

        // Constructors
        public GsRouteDataEdgeEvent(ulong id) : base(id) { }
        public GsRouteDataEdgeEvent() : base() { }

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
