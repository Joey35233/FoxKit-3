﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.StaticArray<>))]
    public class StaticArrayDrawer : PropertyDrawer
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

            root = foldout;

            return root;
        }
    }
}