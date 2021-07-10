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
    public partial class TppCoverPoint : Fox.Tactical.GkTacticalPoint 
    {
        // Properties
        public bool isLeftOpen { get; set; }
        
        public bool isRightOpen { get; set; }
        
        public bool isUpOpen { get; set; }
        
        public bool isUnVaultable { get; set; }
        
        public bool isUseVip { get; set; }
        
        public bool isUseSniper { get; set; }
        
        public bool isBreakDisable { get; set; }
        
        public bool isBreakEnable { get; set; }
        
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
        static TppCoverPoint()
        {
            classInfo = new EntityInfo(new String("TppCoverPoint"), base.GetClassEntityInfo(), 0, "TacticalPoint", 5);
			
			classInfo.StaticProperties.Insert(new String("isLeftOpen"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 400, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isRightOpen"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 401, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isUpOpen"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 402, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isUnVaultable"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 403, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isUseVip"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 404, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isUseSniper"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 405, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isBreakDisable"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 406, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("isBreakEnable"), new PropertyInfo(PropertyInfo.PropertyType.Bool, 407, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppCoverPoint(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "isLeftOpen":
                    this.isLeftOpen = value.GetValueAsBool();
                    return;
                case "isRightOpen":
                    this.isRightOpen = value.GetValueAsBool();
                    return;
                case "isUpOpen":
                    this.isUpOpen = value.GetValueAsBool();
                    return;
                case "isUnVaultable":
                    this.isUnVaultable = value.GetValueAsBool();
                    return;
                case "isUseVip":
                    this.isUseVip = value.GetValueAsBool();
                    return;
                case "isUseSniper":
                    this.isUseSniper = value.GetValueAsBool();
                    return;
                case "isBreakDisable":
                    this.isBreakDisable = value.GetValueAsBool();
                    return;
                case "isBreakEnable":
                    this.isBreakEnable = value.GetValueAsBool();
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