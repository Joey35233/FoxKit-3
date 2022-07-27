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
    [UnityEditor.InitializeOnLoad]
    public partial class ModelDescription : Fox.PartsBuilder.PartDescription 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr modelFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr connectPointFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr gameRigFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr helpBoneFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr lipAdjustBinaryFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr facialSettingFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> invisibleMeshNames { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        public float lodFarPixelSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lodNearPixelSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lodPolygonSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public ModelDescription_DrawRejectionLevel drawRejectionLevel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public ModelDescription_RejectFarRangeShadowCast rejectFarRangeShadowCast { get; set; }
        
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
        static ModelDescription()
        {
            classInfo = new Fox.Core.EntityInfo("ModelDescription", typeof(ModelDescription), new Fox.PartsBuilder.PartDescription().GetClassEntityInfo(), 288, "PartsBuilder", 12);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectPointFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("gameRigFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("helpBoneFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lipAdjustBinaryFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("facialSettingFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("invisibleMeshNames", Fox.Core.PropertyInfo.PropertyType.String, 296, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodFarPixelSize", Fox.Core.PropertyInfo.PropertyType.Float, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodNearPixelSize", Fox.Core.PropertyInfo.PropertyType.Float, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodPolygonSize", Fox.Core.PropertyInfo.PropertyType.Float, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("drawRejectionLevel", Fox.Core.PropertyInfo.PropertyType.Int32, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(ModelDescription_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rejectFarRangeShadowCast", Fox.Core.PropertyInfo.PropertyType.Int32, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(ModelDescription_RejectFarRangeShadowCast), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public ModelDescription(ulong id) : base(id) { }
		public ModelDescription() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "modelFile":
                    this.modelFile = value.GetValueAsFilePtr();
                    return;
                case "connectPointFile":
                    this.connectPointFile = value.GetValueAsFilePtr();
                    return;
                case "gameRigFile":
                    this.gameRigFile = value.GetValueAsFilePtr();
                    return;
                case "helpBoneFile":
                    this.helpBoneFile = value.GetValueAsFilePtr();
                    return;
                case "lipAdjustBinaryFile":
                    this.lipAdjustBinaryFile = value.GetValueAsFilePtr();
                    return;
                case "facialSettingFile":
                    this.facialSettingFile = value.GetValueAsFilePtr();
                    return;
                case "lodFarPixelSize":
                    this.lodFarPixelSize = value.GetValueAsFloat();
                    return;
                case "lodNearPixelSize":
                    this.lodNearPixelSize = value.GetValueAsFloat();
                    return;
                case "lodPolygonSize":
                    this.lodPolygonSize = value.GetValueAsFloat();
                    return;
                case "drawRejectionLevel":
                    this.drawRejectionLevel = (ModelDescription_DrawRejectionLevel)value.GetValueAsInt32();
                    return;
                case "rejectFarRangeShadowCast":
                    this.rejectFarRangeShadowCast = (ModelDescription_RejectFarRangeShadowCast)value.GetValueAsInt32();
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
                case "invisibleMeshNames":
                    while(this.invisibleMeshNames.Count <= index) { this.invisibleMeshNames.Add(default(Fox.Kernel.String)); }
                    this.invisibleMeshNames[index] = value.GetValueAsString();
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