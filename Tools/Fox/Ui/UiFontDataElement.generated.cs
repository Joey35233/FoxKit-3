//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Fox.Ui
{
    public partial class UiFontDataElement : Fox.Core.DataElement 
    {
        // Properties
        public String language { get; set; }
        
        public String fontName { get; set; }
        
        public FilePtr<File> fontFile { get; set; }
        
        public Path texturePath { get; set; }
        
        public float fontWidth { get; set; }
        
        public float fontHeight { get; set; }
        
        public float textSpace { get; set; }
        
        public float lineSpace { get; set; }
        
        public System.Numerics.Vector4 fontEdge { get; set; }
        
        // PropertyInfo
        private static EntityInfo classInfo;
        public static new EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static UiFontDataElement()
        {
            classInfo = new EntityInfo(new String("UiFontDataElement"), base.GetClassEntityInfo(), 128, null, 2);
			
			classInfo.StaticProperties.Insert(new String("language"), new PropertyInfo(PropertyInfo.PropertyType.String, 56, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("fontName"), new PropertyInfo(PropertyInfo.PropertyType.String, 64, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("fontFile"), new PropertyInfo(PropertyInfo.PropertyType.FilePtr, 72, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("texturePath"), new PropertyInfo(PropertyInfo.PropertyType.Path, 96, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("fontWidth"), new PropertyInfo(PropertyInfo.PropertyType.Float, 104, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("fontHeight"), new PropertyInfo(PropertyInfo.PropertyType.Float, 108, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("textSpace"), new PropertyInfo(PropertyInfo.PropertyType.Float, 112, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("lineSpace"), new PropertyInfo(PropertyInfo.PropertyType.Float, 116, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert(new String("fontEdge"), new PropertyInfo(PropertyInfo.PropertyType.Vector4, 128, 1, PropertyInfo.ContainerType.StaticArray, PropertyInfo.PropertyExport.EditorAndGame, PropertyInfo.PropertyExport.EditorAndGame, null, null, PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public UiFontDataElement(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(String propertyName, Value value)
        {
            switch(propertyName.CString())
            {
                case "language":
                    this.language = value.GetValueAsString();
                    return;
                case "fontName":
                    this.fontName = value.GetValueAsString();
                    return;
                case "fontFile":
                    this.fontFile = value.GetValueAsFilePtr();
                    return;
                case "texturePath":
                    this.texturePath = value.GetValueAsPath();
                    return;
                case "fontWidth":
                    this.fontWidth = value.GetValueAsFloat();
                    return;
                case "fontHeight":
                    this.fontHeight = value.GetValueAsFloat();
                    return;
                case "textSpace":
                    this.textSpace = value.GetValueAsFloat();
                    return;
                case "lineSpace":
                    this.lineSpace = value.GetValueAsFloat();
                    return;
                case "fontEdge":
                    this.fontEdge = value.GetValueAsVector4();
                    return;
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, ushort index, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(String propertyName, String key, Value value)
        {
            switch(propertyName.CString())
            {
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}