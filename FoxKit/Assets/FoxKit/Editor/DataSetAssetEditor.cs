using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using Fox.Editor;
using Fox.Core;
using System;

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

            //this.InitializeEntityList(rootElement, dataSet.dataList);

            return rootElement;
        }

        private void AddEntityButton_clicked()
        {
            EntityTypePickerPopup.ShowPopup(typeof(Fox.Core.Data)/*, EntityTypePicker_onTypeSelected*/);
        }

        private void EntityTypePicker_onTypeSelected(Type obj)
        {
            var entity = (Fox.Core.Data)Activator.CreateInstance(obj);

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

        private void InitializeEntityList(VisualElement rootElement, List<Fox.Core.Data> items)
        {
            var listView = rootElement.Q<ListView>();
            listView.BindProperty(this.GetDataListProperty());

            VisualElement makeItem() => new Label();
            void bindItem(VisualElement e, int i)
            {
                var entityProperty = (SerializedProperty)listView.itemsSource[i];
                ((Label)e).text = entityProperty.FindPropertyRelative("name").stringValue;
            }

            listView.makeItem = makeItem;
            listView.bindItem = bindItem;
            listView.itemsSource = items;
            listView.selectionType = SelectionType.Single;
            listView.selectionChanged += ListView_selectionChanged;
            listView.showBoundCollectionSize = false;
        }

        private void ListView_selectionChanged(IEnumerable<object> obj)
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
                var entity = dataSet.dataList[list.selectedIndex] as Data;
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
    }
}