using UnityEditor;

namespace Fox.Core
{
    public static class AssetManager
    {
        public static T LoadAssetAtPath<T>(Kernel.Path path, out string unityPath) where T : UnityEngine.Object
        {
            string pathStr = "/Assets/Game" + path.CString;

            // Remove leading /
            unityPath = pathStr.Remove(0, 1);
            T asset = AssetDatabase.LoadAssetAtPath<T>(unityPath);
            return asset;
        }

        public static T LoadAsset<T>(Core.FilePtr filePtr, out string unityPath) where T : UnityEngine.Object
        {
            return LoadAssetAtPath<T>(filePtr.path, out unityPath);
        }
    }
}