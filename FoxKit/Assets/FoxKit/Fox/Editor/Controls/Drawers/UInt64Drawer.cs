using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.UInt64))]
    public class UInt64Drawer : PropertyDrawer
    {
        private SerializedProperty property;
        private UInt64Field field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            field = new UInt64Field();
            field.label = property.name;
            field.PreBindProperty(property);
            field.BindProperty(property);
            field.labelElement.AddToClassList("unity-property-field__label");
            field.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);

            return field;
        }

        //private void OnValueChanged(ChangeEvent<System.UInt64> evt)
        //{
        //    this.property.SetValue(evt.newValue);
        //}

        //private void OnValueUndoneRedone()
        //{
        //    // When the inspector is not visible, SerializedProperty is Disposed but *NOT* null. Any attempts to confirm this in code result in a custom NullReferenceException.
        //    // field.visible is always true, Finalizers for this drawer are never called.
        //    // Storing the targetObject to later create a new SerializedObject + .FindProperty() doesn't work either. Both vars look fine until the assignment code is called,
        //    // then back to the same NRE.
        //    try
        //    {
        //        field.value = (System.UInt64)property.GetValue();
        //    }
        //    catch (System.NullReferenceException)
        //    {

        //    }
        //}
    }
}