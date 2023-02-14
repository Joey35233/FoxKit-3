﻿namespace Fox.GameService
{
    public partial class GsRouteDataEventAimPointNoTarget : GsRouteDataEventAimPoint
    {
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get;
            private set;
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo() => ClassInfo;
        static GsRouteDataEventAimPointNoTarget()
        {
            ClassInfo = new Fox.Core.EntityInfo(
                new Fox.Kernel.String("GsRouteDataEventAimPointNoTarget"),
                typeof(GsRouteDataEventAimPointNoTarget),
                new Fox.GameService.GsRouteDataEventAimPoint().GetClassEntityInfo(),
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
