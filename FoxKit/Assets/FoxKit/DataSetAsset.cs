using UnityEngine;
using UnityEditor;
using Fox;
using Fox.Core;

namespace FoxKit
{
    public class DataSetAsset : ScriptableObject
    {
        [SerializeReference]
        public InspectorTestData test = new InspectorTestData();

        [SerializeReference]
        public Fox.Core.DataSet dataSet = new Fox.Core.DataSet();

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