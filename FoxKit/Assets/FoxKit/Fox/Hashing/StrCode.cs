using System;

using UnityEngine;

namespace Fox
{
    [Serializable]
    public struct StrCode
    {
        [SerializeField]
        private ulong hash;

        public StrCode(string str)
        {
            hash = Hashing.StrCode(str);
        }

        public static bool TryParse(string str, out StrCode outValue)
        {
            return ulong.TryParse(str, out outValue.hash);
        }

        public override string ToString()
        {
            return hash.ToString("x");
        }
    }
}