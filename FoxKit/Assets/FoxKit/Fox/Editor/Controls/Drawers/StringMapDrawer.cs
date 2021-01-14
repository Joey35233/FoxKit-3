using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.StringMap<>.Cell))]
    public class StringMapCellDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.AddToClassList("unity-base-field");
            container.AddToClassList("unity-composite-field");
            container.style.marginRight = 0;

            var label = new Label(property.name);
            label.AddToClassList("unity-base-field__label");
            label.AddToClassList("unity-property-field__label");
            label.AddToClassList("fox-listview-entry-label");
            container.Add(label);

            var innerContainer = new VisualElement();
            innerContainer.AddToClassList("unity-base-field__input");
            innerContainer.AddToClassList("unity-composite-field__input");

            var keyField = new PropertyField(property.FindPropertyRelative("Key"));
            keyField.AddToClassList("unity-composite-field__field");
            keyField.AddToClassList("unity-composite-field__field--first");
            keyField.AddToClassList("fox-stringmap-key-field");
            innerContainer.Add(keyField);

            //keyField.RegisterCallback<EventCallback<>

            var valueField = new PropertyField(property.FindPropertyRelative("Value"));
            valueField.AddToClassList("unity-composite-field__field");
            valueField.AddToClassList("fox-stringmap-value-field");
            innerContainer.Add(valueField);

            container.Add(innerContainer);

            return container;
        }
    }

    [CustomPropertyDrawer(typeof(Fox.StringMap<>))]
    public class StringMapDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var cellListProperty = property.FindPropertyRelative("_cells");
            var cellList = cellListProperty.GetValue() as IList;

            Func<VisualElement> makeItem = () =>
            {
                var entryField = new PropertyField();

                return entryField;
            };
            Action<VisualElement, int> bindItem = (e, i) =>
            {
                var entryField = e as PropertyField;
                var entry = cellListProperty.GetArrayElementAtIndex(i);

                entryField.BindProperty(entry);
                var fieldLabel = entryField.Query<Label>().First();
                fieldLabel.text = $"[{i}]";
            };

            var field = new ListView
            (
                cellList,
                20,
                makeItem,
                bindItem
            );
            field.AddToClassList("fox-stringmap");

            field.style.height = field.itemHeight * 10;
            field.showBorder = true;
            field.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            field.reorderable = true;

            var foldout = new Foldout();
            foldout.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/StaticArrayDrawer.uss"));
            foldout.text = property.name;

            foldout.Add(field);

            var bottomContainer = new VisualElement();
            bottomContainer.style.flexDirection = FlexDirection.RowReverse;
            bottomContainer.style.alignItems = Align.FlexEnd;

            var duplicateKeyLabel = new Label { text = "Cannot have two entries with the same key." };
            duplicateKeyLabel.style.color = UnityEngine.Color.red;
            duplicateKeyLabel.style.flexGrow = 1;
            duplicateKeyLabel.style.alignSelf = Align.Center;
            duplicateKeyLabel.visible = false;

            var addButton = new Button();
            addButton.AddToClassList("fox-listview-add-button");
            addButton.text = "+";
            addButton.clicked += () =>
            // Add item
            {
                Action validKeyLambda = () =>
                {
                    cellListProperty.InsertArrayElementAtIndex(cellListProperty.arraySize);

                    property.serializedObject.ApplyModifiedProperties();

                    field.Refresh();
                    field.ScrollToItem(cellListProperty.arraySize + 10);
                };

                var popupResult = StringMapDrawerPopup.ShowPopup();

                if (popupResult != null)
                {
                    duplicateKeyLabel.visible = false;

                    // StringMap.TryGet "algorithm"
                    bool hasDuplicate = false;
                    for (int i = 0; i < cellListProperty.arraySize; i++)
                    {
                        var cellProperty = cellListProperty.GetArrayElementAtIndex(i);
                        var keyProperty = cellProperty.FindPropertyRelative("Key");
                        if (popupResult == keyProperty.GetValue() as String)
                            hasDuplicate = true;
                    }
                    if (hasDuplicate)
                    {
                        duplicateKeyLabel.visible = true;
                    }
                    else
                    {
                        var privateList = property.FindPropertyRelative("_cells");

                        privateList.arraySize++;
                        property.serializedObject.ApplyModifiedProperties();

                        var entry = privateList.GetArrayElementAtIndex(privateList.arraySize - 1);

                        var childProperty = entry.FindPropertyRelative("Key");
                        childProperty.SetValue(popupResult);

                        property.serializedObject.ApplyModifiedProperties();

                        field.Refresh();
                    }
                }

                return;
            };

            var removeButton = new Button();
            removeButton.AddToClassList("fox-listview-remove-button");
            removeButton.text = "-";
            removeButton.clicked += () =>
            // Remove item
            {
                duplicateKeyLabel.visible = false;

                var privateList = property.FindPropertyRelative("_cells");

                if (field.selectedIndex != -1)
                    foreach (var index in field.selectedIndices)
                        privateList.DeleteArrayElementAtIndex(index);
                else
                    privateList.DeleteArrayElementAtIndex(privateList.arraySize - 1);

                property.serializedObject.ApplyModifiedProperties();

                field.Refresh();
            };

            bottomContainer.Add(removeButton);
            bottomContainer.Add(addButton);
            bottomContainer.Add(duplicateKeyLabel);

            foldout.Add(bottomContainer);

            return foldout;
        }
    }
}