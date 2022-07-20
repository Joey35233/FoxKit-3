using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Core
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size=16, CharSet=CharSet.Ansi)]
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class String
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
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
        public static Fox.Core.String Empty { get; }

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

        public bool IsPseudoNull()
        {
            return (Length == 0) && (Hash != Empty.Hash);
        }

        public static implicit operator String(string @string) => new String(@string);
        public static implicit operator string(String @string) => @string.CString;
    }
}