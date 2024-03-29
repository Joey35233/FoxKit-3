using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class GenerateUSSPalette
    {
        private const string FolderPath = "Assets/FoxKit/Fox/Editor";
        private static readonly string[] FieldNames = new[]
        {
            "entityhandle",
            "string",
            "path",
            "fileptr",
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
            "vector3",
            "vector4",
            "quaternion",
            "matrix4",
        };

        [MenuItem("FoxKit/Debug/Generate USS Palette")]
        private static void Execute()
        {
            Texture2D paletteTexture = AssetDatabase.LoadAssetAtPath<Texture2D>($"{FolderPath}/Utils/FoxFieldColorPalette.psd");

            Color[] pixels = paletteTexture.GetPixels(0);
            Span<Color> sourceRow = new(pixels, FieldNames.Length, FieldNames.Length);
            Span<Color> adjustedRow = new(pixels, 0, FieldNames.Length);

            string foxFieldSheet = File.ReadAllText($"{FolderPath}/FoxField.uss");

            // https://forum.unity.com/threads/include-import-uss-files-inside-uss-files.718199/#post-8123477
            // Importing is supported but does not appear to work yet as of 2021.3.2f1.
            using (StreamWriter writer = File.CreateText($"{FolderPath}/FoxFieldLight.uss"))
            {
                //writer.WriteLine("@import url(\"FoxField.uss\");");
                writer.WriteLine(foxFieldSheet);
                writer.WriteLine();
                writer.WriteLine($".fox-entityhandle-field__input");
                writer.WriteLine("{");
                writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(sourceRow[0])}");
                writer.WriteLine("}");
                writer.WriteLine($".fox-entityhandle-field__input > .unity-label");
                writer.WriteLine("{");
                writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(sourceRow[0])}");
                writer.WriteLine("}");
                writer.WriteLine($".fox-entityhandle-field__input > .unity-button");
                writer.WriteLine("{");
                writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(sourceRow[0])}");
                writer.WriteLine("}");
                writer.WriteLine($".fox-entityhandle-field__input > .unity-button:hover");
                writer.WriteLine("{");
                {
                    Color.RGBToHSV(sourceRow[0], out float h, out float s, out float v);
                    v = Mathf.Clamp01(v * 1.222f);
                    writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(Color.HSVToRGB(h, s, v))}");
                }
                writer.WriteLine("}");
                for (int i = 1; i < sourceRow.Length; i++)
                {
                    writer.WriteLine($".fox-{FieldNames[i]}-field .unity-base-text-field__input");
                    writer.WriteLine("{");
                    writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(sourceRow[i])}");
                    writer.WriteLine("}");
                }
            }

            using (StreamWriter writer = File.CreateText($"{FolderPath}/FoxFieldDark.uss"))
            {
                //writer.WriteLine("@import url(\"FoxField.uss\");");
                writer.WriteLine(foxFieldSheet);
                writer.WriteLine();
                writer.WriteLine($".fox-entityhandle-field__input");
                writer.WriteLine("{");
                writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(adjustedRow[0])}");
                writer.WriteLine("}");
                writer.WriteLine($".fox-entityhandle-field__input > .unity-label");
                writer.WriteLine("{");
                writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(adjustedRow[0])}");
                writer.WriteLine("}");
                writer.WriteLine($".fox-entityhandle-field__input > .unity-button");
                writer.WriteLine("{");
                writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(adjustedRow[0])}");
                writer.WriteLine("}");
                writer.WriteLine($".fox-entityhandle-field__input > .unity-button:hover");
                writer.WriteLine("{");
                {
                    Color.RGBToHSV(adjustedRow[0], out float h, out float s, out float v);
                    v = Mathf.Clamp01(v * 1.469f);
                    writer.WriteLine($"\tbackground-color: #{ColorUtility.ToHtmlStringRGB(Color.HSVToRGB(h, s, v))}");
                }
                writer.WriteLine("}");
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