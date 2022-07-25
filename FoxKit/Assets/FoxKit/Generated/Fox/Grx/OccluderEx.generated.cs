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

namespace Fox.Grx
{
    [UnityEditor.InitializeOnLoad]
    public partial class OccluderEx : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool isEnable { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isOneSideMode { get; set; }
        
        [field: UnityEngine.SerializeField]
        public OccluderEx_Mode mode { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int numVertices { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.StaticArray<UnityEngine.Vector3> positions { get; set; } = new Fox.FoxKernel.StaticArray<UnityEngine.Vector3>(7);
        
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
        static OccluderEx()
        {
            classInfo = new Fox.EntityInfo("OccluderEx", typeof(OccluderEx), new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Area", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isEnable", Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isOneSideMode", Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mode", Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(OccluderEx_Mode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("numVertices", Fox.Core.PropertyInfo.PropertyType.Int32, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("positions", Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 7, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public OccluderEx(ulong id) : base(id) { }
		public OccluderEx() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "isEnable":
                    this.isEnable = value.GetValueAsBool();
                    return;
                case "isOneSideMode":
                    this.isOneSideMode = value.GetValueAsBool();
                    return;
                case "mode":
                    this.mode = (OccluderEx_Mode)value.GetValueAsInt32();
                    return;
                case "numVertices":
                    this.numVertices = value.GetValueAsInt32();
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
                case "positions":
                    
                    this.positions[index] = value.GetValueAsVector3();
                    return;
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