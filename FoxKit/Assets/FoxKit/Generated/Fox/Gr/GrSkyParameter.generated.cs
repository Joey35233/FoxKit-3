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

namespace Fox.Gr
{
    [UnityEditor.InitializeOnLoad]
    public partial class GrSkyParameter : Fox.Gr.GrViewportParameter 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected bool isAtmosphereOnly { get; set; }
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static GrSkyParameter()
        {
            classInfo = new Fox.EntityInfo("GrSkyParameter", typeof(GrSkyParameter), new Fox.Gr.GrViewportParameter().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isAtmosphereOnly", Fox.Core.PropertyInfo.PropertyType.Bool, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GrSkyParameter(ulong id) : base(id) { }
		public GrSkyParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "isAtmosphereOnly":
                    this.isAtmosphereOnly = value.GetValueAsBool();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
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