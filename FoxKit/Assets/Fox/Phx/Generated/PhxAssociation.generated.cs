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

namespace Fox.Phx
{
    [UnityEditor.InitializeOnLoad]
    public partial class PhxAssociation : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink physicsData { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Phx.PhxAssociationUnitElement>> connections { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Phx.PhxAssociationUnitElement>>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Phx.PhAssociationParam> param { get; set; } = new Fox.Core.EntityPtr<Fox.Phx.PhAssociationParam>();
        
        public uint connectType { get => Get_connectType(); set { Set_connectType(value); } }
        protected partial uint Get_connectType();
        protected partial void Set_connectType(uint value);
        
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
        static PhxAssociation()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhxAssociation"), typeof(PhxAssociation), new Fox.Core.Data().GetClassEntityInfo(), 152, "Phx", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("physicsData"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connections"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 160, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Phx.PhxAssociationUnitElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("param"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhAssociationParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connectType"), Fox.Core.PropertyInfo.PropertyType.UInt32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
        }

        // Constructors
		public PhxAssociation(ulong id) : base(id) { }
		public PhxAssociation() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "physicsData":
                    this.physicsData = value.GetValueAsEntityLink();
                    return;
                case "param":
                    this.param = value.GetValueAsEntityPtr<Fox.Phx.PhAssociationParam>();
                    return;
                case "connectType":
                    this.connectType = value.GetValueAsUInt32();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "connections":
                    this.connections.Insert(key, value.GetValueAsEntityPtr<Fox.Phx.PhxAssociationUnitElement>());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}