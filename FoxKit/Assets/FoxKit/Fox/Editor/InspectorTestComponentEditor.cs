using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomEditor(typeof(InspectorTestComponent))]
    public class InspectorTestComponentEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/InspectorTestComponentEditor.uxml");
            var ui = uxmlTemplate.CloneTree();
            return ui;
        }
    }
}