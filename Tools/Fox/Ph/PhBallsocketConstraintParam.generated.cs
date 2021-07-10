//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Ph
{
    public partial class PhBallsocketConstraintParam : Fox.Ph.PhConstraintParam 
    {
        // Properties
        public bool limitedFlag { get; set; }
        
        public System.Numerics.Vector3 refA { get; set; }
        
        public System.Numerics.Vector3 refB { get; set; }
        
        public float limit { get; set; }
        
        public bool springFlag { get; set; }
        
        public bool springRefCustomFlag { get; set; }
        
        public System.Numerics.Vector3 springRef { get; set; }
        
        public float springConstant { get; set; }
        
        public float flexibility { get; set; }
        
        public bool stopTwistFlag { get; set; }
        
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
        static PhBallsocketConstraintParam()
        {
            classInfo = new EntityInfo(new String("PhBallsocketConstraintParam"), base.GetClassEntityInfo(), 112, "Ph", 2);
			
			classInfo.StaticProperties.Insert(new String("limitedFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 124, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("refA"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("refB"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("limit"), new PropertyInfo(PropertyInfo.PropertyType.Float, 112, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("springFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 125, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("springRefCustomFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 126, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("springRef"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("springConstant"), new PropertyInfo(PropertyInfo.PropertyType.Float, 116, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("flexibility"), new PropertyInfo(PropertyInfo.PropertyType.Float, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("stopTwistFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 127, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhBallsocketConstraintParam(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "limitedFlag":
                    this.limitedFlag = value.GetValueAsBool();
                    return;
                case "refA":
                    this.refA = value.GetValueAsVector3();
                    return;
                case "refB":
                    this.refB = value.GetValueAsVector3();
                    return;
                case "limit":
                    this.limit = value.GetValueAsFloat();
                    return;
                case "springFlag":
                    this.springFlag = value.GetValueAsBool();
                    return;
                case "springRefCustomFlag":
                    this.springRefCustomFlag = value.GetValueAsBool();
                    return;
                case "springRef":
                    this.springRef = value.GetValueAsVector3();
                    return;
                case "springConstant":
                    this.springConstant = value.GetValueAsFloat();
                    return;
                case "flexibility":
                    this.flexibility = value.GetValueAsFloat();
                    return;
                case "stopTwistFlag":
                    this.stopTwistFlag = value.GetValueAsBool();
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