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

namespace Fox.Ui
{
    [UnityEditor.InitializeOnLoad]
    public partial class UiInstanceData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> createWindowParams = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.String windowFactoryName;
        
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
        static UiInstanceData()
        {
            classInfo = new Fox.EntityInfo("UiInstanceData", typeof(UiInstanceData), new Fox.Core.Data().GetClassEntityInfo(), 120, "Ui", 1);
			classInfo.StaticProperties.Insert("createWindowParams", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windowFactoryName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public UiInstanceData(ulong id) : base(id) { }
		public UiInstanceData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "windowFactoryName":
                    this.windowFactoryName = value.GetValueAsString();
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
                case "createWindowParams":
                    this.createWindowParams.Insert(key, value.GetValueAsFilePtr());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}