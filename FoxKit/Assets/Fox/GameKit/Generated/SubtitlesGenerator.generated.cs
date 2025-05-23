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

namespace Fox.GameKit
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxGameKit/SubtitlesGenerator")]
	public partial class SubtitlesGenerator : Fox.Ui.UiGraphEntry
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public string key { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 offset { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 size { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float fontSpace { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lineSpace { get; set; }
		
		[field: UnityEngine.SerializeField]
		public SubtitlesGenerator_TextHorizontalAlign hAlign { get; set; }
		
		[field: UnityEngine.SerializeField]
		public SubtitlesGenerator_TextVerticalAlign vAlign { get; set; }
		
		[field: UnityEngine.SerializeField]
		public SubtitlesGenerator_TextBoxAlign bAlign { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string fontName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool autoLineFeed { get; set; }
		
		// ClassInfos
		public static new bool ClassInfoInitialized = false;
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
		static SubtitlesGenerator()
		{
			if (Fox.Ui.UiGraphEntry.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("SubtitlesGenerator", typeof(SubtitlesGenerator), Fox.Ui.UiGraphEntry.ClassInfo, 192, "Subtitles", 5);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("key", Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("color", Fox.Core.PropertyInfo.PropertyType.Color, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offset", Fox.Core.PropertyInfo.PropertyType.Vector3, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("size", Fox.Core.PropertyInfo.PropertyType.Vector3, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fontSpace", Fox.Core.PropertyInfo.PropertyType.Float, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lineSpace", Fox.Core.PropertyInfo.PropertyType.Float, 228, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hAlign", Fox.Core.PropertyInfo.PropertyType.Int8, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SubtitlesGenerator_TextHorizontalAlign), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vAlign", Fox.Core.PropertyInfo.PropertyType.Int8, 233, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SubtitlesGenerator_TextVerticalAlign), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bAlign", Fox.Core.PropertyInfo.PropertyType.Int8, 234, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SubtitlesGenerator_TextBoxAlign), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fontName", Fox.Core.PropertyInfo.PropertyType.String, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("autoLineFeed", Fox.Core.PropertyInfo.PropertyType.Bool, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "key":
					return new Fox.Core.Value(key);
				case "color":
					return new Fox.Core.Value(color);
				case "offset":
					return new Fox.Core.Value(offset);
				case "size":
					return new Fox.Core.Value(size);
				case "fontSpace":
					return new Fox.Core.Value(fontSpace);
				case "lineSpace":
					return new Fox.Core.Value(lineSpace);
				case "hAlign":
					return new Fox.Core.Value(hAlign);
				case "vAlign":
					return new Fox.Core.Value(vAlign);
				case "bAlign":
					return new Fox.Core.Value(bAlign);
				case "fontName":
					return new Fox.Core.Value(fontName);
				case "autoLineFeed":
					return new Fox.Core.Value(autoLineFeed);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "key":
					this.key = value.GetValueAsString();
					return;
				case "color":
					this.color = value.GetValueAsColor();
					return;
				case "offset":
					this.offset = value.GetValueAsVector3();
					return;
				case "size":
					this.size = value.GetValueAsVector3();
					return;
				case "fontSpace":
					this.fontSpace = value.GetValueAsFloat();
					return;
				case "lineSpace":
					this.lineSpace = value.GetValueAsFloat();
					return;
				case "hAlign":
					this.hAlign = (SubtitlesGenerator_TextHorizontalAlign)value.GetValueAsInt8();
					return;
				case "vAlign":
					this.vAlign = (SubtitlesGenerator_TextVerticalAlign)value.GetValueAsInt8();
					return;
				case "bAlign":
					this.bAlign = (SubtitlesGenerator_TextBoxAlign)value.GetValueAsInt8();
					return;
				case "fontName":
					this.fontName = value.GetValueAsString();
					return;
				case "autoLineFeed":
					this.autoLineFeed = value.GetValueAsBool();
					return;
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}