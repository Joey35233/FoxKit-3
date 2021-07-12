using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.Core.StaticArray<>))]
    public class StaticArrayDrawer : PropertyDrawer
    {
        SerializedProperty InternalListProperty;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            IList list = property.GetValue() as IList;
            InternalListProperty = property.FindPropertyRelative("_list");

            object genericList = property.GetValue();
            Type genericArgument = genericList.GetType().GetGenericArguments()[0];

            ListView listView = new ListView
            (
                list,
                CollectionDrawer.GetListEntrySize(genericArgument),
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
            var entryField = new PropertyField();
            entryField.styleSheets.Add(CollectionDrawer.PropertyDrawerStyleSheet);

            return entryField;
        }

        private void BindItem(VisualElement element, int index)
        {
            var entryField = element as PropertyField;
            var entry = InternalListProperty.GetArrayElementAtIndex(index);

            entryField.BindProperty(entry);

            var oldLabel = entryField.Query<Label>().First();
            var parent = oldLabel.parent;
            parent.Remove(oldLabel);
            var label = new Label($"[{index}]");
            label.AddToClassList("fox-listview-entry-label");
            foreach (var cssClass in oldLabel.GetClasses())
                label.AddToClassList(cssClass);
            parent.Insert(0, label);
        }
    }
}