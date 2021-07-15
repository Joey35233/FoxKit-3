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
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/delete/DataSet/Editor/InspectorTestComponentEditor.uxml");
            var ui = uxmlTemplate.CloneTree();
            return ui;
        }
    }
    [CustomEditor(typeof(InspectorTestComponent2))]
    public class InspectorTestComponent2Editor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/delete/DataSet/Editor/InspectorTestComponentEditor.uxml");
            var ui = uxmlTemplate.CloneTree();
            return ui;
        }
    }
}