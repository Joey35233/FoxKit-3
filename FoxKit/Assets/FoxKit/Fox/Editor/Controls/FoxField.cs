using UnityEngine.UIElements;
using UnityEditor;

namespace Fox.Editor
{
    public abstract class FoxField : BindableElement
    {
        public static StyleSheet FoxFieldStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/FoxField.uss");

        public abstract string label { get; set; }

        protected bool IsUserAssignedLabel = false;

        public abstract void BindProperty(SerializedProperty property);
        public abstract void BindProperty(SerializedProperty property, string label);
    }

    public interface IFoxNumericField : IBindable
    {
        public abstract void BindProperty(SerializedProperty property);
        public abstract void BindProperty(SerializedProperty property, string label);
    }
}