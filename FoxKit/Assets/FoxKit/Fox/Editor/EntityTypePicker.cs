using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityTypePicker : EditorWindow
    {
        private readonly IList<string> allItems = new List<string>();
        private readonly List<string> filteredItems = new List<string>();
        private ListView typeList;

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

            this.allItems.Clear();
            this.filteredItems.Clear();

            const int itemCount = 1000;
            for (int i = 1; i <= itemCount; i++)
            {
                this.allItems.Add(i.ToString());
                this.filteredItems.Add(i.ToString());
            }

            this.typeList = rootVisualElement.Q<ListView>("Types");

            VisualElement makeItem() => new Label();
            void bindItem(VisualElement e, int i) => (e as Label).text = this.filteredItems[i];

            typeList.onItemsChosen += obj => Debug.Log(obj);
            typeList.onSelectionChange += objects => Debug.Log(objects);
            typeList.itemsSource = (System.Collections.IList)this.allItems;
            typeList.makeItem = makeItem;
            typeList.bindItem = bindItem;

            var search = rootVisualElement.Q<ToolbarSearchField>();
            search.RegisterValueChangedCallback(OnTextChanged);
        }

        private void OnTextChanged(ChangeEvent<string> evt)
        {
            filteredItems.Clear();
            typeList.itemsSource = filteredItems;
            typeList.selectedIndex = -1;

            if (string.IsNullOrEmpty(evt.newValue))
            {
                filteredItems.AddRange(this.allItems);
                typeList.Refresh();
                return;
            }

            filteredItems.AddRange(from item in this.allItems
                                   where item.IndexOf(evt.newValue, StringComparison.OrdinalIgnoreCase) >= 0
                                   select item);
            typeList.Refresh();
        }
    }
}