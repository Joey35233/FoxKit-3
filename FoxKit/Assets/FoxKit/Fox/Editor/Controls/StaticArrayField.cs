using Fox.FoxKernel;
using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class StaticArrayField<T> : BaseField<StaticArray<T>>, IFoxField, ICustomBindable
    {
        private ListView ListViewInput;

        private static Func<IFoxField> FieldConstructor = FoxFieldUtils.GetTypeFieldConstructor(typeof(T));

        public new static readonly string ussClassName = "fox-staticarray-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public StaticArrayField() : this(default)
        {
        }

        public StaticArrayField(string label)
            : this(label, new ListView())
        {
        }

        private StaticArrayField(string label, ListView visInput)
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

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;
                if (!property.isArray)
                {
                    BindingExtensions.BindProperty(ListViewInput, property.FindPropertyRelative("_list"));

                    evt.StopPropagation();
                }
            }
        }

        private VisualElement MakeItem()
        {
            return FieldConstructor() as VisualElement;
        }

        private void BindItem(VisualElement element, int index)
        {
            SerializedProperty itemProperty = ListViewInput.itemsSource[index] as SerializedProperty;
            (element as ICustomBindable).BindProperty(itemProperty, $"[{index}]");

            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.fieldUssClassName);
            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.firstFieldVariantUssClassName);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(ListViewInput, property.FindPropertyRelative("_list"));
        }
    }

    [CustomPropertyDrawer(typeof(StaticArray<>))]
    public class StaticArrayDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement genericField = (VisualElement)Activator.CreateInstance(typeof(StaticArrayField<>).MakeGenericType(new Type[] { fieldInfo.FieldType.GenericTypeArguments[0] }), new object[] { property.name });
            (genericField as IFoxField).BindProperty(property);

            genericField.Q(className: BaseField<float>.labelUssClassName).AddToClassList(PropertyField.labelUssClassName);
            genericField.Q(className: BaseField<float>.inputUssClassName).AddToClassList(PropertyField.inputUssClassName);
            genericField.AddToClassList(BaseField<float>.alignedFieldUssClassName);

            return genericField;
        }
    }
}