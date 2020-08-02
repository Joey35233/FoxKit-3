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
    }
}