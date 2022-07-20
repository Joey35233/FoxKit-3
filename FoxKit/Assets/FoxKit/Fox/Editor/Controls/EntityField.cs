using Fox.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;
using System.Linq;

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
        public new static readonly string ussClassName = "fox-entity-field";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public EntityField() : this(new VisualElement()) { }

        private EntityField(VisualElement visInput)
            : base(null, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }

        public void BindProperty(SerializedProperty property, string label)
        {
            Entity entity = property.boxedValue as Entity;
            EntityInfo entityInfo = entity.GetClassEntityInfo();

            DynamicArray<EntityInfo> supers = new DynamicArray<EntityInfo>();
            EntityInfo entityInfoIterator = entityInfo;
            while (entityInfoIterator != null)
            {
                supers.Add(entityInfoIterator);

                entityInfoIterator = entityInfoIterator.Super;
            }

            for (int i = supers.Count - 1; i > -1; i--)
            {
                EntityInfo info = supers[i];

                foreach (KeyValuePair<String, PropertyInfo> pair in info.StaticProperties)
                {
                    PropertyInfo propertyInfo = pair.Value;

                    if (propertyInfo.Readable == PropertyInfo.PropertyExport.Never)
                        continue;

                    if (entityInfo.Super != null && propertyInfo.Offset == 0)
                        continue;

                    ICustomBindable propertyField = FoxFieldUtils.GetCustomBindableField(propertyInfo);
                    propertyField.BindProperty(property.FindPropertyRelative($"<{propertyInfo.Name}>k__BackingField"), pair.Key);
                    VisualElement fieldElement = propertyField as VisualElement;
                    fieldElement.SetEnabled(propertyInfo.Writable != PropertyInfo.PropertyExport.Never);
                    visualInput.Add(propertyField as VisualElement);
                }
            }

            return;
        }
    }
}