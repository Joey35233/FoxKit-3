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

namespace Tpp.GameCore
{
    public partial class TppParasite2Parameter : Fox.Core.DataElement 
    {
        // Properties
        public Fox.Core.FilePtr<Fox.Core.File> partsFile;
        
        public Fox.Core.FilePtr<Fox.Core.File> motionGraphFile;
        
        public Fox.Core.FilePtr<Fox.Core.File> mtarFile;
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> partsFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> vfxFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> fmdlFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> geomFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> fovaFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
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
        static TppParasite2Parameter()
        {
            classInfo = new Fox.EntityInfo("TppParasite2Parameter", new Fox.Core.DataElement(0, 0, 0).GetClassEntityInfo(), 344, null, 3);
			
			classInfo.StaticProperties.Insert("partsFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("motionGraphFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mtarFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("partsFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 176, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fmdlFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("geomFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 272, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fovaFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 320, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppParasite2Parameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "partsFile":
                    this.partsFile = value.GetValueAsFilePtr();
                    return;
                case "motionGraphFile":
                    this.motionGraphFile = value.GetValueAsFilePtr();
                    return;
                case "mtarFile":
                    this.mtarFile = value.GetValueAsFilePtr();
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
                case "partsFiles":
                    this.partsFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "vfxFiles":
                    this.vfxFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "fmdlFiles":
                    this.fmdlFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "geomFiles":
                    this.geomFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                case "fovaFiles":
                    this.fovaFiles.Add(key, value.GetValueAsFilePtr());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}