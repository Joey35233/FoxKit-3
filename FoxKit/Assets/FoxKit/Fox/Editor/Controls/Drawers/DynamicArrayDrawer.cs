using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.Core.DynamicArray<>))]
    public class DynamicArrayDrawer : PropertyDrawer
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
            listView.style.height = listView.fixedItemHeight * 10;
            listView.showBorder = true;
            listView.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            listView.reorderable = true;

            var foldout = new Foldout();
            foldout.styleSheets.Add(CollectionDrawer.PropertyDrawerStyleSheet);
            foldout.text = property.name;

            foldout.Add(listView);

            var buttonContainer = new VisualElement();
            buttonContainer.style.flexDirection = FlexDirection.Row;

            var addButton = new Button();
            addButton.AddToClassList("fox-dynamic-field-add-button");
            addButton.text = "+";
            addButton.clicked += () =>
            {
                var privateList = property.FindPropertyRelative("_list");
                privateList.InsertArrayElementAtIndex(privateList.arraySize);

                property.serializedObject.ApplyModifiedProperties();

                listView.Rebuild();
                listView.ScrollToItem(privateList.arraySize + 10);
            };

            var removeButton = new Button();
            removeButton.AddToClassList("fox-dynamic-field-remove-button");
            removeButton.text = "-";
            removeButton.clicked += () =>
            {
                var privateList = property.FindPropertyRelative("_list");

                if (listView.selectedIndex != -1)
                    foreach (var index in listView.selectedIndices)
                        privateList.DeleteArrayElementAtIndex(index);
                else
                    privateList.DeleteArrayElementAtIndex(privateList.arraySize - 1);

                property.serializedObject.ApplyModifiedProperties();

                listView.Rebuild();

                listView.SetSelection(privateList.arraySize - 1);
            };

            buttonContainer.Add(addButton);
            buttonContainer.Add(removeButton);

            foldout.Add(buttonContainer);

            foldout.AddToClassList("fox-compound-field");
            foldout.AddToClassList("fox-dynamicarray-field");
            return foldout;
        }

        private VisualElement MakeItem()
        {
            var entryField = FieldConstructor();
            entryField.AddToClassList("fox-compound-field-element");

            return entryField;
        }

        private void BindItem(VisualElement element, int index)
        {
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