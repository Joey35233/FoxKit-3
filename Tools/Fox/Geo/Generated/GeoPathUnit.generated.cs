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

namespace Fox.Geo
{
    [UnityEditor.InitializeOnLoad]
    public partial class GeoPathUnit : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<byte> tags { get; set; } = new Fox.Kernel.StringMap<byte>();
        
        // ClassInfos
        public static new bool ClassInfoInitialized = false;
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
        static GeoPathUnit()
        {
            if (Fox.Core.TransformData.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GeoPathUnit"), typeof(GeoPathUnit), Fox.Core.TransformData.ClassInfo, 0, "Path", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("tags"), Fox.Core.PropertyInfo.PropertyType.UInt8, 304, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public GeoPathUnit(ulong id) : base(id) { }
		public GeoPathUnit() : base() { }
        
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
                case "tags":
                    this.tags.Insert(key, value.GetValueAsUInt8());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}