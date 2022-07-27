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

namespace Tpp.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppObjectBrushPluginSkeletonModel : Fox.GameKit.ObjectBrushPlugin 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.FilePtr> modelFile { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.FilePtr> geomFile { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.Path> animFile { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.Path>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.Path> animWindyFile { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.Path>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr mtarFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String soundSeType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float minSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float maxSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isGeomActivity { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float thinkOutRate { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float extensionRadius { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint reserveResourcePlugin { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint reserveResourcePerBlock { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StaticArray<float> lodLength { get; set; } = new Fox.Kernel.StaticArray<float>(4);
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StaticArray<float> lodLengthForHighEnd { get; set; } = new Fox.Kernel.StaticArray<float>(4);
        
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
        static TppObjectBrushPluginSkeletonModel()
        {
            classInfo = new Fox.Core.EntityInfo("TppObjectBrushPluginSkeletonModel", typeof(TppObjectBrushPluginSkeletonModel), new Fox.GameKit.ObjectBrushPlugin().GetClassEntityInfo(), 248, null, 7);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("geomFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 160, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("animFile", Fox.Core.PropertyInfo.PropertyType.Path, 176, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("animWindyFile", Fox.Core.PropertyInfo.PropertyType.Path, 192, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mtarFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("soundSeType", Fox.Core.PropertyInfo.PropertyType.String, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("minSize", Fox.Core.PropertyInfo.PropertyType.Float, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxSize", Fox.Core.PropertyInfo.PropertyType.Float, 260, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isGeomActivity", Fox.Core.PropertyInfo.PropertyType.Bool, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("thinkOutRate", Fox.Core.PropertyInfo.PropertyType.Float, 268, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("extensionRadius", Fox.Core.PropertyInfo.PropertyType.Float, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reserveResourcePlugin", Fox.Core.PropertyInfo.PropertyType.UInt32, 276, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reserveResourcePerBlock", Fox.Core.PropertyInfo.PropertyType.UInt32, 280, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodLength", Fox.Core.PropertyInfo.PropertyType.Float, 284, 4, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodLengthForHighEnd", Fox.Core.PropertyInfo.PropertyType.Float, 300, 4, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppObjectBrushPluginSkeletonModel(ulong id) : base(id) { }
		public TppObjectBrushPluginSkeletonModel() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "mtarFile":
                    this.mtarFile = value.GetValueAsFilePtr();
                    return;
                case "soundSeType":
                    this.soundSeType = value.GetValueAsString();
                    return;
                case "minSize":
                    this.minSize = value.GetValueAsFloat();
                    return;
                case "maxSize":
                    this.maxSize = value.GetValueAsFloat();
                    return;
                case "isGeomActivity":
                    this.isGeomActivity = value.GetValueAsBool();
                    return;
                case "thinkOutRate":
                    this.thinkOutRate = value.GetValueAsFloat();
                    return;
                case "extensionRadius":
                    this.extensionRadius = value.GetValueAsFloat();
                    return;
                case "reserveResourcePlugin":
                    this.reserveResourcePlugin = value.GetValueAsUInt32();
                    return;
                case "reserveResourcePerBlock":
                    this.reserveResourcePerBlock = value.GetValueAsUInt32();
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
                case "modelFile":
                    while(this.modelFile.Count <= index) { this.modelFile.Add(default(Fox.Core.FilePtr)); }
                    this.modelFile[index] = value.GetValueAsFilePtr();
                    return;
                case "geomFile":
                    while(this.geomFile.Count <= index) { this.geomFile.Add(default(Fox.Core.FilePtr)); }
                    this.geomFile[index] = value.GetValueAsFilePtr();
                    return;
                case "animFile":
                    while(this.animFile.Count <= index) { this.animFile.Add(default(Fox.Kernel.Path)); }
                    this.animFile[index] = value.GetValueAsPath();
                    return;
                case "animWindyFile":
                    while(this.animWindyFile.Count <= index) { this.animWindyFile.Add(default(Fox.Kernel.Path)); }
                    this.animWindyFile[index] = value.GetValueAsPath();
                    return;
                case "lodLength":
                    
                    this.lodLength[index] = value.GetValueAsFloat();
                    return;
                case "lodLengthForHighEnd":
                    
                    this.lodLengthForHighEnd[index] = value.GetValueAsFloat();
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