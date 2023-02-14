namespace Fox.GameService
{
    public partial class GsRouteDataNodeEvent : GsRouteDataEvent
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool isLoop
        {
            get; set;
        }

        [field: UnityEngine.SerializeField]
        public float time
        {
            get; set;
        }

        [field: UnityEngine.SerializeField]
        public float dir
        {
            get; set;
        }

        public static new Fox.Core.EntityInfo ClassInfo
        {
            get;
            private set;
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo() => ClassInfo;
        static GsRouteDataNodeEvent()
        {
            ClassInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataNodeEvent"),
                typeof(GsRouteDataNodeEvent),
                new Fox.GameService.GsRouteDataEvent().GetClassEntityInfo(),
                56,
                "Gs",
                0
            );
            ClassInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("isLoop"),
                    Fox.Core.PropertyInfo.PropertyType.Bool,
                    84,
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
            ClassInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("time"),
                    Fox.Core.PropertyInfo.PropertyType.Float,
                    88,
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
            ClassInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("dir"),
                    Fox.Core.PropertyInfo.PropertyType.Float,
                    92,
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
        }

        // Constructors
        public GsRouteDataNodeEvent(ulong id) : base(id) { }
        public GsRouteDataNodeEvent() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch (propertyName.CString)
            {
                case "isLoop":
                    isLoop = value.GetValueAsBool();
                    return;
                case "time":
                    time = value.GetValueAsFloat();
                    return;
                case "dir":
                    dir = value.GetValueAsFloat();
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
