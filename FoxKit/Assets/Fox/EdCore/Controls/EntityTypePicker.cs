using Fox.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public static class EntityTypePickerPopup
    {
        public static EntityInfo ShowPopup(Type baseType)
        {
            EntityTypePickerPopupWindow window = EditorWindow.GetWindow<EntityTypePickerPopupWindow>(true, baseType.Name);
            window.baseType = baseType;
            window.Draw();
            window.ShowModal();

            return window.returnValue;
        }

        private class EntityTypePickerPopupWindow : EditorWindow
        {
            private ToolbarSearchField ToolbarSearchInput;
            private ListView TypesListInput;

            public static readonly string ussClassName = "fox-entitypicker-field";
            public static readonly string inputUssClassName = ussClassName + "__input";
            public static readonly string searchFieldUssClassName = ussClassName + "__search-field";
            public static readonly string typesListUssClassName = ussClassName + "__types-list";

            public VisualElement visualInput
            {
                get; private set;
            }

            private readonly IList<EntityInfo> allItems = new List<EntityInfo>();
            private readonly List<EntityInfo> filteredItems = new();

            public Type baseType;
            public EntityInfo returnValue;

            public void Draw()
            {
                visualInput = new VisualElement();
                visualInput.style.flexDirection = FlexDirection.Column;
                visualInput.style.flexGrow = 1.0f;
                visualInput.AddToClassList(inputUssClassName);

                allItems.Clear();
                filteredItems.Clear();

                foreach (EntityInfo type in GetTypes(baseType))
                {
                    allItems.Add(type);
                    filteredItems.Add(type);
                }

                TypesListInput = new ListView
                {
                    name = "Types",
                    itemsSource = (System.Collections.IList)allItems,
                    makeItem = () => new Label(),
                    bindItem = (VisualElement e, int i) => (e as Label).text = filteredItems[i].Name,
                    showAlternatingRowBackgrounds = AlternatingRowBackground.All,
                    virtualizationMethod = CollectionVirtualizationMethod.FixedHeight,
                    fixedItemHeight = 22,
                    selectionType = SelectionType.Single,
                };
                TypesListInput.selectionChanged += TypeList_selectionChanged;
                TypesListInput.AddToClassList(typesListUssClassName);

                ToolbarSearchInput = new ToolbarSearchField
                {
                    name = "Search"
                };
                ToolbarSearchInput.style.width = new StyleLength(StyleKeyword.Auto);
                _ = ToolbarSearchInput.RegisterValueChangedCallback(OnTextChanged);
                ToolbarSearchInput.AddToClassList(searchFieldUssClassName);

                visualInput.Add(ToolbarSearchInput);
                visualInput.Add(TypesListInput);

                rootVisualElement.Add(visualInput);
                rootVisualElement.AddToClassList(ussClassName);
            }

            private static List<EntityInfo> GetTypes(Type baseType)
            {
                var list = new List<EntityInfo>(EntityInfo.GetEntityInfo(baseType).AllChildren)
                {
                    EntityInfo.GetEntityInfo(baseType)
                };
                return list;
            }

            private void OnTextChanged(ChangeEvent<string> evt)
            {
                filteredItems.Clear();
                TypesListInput.itemsSource = filteredItems;
                TypesListInput.selectedIndex = -1;

                if (string.IsNullOrEmpty(evt.newValue))
                {
                    filteredItems.AddRange(allItems);
                }
                else
                {
                    filteredItems.AddRange(from item in allItems
                                           where item.Name.IndexOf(evt.newValue, StringComparison.OrdinalIgnoreCase) >= 0
                                           select item);
                }

                TypesListInput.Rebuild();
            }

            private void TypeList_selectionChanged(IEnumerable<object> obj)
            {
                var type = obj.ToList()[0] as EntityInfo;
                returnValue = type;
                Close();
            }
        }
    }
}