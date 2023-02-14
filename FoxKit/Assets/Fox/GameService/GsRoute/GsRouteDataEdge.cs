using Fox.Core;

namespace Fox.GameService
{
    public class GsRouteDataEdge : Fox.Graphx.GraphxSpatialGraphDataEdge
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public EntityPtr<GsRouteDataEdgeEvent> edgeEvent
        {
            get; set;
        }

        public static new Fox.Core.EntityInfo ClassInfo
        {
            get;
            private set;
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo() => ClassInfo;
        static GsRouteDataEdge()
        {
            ClassInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEdge"),
                typeof(GsRouteDataEdge),
                new Fox.Graphx.GraphxSpatialGraphDataEdge().GetClassEntityInfo(),
                56,
                "Gs",
                0
            );
            ClassInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("edgeEvent"),
                    Fox.Core.PropertyInfo.PropertyType.EntityPtr,
                    72,
                    1,
                    Fox.Core.PropertyInfo.ContainerType.StaticArray,
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame,
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame,
                    typeof(GsRouteDataEdgeEvent),
                    null,
                    Fox.Core.PropertyInfo.PropertyStorage.Instance,
                    Fox.Core.PropertyInfo.BackingType.Field
                )
            );
        }

        // Constructors
        public GsRouteDataEdge(ulong id) : base(id) { }
        public GsRouteDataEdge() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch (propertyName.CString)
            {
                case "edgeEvent":
                    edgeEvent = value.GetValueAsEntityPtr<GsRouteDataEdgeEvent>();
                    return;
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