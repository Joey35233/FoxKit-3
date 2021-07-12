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

namespace Fox.GameKit
{
    public partial class GkEventTimerData : Fox.Core.Data 
    {
        // Properties
        public double measureTime;
        
        public Fox.String startMessageName;
        
        public Fox.String interruptMessageName;
        
        public Fox.String alarmMessageName;
        
        public bool enableDebugView;
        
        public float debugViewPositionX;
        
        public float debugViewPositionY;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static GkEventTimerData()
        {
            classInfo = new Fox.EntityInfo("GkEventTimerData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("measureTime", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Double, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("startMessageName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("interruptMessageName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("alarmMessageName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enableDebugView", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("debugViewPositionX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("debugViewPositionY", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GkEventTimerData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "measureTime":
                    this.measureTime = value.GetValueAsDouble();
                    return;
                case "startMessageName":
                    this.startMessageName = value.GetValueAsString();
                    return;
                case "interruptMessageName":
                    this.interruptMessageName = value.GetValueAsString();
                    return;
                case "alarmMessageName":
                    this.alarmMessageName = value.GetValueAsString();
                    return;
                case "enableDebugView":
                    this.enableDebugView = value.GetValueAsBool();
                    return;
                case "debugViewPositionX":
                    this.debugViewPositionX = value.GetValueAsFloat();
                    return;
                case "debugViewPositionY":
                    this.debugViewPositionY = value.GetValueAsFloat();
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