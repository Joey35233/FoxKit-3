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
	public partial class TppPlayer2AdditionalMtarData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.FilePtr> mtarFiles { get; private set; } = new Fox.DynamicArray<Fox.Core.FilePtr>();
		
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
		static TppPlayer2AdditionalMtarData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppPlayer2AdditionalMtarData", typeof(TppPlayer2AdditionalMtarData), Fox.Core.Data.ClassInfo, 80, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mtarFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "mtarFiles":
					return new Fox.Core.Value(mtarFiles);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "mtarFiles":
					return new Fox.Core.Value(this.mtarFiles[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "mtarFiles":
					while(this.mtarFiles.Count <= index) { this.mtarFiles.Add(default(Fox.Core.FilePtr)); }
					this.mtarFiles[index] = value.GetValueAsFilePtr();
					return;
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