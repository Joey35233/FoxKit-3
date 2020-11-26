using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.UInt32))]
    public class UInt32Drawer : PropertyDrawer
    {
        private SerializedProperty property;
        private UInt32Field field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            field = new UInt32Field();
            field.label = property.name;
            field.value = (System.UInt32)property.GetValue();
            field.RegisterValueChangedCallback(OnValueChanged);
            field.labelElement.AddToClassList("unity-property-field__label");

            Undo.undoRedoPerformed += OnValueUndoneRedone;

            return field;
        }

        private void OnValueChanged(ChangeEvent<System.UInt32> evt)
        {
            this.property.SetValue(evt.newValue);
        }

        private void OnValueUndoneRedone()
        {
            // When the inspector is not visible, SerializedProperty is Disposed but *NOT* null. Any attempts to confirm this in code result in a custom NullReferenceException.
            // field.visible is always true, Finalizers for this drawer are never called.
            // Storing the targetObject to later create a new SerializedObject + .FindProperty() doesn't work either. Both vars look fine until the assignment code is called,
            // then back to the same NRE.
            try
            {
                field.value = (System.UInt32)property.GetValue();
            }
            catch (System.NullReferenceException)
            {

            }
        }
    }
}