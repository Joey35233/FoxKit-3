//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Sdx
{
    public partial class SoundPhysicsParameter : Fox.Core.Data 
    {
        // Properties
        public String hitEvent { get; set; }
        
        public String rollStartEvent { get; set; }
        
        public String rollEndEvent { get; set; }
        
        public String hitRtpcName { get; set; }
        
        public String rollRtpcName { get; set; }
        
        public String switchName { get; set; }
        
        public String generalEvent1 { get; set; }
        
        public String generalEvent2 { get; set; }
        
        public float hitLowerPower { get; set; }
        
        public float hitUpperPower { get; set; }
        
        public float hitIntervalSeconds { get; set; }
        
        public float hitLowerRtpc { get; set; }
        
        public float hitUpperRtpc { get; set; }
        
        public float rollLowerPower { get; set; }
        
        public float rollUpperPower { get; set; }
        
        public float rollStartSeconds { get; set; }
        
        public float rollEndSeconds { get; set; }
        
        public float rollLowerRtpc { get; set; }
        
        public float rollUpperRtpc { get; set; }
        
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
        static SoundPhysicsParameter()
        {
            classInfo = new EntityInfo(new String("SoundPhysicsParameter"), base.GetClassEntityInfo(), 140, "Sound", 1);
			
			classInfo.StaticProperties.Insert(new String("hitEvent"), new PropertyInfo(PropertyInfo.PropertyType.String, 120, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollStartEvent"), new PropertyInfo(PropertyInfo.PropertyType.String, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollEndEvent"), new PropertyInfo(PropertyInfo.PropertyType.String, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("hitRtpcName"), new PropertyInfo(PropertyInfo.PropertyType.String, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollRtpcName"), new PropertyInfo(PropertyInfo.PropertyType.String, 152, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("switchName"), new PropertyInfo(PropertyInfo.PropertyType.String, 160, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("generalEvent1"), new PropertyInfo(PropertyInfo.PropertyType.String, 168, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("generalEvent2"), new PropertyInfo(PropertyInfo.PropertyType.String, 176, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("hitLowerPower"), new PropertyInfo(PropertyInfo.PropertyType.Float, 184, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("hitUpperPower"), new PropertyInfo(PropertyInfo.PropertyType.Float, 188, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("hitIntervalSeconds"), new PropertyInfo(PropertyInfo.PropertyType.Float, 192, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("hitLowerRtpc"), new PropertyInfo(PropertyInfo.PropertyType.Float, 196, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("hitUpperRtpc"), new PropertyInfo(PropertyInfo.PropertyType.Float, 200, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollLowerPower"), new PropertyInfo(PropertyInfo.PropertyType.Float, 204, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollUpperPower"), new PropertyInfo(PropertyInfo.PropertyType.Float, 208, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollStartSeconds"), new PropertyInfo(PropertyInfo.PropertyType.Float, 212, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollEndSeconds"), new PropertyInfo(PropertyInfo.PropertyType.Float, 216, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollLowerRtpc"), new PropertyInfo(PropertyInfo.PropertyType.Float, 220, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("rollUpperRtpc"), new PropertyInfo(PropertyInfo.PropertyType.Float, 224, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SoundPhysicsParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "hitEvent":
                    this.hitEvent = value.GetValueAsString();
                    return;
                case "rollStartEvent":
                    this.rollStartEvent = value.GetValueAsString();
                    return;
                case "rollEndEvent":
                    this.rollEndEvent = value.GetValueAsString();
                    return;
                case "hitRtpcName":
                    this.hitRtpcName = value.GetValueAsString();
                    return;
                case "rollRtpcName":
                    this.rollRtpcName = value.GetValueAsString();
                    return;
                case "switchName":
                    this.switchName = value.GetValueAsString();
                    return;
                case "generalEvent1":
                    this.generalEvent1 = value.GetValueAsString();
                    return;
                case "generalEvent2":
                    this.generalEvent2 = value.GetValueAsString();
                    return;
                case "hitLowerPower":
                    this.hitLowerPower = value.GetValueAsFloat();
                    return;
                case "hitUpperPower":
                    this.hitUpperPower = value.GetValueAsFloat();
                    return;
                case "hitIntervalSeconds":
                    this.hitIntervalSeconds = value.GetValueAsFloat();
                    return;
                case "hitLowerRtpc":
                    this.hitLowerRtpc = value.GetValueAsFloat();
                    return;
                case "hitUpperRtpc":
                    this.hitUpperRtpc = value.GetValueAsFloat();
                    return;
                case "rollLowerPower":
                    this.rollLowerPower = value.GetValueAsFloat();
                    return;
                case "rollUpperPower":
                    this.rollUpperPower = value.GetValueAsFloat();
                    return;
                case "rollStartSeconds":
                    this.rollStartSeconds = value.GetValueAsFloat();
                    return;
                case "rollEndSeconds":
                    this.rollEndSeconds = value.GetValueAsFloat();
                    return;
                case "rollLowerRtpc":
                    this.rollLowerRtpc = value.GetValueAsFloat();
                    return;
                case "rollUpperRtpc":
                    this.rollUpperRtpc = value.GetValueAsFloat();
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