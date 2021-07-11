using Fox.Core;
using System.IO;
using UnityEditor;

namespace FoxKit.MenuItems
{
    public static class ImportDataSet
    {
        [MenuItem("FoxKit/Import/DataSet")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import DataSet", "", "fox2,bnd,clo,des,evf,fsd,lad,parts,ph,phsd,sdf,sim,tgt,vdp,veh,vfxlf");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new BinaryReader(System.IO.File.OpenRead(assetPath));
            var fox2Reader = new DataSetFile2Reader();
            var entities = fox2Reader.Read(reader);
        }
    }
}