namespace Fox.GameService
{
    public partial class GsRouteDataEventAimPointCharacter : GsRouteDataEventAimPoint
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String characterName
        {
            get; set;
        }

        public static new Fox.Core.EntityInfo ClassInfo
        {
            get;
            private set;
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo() => ClassInfo;
        static GsRouteDataEventAimPointCharacter()
        {
            ClassInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEventAimPointCharacter"),
                typeof(GsRouteDataEventAimPointCharacter),
                new Fox.GameService.GsRouteDataEventAimPoint().GetClassEntityInfo(),
                56,
                "Gs",
                0
            );
            ClassInfo.AddStaticProperty(
                new Fox.Core.PropertyInfo(
                    new Fox.Kernel.String("characterName"),
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
        }

        // Constructors
        public GsRouteDataEventAimPointCharacter(ulong id) : base(id) { }
        public GsRouteDataEventAimPointCharacter() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch (propertyName.CString)
            {
                case "characterName":
                    characterName = value.GetValueAsString();
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
