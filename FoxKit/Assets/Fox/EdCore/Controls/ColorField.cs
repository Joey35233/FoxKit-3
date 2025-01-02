using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class ColorField : BaseField<UnityEngine.Color>, IFoxField
    {
        private readonly IMGUIContainer InternalColorField;

        public static new readonly string ussClassName = "fox-color-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        private static readonly FieldInfo focusOnlyIfHasFocusableControlsFieldInfo = typeof(IMGUIContainer).GetField("<focusOnlyIfHasFocusableControls>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly MethodInfo set_visualInputMethodInfo = typeof(BaseField<UnityEngine.Color>).GetMethod("set_visualInput", BindingFlags.NonPublic | BindingFlags.Instance);

        public VisualElement visualInput
        {
            get;
        }

        public ColorField()
            : this(label: null)
        {
        }
        
        public ColorField(Fox.Core.PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public ColorField(string label)
            : base(label, null)
        {
            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);

            InternalColorField = new IMGUIContainer(OnGUIHandler)
            {
                name = "unity-internal-color-field"
            };
            focusOnlyIfHasFocusableControlsFieldInfo.SetValue(InternalColorField, false);

            _ = set_visualInputMethodInfo.Invoke(this, new object[] { InternalColorField });
            visualInput = InternalColorField;
            visualInput.AddToClassList(inputUssClassName);

            labelElement.focusable = false;
        }

        private void OnGUIHandler()
        {
            bool editorGUIShowMixedValue = EditorGUI.showMixedValue;
            EditorGUI.showMixedValue = showMixedValue;

            Color newColor = EditorGUILayout.ColorField(GUIContent.none, value, false, true, true);
            if (value != newColor)
                value = newColor;

            EditorGUI.showMixedValue = editorGUIShowMixedValue;
        }

        protected override void UpdateMixedValueContent()
        {
        }

        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(UnityEngine.Color))]
    // public class ColorDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new Fox.EdCore.ColorField(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<UnityEngine.Color>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}