using Fox.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public interface IFoxField : IBindable
    {
        private static readonly StyleSheet FoxFieldLightStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Fox/EdCore/FoxFieldLight.uss");
        private static readonly StyleSheet FoxFieldDarkStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Fox/EdCore/FoxFieldDark.uss");

        public static string GetBindingPathForPropertyName(string name) => $"<{name}>k__BackingField";
        
        public void SetLabel(string label);
        public Label GetLabelElement();
        
        public static StyleSheet FoxFieldStyleSheet => EditorGUIUtility.isProSkin ? FoxFieldDarkStyleSheet : FoxFieldLightStyleSheet;
    }
}