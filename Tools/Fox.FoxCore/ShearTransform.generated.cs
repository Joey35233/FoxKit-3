//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.FoxCore
{
    public partial class ShearTransform 
    {
        // Properties
        public System.Numerics.Vector3 shear { get; set; }
        
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
        static ShearTransform()
        {
            classInfo = new EntityInfo(new String("ShearTransform"), null, 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("shear"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		
        
        public virtual void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "shear":
                    this.shear = value.GetValueAsVector3();
                    return;
                default:
				    
                    throw new System.MissingMemberException("Unrecognized property", propertyName.CString);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    throw new System.MissingMemberException("Unrecognized property", propertyName.CString);
                    return;
            }
        }
        
        public virtual void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    throw new System.MissingMemberException("Unrecognized property", propertyName.CString);
                    return;
            }
        }
    }
}