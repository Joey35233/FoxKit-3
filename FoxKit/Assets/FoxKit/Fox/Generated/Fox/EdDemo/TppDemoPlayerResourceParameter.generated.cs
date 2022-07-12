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

namespace Fox.EdDemo
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppDemoPlayerResourceParameter : Fox.Demo.DemoParameter 
    {
        // Properties
        public Fox.String playerInstanceName;
        
        public Fox.String partsFile;
        
        public Fox.String handFv2File;
        
        public Fox.String headFv2File;
        
        public Fox.String camoFv2File;
        
        public bool needReload;
        
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
        static TppDemoPlayerResourceParameter()
        {
            classInfo = new Fox.EntityInfo("TppDemoPlayerResourceParameter", typeof(TppDemoPlayerResourceParameter), new Fox.Demo.DemoParameter().GetClassEntityInfo(), 0, null, 0);
			classInfo.StaticProperties.Insert("playerInstanceName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("partsFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("handFv2File", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("headFv2File", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("camoFv2File", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("needReload", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppDemoPlayerResourceParameter(ulong id) : base(id) { }
		public TppDemoPlayerResourceParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "playerInstanceName":
                    this.playerInstanceName = value.GetValueAsString();
                    return;
                case "partsFile":
                    this.partsFile = value.GetValueAsString();
                    return;
                case "handFv2File":
                    this.handFv2File = value.GetValueAsString();
                    return;
                case "headFv2File":
                    this.headFv2File = value.GetValueAsString();
                    return;
                case "camoFv2File":
                    this.camoFv2File = value.GetValueAsString();
                    return;
                case "needReload":
                    this.needReload = value.GetValueAsBool();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
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