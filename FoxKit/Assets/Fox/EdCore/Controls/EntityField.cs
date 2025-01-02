using System;
using Fox.Core;
using Fox;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class EntityField<T> : BaseField<T>, IEntityField where T : Entity
    {
        public static new readonly string ussClassName = "fox-entity-field";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        
        // Override configuration
        protected virtual void BuildHeader(VisualElement element, SerializedObject serializedObject)
        {
            
        }
        
        protected virtual bool ShouldOverrideBuildBody() => false;
        protected virtual void BuildBodyOverride(VisualElement element, SerializedObject serializedObject)
        {
            
        }
        
        protected virtual void BuildFooter(VisualElement element, SerializedObject serializedObject)
        {
            
        }

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

        private EntityInfo EntityInfo;
        private DynamicArray<EntityInfo> SuperclassList = new();

        private void PreBuild(SerializedObject serializedObject)
        {
            var entity = serializedObject.targetObject as Entity;
            EntityInfo = entity.GetClassEntityInfo();
            
            EntityInfo entityInfoIterator = EntityInfo;
            while (entityInfoIterator != null)
            {
                SuperclassList.Add(entityInfoIterator);

                entityInfoIterator = entityInfoIterator.Super;
            }
        }
        
        void IEntityField.Build(SerializedObject serializedObject)
        {
            PreBuild(serializedObject);
            
            BuildHeader(visualInput, serializedObject);

            if (ShouldOverrideBuildBody())
                BuildBodyOverride(visualInput, serializedObject);
            else
                BuildBodyFromEntity(serializedObject);

            BuildFooter(visualInput, serializedObject);
        }
        
        private void BuildBodyFromEntity(SerializedObject serializedObject)
        {
            for (int i = SuperclassList.Count - 1; i > -1; i--)
            {
                EntityInfo info = SuperclassList[i];

                if (info != Entity.ClassInfo)
                {
                    var headerLabel = new Label
                    {
                        text = $"<b>{info.Name}</b>",
                        style =
                        {
                            fontSize = 16
                        }
                    };
                    visualInput.Add(headerLabel);

                    var headerLine = new VisualElement
                    {
                        style =
                        {
                            flexGrow = 1,
                            height = 0,
                            borderTopColor = Color.gray,
                            borderTopWidth = 1,
                            marginBottom = 4
                        }
                    };
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

                    IFoxField field = FoxFieldUtils.GetCustomBindableField(propertyInfo);
                    VisualElement fieldElement = field as VisualElement;
                    field.bindingPath = $"<{propertyInfo.Name}>k__BackingField";
                    Label labelElement = field.GetLabelElement();
                    if (EntityInfo.LongestNamedVisibleFieldProperty is not null)
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

        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => labelElement;
    }
    
    [CustomEditor(typeof(Entity), true)]
    public class EntityEditor : UnityEditor.Editor
    {
        protected virtual IEntityField CreateField() => System.Activator.CreateInstance(typeof(EntityField<>).MakeGenericType((target as Entity).GetClassEntityInfo().Type)) as IEntityField;
        
        public sealed override VisualElement CreateInspectorGUI()
        {
            var field = CreateField();
            
            field.Build(this.serializedObject);
            
            return field as VisualElement;
        }
    }
}