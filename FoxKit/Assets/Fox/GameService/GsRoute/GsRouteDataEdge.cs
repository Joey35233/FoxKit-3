using Fox.Core;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fox.GameService
{
    public class GsRouteDataEdge : Fox.Graphx.GraphxSpatialGraphDataEdge
    {
        [field: UnityEngine.SerializeField]
        public EntityPtr<GsRouteDataEdgeEvent> edgeEvent { get; set; }

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
        static GsRouteDataEdge()
        {
            classInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEdge"), 
                typeof(GsRouteDataEdge), 
                new Fox.Graphx.GraphxSpatialGraphDataEdge().GetClassEntityInfo(), 
                56,
                "Gs", 
                0
            );
            classInfo.AddStaticProperty(
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
            switch(propertyName.CString)
            {
                case "edgeEvent":
                    this.edgeEvent = value.GetValueAsEntityPtr<GsRouteDataEdgeEvent>();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}