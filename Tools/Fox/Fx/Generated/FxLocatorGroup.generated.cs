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

namespace Fox.Fx
{
    [UnityEditor.InitializeOnLoad]
    public partial class FxLocatorGroup : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String groupInstanceName { get; set; }
        
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
        static FxLocatorGroup()
        {
            classInfo = new Fox.Core.EntityInfo("FxLocatorGroup", typeof(FxLocatorGroup), new Fox.Core.TransformData().GetClassEntityInfo(), 272, "Fx", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("groupInstanceName", Fox.Core.PropertyInfo.PropertyType.String, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public FxLocatorGroup(ulong id) : base(id) { }
		public FxLocatorGroup() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "groupInstanceName":
                    this.groupInstanceName = value.GetValueAsString();
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