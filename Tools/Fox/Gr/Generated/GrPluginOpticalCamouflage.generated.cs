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
    public partial class GrPluginOpticalCamouflage : Fox.Gr.GrRenderPlugin 
    {
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static GrPluginOpticalCamouflage()
        {
            classInfo = new Fox.Core.EntityInfo("GrPluginOpticalCamouflage", typeof(GrPluginOpticalCamouflage), new Fox.Gr.GrRenderPlugin().GetClassEntityInfo(), 0, null, 0);
        }

        // Constructors
		public GrPluginOpticalCamouflage(ulong id) : base(id) { }
		public GrPluginOpticalCamouflage() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
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