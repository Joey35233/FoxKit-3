using System;

using UnityEngine;

namespace Fox.Kernel
{
    [Serializable]
    public struct PathFileNameCode32
    {
        [SerializeField]
        private uint hash;

        public PathFileNameCode32(string str)
        {
            hash = Hashing.PathFileNameCode32(str);
        }

        public bool TryParse(string str)
        {
            return uint.TryParse(str, out hash);
        }
    }
}