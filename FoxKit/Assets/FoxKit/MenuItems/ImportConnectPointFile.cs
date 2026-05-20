using Fox.Core;
using Fox.Fio;
using UnityEditor;

namespace FoxKit.MenuItems
{
    public static class ImportConnectPointFile
    {
        [MenuItem("FoxKit/Import/ConnectPointFile")]
        private static void OnImportAsset()
        {
            string assetPath = Fox.Fs.FileUtils.OpenFilePanel("Import ConnectPointFile", "", "fcnp");
            if (System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }
            // using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var fcnpReader = new ConnectPointFileReader();
            // fcnpReader.Read(reader);

            fcnpReader.ReadUnsafe(System.IO.File.ReadAllBytes(assetPath));
        }
    }
}
