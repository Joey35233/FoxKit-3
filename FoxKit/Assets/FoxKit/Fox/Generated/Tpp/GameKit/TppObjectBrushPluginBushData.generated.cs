//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CsSystem = System;
using Fox;

namespace Tpp.GameKit
{
    public partial class TppObjectBrushPluginBushData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.EntityPtr<Tpp.GameKit.ObjectBrushPluginBushDataElement> parameter;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppObjectBrushPluginBushData()
        {
            classInfo = new Fox.EntityInfo("TppObjectBrushPluginBushData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("parameter", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Tpp.GameKit.ObjectBrushPluginBushDataElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppObjectBrushPluginBushData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "parameter":
                    this.parameter = value.GetValueAsEntityPtr<Tpp.GameKit.ObjectBrushPluginBushDataElement>();
                    return;
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}