using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomEditor(typeof(InspectorTestComponent))]
    public class InspectorTestComponentEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement wrapper = new();

            foreach (SerializedProperty child in serializedObject.FindProperty("data").GetChildren())
            {
                wrapper.Add(new PropertyField(child));
            }

            return wrapper;
        }
    }
    [CustomEditor(typeof(InspectorTestComponent2))]
    public class InspectorTestComponent2Editor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement wrapper = new();

            foreach (SerializedProperty child in serializedObject.FindProperty("data").GetChildren())
            {
                wrapper.Add(new PropertyField(child));
            }

            return wrapper;
        }
    }
}