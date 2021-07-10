//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.GameKit
{
    public partial class TppLadderData : Fox.Core.TransformData 
    {
        // Properties
        public uint numSteps { get; set; }
        
        public String tacticalActionId { get; set; }
        
        public System.Collections.Generic.IList<EntityLink> entryPoints { get; } = new System.Collections.Generic.List<EntityLink>();
        
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
        static TppLadderData()
        {
            classInfo = new EntityInfo(new String("TppLadderData"), base.GetClassEntityInfo(), 288, "Tpp", 3);
			
			classInfo.StaticProperties.Insert(new String("numSteps"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 304, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("tacticalActionId"), new PropertyInfo(PropertyInfo.PropertyType.String, 312, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("entryPoints"), new PropertyInfo(PropertyInfo.PropertyType.EntityLink, 320, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppLadderData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "numSteps":
                    this.numSteps = value.GetValueAsUInt32();
                    return;
                case "tacticalActionId":
                    this.tacticalActionId = value.GetValueAsString();
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
                case "entryPoints":
                    while(this.entryPoints.Count <= index) { this.entryPoints.Add(default(EntityLink)); }
                    this.entryPoints[index] = value.GetValueAsEntityLink();
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