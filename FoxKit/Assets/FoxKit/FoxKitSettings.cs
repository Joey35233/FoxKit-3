using UnityEngine;

namespace FoxKit
{
    [CreateAssetMenu(fileName = "FoxKitSettings", menuName = "FoxKit/Settings")]
    public class FoxKitSettings : ScriptableObject
    {
        public string sourceAssetsPath;
    }
}
