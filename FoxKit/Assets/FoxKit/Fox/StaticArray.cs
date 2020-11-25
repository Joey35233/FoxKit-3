using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

namespace Fox
{
    [System.Serializable]
    public class StaticArray<T> : IList<T>
    {
        private List<T> _list;

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public StaticArray(int capacity)
        {
            _list = new List<T>(capacity);
            for (int i = 0; i < capacity; i++)
                _list.Add(default);
        }

        //bool IList<T>.IsFixedSize()
        //{
        //    return false;
        //}
    }
}