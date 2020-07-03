using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    public struct String
    {
        public string CString { get; private set; } // ASCII

        public uint Length { get; private set; }

        public StrCode Hash { get; private set; }

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