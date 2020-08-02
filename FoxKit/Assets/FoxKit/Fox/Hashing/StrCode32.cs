﻿using System;

using UnityEngine;

namespace Fox
{
    [Serializable]
    public struct StrCode32
    {
        [SerializeField]
        private uint hash;

        public StrCode32(string str)
        {
            hash = Hashing.StrCode32(str);
        }
    }
}