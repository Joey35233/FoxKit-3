using Fox.Core;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(FilePtr<>))]
    public class FilePtrDrawer : PropertyDrawer
    {
        private SerializedProperty fileProperty;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.fileProperty = property.FindPropertyRelative("file");

            var container = new VisualElement();
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/Controls/Drawers/FilePtrDrawer.uxml");
            var drawer = uxmlTemplate.CloneTree(property.propertyPath);

            var picker = drawer.Q<ObjectField>();
            picker.value = this.fileProperty.GetValue() as UnityEngine.Object;
            picker.label = property.name;
            picker.allowSceneObjects = false;
            picker.labelElement.AddToClassList("unity-property-field__label");

            // TODO: Filter this by asset type
            picker.objectType = typeof(UnityEngine.Object);
            picker.RegisterValueChangedCallback(OnValueChanged);

            container.Add(drawer);
            return container;
        }

        private void OnValueChanged(ChangeEvent<UnityEngine.Object> evt)
        {
            // TODO Figure out why undo doesn't appear instantly
            Undo.RecordObject(this.fileProperty.serializedObject.targetObject, "FilePtr");
            this.fileProperty.SetValue(evt.newValue);
            this.fileProperty.serializedObject.ApplyModifiedProperties();
        }
    }
}