using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public class NamedLocatorBinaryArrayAsset : ScriptableObject
    {
        [SerializeReference]
        public List<NamedLocatorBinary> locators = new();

        [MenuItem("FoxKit/Debug/LBA/Create Named LBA")]
        public static void CreateMyAsset()
        {
            NamedLocatorBinaryArrayAsset asset = ScriptableObject.CreateInstance<NamedLocatorBinaryArrayAsset>();

            AssetDatabase.CreateAsset(asset, "Assets/delete/NewLba.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}