using System;

using UnityEngine;

namespace Fox
{
    [Serializable]
    public struct PathFileNameCode
    {
        [SerializeField]
        private ulong hash;

        public PathFileNameCode(string str)
        {
            hash = Hashing.PathFileNameCode(str);
        }

        public static bool TryParse(string str, out PathFileNameCode outValue)
        {
            return ulong.TryParse(str, out outValue.hash);
        }

        public override string ToString()
        {
            return hash.ToString("x");
        }
    }
}