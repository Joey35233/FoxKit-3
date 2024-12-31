using UnityEditor;

namespace Fox.Core
{
    public static class AssetManager
    {
        public static T LoadAssetAtPath<T>(Fox.Path path, out string unityPath) where T : UnityEngine.Object
        {
            unityPath = "Assets/Game" + path.CString;
            T asset = AssetDatabase.LoadAssetAtPath<T>(unityPath);
            return asset;
        }

        public static T LoadAssetAtPathWithExtensionReplacement<T>(Fox.Path path, string newExtension, out string unityPath) where T : UnityEngine.Object
        {
            unityPath = "Assets/Game" + path.CString + '.' + newExtension;
            T asset = AssetDatabase.LoadAssetAtPath<T>(unityPath);
            return asset;
        }

        public static T LoadAsset<T>(Core.FilePtr filePtr, out string unityPath) where T : UnityEngine.Object
        {
            return LoadAssetAtPath<T>(filePtr.path, out unityPath);
        }

        public static T LoadAssetWithExtensionReplacement<T>(Core.FilePtr filePtr, string newExtension, out string unityPath) where T : UnityEngine.Object
        {
            return LoadAssetAtPathWithExtensionReplacement<T>(filePtr.path, newExtension, out unityPath);
        }
    }
}