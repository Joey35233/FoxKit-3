using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.DynamicArray<>))]
    public class DynamicArrayDrawer : PropertyDrawer
    {
        private SerializedProperty property;
        private VisualElement root;
        private ListView field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            var list = property.GetValue() as IList;

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
                var label = entryField.Query<Label>().First();
                label.AddToClassList("fox-listview-entry-label");
                label.text = $"[{i}]";
            };

            field = new ListView
            (
                list,
                20,
                makeItem,
                bindItem
            );

            field.style.flexGrow = 1.0f;
            field.style.height = field.itemHeight * 10;
            field.showBorder = true;
            field.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            field.reorderable = true;

            var foldout = new Foldout();
            foldout.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/StaticArrayDrawer.uss"));
            foldout.text = property.name;

            foldout.Add(field);

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

                field.Refresh();
                field.ScrollToItem(privateList.arraySize + 10);
            };

            var removeButton = new Button();
            removeButton.AddToClassList("fox-listview-remove-button");
            removeButton.text = "-";
            removeButton.clicked += () =>
            {
                var privateList = property.FindPropertyRelative("_list");

                if (field.selectedIndex != -1)
                    foreach (var index in field.selectedIndices)
                        privateList.DeleteArrayElementAtIndex(index);
                else
                    privateList.DeleteArrayElementAtIndex(privateList.arraySize - 1);

                property.serializedObject.ApplyModifiedProperties();

                field.Refresh();

                field.SetSelection(privateList.arraySize - 1);
            };

            buttonContainer.Add(removeButton);
            buttonContainer.Add(addButton);

            foldout.Add(buttonContainer);

            root = foldout;

            return root;
        }
    }
}