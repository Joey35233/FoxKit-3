using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Fox;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Ast;
using System.Linq;
using UnityEditor.UIElements;
using UnityEditorInternal.VersionControl;

namespace FoxKit
{
    [CustomEditor(typeof(DataSetAsset))]
    public class DataSetAssetEditor : UnityEditor.Editor
    {
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

            var asset = (DataSetAsset)target;
            var dataSet = asset.dataSet;

            var test = new Fox.Data();
            test.name = "Hello world";
            dataSet.dataList.Add(test);

            var items = PopulateEntityList(dataSet);
            this.InitializeEntityList(rootElement, items);

            return rootElement;
        }

        private static void ImportUxmlAndStylesheet(VisualElement rootElement)
        {
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(VisualTreePath);
            visualTree.CloneTree(rootElement);

            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(StylesheetPath);
            rootElement.styleSheets.Add(styleSheet);
        }

        private void InitializeEntityList(VisualElement rootElement, List<string> items)
        {
            var listView = rootElement.Q<ListView>();

            VisualElement makeItem() => new Label();
            void bindItem(VisualElement e, int i) => (e as Label).text = items[i];

            listView.makeItem = makeItem;
            listView.bindItem = bindItem;
            listView.itemsSource = items;
            listView.selectionType = SelectionType.Single;
            listView.onSelectionChange += ListView_onSelectionChange;
        }

        private void ListView_onSelectionChange(IEnumerable<object> obj)
        {
            var inspectedEntityLabel = this.rootElement.Q<Label>(InspectedEntityLabelName);
            var inspectedEntityProperties = this.rootElement.Q<PropertyField>(InspectedEntityPropertiesName);

            var selection = obj.ToList();
            if (selection.Count == 0)
            {
                inspectedEntityLabel.text = string.Empty;
            }
            else
            {
                inspectedEntityLabel.text = (selection[0] as string);
                inspectedEntityProperties.Unbind();
            }

            var list = this.rootElement.Q<ListView>();

            var dataSetProperty = this.serializedObject.FindProperty("dataSet");
            var dataListProperty = dataSetProperty.FindPropertyRelative("dataList");
            var listItemProperty = dataListProperty.GetArrayElementAtIndex(list.selectedIndex);
            inspectedEntityProperties.BindProperty(listItemProperty);
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