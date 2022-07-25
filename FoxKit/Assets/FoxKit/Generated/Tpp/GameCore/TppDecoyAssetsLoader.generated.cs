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

namespace Tpp.GameCore
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppDecoyAssetsLoader : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.Core.FilePtr> decoyAssets { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String playerDecoyType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String enemyDecoyType { get; set; }
        
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
        static TppDecoyAssetsLoader()
        {
            classInfo = new Fox.EntityInfo("TppDecoyAssetsLoader", typeof(TppDecoyAssetsLoader), new Fox.Core.Data().GetClassEntityInfo(), 88, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("decoyAssets", Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("playerDecoyType", Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enemyDecoyType", Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppDecoyAssetsLoader(ulong id) : base(id) { }
		public TppDecoyAssetsLoader() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "playerDecoyType":
                    this.playerDecoyType = value.GetValueAsString();
                    return;
                case "enemyDecoyType":
                    this.enemyDecoyType = value.GetValueAsString();
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
                case "decoyAssets":
                    while(this.decoyAssets.Count <= index) { this.decoyAssets.Add(default(Fox.Core.FilePtr)); }
                    this.decoyAssets[index] = value.GetValueAsFilePtr();
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