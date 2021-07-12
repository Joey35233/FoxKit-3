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

namespace Fox.Tactical
{
    public partial class GkTacticalAction : Fox.Core.TransformData 
    {
        // Properties
        public bool enable;
        
        public bool enableInGame;
        
        public Fox.String worldName;
        
        public Fox.Core.EntityLink userData;
        
        public Fox.String userId;
        
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionWaypoint>> waypoints = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionWaypoint>>();
        
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionEdge>> edges = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionEdge>>();
        
        public Fox.Core.DynamicArray<Fox.String> attributeNames = new Fox.Core.DynamicArray<Fox.String>();
        
        public uint attribute;
        
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
        static GkTacticalAction()
        {
            classInfo = new Fox.EntityInfo("GkTacticalAction", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 368, "TacticalAction", 7);
			
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enableInGame", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("worldName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("userData", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("userId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("waypoints", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 368, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Tactical.GkTacticalActionWaypoint), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("edges", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 384, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Tactical.GkTacticalActionEdge), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("attributeNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 400, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("attribute", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GkTacticalAction(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "enableInGame":
                    this.enableInGame = value.GetValueAsBool();
                    return;
                case "worldName":
                    this.worldName = value.GetValueAsString();
                    return;
                case "userData":
                    this.userData = value.GetValueAsEntityLink();
                    return;
                case "userId":
                    this.userId = value.GetValueAsString();
                    return;
                case "attribute":
                    this.attribute = value.GetValueAsUInt32();
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
                case "waypoints":
                    while(this.waypoints.Count <= index) { this.waypoints.Add(default(Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionWaypoint>)); }
                    this.waypoints[index] = value.GetValueAsEntityPtr<Fox.Tactical.GkTacticalActionWaypoint>();
                    return;
                case "edges":
                    while(this.edges.Count <= index) { this.edges.Add(default(Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionEdge>)); }
                    this.edges[index] = value.GetValueAsEntityPtr<Fox.Tactical.GkTacticalActionEdge>();
                    return;
                case "attributeNames":
                    while(this.attributeNames.Count <= index) { this.attributeNames.Add(default(Fox.String)); }
                    this.attributeNames[index] = value.GetValueAsString();
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