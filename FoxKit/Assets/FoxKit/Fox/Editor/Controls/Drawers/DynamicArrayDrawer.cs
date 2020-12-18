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
                entryField.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/StaticArrayDrawer.uss"));

                return entryField;
            };
            Action<VisualElement, int> bindItem = (e, i) =>
            {
                var entryField = e as PropertyField;
                var privateList = property.FindPropertyRelative("_list");
                var entry = privateList.GetArrayElementAtIndex(i);

                entryField.BindProperty(entry);
                var label = entryField.Query<Label>().First();
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
                var privateList = property.FindPropertyRelative("_list");
                privateList.InsertArrayElementAtIndex(privateList.arraySize);

                property.serializedObject.ApplyModifiedProperties();

                field.Refresh();
                field.ScrollToItem(privateList.arraySize + 10);

                root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
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

                field.SetSelection(privateList.arraySize - 1);

                root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
            };

            buttonContainer.Add(removeButton);
            buttonContainer.Add(addButton);

            foldout.Add(buttonContainer);

            root = foldout;
            root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);

            return root;
        }

        private void OnGeometryChanged(GeometryChangedEvent evt)
        {
            VisualElement container = field.Query<VisualElement>("unity-content-container");

            float maxWidth = 0;
            foreach (PropertyField propertyField in container.Children())
            {
                var label = propertyField.Query<Label>().First();
                if (label.resolvedStyle.width > maxWidth)
                    maxWidth = label.resolvedStyle.width;
            }

            foreach (PropertyField propertyField in container.Children())
            {
                var label = propertyField.Query<Label>().First();
                label.style.width = maxWidth;
            }

            root.UnregisterCallback<GeometryChangedEvent>(OnGeometryChanged);
        }
    }
}