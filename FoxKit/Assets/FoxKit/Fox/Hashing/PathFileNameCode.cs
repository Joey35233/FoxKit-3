﻿using System;

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

        public bool TryParse(string str)
        {
            return ulong.TryParse(str, out hash);
        }
    }
}