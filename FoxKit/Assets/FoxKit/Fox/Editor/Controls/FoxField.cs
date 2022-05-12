using UnityEngine.UIElements;
using UnityEditor;

namespace Fox.Editor
{
    public abstract class FoxField : BindableElement
    {
        private static StyleSheet FoxFieldLightStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/FoxField.uss");
        private static StyleSheet FoxFieldDarkStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/FoxFieldDark.uss");

        public static StyleSheet FoxFieldStyleSheet { get { return EditorGUIUtility.isProSkin ? FoxFieldDarkStyleSheet : FoxFieldLightStyleSheet; } }

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