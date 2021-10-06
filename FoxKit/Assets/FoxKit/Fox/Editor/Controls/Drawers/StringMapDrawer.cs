using Fox.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.Core.StringMap<>.Cell))]
    public class StringMapCellDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.AddToClassList("unity-base-field");
            container.AddToClassList("unity-composite-field");
            container.style.marginTop = 0;
            container.style.marginBottom = 0;
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

            var valueField = new PropertyField(property.FindPropertyRelative("Value"));
            valueField.AddToClassList("unity-composite-field__field");
            valueField.AddToClassList("fox-stringmap-value-field");
            innerContainer.Add(valueField);

            container.Add(innerContainer);

            return container;
        }
    }

    [CustomPropertyDrawer(typeof(Fox.Core.StringMap<>))]
    public class StringMapDrawer : PropertyDrawer
    {
        SerializedProperty InternalListProperty;
        IStringMap InternalStringMap;
        Type CollectionTypeArgument;
        Func<BindableElement> FieldConstructor;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            InternalListProperty = property.FindPropertyRelative("Cells");

            var stringMapList = property.GetValue() as IList;
            InternalStringMap = property.GetValue() as IStringMap;

            object genericStringMap = property.GetValue();
            CollectionTypeArgument = genericStringMap.GetType().GetGenericArguments()[0];

            FieldConstructor = CollectionDrawer.GetTypeFieldConstructor(CollectionTypeArgument);

            ListView field = new ListView
            (
                stringMapList,
                20,
                MakeItem,
                BindItem
            );
            field.AddToClassList("fox-stringmap");

            field.style.height = field.itemHeight * 10;
            field.selectionType = SelectionType.Multiple;
            field.showBorder = true;
            field.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            field.reorderable = false;

            var foldout = new Foldout();
            foldout.styleSheets.Add(CollectionDrawer.PropertyDrawerStyleSheet);
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
                String popupResult = StringMapDrawerPopup.ShowPopup();

                if (popupResult != null)
                {
                    duplicateKeyLabel.visible = false;

                    if (InternalStringMap.ContainsKey(popupResult))
                    {
                        duplicateKeyLabel.visible = true;
                    }
                    else
                    {
                        InternalStringMap.Insert(popupResult);

                        property.serializedObject.ApplyModifiedProperties();

                        field.Refresh();
                    }

                    return;
                }
            };

            var removeButton = new Button();
            removeButton.AddToClassList("fox-listview-remove-button");
            removeButton.text = "-";
            removeButton.clicked += () =>
            // Remove item
            {
                duplicateKeyLabel.visible = false;

                List<String> keys = new List<String>();
                {
                    var privateList = property.FindPropertyRelative("Cells");

                    if (field.selectedIndex != -1)
                        foreach (var index in field.selectedIndices)
                            keys.Add(privateList.GetArrayElementAtIndex(InternalStringMap.OccupiedIndexToAbsoluteIndex(index)).FindPropertyRelative("Key").GetValue() as String);
                    else
                        privateList.DeleteArrayElementAtIndex(privateList.arraySize - 1);
                }

                foreach (var key in keys)
                    InternalStringMap.Remove(key);

                property.serializedObject.ApplyModifiedProperties();

                field.Refresh();
            };

            bottomContainer.Add(removeButton);
            bottomContainer.Add(addButton);
            bottomContainer.Add(duplicateKeyLabel);

            foldout.Add(bottomContainer);

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
                var entry = InternalListProperty.GetArrayElementAtIndex(InternalStringMap.OccupiedIndexToAbsoluteIndex(index));

                entryField.BindProperty(entry, $"[{index}]", new string[] { "fox-listview-entry-label" });
            }
            else if (element is IFoxNumericField)
            {
                var entryField = element as IFoxNumericField;
                var entry = InternalListProperty.GetArrayElementAtIndex(InternalStringMap.OccupiedIndexToAbsoluteIndex(index));

                entryField.BindProperty(entry, $"[{index}]", new string[] { "fox-listview-entry-label" });
            }
        }
    }
}