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

namespace Fox.Ph
{
    public partial class PhPolyhedronShapeParam : Fox.Ph.PhShapeParam 
    {
        // Properties
        public CsSystem.Collections.Generic.List<UnityEngine.Vector3> verts = new CsSystem.Collections.Generic.List<UnityEngine.Vector3>();
        
        public CsSystem.Collections.Generic.List<uint> polys = new CsSystem.Collections.Generic.List<uint>();
        
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
        static PhPolyhedronShapeParam()
        {
            classInfo = new Fox.EntityInfo("PhPolyhedronShapeParam", new Fox.Ph.PhShapeParam(0, 0, 0).GetClassEntityInfo(), 0, "Ph", 0);
			
			classInfo.StaticProperties.Insert("verts", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 112, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("polys", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhPolyhedronShapeParam(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "verts":
                    while(this.verts.Count <= index) { this.verts.Add(default(UnityEngine.Vector3)); }
                    this.verts[index] = value.GetValueAsVector3();
                    return;
                case "polys":
                    while(this.polys.Count <= index) { this.polys.Add(default(uint)); }
                    this.polys[index] = value.GetValueAsUInt32();
                    return;
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