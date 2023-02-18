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

        public bool TryParse(string str) => UInt32.TryParse(str, out hash);
    }
}