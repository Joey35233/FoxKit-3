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

namespace Fox.PartsBuilder
{
    public partial class GeomDescription : Fox.PartsBuilder.PartDescription 
    {
        // Properties
        public Fox.Core.FilePtr<Fox.Core.File> geomFile;
        
        public Fox.String skeletonName;
        
        public UnityEngine.Vector3 offsetScale;
        
        public UnityEngine.Quaternion offsetRotQuat;
        
        public UnityEngine.Vector3 offsetTranslation;
        
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
        static GeomDescription()
        {
            classInfo = new Fox.EntityInfo("GeomDescription", new Fox.PartsBuilder.PartDescription(0, 0, 0).GetClassEntityInfo(), 176, "PartsBuilder", 3);
			
			classInfo.StaticProperties.Insert("geomFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("skeletonName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("offsetScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("offsetRotQuat", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("offsetTranslation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeomDescription(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "geomFile":
                    this.geomFile = value.GetValueAsFilePtr();
                    return;
                case "skeletonName":
                    this.skeletonName = value.GetValueAsString();
                    return;
                case "offsetScale":
                    this.offsetScale = value.GetValueAsVector3();
                    return;
                case "offsetRotQuat":
                    this.offsetRotQuat = value.GetValueAsQuat();
                    return;
                case "offsetTranslation":
                    this.offsetTranslation = value.GetValueAsVector3();
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