using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(EntityHandle))]
    public class EntityHandleDrawer : PropertyDrawer
    {
        public SerializedProperty property;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            var container = new VisualElement();
            var uxmlTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/FoxKit/Fox/Editor/Controls/Drawers/EntityHandleDrawer.uxml");
            var drawer = uxmlTemplate.CloneTree(property.propertyPath);

            var dataSet = GetDataSet(property);
            if (dataSet == null)
            {
                var error = new TextField
                {
                    label = property.name,
                    value = "Orphaned EntityHandle",
                    isReadOnly = true
                };

                drawer.Add(error);
            }
            else
            {
                var index = GetSelectedIndex(dataSet, (EntityHandle)property.GetValue()) + 1;
                if (index < 0)
                {
                    index = 0;
                }

                var options = new List<Data>();
                options.Add(null);
                options.AddRange(dataSet.dataList);

                var popup = new PopupField<Data>(property.name, options, index, FormatSelectedValue, FormatListItem);
                container.Add(popup);
            }

            container.Add(drawer);
            return container;
        }

        private static int GetSelectedIndex(DataSet dataSet, EntityHandle handle)
        {
            var entity = handle.Entity();
            if (entity == null)
            {
                return -1;
            }

            return dataSet.dataList.IndexOf((Fox.Data)entity);
        }

        private string FormatSelectedValue(Data arg)
        {
            this.property.SetValue(EntityHandle.Get(arg));
            if (arg == null)
            {
                return "Null";
            }

            return arg.name;
        }

        private string FormatListItem(Data arg)
        {
            if (arg == null)
            {
                return "Null";
            }

            return arg.name;
        }

        private static DataSet GetDataSet(SerializedProperty property)
        {
            var dataSetProperty = property.serializedObject.FindProperty("dataSet");
            if (dataSetProperty == null)
            {
                return null;
            }

            return (DataSet)dataSetProperty.GetValue();
        }
    }
}