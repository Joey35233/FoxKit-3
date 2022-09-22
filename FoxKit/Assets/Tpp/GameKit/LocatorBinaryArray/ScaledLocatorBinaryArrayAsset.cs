using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Tpp.GameKit
{
    public class ScaledLocatorBinaryArrayAsset : ScriptableObject
    {
        [SerializeReference]
        public List<ScaledLocatorBinary> locators = new List<ScaledLocatorBinary>();
    
        [MenuItem("FoxKit/Debug/LBA/Create Scaled LBA")]
        public static void CreateMyAsset()
        {
            var asset = ScriptableObject.CreateInstance<ScaledLocatorBinaryArrayAsset>() as ScaledLocatorBinaryArrayAsset;

            AssetDatabase.CreateAsset(asset, "Assets/delete/NewLba.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}