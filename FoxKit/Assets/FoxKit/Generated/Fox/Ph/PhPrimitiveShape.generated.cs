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
    [UnityEditor.InitializeOnLoad]
    public partial class PhPrimitiveShape : Fox.Ph.PhShape 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public PhPrimitiveShapeType type { get; set; }
        
        public UnityEngine.Vector3 size { get => Get_size(); set { Set_size(value); } }
        protected partial UnityEngine.Vector3 Get_size();
        protected partial void Set_size(UnityEngine.Vector3 value);
        
        public float radius { get => Get_radius(); set { Set_radius(value); } }
        protected partial float Get_radius();
        protected partial void Set_radius(float value);
        
        public float height { get => Get_height(); set { Set_height(value); } }
        protected partial float Get_height();
        protected partial void Set_height(float value);
        
        public float radius2 { get => Get_radius2(); set { Set_radius2(value); } }
        protected partial float Get_radius2();
        protected partial void Set_radius2(float value);
        
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
        static PhPrimitiveShape()
        {
            classInfo = new Fox.EntityInfo("PhPrimitiveShape", typeof(PhPrimitiveShape), new Fox.Ph.PhShape().GetClassEntityInfo(), 272, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("type", Fox.Core.PropertyInfo.PropertyType.Int32, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PhPrimitiveShapeType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("size", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("radius", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("height", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("radius2", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public PhPrimitiveShape(ulong id) : base(id) { }
		public PhPrimitiveShape() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "type":
                    this.type = (PhPrimitiveShapeType)value.GetValueAsInt32();
                    return;
                case "size":
                    this.size = value.GetValueAsVector3();
                    return;
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "height":
                    this.height = value.GetValueAsFloat();
                    return;
                case "radius2":
                    this.radius2 = value.GetValueAsFloat();
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