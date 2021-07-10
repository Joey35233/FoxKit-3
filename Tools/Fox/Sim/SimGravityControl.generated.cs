//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Sim
{
    public partial class SimGravityControl : Fox.Sim.SimControlElement 
    {
        // Properties
        public EntityPtr<Sim.SimGravityControlParam> controlParam { get; set; }
        
        public float gravityCoefficient { get; set; }
        
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
        static SimGravityControl()
        {
            classInfo = new EntityInfo(new String("SimGravityControl"), base.GetClassEntityInfo(), 64, "Sim", 0);
			
			classInfo.StaticProperties.Insert(new String("controlParam"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.Never, PropertyInfo.PropertyExport.Never, typeof(Sim.SimGravityControlParam), null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("gravityCoefficient"), new PropertyInfo(PropertyInfo.PropertyType.Float, 80, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SimGravityControl(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "controlParam":
                    this.controlParam = EntityPtr<Sim.SimGravityControlParam>.Get(value.GetValueAsEntityPtr().Entity as Sim.SimGravityControlParam);
                    return;
                case "gravityCoefficient":
                    this.gravityCoefficient = value.GetValueAsFloat();
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