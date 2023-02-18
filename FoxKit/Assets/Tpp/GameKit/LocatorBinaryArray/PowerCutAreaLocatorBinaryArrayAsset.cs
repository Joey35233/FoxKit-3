using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    public class PowerCutAreaLocatorBinaryArrayAsset : ScriptableObject
    {
        [SerializeReference]
        public List<PowerCutAreaLocatorBinary> locators = new();

        [MenuItem("FoxKit/Debug/LBA/Create PowerCutArea LBA")]
        public static void CreateMyAsset()
        {
            PowerCutAreaLocatorBinaryArrayAsset asset = ScriptableObject.CreateInstance<PowerCutAreaLocatorBinaryArrayAsset>();

            AssetDatabase.CreateAsset(asset, "Assets/delete/NewLba.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}