using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Fox.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fox.Editor
{
    public class EntityHandleField : ObjectField
    {
        public new static readonly string ussClassName = "fox-entityhandle-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public EntityHandleField() 
            : this(null)
        {
        }

        public EntityHandleField(string label)
            : base(label)
        {
            RemoveFromClassList(ObjectField.ussClassName);
            AddToClassList(ussClassName);

            allowSceneObjects = true;
            objectType = typeof(FoxEntity);

            visualInput = this.Q(className: BaseField<string>.inputUssClassName);

            //visualInput.RemoveFromClassList(ObjectField.inputUssClassName);
            visualInput.AddToClassList(inputUssClassName);

            labelElement.RemoveFromClassList(ObjectField.labelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
    }

    [CustomPropertyDrawer(typeof(EntityHandle))]
    public class EntityHandleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new EntityHandleField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<Fox.Core.EntityHandle>.alignedFieldUssClassName);

            return field;
        }
    }
}