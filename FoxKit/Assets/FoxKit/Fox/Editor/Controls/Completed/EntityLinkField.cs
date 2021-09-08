using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class EntityLinkField : IFoxField
    {
        private PropertyField InternalField;
        private SerializedProperty Property;

        public EntityLinkField()
        {
            InternalField = new PropertyField();

            this.Add(InternalField);
        }

        public EntityLinkField(string label)
        {
            InternalField = new PropertyField(null, label);

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            this.Property = property;

            InternalField.label = label;
            InternalField.BindProperty(property);
        }
    }

    //[CustomPropertyDrawer(typeof(Fox.Core.EntityLink))]
    //public class EntityLinkDrawer : PropertyDrawer
    //{
    //    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //    {
    //        var field = new EntityLinkField();
    //        field.BindProperty(property);
            
    //        return field;
    //    }
    //}
}