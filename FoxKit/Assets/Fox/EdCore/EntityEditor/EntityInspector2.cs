using System;
using Fox.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class CustomEntityInspector2 : Attribute
    {
        public bool OverridesHeader;
        public bool OverridesBody;
        public BuildBodyOverrideBehavior BuildBodyOverrideBehavior;
        public bool OverridesFooter;
        
        public CustomEntityInspector2(bool overridesHeader, bool overridesBody,
            BuildBodyOverrideBehavior buildBodyOverrideBehavior, bool overridesFooter)
        {
            OverridesHeader = overridesHeader;
            OverridesBody = overridesBody;
            BuildBodyOverrideBehavior = buildBodyOverrideBehavior;
            OverridesFooter = overridesFooter;
        }
    }
    
    public class EntityInspector2<T> where T : Entity, new()
    {
        public T Target;

        protected EntityInspector2(T target)
        {
            Target = target;
        }

        public virtual void BuildHeader(VisualElement header)
        {
            
        }

        public virtual void BuildBody(VisualElement body)
        {
            
        }

        public virtual void BuildFooter(VisualElement footer)
        {
            
        }
    }
}