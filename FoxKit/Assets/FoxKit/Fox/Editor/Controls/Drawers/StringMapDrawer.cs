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

            var label = new Label(property.name);
            label.AddToClassList("unity-base-field__label");
            label.AddToClassList("unity-property-field__label");
            container.Add(label);

            var innerContainer = new VisualElement();
            innerContainer.AddToClassList("unity-base-field__input");
            innerContainer.AddToClassList("unity-composite-field__input");

            var keyField = new PropertyField(property.FindPropertyRelative("Key"));
            keyField.AddToClassList("unity-composite-field__field");
            keyField.AddToClassList("unity-composite-field__field--first");
            innerContainer.Add(keyField);

            var valueField = new PropertyField(property.FindPropertyRelative("Value"));
            valueField.AddToClassList("unity-composite-field__field");
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
                entryField.AddToClassList("unity-composite-field");
                //entryField.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/StaticArrayDrawer.uss"));

                return entryField;
            };
            Action<VisualElement, int> bindItem = (e, i) =>
            {
                var entryField = e as PropertyField;
                var entry = cellListProperty.GetArrayElementAtIndex(i);

                entryField.BindProperty(entry);
                var label = entryField.Query<Label>().First();
                label.AddToClassList("unity-property-field__label");
                label.text = $"[{i}]";
            };

            var field = new ListView
            (
                cellList,
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
            foldout.text = property.name;

            foldout.Add(field);

            var buttonContainer = new VisualElement();
            buttonContainer.style.flexDirection = FlexDirection.RowReverse;
            buttonContainer.style.alignItems = Align.FlexEnd;

            var addButton = new Button();
            addButton.text = "+";
            addButton.style.marginTop = 0;
            addButton.style.borderTopWidth = 0;
            addButton.style.marginRight = 0;
            addButton.style.borderTopLeftRadius = 0;
            addButton.style.borderTopRightRadius = 0;
            addButton.style.borderBottomRightRadius = 0;
            addButton.style.marginRight = 0;
            addButton.style.height = 22;
            addButton.style.width = 32;
            addButton.style.fontSize = 18;
            addButton.style.unityTextAlign = UnityEngine.TextAnchor.LowerCenter;
            addButton.clicked += () =>
            {
                cellListProperty.InsertArrayElementAtIndex(cellListProperty.arraySize);

                property.serializedObject.ApplyModifiedProperties();

                field.Refresh();
                field.ScrollToItem(cellListProperty.arraySize + 10);
            };

            var removeButton = new Button();
            removeButton.text = "-";
            removeButton.style.marginTop = 0;
            removeButton.style.borderTopWidth = 0;
            removeButton.style.marginRight = 0;
            removeButton.style.marginLeft = 0;
            removeButton.style.borderLeftWidth = 0;
            removeButton.style.borderTopLeftRadius = 0;
            removeButton.style.borderTopRightRadius = 0;
            removeButton.style.borderBottomLeftRadius = 0;
            removeButton.style.height = 22;
            removeButton.style.width = 31;
            removeButton.style.fontSize = 18;
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
            };

            buttonContainer.Add(removeButton);
            buttonContainer.Add(addButton);

            foldout.Add(buttonContainer);

            return foldout;
        }
    }
}