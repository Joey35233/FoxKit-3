using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class EntityLinkField : FoxField
    {
        private Foldout InternalFoldout;
        private Label InternalLabel;
        private VisualElement InternalContainer;
        private bool IsInline;

        private EntityHandleField InternalHandleField;
        private PathField InternalPackagePathField;
        private PathField InternalArchivePathField;
        private StringField InternalNameField;

        public override string label
        {
            get => InternalFoldout.text;
            set
            {
                IsUserAssignedLabel = true;
                InternalFoldout.text = value;
            }
        }

        public EntityLinkField(bool isInline = false) : this(null, isInline)
        {

        }

        public EntityLinkField() : this(null)
        {
        }


        public EntityLinkField(string label) : this(label, false)
        {

        }

        public EntityLinkField(string label, bool isInline)
        {
            IsInline = isInline;

            if (!IsInline)
            {
                InternalFoldout = new Foldout();
                InternalFoldout.text = label;
                if (label != null)
                    IsUserAssignedLabel = true;
                InternalFoldout.style.flexDirection = FlexDirection.Column;
            }
            else
            {
                this.style.flexDirection = FlexDirection.Row;
                InternalLabel = new Label();
                InternalLabel.AddToClassList("unity-base-field__label");
                this.Add(InternalLabel);
                InternalLabel.text = label;
                if (label != null)
                    IsUserAssignedLabel = true;
            }

            InternalHandleField = new EntityHandleField();
            InternalPackagePathField = new PathField();
            InternalArchivePathField = new PathField();
            InternalNameField = new StringField();

            this.AddToClassList("fox-entitylink-field");
			this.AddToClassList("fox-base-field");

            if (!isInline)
            {
                InternalFoldout.Add(InternalHandleField);
                InternalFoldout.Add(InternalPackagePathField);
                InternalFoldout.Add(InternalArchivePathField);
                InternalFoldout.Add(InternalNameField);
                this.Add(InternalFoldout);
            }
            else
            {
                InternalContainer = new VisualElement();
                InternalContainer.style.flexDirection = FlexDirection.Column;
                InternalContainer.style.flexGrow = 1;
                InternalContainer.Add(InternalHandleField);
                InternalContainer.Add(InternalPackagePathField);
                InternalContainer.Add(InternalArchivePathField);
                InternalContainer.Add(InternalNameField);
                this.Add(InternalContainer);
            }

            this.styleSheets.Add(FoxFieldStyleSheet);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label)
        {
            if (!IsUserAssignedLabel)
            {
                if (!IsInline)
                    InternalFoldout.text = label;
                else
                    InternalLabel.text = label;
            }

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