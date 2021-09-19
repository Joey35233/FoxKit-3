using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class EntityLinkField : IFoxField
    {
        private Foldout InternalFoldout;
        private EntityHandleField InternalHandleField;
        private PathField InternalPackagePathField;
        private PathField InternalArchivePathField;
        private StringField InternalNameField;
        private SerializedProperty Property;

        public EntityLinkField() : this(default)
        {
        }

        public EntityLinkField(string label)
        {
            InternalFoldout = new Foldout();
            InternalFoldout.text = label;
            InternalFoldout.style.flexDirection = FlexDirection.Column;

            InternalHandleField = new EntityHandleField();
            InternalPackagePathField = new PathField();
            InternalArchivePathField = new PathField();
            InternalNameField = new StringField();

            InternalFoldout.Add(InternalHandleField);
            InternalFoldout.Add(InternalPackagePathField);
            InternalFoldout.Add(InternalArchivePathField);
            InternalFoldout.Add(InternalNameField);

            this.Add(InternalFoldout);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            this.Property = property;

            InternalFoldout.text = label;

            InternalHandleField.BindProperty(property.FindPropertyRelative("handle"));
            InternalPackagePathField.BindProperty(property.FindPropertyRelative("packagePath"));
            InternalArchivePathField.BindProperty(property.FindPropertyRelative("archivePath"));
            InternalNameField.BindProperty(property.FindPropertyRelative("nameInArchive"));
        }
    }

    [CustomPropertyDrawer(typeof(Fox.Core.EntityLink))]
    public class EntityLinkDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new EntityLinkField();
            field.BindProperty(property);

            return field;
        }
    }
}