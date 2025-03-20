using Fox.Fio;
using Fox.Geo;
using UnityEditor;

namespace FoxKit.MenuItems
{
    public class ImportGeoFile
    {
        [MenuItem("FoxKit/Import/GeoFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import GeoFile", "", "geom,geoms,gskl");
            if (System.String.IsNullOrEmpty(assetPath))
                return;

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var geoReader = new GeoFileReader();
            geoReader.Read(reader);
        }

    }
}
