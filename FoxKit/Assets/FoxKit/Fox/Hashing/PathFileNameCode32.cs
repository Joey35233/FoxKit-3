using System;

using UnityEngine;

namespace Fox
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
    }
}