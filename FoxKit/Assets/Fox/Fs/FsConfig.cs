using System.IO;
using UnityEngine;

namespace Fox.Fs
{
    [CreateAssetMenu(fileName = "FsConfig", menuName = "Fox/Fs/FsConfig")]
    public class FsConfig : ScriptableObject
    {
        public static FsConfig Instance { get; internal set; }
        
        public string UnityBasePath;
        public string ExternalBasePath;

        public bool Validate()
        {
            bool externalBasePathCheck = !string.IsNullOrEmpty(ExternalBasePath) &&
                                         Directory.Exists(ExternalBasePath);

            return externalBasePathCheck;
        }
    }
}