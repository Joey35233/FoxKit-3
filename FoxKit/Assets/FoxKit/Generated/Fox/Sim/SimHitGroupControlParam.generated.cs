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

namespace Fox.Sim
{
    [UnityEditor.InitializeOnLoad]
    public partial class SimHitGroupControlParam : Fox.Sim.SimControlParam 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected uint groupIndex { get; set; }
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static SimHitGroupControlParam()
        {
            classInfo = new Fox.EntityInfo("SimHitGroupControlParam", typeof(SimHitGroupControlParam), new Fox.Sim.SimControlParam().GetClassEntityInfo(), 28, "Sim", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("groupIndex", Fox.Core.PropertyInfo.PropertyType.UInt32, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public SimHitGroupControlParam(ulong id) : base(id) { }
		public SimHitGroupControlParam() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "groupIndex":
                    this.groupIndex = value.GetValueAsUInt32();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}