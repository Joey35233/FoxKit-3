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

namespace Fox.GameKit
{
    public partial class OrthogonalCamera : Fox.GameKit.Camera 
    {
        // Properties
        public OrthogonalCamera_ViewType type;
        
        public float scale;
        
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
        static OrthogonalCamera()
        {
            classInfo = new Fox.EntityInfo("OrthogonalCamera", new Fox.GameKit.Camera().GetClassEntityInfo(), 0, null, 0);
			
			classInfo.StaticProperties.Insert("type", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 448, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, typeof(OrthogonalCamera_ViewType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("scale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 452, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public OrthogonalCamera(ulong address, ulong id) : base(address, id) { }
		public OrthogonalCamera() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "type":
                    this.type = (OrthogonalCamera_ViewType)value.GetValueAsInt32();
                    return;
                case "scale":
                    this.scale = value.GetValueAsFloat();
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