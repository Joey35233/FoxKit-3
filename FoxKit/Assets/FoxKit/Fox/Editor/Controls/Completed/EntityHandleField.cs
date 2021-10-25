using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Fox.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fox.Editor
{
    public class EntityHandleField : FoxField
    {
        private ObjectField InternalField;
        private SerializedProperty EntityProperty;

        public override string label
        {
            get => InternalField.label;
            set
            {
                IsUserAssignedLabel = true;
                InternalField.label = value;
            }
        }

        public EntityHandleField() : this(default)
        {
        }

        public EntityHandleField(string label)
        {
            InternalField = new ObjectField(label);
            if (label != null)
                IsUserAssignedLabel = true;
            InternalField.allowSceneObjects = true;
            InternalField.objectType = typeof(FoxEntity);

            this.AddToClassList("fox-entityhandle-field");
			this.AddToClassList("fox-base-field");
            this.styleSheets.Add(FoxField.FoxFieldStyleSheet);
            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label)
        {
            this.EntityProperty = property.FindPropertyRelative("entity");

            if (!IsUserAssignedLabel)
                InternalField.label = label;
            InternalField.BindProperty(EntityProperty);
        }
    }

    [CustomPropertyDrawer(typeof(EntityHandle))]
    public class EntityHandleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new EntityHandleField(property.name);
            field.BindProperty(property);

            return field;
        }
    }
}