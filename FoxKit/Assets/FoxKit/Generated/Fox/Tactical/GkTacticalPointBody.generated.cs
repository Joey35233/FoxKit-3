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

namespace Fox.Tactical
{
    [UnityEditor.InitializeOnLoad]
    public partial class GkTacticalPointBody : Fox.Core.TransformDataBody 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityHandle @object { get; set; }
        
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
        static GkTacticalPointBody()
        {
            classInfo = new Fox.EntityInfo("GkTacticalPointBody", typeof(GkTacticalPointBody), new Fox.Core.TransformDataBody().GetClassEntityInfo(), 0, "TacticalPoint", 0);
			classInfo.StaticProperties.Insert("object", new Fox.Core.PropertyInfo("object", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GkTacticalPointBody(ulong id) : base(id) { }
		public GkTacticalPointBody() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "@object":
                    this.@object = value.GetValueAsEntityHandle();
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