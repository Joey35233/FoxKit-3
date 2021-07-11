using Fox.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityTypePicker : EditorWindow
    {
        private readonly IList<Type> allItems = new List<Type>();
        private readonly List<Type> filteredItems = new List<Type>();
        private ListView typeList;
        private Type baseType;
        private Action<Type> onTypeSelected;

        public static void Show(Type baseType, Action<Type> onTypeSelected)
        {
            var window = CreateWindow<EntityTypePicker>();
            window.baseType = baseType;
            window.onTypeSelected = onTypeSelected;
            window.titleContent = new GUIContent(baseType.Name);
            window.Show();
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

            foreach(var type in GetTypes(baseType))
            {
                this.allItems.Add(type);
                this.filteredItems.Add(type);
            }

            this.typeList = rootVisualElement.Q<ListView>("Types");

            VisualElement makeItem() => new Label();
            void bindItem(VisualElement e, int i) => (e as Label).text = this.filteredItems[i].Name;

            typeList.onSelectionChange += TypeList_onSelectionChange;
            typeList.itemsSource = (System.Collections.IList)this.allItems;
            typeList.makeItem = makeItem;
            typeList.bindItem = bindItem;

            var search = rootVisualElement.Q<ToolbarSearchField>();
            search.RegisterValueChangedCallback(OnTextChanged);
        }

        private void TypeList_onSelectionChange(IEnumerable<object> obj)
        {
            var type = obj.ToList()[0] as Type;
            this.onTypeSelected(type);
            this.Close();
        }

        // TODO: Need EntityClassDictionary up and running
        private static List<Type> GetTypes(Type baseType)
        {
            return new List<Type>
            {
                typeof(Entity),
                typeof(Data),
                typeof(Core.DataSet)
            };
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
                                   where item.Name.IndexOf(evt.newValue, StringComparison.OrdinalIgnoreCase) >= 0
                                   select item);
            typeList.Refresh();
        }
    }
}