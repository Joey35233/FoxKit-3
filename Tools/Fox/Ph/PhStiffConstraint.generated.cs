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
    public partial class PhStiffConstraint : Fox.Ph.PhConstraint 
    {
        // Properties
        public System.Numerics.Vector3 endurancePower { get; set; }
        
        public System.Numerics.Vector3 enduranceTorque { get; set; }
        
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
        static PhStiffConstraint()
        {
            classInfo = new EntityInfo(new String("PhStiffConstraint"), base.GetClassEntityInfo(), 0, "Ph", 0);
			
			classInfo.StaticProperties.Insert(new String("endurancePower"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("enduranceTorque"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhStiffConstraint(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "endurancePower":
                    this.endurancePower = value.GetValueAsVector3();
                    return;
                case "enduranceTorque":
                    this.enduranceTorque = value.GetValueAsVector3();
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