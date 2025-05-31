using System;
using Fox.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    [CustomEditor(typeof(Entity), true)]
    public class BaseEntityEditor : UnityEditor.Editor
    {
        protected new Entity target => base.target as Entity;
        
        public override VisualElement CreateInspectorGUI()
        {
            EntityInfo entityInfo = target.GetClassEntityInfo();
            
            CustomEntityFieldDesc? customFieldDesc = EntityEditorManager.Get(entityInfo);
            IEntityField field = customFieldDesc?.Constructor() ?? Activator.CreateInstance(typeof(BaseEntityField<>).MakeGenericType(entityInfo.Type)) as IEntityField;

            field.Build(this.serializedObject);
            
            return field as VisualElement;
        }
    }
}