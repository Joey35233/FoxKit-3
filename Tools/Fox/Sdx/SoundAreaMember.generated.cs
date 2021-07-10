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
    public partial class SoundAreaMember : Fox.Core.Data 
    {
        // Properties
        public System.Collections.Generic.IList<EntityLink> shapes { get; } = new System.Collections.Generic.List<EntityLink>();
        
        public uint priority { get; set; }
        
        public EntityPtr<Sdx.SoundAreaParameter> parameter { get; set; }
        
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
        static SoundAreaMember()
        {
            classInfo = new EntityInfo(new String("SoundAreaMember"), base.GetClassEntityInfo(), 96, "Sound", 2);
			
			classInfo.StaticProperties.Insert(new String("shapes"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 120, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("priority"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 136, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("parameter"), new PropertyInfo(PropertyInfo.PropertyType.EntityPtr, 144, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, typeof(Sdx.SoundAreaParameter), null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public SoundAreaMember(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "priority":
                    this.priority = value.GetValueAsUInt32();
                    return;
                case "parameter":
                    this.parameter = EntityPtr<Sdx.SoundAreaParameter>.Get(value.GetValueAsEntityPtr().Entity as Sdx.SoundAreaParameter);
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
                case "shapes":
                    while(this.shapes.Count <= index) { this.shapes.Add(default(EntityLink)); }
                    this.shapes[index] = value.GetValueAsEntityLink();
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