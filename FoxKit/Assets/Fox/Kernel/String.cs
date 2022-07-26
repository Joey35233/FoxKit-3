using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Kernel
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size=16, CharSet=CharSet.Ansi)]
    public class String
    {
        [SerializeField, FieldOffset(0)]
        private string _cString;
        public string CString
        {
            get => _cString;
        }

        [SerializeField, FieldOffset(8)]
        private int _length;
        public int Length
        {
            get => _length;
        }

        [SerializeField, FieldOffset(12)]
        private StrCode _hash;
        public StrCode Hash
        {
            get => _hash;
        }

        /// <summary>
        /// The empty string.
        /// </summary>
        public static String Empty { get; }

        static String()
        {
            Empty = new String
            {
                _cString = string.Empty,
                _length = 0,
                _hash = new StrCode(string.Empty)
            };
        }

        private String()
        {

        }

        public String(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this._cString = name;
                this._length = name.Length;
                this._hash = new StrCode(name);
            }
            else
            {
                this._cString = Empty.CString;
                this._length = Empty.Length;
                this._hash = Empty.Hash;
            }
        }

        public static bool operator==(String a, String b)
        {
            return a?.Hash == b?.Hash;
        }

        public static bool operator!=(String a, String b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return CString;
        }

        public bool IsPseudoNull() => (Length == 0) && (Hash != Empty.Hash);

        public override bool Equals(object obj)
        {
            return obj is String rhs && this == rhs;
        }

        public override int GetHashCode()
        {
            return unchecked((int)Hash.GetBacking());
        }

        public static implicit operator String(string @string) => new String(@string);
        public static implicit operator string(String @string) => @string.CString;
    }
}