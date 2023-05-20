using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public class ObjectBrushAsset : ScriptableObject
    {
        public float blockSizeW;
        public float blockSizeH;
        public uint numBlocksW;
        public uint numBlocksH;
        [SerializeReference]
        public List<ObjectBrushObjectBinary> objects = new();
        [MenuItem("FoxKit/Debug/OBR/Create OBR")]
        public static void CreateMyAsset()
        {
            ObjectBrushAsset asset = ScriptableObject.CreateInstance<ObjectBrushAsset>();

            AssetDatabase.CreateAsset(asset, "Assets/delete/NewObr.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
