using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FoxKit.Config.Internal
{
    public class FoxKitStartupState : ScriptableObject
    {
        private const string AssetPath = "Assets/FoxKit/FoxKitStartupState.asset";

        [SerializeField]
        public string ExportConfigPath;

        public static FoxKitStartupState GetInstance()
        {
            FoxKitStartupState state = AssetDatabase.LoadAssetAtPath<FoxKitStartupState>(AssetPath);
            if (state == null)
            {
                state = ScriptableObject.CreateInstance<FoxKitStartupState>();
                AssetDatabase.CreateAsset(state, AssetPath);
                AssetDatabase.SaveAssets();
            }

            return state;
        }
    }

}