using CsSystem = System;
using Fox;
using Fox.Graphx;
using System;

namespace Fox.GameService
{
    public partial class GsRouteDataEvent : Fox.Core.DataElement
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String id { get; set; }
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityPtr<GsRouteDataEventAimPoint> aimPoint { get; set; }
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StaticArray<uint> extensions { get; set; } = new Fox.Kernel.StaticArray<uint>(4);
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
        static GsRouteDataEvent()
        {
            classInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEvent"), 
                typeof(GsRouteDataEvent), 
                new Fox.Core.DataElement().GetClassEntityInfo(), 
                80,
                "Gs", 
                0
            );
            classInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("id"), 
                    Fox.Core.PropertyInfo.PropertyType.String, 
                    64, 
                    1,
                    Fox.Core.PropertyInfo.ContainerType.StaticArray, 
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, 
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, 
                    null, 
                    null, 
                    Fox.Core.PropertyInfo.PropertyStorage.Instance, 
                    Fox.Core.PropertyInfo.BackingType.Field
                )
            );
            classInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("aimPoint"), 
                    Fox.Core.PropertyInfo.PropertyType.EntityPtr, 
                    80, 
                    1, 
                    Fox.Core.PropertyInfo.ContainerType.StaticArray, 
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, 
                    Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, 
                    typeof(GsRouteDataEventAimPoint), 
                    null, 
                    Fox.Core.PropertyInfo.PropertyStorage.Instance, 
                    Fox.Core.PropertyInfo.BackingType.Field
                )
            );
            classInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("extensions"),
                    Fox.Core.PropertyInfo.PropertyType.UInt32,
                    64,
                    4, //count?
                    Fox.Core.PropertyInfo.ContainerType.StaticArray,
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
        public GsRouteDataEvent(ulong id) : base(id) { }
        public GsRouteDataEvent() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch (propertyName.CString)
            {
                case "id":
                    this.id = value.GetValueAsString();
                    return;
                case "aimPoint":
                    this.aimPoint = value.GetValueAsEntityPtr<GsRouteDataEventAimPoint>();
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
                case "extensions":
                    this.extensions[index] = value.GetValueAsUInt32();
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
