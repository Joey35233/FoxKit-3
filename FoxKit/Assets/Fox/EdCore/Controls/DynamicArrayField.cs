using Fox.Kernel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using IList = System.Collections.IList;

namespace Fox.EdCore
{
    public class DynamicArrayField<T> : BaseField<DynamicArray<T>>, IFoxField, ICustomBindable
    {
        private readonly ListView ListViewInput;

        private static readonly Func<IFoxField> DefaultFieldConstructor = FoxFieldUtils.GetBindableElementConstructorForType(typeof(T));
        private Func<IFoxField> FieldConstructor = DefaultFieldConstructor;

        private SerializedProperty DynamicArrayProperty;

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
            ListViewInput.style.flexGrow = 1.0f;
            ListViewInput.selectionType = SelectionType.Single;
            ListViewInput.showBorder = true;
            ListViewInput.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            ListViewInput.reorderable = false;
            ListViewInput.showBoundCollectionSize = false;
            ListViewInput.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;
            ListViewInput.showAddRemoveFooter = false;

            // Technically, the header is the footer, just at the top.
            var header = new VisualElement
            {
                name = ListView.footerUssClassName
            };
            header.AddToClassList(ListView.footerUssClassName);

            var addButton = new Button(AddButton_clicked)
            {
                name = ListView.ussClassName + "__add-button",
                text = "＋"
            };
            addButton.AddToClassList(addButtonUssClassName);

            var removeButton = new Button(RemoveButton_clicked)
            {
                name = ListView.ussClassName + "__remove-button",
                text = "－"
            };
            removeButton.AddToClassList(removeButtonUssClassName);

            header.Add(removeButton);
            header.Add(addButton);

            ListViewInput.hierarchy.Insert(0, header);
            ListViewInput.AddToClassList(ListView.listViewWithFooterUssClassName);
            ListViewInput.Q<ScrollView>(className: ListView.listScrollViewUssClassName).AddToClassList(ListView.scrollViewWithFooterUssClassName);

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

                if (property.type.StartsWith("Fox.Kernel.DynamicArray"))
                {
                    // DynamicArrayProperty = property;
                    //
                    // BindingExtensions.TrackPropertyValue(this, DynamicArrayProperty, OnPropertyChanged);
                    //
                    // OnPropertyChanged(null);

                    ListViewInput.BindProperty(property.FindPropertyRelative("_list"));

                    // Stop the DynamicArrayField itself's binding event; it's just a container for the actual BindableElements.
                    evt.StopPropagation();
                }
            }
        }

        private void OnPropertyChanged(SerializedProperty property)
        {
            ListViewInput.itemsSource = DynamicArrayProperty.GetValue() as IList;
            ListViewInput.RefreshItems();
        }

        private void AddButton_clicked()
        {
            SerializedProperty listProperty = DynamicArrayProperty.FindPropertyRelative("_list");

            int targetValue = listProperty.arraySize;
            listProperty.InsertArrayElementAtIndex(targetValue);

            SerializedProperty prop = listProperty.GetArrayElementAtIndex(targetValue);
            if (typeof(T).IsClass && prop.propertyType == SerializedPropertyType.ObjectReference)
                prop.boxedValue = null;

            _ = DynamicArrayProperty.serializedObject.ApplyModifiedProperties();
        }

        private void RemoveButton_clicked()
        {
            SerializedProperty listProperty = DynamicArrayProperty.FindPropertyRelative("_list");

            if (ListViewInput.selectedIndex != -1)
            {
                foreach (int selectedIndex in ListViewInput.selectedIndices)
                {
                    listProperty.DeleteArrayElementAtIndex(selectedIndex);
                }
            }
            else
            {
                listProperty.DeleteArrayElementAtIndex(listProperty.arraySize - 1);
            }

            _ = DynamicArrayProperty.serializedObject.ApplyModifiedProperties();
        }

        private VisualElement MakeItem() => FieldConstructor() as VisualElement;

        private void BindItem(VisualElement element, int index)
        {
            var itemProperty = DynamicArrayProperty.FindPropertyRelative("_list").GetArrayElementAtIndex(index) as SerializedProperty;
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

            //ListViewInput.BindProperty(property.FindPropertyRelative("_list"));
            DynamicArrayProperty = property;

            BindingExtensions.TrackPropertyValue(this, DynamicArrayProperty, OnPropertyChanged);

            OnPropertyChanged(null);
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