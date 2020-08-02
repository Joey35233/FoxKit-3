using System;

using UnityEngine;

namespace Fox
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
    }
}