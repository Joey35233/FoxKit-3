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
    [UnityEditor.InitializeOnLoad]
    public partial class SimOnPhysics : Fox.Sim.SimObject 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simRootBones { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simBones { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simTransBones { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>> simHitBones { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnit>>();
        
        [field: UnityEngine.SerializeField]
        public uint formatVersion { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink physicsData { get; set; }
        
        public SimLodLevelName minLodLevel { get => Get_minLodLevel(); set { Set_minLodLevel(value); } }
        protected partial SimLodLevelName Get_minLodLevel();
        protected partial void Set_minLodLevel(SimLodLevelName value);
        
        public SimLodLevelName maxLodLevel { get => Get_maxLodLevel(); set { Set_maxLodLevel(value); } }
        protected partial SimLodLevelName Get_maxLodLevel();
        protected partial void Set_maxLodLevel(SimLodLevelName value);
        
        public bool isEnableGeoCheck { get => Get_isEnableGeoCheck(); set { Set_isEnableGeoCheck(value); } }
        protected partial bool Get_isEnableGeoCheck();
        protected partial void Set_isEnableGeoCheck(bool value);
        
        public bool convertMoveToWind { get => Get_convertMoveToWind(); set { Set_convertMoveToWind(value); } }
        protected partial bool Get_convertMoveToWind();
        protected partial void Set_convertMoveToWind(bool value);
        
        // PropertyInfo
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
        static SimOnPhysics()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SimOnPhysics"), typeof(SimOnPhysics), new Fox.Sim.SimObject().GetClassEntityInfo(), 328, "Sim", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simRootBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simTransBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 248, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simHitBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 296, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("formatVersion"), Fox.Core.PropertyInfo.PropertyType.UInt32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("physicsData"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("minLodLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SimLodLevelName), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxLodLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SimLodLevelName), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isEnableGeoCheck"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("convertMoveToWind"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public SimOnPhysics(ulong id) : base(id) { }
		public SimOnPhysics() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
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
                case "simRootBones":
                    this.simRootBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                case "simBones":
                    this.simBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                case "simTransBones":
                    this.simTransBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                case "simHitBones":
                    this.simHitBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}