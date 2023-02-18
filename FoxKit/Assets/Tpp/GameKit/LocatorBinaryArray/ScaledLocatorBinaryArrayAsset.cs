using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public class ScaledLocatorBinaryArrayAsset : ScriptableObject
    {
        [SerializeReference]
        public List<ScaledLocatorBinary> locators = new();

        [MenuItem("FoxKit/Debug/LBA/Create Scaled LBA")]
        public static void CreateMyAsset()
        {
            ScaledLocatorBinaryArrayAsset asset = ScriptableObject.CreateInstance<ScaledLocatorBinaryArrayAsset>();

            AssetDatabase.CreateAsset(asset, "Assets/delete/NewLba.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}