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
    public partial class PhConstraint : Fox.Ph.PhSubObject 
    {
        // Properties
        public EntityPtr<Ph.PhConstraintParam> param { get; set; }
        
        public EntityLink bodyA { get; set; }
        
        public EntityLink bodyB { get; set; }
        
        public System.Numerics.Vector3 defaultPosition { get; set; }
        
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
        static PhConstraint()
        {
            classInfo = new EntityInfo(new String("PhConstraint"), base.GetClassEntityInfo(), 0, "Ph", 1);
			
			classInfo.StaticProperties.Insert(new String("param"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 304, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, typeof(Ph.PhConstraintParam), null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("bodyA"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 312, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("bodyB"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 352, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("defaultPosition"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 0, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhConstraint(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "param":
                    this.param = EntityPtr<Ph.PhConstraintParam>.Get(value.GetValueAsEntityPtr().Entity as Ph.PhConstraintParam);
                    return;
                case "bodyA":
                    this.bodyA = value.GetValueAsEntityLink();
                    return;
                case "bodyB":
                    this.bodyB = value.GetValueAsEntityLink();
                    return;
                case "defaultPosition":
                    this.defaultPosition = value.GetValueAsVector3();
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