using Fox.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    // [CustomEditor(typeof(DynamicProperty))]
    // public class DynamicPropertyEditor : UnityEditor.Editor
    // {
    //     public override VisualElement CreateInspectorGUI()
    //     {
    //         VisualElement container = new VisualElement();
    //
    //         var stringField = new StringField("name");
    //         stringField.bindingPath = "Info.Name";
    //         container.Add(stringField);
    //
    //         var typeField = new EnumField("type");
    //         typeField.bindingPath = "Info.Type";
    //         container.Add(typeField);
    //         
    //         return container;
    //     }
    // }
}