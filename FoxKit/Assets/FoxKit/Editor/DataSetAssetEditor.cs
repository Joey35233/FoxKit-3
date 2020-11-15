using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using Fox.Editor;
using System;
using Fox;

namespace FoxKit
{
    [CustomEditor(typeof(DataSetAsset))]
    public class DataSetAssetEditor : UnityEditor.Editor
    {
        private const string AddEntityButtonName = "AddEntityButton";
        private const string InspectedEntityLabelName = "InspectedEntityLabel";
        private const string InspectedEntityPropertiesName = "InspectedEntityProperties";

        private const string StylesheetPath = "Assets/FoxKit/Editor/DataSetAssetEditor.uss";
        private const string VisualTreePath = "Assets/FoxKit/Editor/DataSetAssetEditor.uxml";

        [SerializeField]
        private VisualElement rootElement;

        public override VisualElement CreateInspectorGUI()
        {
            this.rootElement = new VisualElement();
            ImportUxmlAndStylesheet(this.rootElement);

            var addEntityButton = this.rootElement.Q<Button>(AddEntityButtonName);
            addEntityButton.clicked += AddEntityButton_clicked;

            var asset = (DataSetAsset)target;
            var dataSet = asset.dataSet;

            //var items = PopulateEntityList(dataSet);
            this.InitializeEntityList(rootElement, dataSet.dataList);

            return rootElement;
        }

        private void AddEntityButton_clicked()
        {
            EntityTypePicker.Show(typeof(Fox.Data), EntityTypePicker_onTypeSelected);
        }

        private void EntityTypePicker_onTypeSelected(Type obj)
        {
            var entity = (Fox.Data)Activator.CreateInstance(obj);

            var dataListProperty = this.GetDataListProperty();
            var newIndex = dataListProperty.arraySize;
            entity.name = "Data" + newIndex;

            dataListProperty.InsertArrayElementAtIndex(newIndex);
            dataListProperty.serializedObject.ApplyModifiedProperties();
            dataListProperty.GetArrayElementAtIndex(newIndex).SetValue(entity);
            dataListProperty.serializedObject.ApplyModifiedProperties();
        }

        private static void ImportUxmlAndStylesheet(VisualElement rootElement)
        {
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(VisualTreePath);
            visualTree.CloneTree(rootElement);

            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(StylesheetPath);
            rootElement.styleSheets.Add(styleSheet);
        }

        private void InitializeEntityList(VisualElement rootElement, List<Fox.Data> items)
        {
            var listView = rootElement.Q<ListView>();
            listView.BindProperty(this.GetDataListProperty());

            var dataListProperty = this.GetDataListProperty();

            // TODO: Figure out why this is trying to bind to items that don't exist
            // https://forum.unity.com/threads/correct-way-to-use-listview-bind.861862/
            VisualElement makeItem() => new Label();
            void bindItem(VisualElement e, int i)
            {
                var entityProperty = (SerializedProperty)listView.itemsSource[i];
                (e as Label).text = entityProperty.FindPropertyRelative("name").stringValue;
            }

            listView.makeItem = makeItem;
            listView.bindItem = bindItem;
            listView.itemsSource = items;
            listView.selectionType = SelectionType.Single;
            listView.onSelectionChange += ListView_onSelectionChange;
            listView.showBoundCollectionSize = false;
        }

        private void ListView_onSelectionChange(IEnumerable<object> obj)
        {
            var inspectedEntityLabel = this.rootElement.Q<Label>(InspectedEntityLabelName);
            var inspectedEntityProperties = this.rootElement.Q<PropertyField>(InspectedEntityPropertiesName);
            var list = this.rootElement.Q<ListView>();
            var dataSet = ((DataSetAsset)this.target).dataSet;

            var selection = obj.ToList();
            if (selection.Count == 0)
            {
                inspectedEntityLabel.text = string.Empty;
            }
            else
            {
                var entity = dataSet.dataList[list.selectedIndex];
                inspectedEntityLabel.text = entity.name + $" ({entity.GetType().Name})";
                inspectedEntityProperties.Unbind();
            }

            var dataListProperty = GetDataListProperty();
            var listItemProperty = dataListProperty.GetArrayElementAtIndex(list.selectedIndex);
            inspectedEntityProperties.BindProperty(listItemProperty);
        }

        private SerializedProperty GetDataListProperty()
        {
            var dataSetProperty = this.serializedObject.FindProperty("dataSet");
            return dataSetProperty.FindPropertyRelative("dataList");
        }

        private static List<string> PopulateEntityList(Fox.DataSet dataSet)
        {
            var items = new List<string>();
            foreach(var data in dataSet.dataList)
            {
                items.Add(data.name);
            }

            return items;
        }
    }
}