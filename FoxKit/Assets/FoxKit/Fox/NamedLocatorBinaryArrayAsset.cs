namespace Fox
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    public class NamedLocatorBinaryArrayAsset : ScriptableObject
    {
        [SerializeReference]
        public List<NamedLocatorBinary> locators = new List<NamedLocatorBinary>();
    
        [MenuItem("FoxKit/Debug/LBA/Create Named LBA")]
        public static void CreateMyAsset()
        {
            var asset = ScriptableObject.CreateInstance<NamedLocatorBinaryArrayAsset>() as NamedLocatorBinaryArrayAsset;

            AssetDatabase.CreateAsset(asset, "Assets/delete/NewLba.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}