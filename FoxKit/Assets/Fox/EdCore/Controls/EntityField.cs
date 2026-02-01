using System;
using System.Collections.Generic;
using Fox.Core;
using Fox;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public struct EntityFieldBuildContext
    {
        public EntityField<Entity> Field;
        public VisualElement HeaderElement;
        public VisualElement BodyElement;
        public VisualElement FooterElement;
        public SerializedObject Object;
    }
    
    public class EntityField<T> : BaseField<T>, IEntityField where T : Entity
    {
        public static new readonly string ussClassName = "fox-entity-field";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

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
        private readonly List<(EntityInfo, CustomEntityFieldDesc?)> SuperclassList = new();

        private void PreBuild(EntityFieldBuildContext context)
        {
            var entity = context.Object.targetObject as Entity;
            EntityInfo = entity.GetClassEntityInfo();
            
            EntityInfo entityInfoIterator = EntityInfo;
            while (entityInfoIterator != null)
            {
                CustomEntityFieldDesc? customFieldDesc = CustomEntityFieldManager.Get(entityInfoIterator);
                
                SuperclassList.Add((entityInfoIterator, customFieldDesc));

                entityInfoIterator = entityInfoIterator.Super;
            }
        }

        public void Build(SerializedObject serializedObject)
        {
            EntityFieldBuildContext context = new EntityFieldBuildContext{ Field = this as EntityField<Entity>, BodyElement = visualInput, Object = serializedObject };
            PreBuild(context);
            BuildBodyFromEntity(context);
        }
        
        private void BuildBodyFromEntity(EntityFieldBuildContext context)
        {
            for (int i = SuperclassList.Count - 1; i > -1; i--)
            {
                (EntityInfo classInfo, CustomEntityFieldDesc? customFieldDesc) = SuperclassList[i];

                // ----------------
                // Draw name of class with underline
                var headerLabel = new Label
                {
                    text = $"{(i != 0 ? "↱" : "")}<b>{classInfo.Name}</b>",
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

                // ----------------
                // Should this class' editor be drawn or is there a higher-level Entity with a custom field that overrides this?
                bool buildIsOverriddenByMoreSpecificClass = false;
                for (int j = 0; j < i; j++)
                {
                    (_, CustomEntityFieldDesc? iteratorCustomFieldDesc) = SuperclassList[j];
                    if (iteratorCustomFieldDesc?.BodyOverrideBehavior == BuildBodyOverrideBehavior.ChildrenOverride)
                    {
                        buildIsOverriddenByMoreSpecificClass = true;
                        break;
                    }
                }
                if (buildIsOverriddenByMoreSpecificClass)
                    continue;
                
                // ----------------
                // CUSTOM HEADER
                VisualElement header = new VisualElement();
                context.HeaderElement = header;
                customFieldDesc?.BuildHeader?.Invoke(context);
                visualInput.Add(header);
                
                // ----------------
                // CUSTOM BODY
                if (customFieldDesc?.BuildBody is { } buildBody)
                {
                    VisualElement body = new VisualElement();
                    context.BodyElement = body;
                    buildBody(context);
                    visualInput.Add(body);
                }
                else
                {
                    foreach (PropertyInfo propertyInfo in classInfo.OrderedStaticProperties)
                    {
                        // TODO: Reimplement property hiding based on access modifiers once custom editor support is further along.
                        if (/*propertyInfo.Readable == PropertyInfo.PropertyExport.Never || */propertyInfo.Backing == PropertyInfo.BackingType.Accessor)
                            continue;

                        IFoxField field = FoxFieldUtils.GetCustomBindableField(propertyInfo);
                        VisualElement fieldElement = field as VisualElement;
                        field.bindingPath = IFoxField.GetBindingPathForPropertyName(propertyInfo.Name);
                        Label fieldLabel = field.GetLabelElement();
                        if (EntityInfo.LongestNamedVisibleFieldProperty is not null)
                        {
                            fieldLabel.style.minWidth = StyleKeyword.Auto;
                            fieldLabel.style.width = classInfo.LongestNamedVisibleFieldProperty.Name.Length * 8f;
                        }

                        // TODO: Reimplement property disabling based on access modifiers once custom editor support is further along.
                        // fieldElement.SetEnabled(propertyInfo.Writable != PropertyInfo.PropertyExport.Never);
                        
                        visualInput.Add(fieldElement);
                    }
                }
                
                // ----------------
                // CUSTOM FOOTER
                VisualElement footer = new VisualElement();
                context.FooterElement = footer;
                customFieldDesc?.BuildFooter?.Invoke(context);
                visualInput.Add(footer);
            }

            return;
        }

        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => labelElement;
    }
    
    [CustomEditor(typeof(Entity), true)]
    public class EntityEditor : UnityEditor.Editor
    {
        protected new Entity target => base.target as Entity;
        
        public override VisualElement CreateInspectorGUI()
        {
            EntityInfo entityInfo = target.GetClassEntityInfo();
            
            CustomEntityFieldDesc? customFieldDesc = CustomEntityFieldManager.Get(entityInfo);
            IEntityField field = customFieldDesc?.Constructor() ?? Activator.CreateInstance(typeof(EntityField<>).MakeGenericType(entityInfo.Type)) as IEntityField;

            field.Build(this.serializedObject);
            
            return field as VisualElement;
        }
    }
}