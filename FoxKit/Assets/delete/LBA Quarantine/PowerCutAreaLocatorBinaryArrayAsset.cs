namespace Fox
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    public class PowerCutAreaLocatorBinaryArrayAsset : ScriptableObject
    {
        [SerializeReference]
        public List<PowerCutAreaLocatorBinary> locators = new List<PowerCutAreaLocatorBinary>();
    
        [MenuItem("FoxKit/Debug/LBA/Create PowerCutArea LBA")]
        public static void CreateMyAsset()
        {
            var asset = ScriptableObject.CreateInstance<PowerCutAreaLocatorBinaryArrayAsset>() as PowerCutAreaLocatorBinaryArrayAsset;

            AssetDatabase.CreateAsset(asset, "Assets/delete/NewLba.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}