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
    public partial class PivotTransform 
    {
        // Properties
        public System.Numerics.Vector3 pivot { get; set; }
        
        public System.Numerics.Vector3 pivotTranslation { get; set; }
        
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
        static PivotTransform()
        {
            classInfo = new EntityInfo(new String("PivotTransform"), null, 0, null, 0);
			
			classInfo.StaticProperties.Insert(new String("pivot"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("pivotTranslation"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 16, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		
        
        public virtual void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "pivot":
                    this.pivot = value.GetValueAsVector3();
                    return;
                case "pivotTranslation":
                    this.pivotTranslation = value.GetValueAsVector3();
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