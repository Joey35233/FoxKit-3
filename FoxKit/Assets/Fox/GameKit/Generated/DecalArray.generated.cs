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

namespace Fox.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class DecalArray : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink material { get; set; }
        
        [field: UnityEngine.SerializeField]
        public DecalArray_ProjectionMode projectionMode { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float nearClipScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public DecalArray_ProjectionTarget projectionTarget { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float repeatU { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float repeatV { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float transparency { get; set; }
        
        [field: UnityEngine.SerializeField]
        public DecalArray_PolygonDataSource polygonDataSource { get; set; }
        
        [field: UnityEngine.SerializeField]
        public DecalArray_DrawRejectionLevel drawRejectionLevel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float drawRejectionDegree { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint decalFlags { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<UnityEngine.Vector3> scales { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<UnityEngine.Quaternion> rotations { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Quaternion>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<UnityEngine.Vector3> translations { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> targets { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> targetIndices { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> targetStartIndices { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<int> renderingPriorities { get; set; } = new Fox.Kernel.DynamicArray<int>();
        
        public bool isDisableAlbedo { get => Get_isDisableAlbedo(); set { Set_isDisableAlbedo(value); } }
        protected partial bool Get_isDisableAlbedo();
        protected partial void Set_isDisableAlbedo(bool value);
        
        public bool isPreserveAspect { get => Get_isPreserveAspect(); set { Set_isPreserveAspect(value); } }
        protected partial bool Get_isPreserveAspect();
        protected partial void Set_isPreserveAspect(bool value);
        
        public bool isWrap { get => Get_isWrap(); set { Set_isWrap(value); } }
        protected partial bool Get_isWrap();
        protected partial void Set_isWrap(bool value);
        
        public bool showObject { get => Get_showObject(); set { Set_showObject(value); } }
        protected partial bool Get_showObject();
        protected partial void Set_showObject(bool value);
        
        public bool isVisibleGeom { get => Get_isVisibleGeom(); set { Set_isVisibleGeom(value); } }
        protected partial bool Get_isVisibleGeom();
        protected partial void Set_isVisibleGeom(bool value);
        
        public bool isSSDecal { get => Get_isSSDecal(); set { Set_isSSDecal(value); } }
        protected partial bool Get_isSSDecal();
        protected partial void Set_isSSDecal(bool value);
        
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
        static DecalArray()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("DecalArray"), typeof(DecalArray), new Fox.Core.TransformData().GetClassEntityInfo(), 448, "Decal", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("material"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("projectionMode"), Fox.Core.PropertyInfo.PropertyType.Int32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_ProjectionMode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("nearClipScale"), Fox.Core.PropertyInfo.PropertyType.Float, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("projectionTarget"), Fox.Core.PropertyInfo.PropertyType.Int32, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_ProjectionTarget), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("repeatU"), Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("repeatV"), Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("transparency"), Fox.Core.PropertyInfo.PropertyType.Float, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("polygonDataSource"), Fox.Core.PropertyInfo.PropertyType.Int32, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_PolygonDataSource), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("drawRejectionLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("drawRejectionDegree"), Fox.Core.PropertyInfo.PropertyType.Float, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("decalFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 380, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("scales"), Fox.Core.PropertyInfo.PropertyType.Vector3, 384, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotations"), Fox.Core.PropertyInfo.PropertyType.Quat, 400, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("translations"), Fox.Core.PropertyInfo.PropertyType.Vector3, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targets"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 432, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targetIndices"), Fox.Core.PropertyInfo.PropertyType.UInt32, 448, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targetStartIndices"), Fox.Core.PropertyInfo.PropertyType.UInt32, 464, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("renderingPriorities"), Fox.Core.PropertyInfo.PropertyType.Int32, 480, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDisableAlbedo"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isPreserveAspect"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isWrap"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showObject"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isVisibleGeom"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isSSDecal"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public DecalArray(ulong id) : base(id) { }
		public DecalArray() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "material":
                    this.material = value.GetValueAsEntityLink();
                    return;
                case "projectionMode":
                    this.projectionMode = (DecalArray_ProjectionMode)value.GetValueAsInt32();
                    return;
                case "nearClipScale":
                    this.nearClipScale = value.GetValueAsFloat();
                    return;
                case "projectionTarget":
                    this.projectionTarget = (DecalArray_ProjectionTarget)value.GetValueAsInt32();
                    return;
                case "repeatU":
                    this.repeatU = value.GetValueAsFloat();
                    return;
                case "repeatV":
                    this.repeatV = value.GetValueAsFloat();
                    return;
                case "transparency":
                    this.transparency = value.GetValueAsFloat();
                    return;
                case "polygonDataSource":
                    this.polygonDataSource = (DecalArray_PolygonDataSource)value.GetValueAsInt32();
                    return;
                case "drawRejectionLevel":
                    this.drawRejectionLevel = (DecalArray_DrawRejectionLevel)value.GetValueAsInt32();
                    return;
                case "drawRejectionDegree":
                    this.drawRejectionDegree = value.GetValueAsFloat();
                    return;
                case "decalFlags":
                    this.decalFlags = value.GetValueAsUInt32();
                    return;
                case "isDisableAlbedo":
                    this.isDisableAlbedo = value.GetValueAsBool();
                    return;
                case "isPreserveAspect":
                    this.isPreserveAspect = value.GetValueAsBool();
                    return;
                case "isWrap":
                    this.isWrap = value.GetValueAsBool();
                    return;
                case "showObject":
                    this.showObject = value.GetValueAsBool();
                    return;
                case "isVisibleGeom":
                    this.isVisibleGeom = value.GetValueAsBool();
                    return;
                case "isSSDecal":
                    this.isSSDecal = value.GetValueAsBool();
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
                case "scales":
                    while(this.scales.Count <= index) { this.scales.Add(default(UnityEngine.Vector3)); }
                    this.scales[index] = value.GetValueAsVector3();
                    return;
                case "rotations":
                    while(this.rotations.Count <= index) { this.rotations.Add(default(UnityEngine.Quaternion)); }
                    this.rotations[index] = value.GetValueAsQuat();
                    return;
                case "translations":
                    while(this.translations.Count <= index) { this.translations.Add(default(UnityEngine.Vector3)); }
                    this.translations[index] = value.GetValueAsVector3();
                    return;
                case "targets":
                    while(this.targets.Count <= index) { this.targets.Add(default(Fox.Core.EntityLink)); }
                    this.targets[index] = value.GetValueAsEntityLink();
                    return;
                case "targetIndices":
                    while(this.targetIndices.Count <= index) { this.targetIndices.Add(default(uint)); }
                    this.targetIndices[index] = value.GetValueAsUInt32();
                    return;
                case "targetStartIndices":
                    while(this.targetStartIndices.Count <= index) { this.targetStartIndices.Add(default(uint)); }
                    this.targetStartIndices[index] = value.GetValueAsUInt32();
                    return;
                case "renderingPriorities":
                    while(this.renderingPriorities.Count <= index) { this.renderingPriorities.Add(default(int)); }
                    this.renderingPriorities[index] = value.GetValueAsInt32();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}