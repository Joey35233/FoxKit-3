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
        public BaseEntityField<Entity> Field;
        public VisualElement HeaderElement;
        public VisualElement BodyElement;
        public VisualElement FooterElement;
        public SerializedObject Object;
    }
    
    public class BaseEntityField<T> : BaseField<T>, IEntityField where T : Entity
    {
        public static new readonly string ussClassName = "fox-entityfield";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string headerUssClassName = ussClassName + "__header";
        public static readonly string headerLabelUssClassName = ussClassName + "__header-label";
        public static readonly string headerLineUssClassName = ussClassName + "__header-line";
        public static readonly string bodyUssClassName = ussClassName + "__body";
        public static readonly string footerUssClassName = ussClassName + "__footer";

        public VisualElement visualInput { get; }

        public BaseEntityField() : this(new VisualElement()) { }

        private BaseEntityField(VisualElement visInput)
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
                CustomEntityFieldDesc? customFieldDesc = EntityEditorManager.Get(entityInfoIterator);
                
                SuperclassList.Add((entityInfoIterator, customFieldDesc));

                entityInfoIterator = entityInfoIterator.Super;
            }
        }

        public void Build(SerializedObject serializedObject)
        {
            EntityFieldBuildContext context = new EntityFieldBuildContext{ Field = this as BaseEntityField<Entity>, Object = serializedObject };
            PreBuild(context);
            BuildBodyFromEntity(context);
        }
        
        private void BuildBodyFromEntity(EntityFieldBuildContext context)
        {
            for (int i = SuperclassList.Count - 1; i > -1; i--)
            {
                (EntityInfo classInfo, CustomEntityFieldDesc? customFieldDesc) = SuperclassList[i];
                
                // ----------------
                // Init context
                context.HeaderElement = null;
                context.BodyElement = null;
                context.FooterElement = null;
                
                // ----------------
                // HEADER
                VisualElement header = new VisualElement();
                context.HeaderElement = header;
                header.AddToClassList(headerUssClassName);

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
                headerLabel.AddToClassList(headerLabelUssClassName);
                header.Add(headerLabel);

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
                headerLabel.AddToClassList(headerLineUssClassName);
                header.Add(headerLine);

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
                {
                    visualInput.Add(header);
                    continue;
                }
                
                // ----------------
                // CUSTOM HEADER
                if (customFieldDesc?.BuildHeader is { } buildHeader)
                {
                    buildHeader(context);
                }
                visualInput.Add(header);
                
                // ----------------
                // BODY
                VisualElement body = new VisualElement();
                body.AddToClassList(bodyUssClassName);
                context.BodyElement = body;
                if (customFieldDesc?.BuildBody is { } buildBody)
                {
                    buildBody(context);
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
                        
                        body.Add(fieldElement);
                    }
                }
                visualInput.Add(body);
                
                // ----------------
                // FOOTER
                VisualElement footer = new VisualElement();
                footer.AddToClassList(footerUssClassName);
                context.FooterElement = footer;
                if (customFieldDesc?.BuildFooter is { } buildFooter)
                {
                    buildFooter(context);
                }
                visualInput.Add(footer);
            }

            return;
        }

        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => labelElement;
    }
}