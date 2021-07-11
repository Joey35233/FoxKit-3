using Fox.Core;
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

            var dataSet = GetDataSet(property);
            if (dataSet == null)
            {
                var error = new TextField
                {
                    label = property.name,
                    value = "Orphaned EntityHandle",
                    isReadOnly = true
                };
                error.labelElement.AddToClassList("unity-property-field__label");

                return error;
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

                foreach(var data in dataSet.dataList)
                {
                    options.Add(data as Data);
                }

                var popup = new PopupField<Data>(property.name, options, index, FormatSelectedValue, FormatListItem);
                return popup;
            }
        }

        private static int GetSelectedIndex(DataSet dataSet, EntityHandle handle)
        {
            var entity = handle.Entity();
            if (entity == null)
            {
                return -1;
            }

            return dataSet.dataList.IndexOf((Fox.Core.Data)entity);
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