using Fox;
using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class DynamicArrayField<T> : BaseField<DynamicArray<T>>, IFoxField, ICustomBindable
    {
        private readonly ListView ListViewInput;

        private static readonly Func<IFoxField> DefaultFieldConstructor = FoxFieldUtils.GetBindableElementConstructorForType(typeof(T));
        private Func<IFoxField> FieldConstructor = DefaultFieldConstructor;

        public static new readonly string ussClassName = "fox-dynamicarray-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string addButtonUssClassName = ussClassName + "__add-button";
        public static readonly string removeButtonUssClassName = ussClassName + "__remove-button";

        public VisualElement visualInput
        {
            get;
        }

        public DynamicArrayField() : this(default)
        {
        }

        public DynamicArrayField(string label)
            : this(label, new ListView())
        {
        }

        private DynamicArrayField(string label, ListView visInput)
            : base(label, visInput)
        {
            ListViewInput = visInput;
            visualInput = ListViewInput;

            ListViewInput.itemsSource = value;
            ListViewInput.makeItem = MakeItem;
            ListViewInput.bindItem = BindItem;
            ListViewInput.unbindItem = (element, i) => {};
            ListViewInput.style.flexGrow = 1.0f;
            ListViewInput.selectionType = SelectionType.Single;
            ListViewInput.showBorder = true;
            ListViewInput.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            ListViewInput.reorderable = false;
            ListViewInput.showBoundCollectionSize = false;
            ListViewInput.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;
            ListViewInput.showAddRemoveFooter = true;

            Button addButton = ListViewInput.Q<Button>(name: "unity-list-view__add-button");
            addButton.text = "＋";
            addButton.AddToClassList(addButtonUssClassName);

            Button removeButton = ListViewInput.Q<Button>(name: "unity-list-view__remove-button");
            removeButton.AddToClassList(removeButtonUssClassName);
            removeButton.text = "－";

            VisualElement footer = ListViewInput.Q(name: ListView.footerUssClassName);
            ListViewInput.Remove(footer);
            ListViewInput.hierarchy.Insert(0, footer); // Technically, this is now the header.

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !System.String.IsNullOrWhiteSpace(bindingPath))
            {
                var property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                if (!property.isArray)
                {
                    BindingExtensions.BindProperty(ListViewInput, property.FindPropertyRelative("_list"));

                    evt.StopPropagation();
                }
            }
        }

        private VisualElement MakeItem() => FieldConstructor() as VisualElement;

        private void BindItem(VisualElement element, int index)
        {
            var itemProperty = ListViewInput.itemsSource[index] as SerializedProperty;
            (element as ICustomBindable).BindProperty(itemProperty, $"[{index}]");

            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.fieldUssClassName);
            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.firstFieldVariantUssClassName);
        }

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label, Core.PropertyInfo propertyInfo = null)
        {
            if (propertyInfo is not null)
                FieldConstructor = FoxFieldUtils.GetBindableElementConstructorForPropertyInfo(propertyInfo);

            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(ListViewInput, property.FindPropertyRelative("_list"));
        }
    }

    [CustomPropertyDrawer(typeof(DynamicArray<>))]
    public class DynamicArrayDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var genericField = (VisualElement)Activator.CreateInstance(typeof(DynamicArrayField<>).MakeGenericType(fieldInfo.FieldType.GenericTypeArguments), new object[] { property.name });
            (genericField as IFoxField).BindProperty(property);

            genericField.Q(className: BaseField<float>.labelUssClassName).AddToClassList(PropertyField.labelUssClassName);
            genericField.Q(className: BaseField<float>.inputUssClassName).AddToClassList(PropertyField.inputUssClassName);
            genericField.AddToClassList(BaseField<float>.alignedFieldUssClassName);

            return genericField;
        }
    }
}