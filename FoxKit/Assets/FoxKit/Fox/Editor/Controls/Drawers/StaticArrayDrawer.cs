using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Core.StaticArray<>))]
    public class StaticArrayDrawer : PropertyDrawer
    {
        SerializedProperty InternalListProperty;
        Type CollectionTypeArgument;
        Func<BindableElement> FieldConstructor;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            IList list = property.GetValue() as IList;
            InternalListProperty = property.FindPropertyRelative("_list");

            object genericList = property.GetValue();
            CollectionTypeArgument = genericList.GetType().GetGenericArguments()[0];

            FieldConstructor = CollectionDrawer.GetTypeFieldConstructor(CollectionTypeArgument);

            ListView listView = new ListView
            (
                list,
                CollectionDrawer.GetListEntrySize(CollectionTypeArgument),
                MakeItem,
                BindItem
            );

            listView.style.flexGrow = 1.0f;
            listView.style.height = listView.itemHeight * 10;
            listView.showBorder = true;
            listView.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            listView.reorderable = true;

            var foldout = new Foldout();
            foldout.text = property.name;

            foldout.Add(listView);

            return foldout;
        }

        private VisualElement MakeItem()
        {
            var entryField = FieldConstructor();
            entryField.styleSheets.Add(CollectionDrawer.PropertyDrawerStyleSheet);

            return entryField;
        }

        private void BindItem(VisualElement element, int index)
        {
            if (element is IFoxField)
            {
                var entryField = element as IFoxField;
                var entry = InternalListProperty.GetArrayElementAtIndex(index);

                entryField.BindProperty(entry, $"[{index}]", new string[] { "fox-listview-entry-label" });
            }
            else if (element is IFoxNumericField)
            {
                var entryField = element as IFoxNumericField;
                var entry = InternalListProperty.GetArrayElementAtIndex(index);

                entryField.BindProperty(entry, $"[{index}]", new string[] { "fox-listview-entry-label" });
            }
        }
    }
}