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

namespace Fox.Geox
{
    [UnityEditor.InitializeOnLoad]
    public partial class GeoxPath2 : Fox.Graphx.GraphxPathData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public int selectIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool enable { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.String> tags { get; set; } = new Fox.Core.DynamicArray<Fox.Core.String>();
        
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
        static GeoxPath2()
        {
            classInfo = new Fox.EntityInfo("GeoxPath2", typeof(GeoxPath2), new Fox.Graphx.GraphxPathData().GetClassEntityInfo(), 320, "Geox", 1);
			classInfo.StaticProperties.Insert("selectIndex", new Fox.Core.PropertyInfo("selectIndex", Fox.Core.PropertyInfo.PropertyType.Int32, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("tags", new Fox.Core.PropertyInfo("tags", Fox.Core.PropertyInfo.PropertyType.String, 344, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxPath2(ulong id) : base(id) { }
		public GeoxPath2() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "selectIndex":
                    this.selectIndex = value.GetValueAsInt32();
                    return;
                case "enable":
                    this.enable = value.GetValueAsBool();
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
                case "tags":
                    while(this.tags.Count <= index) { this.tags.Add(default(Fox.Core.String)); }
                    this.tags[index] = value.GetValueAsString();
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
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}