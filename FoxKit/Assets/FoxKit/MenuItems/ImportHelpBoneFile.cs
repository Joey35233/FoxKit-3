using Fox.Animx;
using UnityEditor;

namespace FoxKit.MenuItems
{
    public static class ImportHelpBoneFile
    {
        [MenuItem("FoxKit/Import/HelpBoneFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import HelpBoneFile", "", "frdv");
            if (System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            HelpBoneFile.Read(System.IO.File.ReadAllBytes(assetPath));
        }
    }
}
