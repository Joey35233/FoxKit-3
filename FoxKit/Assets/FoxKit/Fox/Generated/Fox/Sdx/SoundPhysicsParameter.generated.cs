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

namespace Fox.Sdx
{
    public partial class SoundPhysicsParameter : Fox.Core.Data 
    {
        // Properties
        public string hitEvent;
        
        public string rollStartEvent;
        
        public string rollEndEvent;
        
        public string hitRtpcName;
        
        public string rollRtpcName;
        
        public string switchName;
        
        public string generalEvent1;
        
        public string generalEvent2;
        
        public float hitLowerPower;
        
        public float hitUpperPower;
        
        public float hitIntervalSeconds;
        
        public float hitLowerRtpc;
        
        public float hitUpperRtpc;
        
        public float rollLowerPower;
        
        public float rollUpperPower;
        
        public float rollStartSeconds;
        
        public float rollEndSeconds;
        
        public float rollLowerRtpc;
        
        public float rollUpperRtpc;
        
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
        static SoundPhysicsParameter()
        {
            classInfo = new Fox.EntityInfo("SoundPhysicsParameter", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 140, "Sound", 1);
			
			classInfo.StaticProperties.Insert("hitEvent", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollStartEvent", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollEndEvent", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hitRtpcName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollRtpcName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("switchName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("generalEvent1", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("generalEvent2", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hitLowerPower", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hitUpperPower", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hitIntervalSeconds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hitLowerRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hitUpperRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollLowerPower", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollUpperPower", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollStartSeconds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollEndSeconds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollLowerRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rollUpperRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SoundPhysicsParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "hitEvent":
                    this.hitEvent = value.GetValueAsString();
                    return;
                case "rollStartEvent":
                    this.rollStartEvent = value.GetValueAsString();
                    return;
                case "rollEndEvent":
                    this.rollEndEvent = value.GetValueAsString();
                    return;
                case "hitRtpcName":
                    this.hitRtpcName = value.GetValueAsString();
                    return;
                case "rollRtpcName":
                    this.rollRtpcName = value.GetValueAsString();
                    return;
                case "switchName":
                    this.switchName = value.GetValueAsString();
                    return;
                case "generalEvent1":
                    this.generalEvent1 = value.GetValueAsString();
                    return;
                case "generalEvent2":
                    this.generalEvent2 = value.GetValueAsString();
                    return;
                case "hitLowerPower":
                    this.hitLowerPower = value.GetValueAsFloat();
                    return;
                case "hitUpperPower":
                    this.hitUpperPower = value.GetValueAsFloat();
                    return;
                case "hitIntervalSeconds":
                    this.hitIntervalSeconds = value.GetValueAsFloat();
                    return;
                case "hitLowerRtpc":
                    this.hitLowerRtpc = value.GetValueAsFloat();
                    return;
                case "hitUpperRtpc":
                    this.hitUpperRtpc = value.GetValueAsFloat();
                    return;
                case "rollLowerPower":
                    this.rollLowerPower = value.GetValueAsFloat();
                    return;
                case "rollUpperPower":
                    this.rollUpperPower = value.GetValueAsFloat();
                    return;
                case "rollStartSeconds":
                    this.rollStartSeconds = value.GetValueAsFloat();
                    return;
                case "rollEndSeconds":
                    this.rollEndSeconds = value.GetValueAsFloat();
                    return;
                case "rollLowerRtpc":
                    this.rollLowerRtpc = value.GetValueAsFloat();
                    return;
                case "rollUpperRtpc":
                    this.rollUpperRtpc = value.GetValueAsFloat();
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