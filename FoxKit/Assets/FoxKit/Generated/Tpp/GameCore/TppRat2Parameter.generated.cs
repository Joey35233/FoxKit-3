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
    [UnityEditor.InitializeOnLoad]
    public partial class TppRat2Parameter : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr partsFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr mtarFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.FilePtr> fovaFiles { get; set; } = new Fox.Core.DynamicArray<Fox.Core.FilePtr>();
        
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
        static TppRat2Parameter()
        {
            classInfo = new Fox.EntityInfo("TppRat2Parameter", typeof(TppRat2Parameter), new Fox.Core.DataElement().GetClassEntityInfo(), 96, null, 1);
			classInfo.StaticProperties.Insert("partsFile", new Fox.Core.PropertyInfo("partsFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mtarFile", new Fox.Core.PropertyInfo("mtarFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fovaFiles", new Fox.Core.PropertyInfo("fovaFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 112, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppRat2Parameter(ulong id) : base(id) { }
		public TppRat2Parameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "partsFile":
                    this.partsFile = value.GetValueAsFilePtr();
                    return;
                case "mtarFile":
                    this.mtarFile = value.GetValueAsFilePtr();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "fovaFiles":
                    while(this.fovaFiles.Count <= index) { this.fovaFiles.Add(default(Fox.Core.FilePtr)); }
                    this.fovaFiles[index] = value.GetValueAsFilePtr();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
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