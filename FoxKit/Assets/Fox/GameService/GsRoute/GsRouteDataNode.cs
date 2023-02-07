using Fox.Core;
namespace Fox.GameService
{
    public class GsRouteDataNode : Fox.Graphx.GraphxSpatialGraphDataNode
    {
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<EntityPtr<GsRouteDataNodeEvent>> nodeEvents { get; set; } = new Fox.Kernel.DynamicArray<EntityPtr<GsRouteDataNodeEvent>>();
        
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
        static GsRouteDataNode()
        {
            classInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataNode"), 
                typeof(GsRouteDataNode), 
                new Fox.Graphx.GraphxSpatialGraphDataNode().GetClassEntityInfo(), 
                96,
                "Gs", 
                0
            );
            classInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("nodeEvents"),
                    Fox.Core.PropertyInfo.PropertyType.EntityPtr,
                    112,
                    1,
                    Fox.Core.PropertyInfo.ContainerType.DynamicArray,
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame,
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame,
                    typeof(GsRouteDataNodeEvent),
                    null,
                    Fox.Core.PropertyInfo.PropertyStorage.Instance,
                    Fox.Core.PropertyInfo.BackingType.Field
                )
            );
        }

        // Constructors
        public GsRouteDataNode(ulong id) : base(id) { }
        public GsRouteDataNode() : base() { }

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
                case "nodeEvents":
                    while (this.nodeEvents.Count <= index) { this.nodeEvents.Add(default(EntityPtr<GsRouteDataNodeEvent>)); }
                    this.nodeEvents[index] = value.GetValueAsEntityPtr<GsRouteDataNodeEvent>();
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
