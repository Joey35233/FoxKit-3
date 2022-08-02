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
    public partial class TppHeli2Parameter : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> partsFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> fmdlFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> fcnpFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> gsklFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> vfxFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> fovaFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr mtarFile { get; set; }
        
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
        static TppHeli2Parameter()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppHeli2Parameter"), typeof(TppHeli2Parameter), new Fox.Core.DataElement().GetClassEntityInfo(), 344, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fmdlFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 104, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fcnpFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("gsklFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 248, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fovaFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 296, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("mtarFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppHeli2Parameter(ulong id) : base(id) { }
		public TppHeli2Parameter() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "mtarFile":
                    this.mtarFile = value.GetValueAsFilePtr();
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
                case "partsFiles":
                    this.partsFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "fmdlFiles":
                    this.fmdlFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "fcnpFiles":
                    this.fcnpFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "gsklFiles":
                    this.gsklFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "vfxFiles":
                    this.vfxFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "fovaFiles":
                    this.fovaFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}