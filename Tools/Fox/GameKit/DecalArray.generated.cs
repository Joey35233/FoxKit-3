//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.GameKit
{
    public partial class DecalArray : Fox.Core.TransformData 
    {
        // Properties
        public EntityLink material { get; set; }
        
        public DecalArray_ProjectionMode projectionMode { get; set; }
        
        public float nearClipScale { get; set; }
        
        public DecalArray_ProjectionTarget projectionTarget { get; set; }
        
        public float repeatU { get; set; }
        
        public float repeatV { get; set; }
        
        public float transparency { get; set; }
        
        public DecalArray_PolygonDataSource polygonDataSource { get; set; }
        
        public DecalArray_DrawRejectionLevel drawRejectionLevel { get; set; }
        
        public float drawRejectionDegree { get; set; }
        
        public uint decalFlags { get; set; }
        
        public System.Collections.Generic.IList<System.Numerics.Vector3> scales { get; } = new System.Collections.Generic.List<System.Numerics.Vector3>();
        
        public System.Collections.Generic.IList<System.Numerics.Quaternion> rotations { get; } = new System.Collections.Generic.List<System.Numerics.Quaternion>();
        
        public System.Collections.Generic.IList<System.Numerics.Vector3> translations { get; } = new System.Collections.Generic.List<System.Numerics.Vector3>();
        
        public System.Collections.Generic.IList<EntityLink> targets { get; } = new System.Collections.Generic.List<EntityLink>();
        
        public System.Collections.Generic.IList<uint> targetIndices { get; } = new System.Collections.Generic.List<uint>();
        
        public System.Collections.Generic.IList<uint> targetStartIndices { get; } = new System.Collections.Generic.List<uint>();
        
        public System.Collections.Generic.IList<int> renderingPriorities { get; } = new System.Collections.Generic.List<int>();
        
        public bool isDisableAlbedo { get; set; }
        
        public bool isPreserveAspect { get; set; }
        
        public bool isWrap { get; set; }
        
        public bool showObject { get; set; }
        
        public bool isVisibleGeom { get; set; }
        
        public bool isSSDecal { get; set; }
        
        // PropertyInfo
        private static EntityInfo classInfo;
        public static new EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static DecalArray()
        {
            classInfo = new EntityInfo(new String("DecalArray"), base.GetClassEntityInfo(), 448, "Decal", 1);
			
			classInfo.StaticProperties.Insert(new String("material"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 304, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("projectionMode"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 344, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_ProjectionMode), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("nearClipScale"), new PropertyInfo(PropertyInfo.PropertyType.Float, 348, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("projectionTarget"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 352, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_ProjectionTarget), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("repeatU"), new PropertyInfo(PropertyInfo.PropertyType.Float, 356, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("repeatV"), new PropertyInfo(PropertyInfo.PropertyType.Float, 360, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("transparency"), new PropertyInfo(PropertyInfo.PropertyType.Float, 364, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("polygonDataSource"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 368, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_PolygonDataSource), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("drawRejectionLevel"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 372, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_DrawRejectionLevel), PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("drawRejectionDegree"), new PropertyInfo(PropertyInfo.PropertyType.Float, 376, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("decalFlags"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 380, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("scales"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 384, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rotations"), new PropertyInfo(PropertyInfo.PropertyType.Quat, 400, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("translations"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 416, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("targets"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 432, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("targetIndices"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 448, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("targetStartIndices"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 464, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("renderingPriorities"), new PropertyInfo(PropertyInfo.PropertyType.Int32, 480, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isDisableAlbedo"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isPreserveAspect"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isWrap"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("showObject"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isVisibleGeom"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isSSDecal"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public DecalArray(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
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
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                case "scales":
                    while(this.scales.Count <= index) { this.scales.Add(default(System.Numerics.Vector3)); }
                    this.scales[index] = value.GetValueAsVector3();
                    return;
                case "rotations":
                    while(this.rotations.Count <= index) { this.rotations.Add(default(System.Numerics.Quaternion)); }
                    this.rotations[index] = value.GetValueAsQuat();
                    return;
                case "translations":
                    while(this.translations.Count <= index) { this.translations.Add(default(System.Numerics.Vector3)); }
                    this.translations[index] = value.GetValueAsVector3();
                    return;
                case "targets":
                    while(this.targets.Count <= index) { this.targets.Add(default(EntityLink)); }
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
        
        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}