//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CsSystem = System;
using Fox;

namespace Fox.GameService
{
    [UnityEditor.InitializeOnLoad]
    public partial class GsRouteDataRtEvPickUpHoneyBee : Fox.GameService.GsRouteDataRouteEvent 
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
        static GsRouteDataRtEvPickUpHoneyBee()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GsRouteDataRtEvPickUpHoneyBee"), typeof(GsRouteDataRtEvPickUpHoneyBee), new Fox.GameService.GsRouteDataRouteEvent().GetClassEntityInfo(), 0, null, 0);
        }

        // Constructors
		public GsRouteDataRtEvPickUpHoneyBee(ulong id) : base(id) { }
		public GsRouteDataRtEvPickUpHoneyBee() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
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