//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Phx
{
    public partial class PhxWheelConstraintParam : Fox.Ph.PhConstraintParam 
    {
        // Properties
        public System.Numerics.Quaternion defaultRotation { get; set; }
        
        public System.Numerics.Vector3 positionL { get; set; }
        
        public System.Numerics.Vector3 frontL { get; set; }
        
        public System.Numerics.Vector3 upL { get; set; }
        
        public System.Numerics.Vector3 wheelPositionOffset { get; set; }
        
        public float radius { get; set; }
        
        public float suspensionLength { get; set; }
        
        public float maxSuspensionForce { get; set; }
        
        public float dampingFactorElong { get; set; }
        
        public float dampingFactorCompress { get; set; }
        
        public float friction { get; set; }
        
        public float restitution { get; set; }
        
        public float inertia { get; set; }
        
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
        static PhxWheelConstraintParam()
        {
            classInfo = new EntityInfo(new String("PhxWheelConstraintParam"), base.GetClassEntityInfo(), 160, "Phx", 2);
			
			classInfo.StaticProperties.Insert(new String("defaultRotation"), new PropertyInfo(PropertyInfo.PropertyType.Quat, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("positionL"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("frontL"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("upL"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 112, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("wheelPositionOffset"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("radius"), new PropertyInfo(PropertyInfo.PropertyType.Float, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("suspensionLength"), new PropertyInfo(PropertyInfo.PropertyType.Float, 148, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("maxSuspensionForce"), new PropertyInfo(PropertyInfo.PropertyType.Float, 152, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("dampingFactorElong"), new PropertyInfo(PropertyInfo.PropertyType.Float, 156, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("dampingFactorCompress"), new PropertyInfo(PropertyInfo.PropertyType.Float, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("friction"), new PropertyInfo(PropertyInfo.PropertyType.Float, 164, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("restitution"), new PropertyInfo(PropertyInfo.PropertyType.Float, 168, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("inertia"), new PropertyInfo(PropertyInfo.PropertyType.Float, 172, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhxWheelConstraintParam(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "defaultRotation":
                    this.defaultRotation = value.GetValueAsQuat();
                    return;
                case "positionL":
                    this.positionL = value.GetValueAsVector3();
                    return;
                case "frontL":
                    this.frontL = value.GetValueAsVector3();
                    return;
                case "upL":
                    this.upL = value.GetValueAsVector3();
                    return;
                case "wheelPositionOffset":
                    this.wheelPositionOffset = value.GetValueAsVector3();
                    return;
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "suspensionLength":
                    this.suspensionLength = value.GetValueAsFloat();
                    return;
                case "maxSuspensionForce":
                    this.maxSuspensionForce = value.GetValueAsFloat();
                    return;
                case "dampingFactorElong":
                    this.dampingFactorElong = value.GetValueAsFloat();
                    return;
                case "dampingFactorCompress":
                    this.dampingFactorCompress = value.GetValueAsFloat();
                    return;
                case "friction":
                    this.friction = value.GetValueAsFloat();
                    return;
                case "restitution":
                    this.restitution = value.GetValueAsFloat();
                    return;
                case "inertia":
                    this.inertia = value.GetValueAsFloat();
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