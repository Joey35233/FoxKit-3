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
    public partial class TppObjectBrushPluginFlutteringGrass : Fox.GameKit.ObjectBrushPluginClone 
    {
        // Properties
        public float baseCycleSpeedRate { get; set; }
        
        public float windAmplitude { get; set; }
        
        public float windOffsetFactor { get; set; }
        
        public bool windDirYAxisFixZero { get; set; }
        
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
        static TppObjectBrushPluginFlutteringGrass()
        {
            classInfo = new EntityInfo(new String("TppObjectBrushPluginFlutteringGrass"), base.GetClassEntityInfo(), 136, null, 0);
			
			classInfo.StaticProperties.Insert(new String("baseCycleSpeedRate"), new PropertyInfo(PropertyInfo.PropertyType.Float, 184, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("windAmplitude"), new PropertyInfo(PropertyInfo.PropertyType.Float, 188, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("windOffsetFactor"), new PropertyInfo(PropertyInfo.PropertyType.Float, 192, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("windDirYAxisFixZero"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 196, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppObjectBrushPluginFlutteringGrass(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "baseCycleSpeedRate":
                    this.baseCycleSpeedRate = value.GetValueAsFloat();
                    return;
                case "windAmplitude":
                    this.windAmplitude = value.GetValueAsFloat();
                    return;
                case "windOffsetFactor":
                    this.windOffsetFactor = value.GetValueAsFloat();
                    return;
                case "windDirYAxisFixZero":
                    this.windDirYAxisFixZero = value.GetValueAsBool();
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