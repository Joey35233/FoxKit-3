using UnityEditor;

namespace Fox.Core
{
    public static class AssetManager
    {
        public static T LoadAssetAtPath<T>(Kernel.Path path, out string unityPath) where T : UnityEngine.Object
        {
            unityPath = "Assets/Game" + path.CString;
            T asset = AssetDatabase.LoadAssetAtPath<T>(unityPath);
            return asset;
        }

        public static T LoadAssetAtPathWithExtensionReplacement<T>(Kernel.Path path, string newExtension, out string unityPath) where T : UnityEngine.Object
        {
            string oldExtension = System.IO.Path.GetExtension(path.CString);
            unityPath = "Assets/Game" + path.CString.Replace(oldExtension, newExtension);
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