using Fox.Core;
using Fox;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    [CustomEditor(typeof(Entity), true)]
    public class EntityEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var field = System.Activator.CreateInstance(typeof(EntityField<>).MakeGenericType(new System.Type[] { (target as Entity).GetClassEntityInfo().Type })) as ICustomBindable;
            field.Bind(this.serializedObject);
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

        public void BindProperty(SerializedProperty property, string label, PropertyInfo propertyInfo = null)
        {
            Bind(new SerializedObject(property.objectReferenceValue));
        }

        public void Bind(SerializedObject serializedObject)
        {
            var entity = serializedObject.targetObject as Entity;
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

                if (info != Entity.ClassInfo)
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

                // TODO: Refactor into custom editor support
                if (info == Data.ClassInfo || info == DataElement.ClassInfo || info == DataSet.ClassInfo || info == TransformEntity.ClassInfo || info == ShearTransformEntity.ClassInfo || info == PivotTransformEntity.ClassInfo)
                    continue;

                foreach (PropertyInfo propertyInfo in info.OrderedStaticProperties)
                {
                    // TODO: Reimplement property hiding based on access modifiers once custom editor support is further along.
                    if (/*propertyInfo.Readable == PropertyInfo.PropertyExport.Never || */propertyInfo.Backing == PropertyInfo.BackingType.Accessor)
                        continue;

                    // TODO: Refactor into custom editor support
                    if (info == TransformData.ClassInfo && propertyInfo.Name != "transform" && propertyInfo.Name != "shearTransform" && propertyInfo.Name != "pivotTransform" && propertyInfo.Name != "flags")
                        continue;

                    ICustomBindable propertyField = FoxFieldUtils.GetCustomBindableField(propertyInfo);
                    propertyField.BindProperty(serializedObject.FindProperty($"<{propertyInfo.Name}>k__BackingField"), propertyInfo.Name, propertyInfo);
                    var fieldElement = propertyField as VisualElement;
                    Label labelElement = fieldElement.Query<Label>(className: BaseField<float>.labelUssClassName).First();
                    if (entityInfo.LongestNamedVisibleFieldProperty is not null)
                    {
                        labelElement.style.minWidth = StyleKeyword.Auto;
                        labelElement.style.width = info.LongestNamedVisibleFieldProperty.Name.Length * 8f;
                    }

                    // TODO: Reimplement property disabling based on access modifiers once custom editor support is further along.
                    // fieldElement.SetEnabled(propertyInfo.Writable != PropertyInfo.PropertyExport.Never);
                    visualInput.Add(fieldElement);
                }
            }

            return;
        }
    }
}