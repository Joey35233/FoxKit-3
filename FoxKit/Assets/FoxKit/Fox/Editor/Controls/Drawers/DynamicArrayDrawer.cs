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
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            IList list = property.GetValue() as IList;

            Func<VisualElement> makeItem = () =>
            {
                var entryField = new PropertyField();

                return entryField;
            };
            Action<VisualElement, int> bindItem = (e, i) =>
            {
                var entryField = e as PropertyField;
                var privateList = property.FindPropertyRelative("_list");
                var entry = privateList.GetArrayElementAtIndex(i);

                entryField.BindProperty(entry);

                var oldLabel = entryField.Query<Label>().First();
                var parent = oldLabel.parent;
                parent.Remove(oldLabel);
                var label = new Label($"[{i}]");
                label.AddToClassList("fox-listview-entry-label");
                foreach (var cssClass in oldLabel.GetClasses())
                    label.AddToClassList(cssClass);
                parent.Insert(0, label);
            };

            ListView listView = new ListView
            (
                list,
                20,
                makeItem,
                bindItem
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
    }
}