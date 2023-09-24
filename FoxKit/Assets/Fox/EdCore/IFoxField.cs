using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public interface IFoxField : IBindable
    {
        private static readonly StyleSheet FoxFieldLightStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Fox/EdCore/FoxFieldLight.uss");
        private static readonly StyleSheet FoxFieldDarkStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Fox/EdCore/FoxFieldDark.uss");

        public static StyleSheet FoxFieldStyleSheet => EditorGUIUtility.isProSkin ? FoxFieldDarkStyleSheet : FoxFieldLightStyleSheet;
    }
}