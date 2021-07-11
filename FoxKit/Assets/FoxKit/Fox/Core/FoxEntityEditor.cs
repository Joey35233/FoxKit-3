using Fox.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomEditor(typeof(FoxEntity))]
    public class FoxEntitytEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Core/FoxEntityEditor.uxml");
            var ui = uxmlTemplate.CloneTree();
            return ui;
        }
    }
}