using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace FoxKit.MenuItems
{
	public static class GenerateUSSPalette
	{
		const string FolderPath = "Assets/FoxKit/Fox/Editor/Controls/Utils";

		readonly static string[] FieldNames = new[]
		{
			"quaternion",
			"vector3",
			"vector4",
			"matrix4",
			"entityhandle",
			"string",
			"path",
			"float",
			"double",
			"enum",
			"enum-flags",
			"uint8",
			"uint16",
			"uint32",
			"uint64",
			"int8",
			"int16",
			"int32",
			"int64",
		};

		[MenuItem("FoxKit/Debug/Generate USS Palette")]
		static void Execute()
        {
			Texture2D paletteTexture = AssetDatabase.LoadAssetAtPath<Texture2D>($"{FolderPath}/FoxFieldColorPalette.psd");

			Color[] pixels = paletteTexture.GetPixels(0);

			Span<Color> sourceRow = new(pixels, 19, 19);
			Span<Color> adjustedRow = new(pixels, 0, 19);

			using (var writer = File.CreateText($"{FolderPath}/FoxFieldColorPalette.uss"))
			{
				writer.WriteLine("/* Light */");
				for (int i = 0; i < sourceRow.Length; i++)
				{
                    writer.WriteLine($".fox-{FieldNames[i]}-field .unity-base-text-field__input");
                    writer.WriteLine("{");
                    writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(sourceRow[i])}");
					writer.WriteLine("}");
				}

				writer.WriteLine();
				writer.WriteLine("/* Dark */");
				for (int i = 0; i < adjustedRow.Length; i++)
                {
                    writer.WriteLine($".fox-{FieldNames[i]}-field .unity-base-text-field__input");
                    writer.WriteLine("{");
                    writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(adjustedRow[i])}");
                    writer.WriteLine("}");
                }
            }
		}
	}

}