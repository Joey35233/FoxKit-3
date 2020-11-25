using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.StaticArray<>))]
    public class StaticArrayDrawer : PropertyDrawer
    {
        private SerializedProperty property;
        //private  field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            const int itemCount = 1000;
            var items = new List<string>(itemCount);
            for (int i = 1; i <= itemCount; i++)
                items.Add(i.ToString());

            var list = property.GetValue();
            var list2 = (IList)list;

            var type = property.GetValue().GetType().GenericTypeArguments[0];

            Func<VisualElement> makeItem = () => new PropertyField();
            Action<VisualElement, int> bindItem = (e, i) =>
            {
                var field = e as PropertyField;
                field.BindProperty(property.GetArrayElementAtIndex(i));
            };

            var field = new ListView
            (
                list2,
                16,
                makeItem,
                bindItem
            );

            field.style.flexGrow = 1.0f;
            field.style.height = field.itemHeight * 10;
            field.showBorder = true;
            field.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            field.reorderable = true;

            var foldout = new Foldout();
            foldout.text = property.name;

            foldout.Add(field);

            return foldout;
        }

        //private void OnValueChanged(ChangeEvent<System.Byte> evt)
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
        //        field.value = (System.Byte)property.GetValue();
        //    }
        //    catch (System.NullReferenceException)
        //    {

        //    }
        //}
    }
}