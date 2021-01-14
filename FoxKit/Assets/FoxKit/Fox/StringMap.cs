using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Fox
{
    [Serializable]
    public class StringMap<T> //: IEnumerable<StringMap<T>.Cell>
    {
        [Serializable]
        public class Cell
        {
            public String Key;
            //public Cell cUnknown0;
            //public Cell cUnknown1;
            //public Cell cUnknown2;
            public T Value;
        }

        [SerializeField]
        private List<Cell> _cells;

        public T this[String key]
        {
            get => GetT(key);
        }
        private T GetT(String key)
        {
            T value;
            TryGet(key, out value);

            return value;
        }

        public bool TryGet(String key, out T value)
        {
            foreach (var cell in _cells)
            {
                if (key == cell.Key)
                {
                    value = cell.Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public void Insert(String key, T value)
        {
            if (ContainsKey(key))
                throw new System.ArgumentException();
            else
                _cells.Add(new Cell { Key = key, Value = value });
        }

        public void ChangeHashSize(uint newSize)
        {
            throw new System.NotImplementedException();
        }

        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    throw new System.NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new System.NotImplementedException();
        //}

        public bool ContainsKey(String key)
        {
            T value;
            if (TryGet(key, out value))
                return true;
            else
                return false;
        }
    }
}