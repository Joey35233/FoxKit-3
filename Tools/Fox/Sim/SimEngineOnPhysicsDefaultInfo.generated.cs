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
    public partial class SimEngineOnPhysicsDefaultInfo : Fox.Core.DataElement 
    {
        // Properties
        public float defaultRadius { get; set; }
        
        public float defaultLimit { get; set; }
        
        public float defaultSpring { get; set; }
        
        public bool defaultStopTwistFlag { get; set; }
        
        public float defaultMass { get; set; }
        
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
        static SimEngineOnPhysicsDefaultInfo()
        {
            classInfo = new EntityInfo(new String("SimEngineOnPhysicsDefaultInfo"), base.GetClassEntityInfo(), 0, "Sim", 1);
			
			classInfo.StaticProperties.Insert(new String("defaultRadius"), new PropertyInfo(PropertyInfo.PropertyType.Float, 56, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("defaultLimit"), new PropertyInfo(PropertyInfo.PropertyType.Float, 60, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("defaultSpring"), new PropertyInfo(PropertyInfo.PropertyType.Float, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("defaultStopTwistFlag"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 68, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("defaultMass"), new PropertyInfo(PropertyInfo.PropertyType.Float, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorOnly, PropertyInfo.PropertyExport.EditorOnly, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SimEngineOnPhysicsDefaultInfo(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "defaultRadius":
                    this.defaultRadius = value.GetValueAsFloat();
                    return;
                case "defaultLimit":
                    this.defaultLimit = value.GetValueAsFloat();
                    return;
                case "defaultSpring":
                    this.defaultSpring = value.GetValueAsFloat();
                    return;
                case "defaultStopTwistFlag":
                    this.defaultStopTwistFlag = value.GetValueAsBool();
                    return;
                case "defaultMass":
                    this.defaultMass = value.GetValueAsFloat();
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