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
            foldout.styleSheets.Add(CollectionDrawer.PropertyDrawerStyleSheet);
            foldout.text = property.name;

            foldout.Add(listView);

            return foldout;
        }

        private VisualElement MakeItem()
        {
            VisualElement container = new();

            var entryField = FieldConstructor();
            entryField.AddToClassList("fox-compound-field-element");

            container.Add(entryField);

            return container;
        }

        private void BindItem(VisualElement element, int index)
        {
            //element = element.Children().First();

            //if (element is BindableElement)
            //{
            //    var entryField = element as BindableElement;
            //    var entry = InternalListProperty.GetArrayElementAtIndex(index);

            //    entryField.BindProperty(entry/*, $"[{index}]"*/);
            //}
            //else
            //    return;

            //var labelElement = element.Q<Label>();
            //labelElement?.AddToClassList("fox-compound-field-element__label");
            //labelElement.style.minWidth = 20;
        }
    }
}