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
            listView.style.height = listView.itemHeight * 10;
            listView.showBorder = true;
            listView.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            listView.reorderable = true;

            var foldout = new Foldout();
            foldout.styleSheets.Add(CollectionDrawer.PropertyDrawerStyleSheet);
            foldout.text = property.name;

            foldout.Add(listView);

            var buttonContainer = new VisualElement();
            buttonContainer.style.flexDirection = FlexDirection.RowReverse;
            buttonContainer.style.alignItems = Align.FlexEnd;

            var addButton = new Button();
            addButton.AddToClassList("fox-listview-add-button");
            addButton.text = "+";
            addButton.clicked += () =>
            {
                var privateList = property.FindPropertyRelative("_list");
                privateList.InsertArrayElementAtIndex(privateList.arraySize);

                property.serializedObject.ApplyModifiedProperties();

                listView.Refresh();
                listView.ScrollToItem(privateList.arraySize + 10);
            };

            var removeButton = new Button();
            removeButton.AddToClassList("fox-listview-remove-button");
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

                listView.Refresh();

                listView.SetSelection(privateList.arraySize - 1);
            };

            buttonContainer.Add(removeButton);
            buttonContainer.Add(addButton);

            foldout.Add(buttonContainer);

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
            if (element is FoxField)
            {
                var entryField = element as FoxField;
                var entry = InternalListProperty.GetArrayElementAtIndex(index);

                entryField.BindProperty(entry, $"[{index}]");
            }
            else if (element is IFoxNumericField)
            {
                var entryField = element as IFoxNumericField;
                var entry = InternalListProperty.GetArrayElementAtIndex(index);

                entryField.BindProperty(entry, $"[{index}]");
            }
            else
            {
                throw new ArgumentException($"Invalid type: {element}");
            }
        }
    }
}