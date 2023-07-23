using System;
using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Gr.Editor
{
    [CustomEditor(typeof(TerrainMapAsset))]
    public class TerrainFileAssetEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement wrapper = new();

            var exportButton = new Button
            {
                text = "Export"
            };

            exportButton.clicked += OnExport;
            wrapper.Add(exportButton);

            SerializedProperty child = serializedObject.GetIterator();
            if (child.NextVisible(true))
            {
                do
                {
                    if (child.name != "m_Script")
                        wrapper.Add(new PropertyField(child));
                } while (child.NextVisible(false));
            }

            return wrapper;
        }

        private void OnExport()
        {
            //var terrain = this.target as TerrainFileAsset;
            //string outputPath = EditorUtility.SaveFilePanel("Export TerrainFile", "", $"{terrain.name}", "tre2");
            //if (System.String.IsNullOrEmpty(outputPath))
            //{
            //    return;
            //}

            //using var binWriter = new BinaryWriter(System.IO.File.Open(outputPath, FileMode.Create), System.Text.Encoding.Default);
            //var writer = new TerrainFileWriter();
            //writer.Write(binWriter, terrain);
        }
    }
}