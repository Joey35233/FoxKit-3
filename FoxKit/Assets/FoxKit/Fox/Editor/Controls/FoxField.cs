using UnityEngine.UIElements;
using UnityEditor;

namespace Fox.Editor
{
    public abstract class IFoxField : BindableElement
    {
        public abstract void BindProperty(SerializedProperty property);
        public abstract void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null);
    }
}