namespace Fox.GameService
{
    public partial class GsRouteDataEventAimPointRouteAsSightMovePath : GsRouteDataEventAimPoint
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StaticArray<Fox.Kernel.String> routeNames { get; set; } = new Fox.Kernel.StaticArray<Fox.Kernel.String>(4);

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
        static GsRouteDataEventAimPointRouteAsSightMovePath()
        {
            classInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEventAimPointRouteAsSightMovePath"),
                typeof(GsRouteDataEventAimPointRouteAsSightMovePath),
                new Fox.Graphx.GraphxSpatialGraphDataEdge().GetClassEntityInfo(),
                56,
                "Gs",
                0
            );
            classInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("routeNames"),
                    Fox.Core.PropertyInfo.PropertyType.String,
                    64,
                    4,
                    Fox.Core.PropertyInfo.ContainerType.DynamicArray,
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame,
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame,
                    null,
                    null,
                    Fox.Core.PropertyInfo.PropertyStorage.Instance,
                    Fox.Core.PropertyInfo.BackingType.Field
                )
            );
        }

        // Constructors
        public GsRouteDataEventAimPointRouteAsSightMovePath(ulong id) : base(id) { }
        public GsRouteDataEventAimPointRouteAsSightMovePath() : base() { }

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
                case "routeNames":
                    while (this.routeNames.Count <= index) { this.routeNames.Add(default(Fox.Kernel.String)); }
                    this.routeNames[index] = value.GetValueAsString();
                    return;
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
