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

namespace Tpp.Sound
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppSoundWorld : Fox.Core.Data 
    {
        // Properties
        public uint updateSeconds;
        
        public float startMorning;
        
        public float midMorning;
        
        public float endMorning;
        
        public float startEvening;
        
        public float midEvening;
        
        public float endEvening;
        
        public Fox.String situationEvent;
        
        public Fox.String clockRtpc;
        
        public Fox.String windVelocityRtpc;
        
        public Fox.String windDirectionRtpc;
        
        public Fox.String rainRtpc;
        
        public Fox.String heightRtpc;
        
        public Fox.Core.StaticArray<Fox.Core.EntityLink> ambientParameter = new Fox.Core.StaticArray<Fox.Core.EntityLink>(8);
        
        public Fox.String categoryFpvStateGroup;
        
        public Fox.String categoryFpvStateValue;
        
        public Fox.String dashStartEventName;
        
        public Fox.String dashFinishEventName;
        
        public float blockedObstruction;
        
        public float blockedOcclusion;
        
        public float unlinkedObstruction;
        
        public float unlinkedOcclusion;
        
        public float interferenceSlope;
        
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
        static TppSoundWorld()
        {
            classInfo = new Fox.EntityInfo("TppSoundWorld", typeof(TppSoundWorld), new Fox.Core.Data().GetClassEntityInfo(), 408, "Sound", 8);
			classInfo.StaticProperties.Insert("updateSeconds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("startMorning", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("midMorning", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("endMorning", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("startEvening", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("midEvening", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("endEvening", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("situationEvent", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("clockRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windVelocityRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("windDirectionRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rainRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("heightRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("ambientParameter", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 216, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("categoryFpvStateGroup", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 536, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("categoryFpvStateValue", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 544, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("dashStartEventName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 552, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("dashFinishEventName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 560, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockedObstruction", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockedOcclusion", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("unlinkedObstruction", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("unlinkedOcclusion", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("interferenceSlope", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppSoundWorld(ulong id) : base(id) { }
		public TppSoundWorld() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "updateSeconds":
                    this.updateSeconds = value.GetValueAsUInt32();
                    return;
                case "startMorning":
                    this.startMorning = value.GetValueAsFloat();
                    return;
                case "midMorning":
                    this.midMorning = value.GetValueAsFloat();
                    return;
                case "endMorning":
                    this.endMorning = value.GetValueAsFloat();
                    return;
                case "startEvening":
                    this.startEvening = value.GetValueAsFloat();
                    return;
                case "midEvening":
                    this.midEvening = value.GetValueAsFloat();
                    return;
                case "endEvening":
                    this.endEvening = value.GetValueAsFloat();
                    return;
                case "situationEvent":
                    this.situationEvent = value.GetValueAsString();
                    return;
                case "clockRtpc":
                    this.clockRtpc = value.GetValueAsString();
                    return;
                case "windVelocityRtpc":
                    this.windVelocityRtpc = value.GetValueAsString();
                    return;
                case "windDirectionRtpc":
                    this.windDirectionRtpc = value.GetValueAsString();
                    return;
                case "rainRtpc":
                    this.rainRtpc = value.GetValueAsString();
                    return;
                case "heightRtpc":
                    this.heightRtpc = value.GetValueAsString();
                    return;
                case "categoryFpvStateGroup":
                    this.categoryFpvStateGroup = value.GetValueAsString();
                    return;
                case "categoryFpvStateValue":
                    this.categoryFpvStateValue = value.GetValueAsString();
                    return;
                case "dashStartEventName":
                    this.dashStartEventName = value.GetValueAsString();
                    return;
                case "dashFinishEventName":
                    this.dashFinishEventName = value.GetValueAsString();
                    return;
                case "blockedObstruction":
                    this.blockedObstruction = value.GetValueAsFloat();
                    return;
                case "blockedOcclusion":
                    this.blockedOcclusion = value.GetValueAsFloat();
                    return;
                case "unlinkedObstruction":
                    this.unlinkedObstruction = value.GetValueAsFloat();
                    return;
                case "unlinkedOcclusion":
                    this.unlinkedOcclusion = value.GetValueAsFloat();
                    return;
                case "interferenceSlope":
                    this.interferenceSlope = value.GetValueAsFloat();
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
                case "ambientParameter":
                    
                    this.ambientParameter[index] = value.GetValueAsEntityLink();
                    return;
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