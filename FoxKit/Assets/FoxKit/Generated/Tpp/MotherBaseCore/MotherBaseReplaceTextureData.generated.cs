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

namespace Tpp.MotherBaseCore
{
    [UnityEditor.InitializeOnLoad]
    public partial class MotherBaseReplaceTextureData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<ulong> pathCodes { get; set; } = new Fox.Core.DynamicArray<ulong>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<int> flags { get; set; } = new Fox.Core.StringMap<int>();
        
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
        static MotherBaseReplaceTextureData()
        {
            classInfo = new Fox.EntityInfo("MotherBaseReplaceTextureData", typeof(MotherBaseReplaceTextureData), new Fox.Core.Data().GetClassEntityInfo(), 128, "TppMotherBase", 0);
			classInfo.StaticProperties.Insert("pathCodes", new Fox.Core.PropertyInfo("pathCodes", Fox.Core.PropertyInfo.PropertyType.UInt64, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("flags", new Fox.Core.PropertyInfo("flags", Fox.Core.PropertyInfo.PropertyType.Int32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public MotherBaseReplaceTextureData(ulong id) : base(id) { }
		public MotherBaseReplaceTextureData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "pathCodes":
                    while(this.pathCodes.Count <= index) { this.pathCodes.Add(default(ulong)); }
                    this.pathCodes[index] = value.GetValueAsUInt64();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "flags":
                    this.flags.Insert(key, value.GetValueAsInt32());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}