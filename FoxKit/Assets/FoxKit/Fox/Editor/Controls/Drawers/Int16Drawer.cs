using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Int16))]
    public class Int16Drawer : PropertyDrawer
    {
        private SerializedProperty property;
        private Int16Field field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            field = new Int16Field();
            field.label = property.name;
            field.value = (System.Int16)property.GetValue();
            field.RegisterValueChangedCallback(OnValueChanged);

            Undo.undoRedoPerformed += OnValueUndoneRedone;

            return field;
        }

        private void OnValueChanged(ChangeEvent<System.Int16> evt)
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
                field.value = (System.Int16)property.GetValue();
            }
            catch (System.NullReferenceException)
            {

            }
        }
    }
}