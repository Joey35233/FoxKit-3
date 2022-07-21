using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine;
using System.Reflection;

namespace Fox.Editor
{
    public class ColorField : BaseField<UnityEngine.Color>, IFoxField, ICustomBindable
    {
        private IMGUIContainer InternalColorField;

        public new static readonly string ussClassName = "fox-color-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        private static FieldInfo focusOnlyIfHasFocusableControlsFieldInfo = typeof(IMGUIContainer).GetField("<focusOnlyIfHasFocusableControls>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
        private static MethodInfo set_visualInputMethodInfo = typeof(BaseField<UnityEngine.Color>).GetMethod("set_visualInput", BindingFlags.NonPublic | BindingFlags.Instance);

        public VisualElement visualInput { get; }

        public ColorField()
            : this(null) 
        { 
        }

        public ColorField(string label)
            : base(label, null)
        {
            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);

            InternalColorField = new IMGUIContainer(OnGUIHandler);
            InternalColorField.name = "unity-internal-color-field";
            focusOnlyIfHasFocusableControlsFieldInfo.SetValue(InternalColorField, false);
            
            set_visualInputMethodInfo.Invoke(this, new object[] { InternalColorField });
            visualInput = InternalColorField;
            visualInput.AddToClassList(inputUssClassName);

            labelElement.focusable = false;
        }

        private void OnGUIHandler()
        {
            var editorGUIShowMixedValue = EditorGUI.showMixedValue;
            EditorGUI.showMixedValue = showMixedValue;

            Color newColor = EditorGUILayout.ColorField(GUIContent.none, value, false, true, true);
            if (value != newColor)
                value = newColor;

            EditorGUI.showMixedValue = editorGUIShowMixedValue;
        }

        protected override void UpdateMixedValueContent()
        {
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Color))]
    public class ColorDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Fox.Editor.ColorField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<UnityEngine.Color>.alignedFieldUssClassName);

            return field;
        }
    }
}