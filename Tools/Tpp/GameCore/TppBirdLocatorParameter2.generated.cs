//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tpp.GameCore
{
    public partial class TppBirdLocatorParameter2 : Fox.Core.DataElement 
    {
        // Properties
        public uint count { get; set; }
        
        public System.Collections.Generic.IList<System.Numerics.Vector3> grounds { get; } = new System.Collections.Generic.List<System.Numerics.Vector3>();
        
        public System.Collections.Generic.IList<System.Numerics.Vector3> perchPoints { get; } = new System.Collections.Generic.List<System.Numerics.Vector3>();
        
        public byte radius { get; set; }
        
        public byte height { get; set; }
        
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
        static TppBirdLocatorParameter2()
        {
            classInfo = new EntityInfo(new String("TppBirdLocatorParameter2"), base.GetClassEntityInfo(), 80, null, 2);
			
			classInfo.StaticProperties.Insert(new String("count"), new PropertyInfo(PropertyInfo.PropertyType.UInt32, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("grounds"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 72, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("perchPoints"), new PropertyInfo(PropertyInfo.PropertyType.Vector3, 88, 1, PropertyInfo.ContainerType.DynamicArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("radius"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("height"), new PropertyInfo(PropertyInfo.PropertyType.UInt8, 105, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppBirdLocatorParameter2(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "count":
                    this.count = value.GetValueAsUInt32();
                    return;
                case "radius":
                    this.radius = value.GetValueAsUInt8();
                    return;
                case "height":
                    this.height = value.GetValueAsUInt8();
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
                case "grounds":
                    while(this.grounds.Count <= index) { this.grounds.Add(default(System.Numerics.Vector3)); }
                    this.grounds[index] = value.GetValueAsVector3();
                    return;
                case "perchPoints":
                    while(this.perchPoints.Count <= index) { this.perchPoints.Add(default(System.Numerics.Vector3)); }
                    this.perchPoints[index] = value.GetValueAsVector3();
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