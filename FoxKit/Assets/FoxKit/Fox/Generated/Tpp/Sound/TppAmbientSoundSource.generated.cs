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

namespace Tpp.Sound
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppAmbientSoundSource : Fox.Sdx.SoundSource 
    {
        // Properties
        public Fox.String volumeRtpc;
        
        public byte ambientIndex;
        
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
        static TppAmbientSoundSource()
        {
            classInfo = new Fox.EntityInfo("TppAmbientSoundSource", typeof(TppAmbientSoundSource), new Fox.Sdx.SoundSource().GetClassEntityInfo(), 304, "Sound", 0);
			classInfo.StaticProperties.Insert("volumeRtpc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("ambientIndex", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppAmbientSoundSource(ulong address, ulong id) : base(address, id) { }
		public TppAmbientSoundSource() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "volumeRtpc":
                    this.volumeRtpc = value.GetValueAsString();
                    return;
                case "ambientIndex":
                    this.ambientIndex = value.GetValueAsUInt8();
                    return;
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