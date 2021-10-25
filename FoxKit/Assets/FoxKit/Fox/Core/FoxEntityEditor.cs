using Fox.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    [CustomEditor(typeof(FoxEntity))]
    public class FoxEntityEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var field = new PropertyField(serializedObject.FindProperty("Entity"));

            return field;
        }
    }
}