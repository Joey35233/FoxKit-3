using System;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    [Serializable]
    public struct String
    {
        public string CString;

        public uint Length;

        public StrCode Hash;

        private static String DefaultString()
        {
            return new String
            {
                CString = "",
                Length = 0,
                Hash = new StrCode(""),
            };
        }

        public String(string name)
        {
            if (name != null)
            {
                CString = name;
                Length = (uint)name.Length;
                Hash = new StrCode(name);
            }
            else
            {
                this = DefaultString();
            }
        }
    }
}