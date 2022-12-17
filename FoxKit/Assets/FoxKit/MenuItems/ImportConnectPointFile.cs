using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Fox.Fio;

namespace FoxKit.MenuItems
{
    public static class ImportConnectPointFile
    {
        [MenuItem("FoxKit/Import/ConnectPointFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import ConnectPointFile", "", "fcnp");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new FileStreamReader(File.OpenRead(assetPath));
            var fileReader = new Fox.Core.ConnectPointFileReader();

            fileReader.Read(reader);
        }
    }
}
