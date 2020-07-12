using System;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    [Serializable]
    public struct String
    {
        [SerializeField]
        private string cString;

        [SerializeField]
        private uint length;

        [SerializeField]
        private StrCode hash;

        /// <summary>
        /// The empty string.
        /// </summary>
        public static Fox.String Empty { get; }

        static String()
        {
            Empty = new String(string.Empty, 0, new StrCode(string.Empty));
        }

        public String(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.cString = name;
                this.length = (uint)name.Length;
                this.hash = new StrCode(name);
            }
            else
            {
                this.cString = Empty.CString();
                this.length = Empty.length;
                this.hash = Empty.hash;
            }
        }

        public string CString() => this.cString;

        private String(string cString, uint length, StrCode hash)
        {
            this.cString = cString;
            this.length = length;
            this.hash = hash;
        }
    }
}