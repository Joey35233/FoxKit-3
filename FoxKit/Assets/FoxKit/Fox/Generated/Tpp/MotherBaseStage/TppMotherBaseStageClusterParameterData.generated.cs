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

namespace Tpp.MotherBaseStage
{
    public partial class TppMotherBaseStageClusterParameterData : Fox.Core.Data 
    {
        // Properties
        public bool enable;
        
        public Fox.Core.StaticArray<byte> cluster00divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<byte> cluster01divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<byte> cluster02divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<byte> cluster03divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<byte> cluster04divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<byte> cluster05divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<byte> cluster06divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<byte> cluster07divisionPackageIds = new Fox.Core.StaticArray<byte>(12);
        
        public Fox.Core.StaticArray<UnityEngine.Vector3> clusterPositions = new Fox.Core.StaticArray<UnityEngine.Vector3>(8);
        
        public Fox.Core.StaticArray<uint> clusterRequestRadiuses = new Fox.Core.StaticArray<uint>(8);
        
        public Fox.Core.StaticArray<uint> clusterRequireRadiuses = new Fox.Core.StaticArray<uint>(8);
        
        public Fox.Core.DynamicArray<short> cluster00loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
        public Fox.Core.DynamicArray<short> cluster01loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
        public Fox.Core.DynamicArray<short> cluster02loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
        public Fox.Core.DynamicArray<short> cluster03loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
        public Fox.Core.DynamicArray<short> cluster04loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
        public Fox.Core.DynamicArray<short> cluster05loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
        public Fox.Core.DynamicArray<short> cluster06loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
        public Fox.Core.DynamicArray<short> cluster07loadAreaVertices = new Fox.Core.DynamicArray<short>();
        
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
        static TppMotherBaseStageClusterParameterData()
        {
            classInfo = new Fox.EntityInfo("TppMotherBaseStageClusterParameterData", new Fox.Core.Data().GetClassEntityInfo(), 496, null, 3);
			
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 544, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster00divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 120, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster01divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 132, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster02divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 144, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster03divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 156, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster04divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 168, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster05divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 180, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster06divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 192, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster07divisionPackageIds", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 204, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("clusterPositions", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 224, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("clusterRequestRadiuses", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 352, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("clusterRequireRadiuses", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 384, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster00loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster01loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 432, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster02loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 448, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster03loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 464, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster04loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 480, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster05loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 496, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster06loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 512, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cluster07loadAreaVertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int16, 528, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppMotherBaseStageClusterParameterData(ulong address, ulong id) : base(address, id) { }
		public TppMotherBaseStageClusterParameterData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
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
                case "cluster00divisionPackageIds":
                    
                    this.cluster00divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "cluster01divisionPackageIds":
                    
                    this.cluster01divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "cluster02divisionPackageIds":
                    
                    this.cluster02divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "cluster03divisionPackageIds":
                    
                    this.cluster03divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "cluster04divisionPackageIds":
                    
                    this.cluster04divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "cluster05divisionPackageIds":
                    
                    this.cluster05divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "cluster06divisionPackageIds":
                    
                    this.cluster06divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "cluster07divisionPackageIds":
                    
                    this.cluster07divisionPackageIds[index] = value.GetValueAsUInt8();
                    return;
                case "clusterPositions":
                    
                    this.clusterPositions[index] = value.GetValueAsVector3();
                    return;
                case "clusterRequestRadiuses":
                    
                    this.clusterRequestRadiuses[index] = value.GetValueAsUInt32();
                    return;
                case "clusterRequireRadiuses":
                    
                    this.clusterRequireRadiuses[index] = value.GetValueAsUInt32();
                    return;
                case "cluster00loadAreaVertices":
                    while(this.cluster00loadAreaVertices.Count <= index) { this.cluster00loadAreaVertices.Add(default(short)); }
                    this.cluster00loadAreaVertices[index] = value.GetValueAsInt16();
                    return;
                case "cluster01loadAreaVertices":
                    while(this.cluster01loadAreaVertices.Count <= index) { this.cluster01loadAreaVertices.Add(default(short)); }
                    this.cluster01loadAreaVertices[index] = value.GetValueAsInt16();
                    return;
                case "cluster02loadAreaVertices":
                    while(this.cluster02loadAreaVertices.Count <= index) { this.cluster02loadAreaVertices.Add(default(short)); }
                    this.cluster02loadAreaVertices[index] = value.GetValueAsInt16();
                    return;
                case "cluster03loadAreaVertices":
                    while(this.cluster03loadAreaVertices.Count <= index) { this.cluster03loadAreaVertices.Add(default(short)); }
                    this.cluster03loadAreaVertices[index] = value.GetValueAsInt16();
                    return;
                case "cluster04loadAreaVertices":
                    while(this.cluster04loadAreaVertices.Count <= index) { this.cluster04loadAreaVertices.Add(default(short)); }
                    this.cluster04loadAreaVertices[index] = value.GetValueAsInt16();
                    return;
                case "cluster05loadAreaVertices":
                    while(this.cluster05loadAreaVertices.Count <= index) { this.cluster05loadAreaVertices.Add(default(short)); }
                    this.cluster05loadAreaVertices[index] = value.GetValueAsInt16();
                    return;
                case "cluster06loadAreaVertices":
                    while(this.cluster06loadAreaVertices.Count <= index) { this.cluster06loadAreaVertices.Add(default(short)); }
                    this.cluster06loadAreaVertices[index] = value.GetValueAsInt16();
                    return;
                case "cluster07loadAreaVertices":
                    while(this.cluster07loadAreaVertices.Count <= index) { this.cluster07loadAreaVertices.Add(default(short)); }
                    this.cluster07loadAreaVertices[index] = value.GetValueAsInt16();
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