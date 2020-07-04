namespace Fox
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    public class DataSetAsset : ScriptableObject
    {
        [SerializeReference]
        public InspectorTestData test = new InspectorTestData();
    
        [MenuItem("FoxKit/Debug/FOX2/Create DataSet")]
        public static void CreateMyAsset()
        {
            var asset = ScriptableObject.CreateInstance<DataSetAsset>() as DataSetAsset;

            AssetDatabase.CreateAsset(asset, "Assets/delete/DataSet.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}