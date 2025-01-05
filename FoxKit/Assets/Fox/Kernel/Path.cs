using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox
{
    [Serializable]
    public class Path
    {
        [SerializeField]
        private string cString;
        public string String => cString;

        public PathCode Hash => new PathCode(String);

        public static Path Empty => new Path("");

        private Path()
        {
            cString = Empty.String;
        }

        public Path(ReadOnlySpan<char> value)
            : this(new string(value))
        {
            
        }

        public Path(string name)
        {
            if (name is null)
                cString = Empty.String;
            else
                cString = name;
        }

        public Path(PathCode hash)
        {
            throw new NotImplementedException();
        }
        
        public override string ToString() => String;

        // Fox.Path
        public static bool operator ==(Path a, Path b)
        {
            if (a is null && b is not null)
                return false;
            if (a is not null && b is null)
                return false;

            if (a.String == b.String)
                return true;

            return a.Hash == b.Hash;
        }

        public static bool operator !=(Path a, Path b) => !(a == b);

        // // ReadOnlySpan<char> comparisons
        public static bool operator ==(Path a, ReadOnlySpan<char> b) => a == new Path(b);
        public static bool operator !=(Path a, ReadOnlySpan<char> b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is Path rhs && this == rhs;

        public override int GetHashCode() => unchecked(Hash.GetHashCode());
    }
}