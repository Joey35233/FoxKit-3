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

namespace Tpp.MotherBaseCore
{
    [UnityEditor.InitializeOnLoad]
    public partial class MotherBaseConstructDivisionLocatorBody : Fox.Core.TransformDataBody 
    {
        
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
        static MotherBaseConstructDivisionLocatorBody()
        {
            classInfo = new Fox.EntityInfo("MotherBaseConstructDivisionLocatorBody", typeof(MotherBaseConstructDivisionLocatorBody), new Fox.Core.TransformDataBody().GetClassEntityInfo(), 0, "TppMotherBase", 0);
        }

        // Constructors
		public MotherBaseConstructDivisionLocatorBody(ulong address, ulong id) : base(address, id) { }
		public MotherBaseConstructDivisionLocatorBody() : base() { }
        
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