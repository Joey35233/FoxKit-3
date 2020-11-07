using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityTypePicker : EditorWindow
    {
        public static void Show(Type baseType)
        {
            var window = GetWindow<EntityTypePicker>();
            window.titleContent = new GUIContent(baseType.Name);
            window.ShowModalUtility();
        }

        public void OnEnable()
        {
            VisualElement root = rootVisualElement;

            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/EntityTypePicker.uxml");
            var uss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/EntityTypePicker.uss");

            visualTree.CloneTree(root);

            root.styleSheets.Add(uss);
            root.style.flexDirection = FlexDirection.Column;
            root.style.flexGrow = 1.0f;

            var typeList = rootVisualElement.Q<ListView>("Types");

            // Create some list of data, here simply numbers in interval [1, 1000]
            const int itemCount = 1000;
            var items = new List<string>(itemCount);
            for (int i = 1; i <= itemCount; i++)
            {
                items.Add(i.ToString());
            }

            // The "makeItem" function will be called as needed
            // when the ListView needs more items to render
            Func<VisualElement> makeItem = () => new Label();

            // As the user scrolls through the list, the ListView object
            // will recycle elements created by the "makeItem"
            // and invoke the "bindItem" callback to associate
            // the element with the matching data item (specified as an index in the list)
            Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i];

            typeList.onItemsChosen += obj => Debug.Log(obj);
            typeList.onSelectionChange += objects => Debug.Log(objects);
            typeList.itemsSource = items;
            typeList.makeItem = makeItem;
            typeList.bindItem = bindItem;
            //typeList.style.minHeight = 500;
            //typeList.style.flexGrow = 1.0f;
        }
    }
}