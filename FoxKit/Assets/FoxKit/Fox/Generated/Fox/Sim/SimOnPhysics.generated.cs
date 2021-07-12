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

namespace Fox.Sim
{
    public partial class SimOnPhysics : Fox.Sim.SimObject 
    {
        // Properties
        public Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simRootBones = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        public Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simBones = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        public Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simTransBones = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        public Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simHitBones = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        public uint formatVersion;
        
        public Fox.Core.EntityLink physicsData;
        
        public SimLodLevelName minLodLevel;
        
        public SimLodLevelName maxLodLevel;
        
        public bool isEnableGeoCheck;
        
        public bool convertMoveToWind;
        
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
        static SimOnPhysics()
        {
            classInfo = new Fox.EntityInfo("SimOnPhysics", new Fox.Sim.SimObject(0, 0, 0).GetClassEntityInfo(), 328, "Sim", 2);
			
			classInfo.StaticProperties.Insert("simRootBones", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("simBones", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("simTransBones", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 248, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("simHitBones", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 296, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("formatVersion", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("physicsData", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("minLodLevel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SimLodLevelName), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maxLodLevel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SimLodLevelName), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isEnableGeoCheck", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("convertMoveToWind", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SimOnPhysics(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "formatVersion":
                    this.formatVersion = value.GetValueAsUInt32();
                    return;
                case "physicsData":
                    this.physicsData = value.GetValueAsEntityLink();
                    return;
                case "minLodLevel":
                    this.minLodLevel = (SimLodLevelName)value.GetValueAsInt32();
                    return;
                case "maxLodLevel":
                    this.maxLodLevel = (SimLodLevelName)value.GetValueAsInt32();
                    return;
                case "isEnableGeoCheck":
                    this.isEnableGeoCheck = value.GetValueAsBool();
                    return;
                case "convertMoveToWind":
                    this.convertMoveToWind = value.GetValueAsBool();
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
                case "simRootBones":
                    this.simRootBones.Add(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                case "simBones":
                    this.simBones.Add(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                case "simTransBones":
                    this.simTransBones.Add(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                case "simHitBones":
                    this.simHitBones.Add(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}