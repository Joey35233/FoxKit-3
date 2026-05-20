using Fox.Anim;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class ImportMtarFile
    {
        [MenuItem("FoxKit/Import/MtarFile")]
        private static void OnImportAsset()
        {
            string assetPath = Fox.Fs.FileUtils.OpenFilePanel("Import MtarFile", "", "mtar");
            if (System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            AnimationClip clip = MtarFile.Convert(System.IO.File.ReadAllBytes(assetPath));
            
            AssetDatabase.CreateAsset(clip, "Assets/TESTOBJECT.asset");
            AssetDatabase.SaveAssets();
        }
    }
}