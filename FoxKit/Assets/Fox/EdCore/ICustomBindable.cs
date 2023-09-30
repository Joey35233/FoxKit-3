using Fox.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public interface ICustomBindable : IBindable
    {
        void Bind(SerializedObject serializedObject)
        {
        }

        void BindProperty(SerializedProperty property);

        void BindProperty(SerializedProperty property, string label, PropertyInfo propertyInfo = null);
    }
}