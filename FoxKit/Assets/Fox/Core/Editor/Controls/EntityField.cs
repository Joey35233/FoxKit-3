using Fox.Core;
using Fox.Kernel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomEditor(typeof(FoxEntity))]
    public class FoxEntityEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            SerializedProperty entityProperty = serializedObject.FindProperty("Entity");
            var field = System.Activator.CreateInstance(typeof(EntityField<>).MakeGenericType(new System.Type[] { (target as FoxEntity).Entity.GetClassEntityInfo().Type })) as ICustomBindable;
            field.BindProperty(entityProperty);

            return field as VisualElement;
        }
    }

    public class EntityField<T> : BaseField<T>, ICustomBindable where T : Entity
    {
        public static new readonly string ussClassName = "fox-entity-field";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public EntityField() : this(new VisualElement()) { }

        private EntityField(VisualElement visInput)
            : base(null, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);

        public void BindProperty(SerializedProperty property, string label)
        {
            var entity = property.boxedValue as Entity;
            EntityInfo entityInfo = entity.GetClassEntityInfo();

            var supers = new DynamicArray<EntityInfo>();
            EntityInfo entityInfoIterator = entityInfo;
            while (entityInfoIterator != null)
            {
                supers.Add(entityInfoIterator);

                entityInfoIterator = entityInfoIterator.Super;
            }

            for (int i = supers.Count - 1; i > -1; i--)
            {
                EntityInfo info = supers[i];

                if (info.Id != Entity.ClassInfo.Id)
                {
                    var headerLabel = new Label
                    {
                        text = $"<b>{info.Name}</b>"
                    };
                    headerLabel.style.fontSize = 16;
                    visualInput.Add(headerLabel);

                    var headerLine = new VisualElement();
                    headerLine.style.flexGrow = 1;
                    headerLine.style.height = 0;
                    headerLine.style.borderTopColor = Color.gray;
                    headerLine.style.borderTopWidth = 1;
                    headerLine.style.marginBottom = 4;
                    visualInput.Add(headerLine);
                }

                foreach (PropertyInfo propertyInfo in info.OrderedStaticProperties)
                {
                    if (propertyInfo.Readable == PropertyInfo.PropertyExport.Never || propertyInfo.Backing == PropertyInfo.BackingType.Accessor)
                        continue;

                    if (info == Data.ClassInfo && propertyInfo.Name == "name")
                        continue;

                    ICustomBindable propertyField = FoxFieldUtils.GetCustomBindableField(propertyInfo);


                    //propertyField.BindProperty(property.FindPropertyRelative($"<{propertyInfo.Name}k__BackingField"), propertyInfo.Name.CString);
                    var fieldElement = propertyField as VisualElement;
                    Label labelElement = fieldElement.Query<Label>(className: BaseField<float>.labelUssClassName).First();
                    if (entityInfo.LongestNamedVisibleFieldProperty is not null)
                    {
                        labelElement.style.minWidth = StyleKeyword.Auto;
                        labelElement.style.width = info.LongestNamedVisibleFieldProperty.Name.Length * 8f;
                    }
                    fieldElement.SetEnabled(propertyInfo.Writable != PropertyInfo.PropertyExport.Never);
                    visualInput.Add(fieldElement);
                }
            }

            return;
        }
    }
}