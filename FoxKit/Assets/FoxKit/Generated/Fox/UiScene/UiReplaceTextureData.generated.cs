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

namespace Fox.UiScene
{
    [UnityEditor.InitializeOnLoad]
    public partial class UiReplaceTextureData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.FoxKernel.Path> texturePath { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.FoxKernel.Path>();
        
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
        static UiReplaceTextureData()
        {
            classInfo = new Fox.EntityInfo("UiReplaceTextureData", typeof(UiReplaceTextureData), new Fox.Core.Data().GetClassEntityInfo(), 0, "Ui", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("texturePath", Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public UiReplaceTextureData(ulong id) : base(id) { }
		public UiReplaceTextureData() : base() { }
        
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
                case "texturePath":
                    while(this.texturePath.Count <= index) { this.texturePath.Add(default(Fox.FoxKernel.Path)); }
                    this.texturePath[index] = value.GetValueAsPath();
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