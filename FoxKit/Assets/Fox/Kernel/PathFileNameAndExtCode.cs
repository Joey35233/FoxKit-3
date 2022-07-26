using System;

using UnityEngine;

namespace Fox.Kernel
{
    [Serializable]
    public struct PathFileNameAndExtCode
    {
        [SerializeField]
        private ulong hash;

        public PathFileNameAndExtCode(string str)
        {
            hash = Hashing.PathFileNameAndExtCode(str);
        }

        public bool TryParse(string str)
        {
            return ulong.TryParse(str, out hash);
        }
    }
}