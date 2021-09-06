using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Fox.Core;
using System.Collections.Generic;

namespace Fox.Editor
{
    public class EntityHandleField : IFoxField
    {
        private PopupField<Data> InternalField;
        private SerializedProperty Property;

        public EntityHandleField() : this(default)
        {
        }

        public EntityHandleField(string label)
        {
            var error = new TextField
            {
                label = label,
                value = "Orphaned EntityHandle",
                isReadOnly = true
            };
            error.labelElement.AddToClassList("unity-property-field__label");

            this.Clear();
            this.Add(error);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            this.Property = property;

            var dataSet = GetDataSet(property);
            if (dataSet == null)
                return;

            var index = GetSelectedIndex(dataSet, (EntityHandle)property.GetValue()) + 1;
            if (index < 0)
            {
                index = 0;
            }

            var options = new List<Data>();
            options.Add(null);

            foreach (var data in dataSet.dataList)
            {
                options.Add(data as Data);
            }

            InternalField = new PopupField<Data>(label, options, index, FormatSelectedValue, FormatListItem);
            this.Clear();
            this.Add(InternalField);
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
            Property.SetValue(EntityHandle.Get(arg));
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

    [CustomPropertyDrawer(typeof(EntityHandle))]
    public class EntityHandleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new EntityHandleField(property.name);
            container.BindProperty(property);

            return container;
        }
    }
}