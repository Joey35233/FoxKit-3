using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Fox.Kernel
{
    public interface IStringMap
    {
        public void Insert(String key, object value);
        public void Insert(String key);

        public bool Remove(String key);

        public object this[String key] { get; }

        public bool ContainsKey(String key);

        public int OccupiedIndexToAbsoluteIndex(int index);
    }

    [Serializable]
    public class StringMap<T> : IStringMap, IList, IEnumerable<KeyValuePair<String, T>>
    {
        private const int InitialSize = 256;
        private const int LoadFactor = 90;

        [Serializable]
        public struct Cell
        {
            public Cell(uint distance, String key, T value)
            {
                Distance = distance;
                Key = key;
                Value = value;
            }

            override public string ToString()
            {
                if (Key is null)
                    return "Empty";
                else
                    return $"{{{Key}, {Value}}}";
            }

            public uint Distance;
            public String Key;
            public T Value;
        }

        [SerializeField]
        private int Threshold;
        [SerializeField]
        private uint HashMask; // Since this map has a 2^n size, (hash & HashMask) or (hash & Capacity - 1)
                               // serves the same remapping purpose as (hash % Capacity)

        [SerializeField]
        private int CellCount;
        [SerializeField]
        private List<Cell> Cells; // Open addressing style,
                                  // Unfortunately, we have to use a List<T> instead of an array because SerializedProperty.boxedObject won't work any other way which is weird

        public StringMap()
        {
            CellCount = 0;

            Allocate(InitialSize);
        }

        private int RoundUpToPowerOfTwo(int x)
        {
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x++;

            return x;
        }

        public StringMap(int capacity)
        {
            CellCount = 0;

            Allocate(capacity <= InitialSize ? InitialSize : RoundUpToPowerOfTwo(capacity));
        }

        private void Allocate(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException();

            Cells = new List<Cell>(capacity);
            for (int i = 0; i < capacity; i++)
                Cells.Add(new Cell());

            Threshold = capacity * LoadFactor / 100;

            HashMask = unchecked((uint)(capacity - 1));
        }

        private bool IsCellEmpty(Cell cell)
        {
            return cell.Key is null || cell.Key.IsPseudoNull();
        }

        private void Resize()
        {
            List<Cell> oldCells = Cells;

            int newCapacity = Cells.Count * 2;

            Allocate(newCapacity);

            for (int i = 0; i < oldCells.Count; i++)
            {
                Cell oldCell = oldCells[i];

                if (!IsCellEmpty(oldCell))
                {
                    InsertNoResize(oldCell.Key, oldCell.Value);
                }
            }
        }

        private void InsertNoResize(String key, T value)
        {
            uint index = key.Hash & HashMask;

            uint probeDistance = 0;
            while (true)
            {
                Cell cell = Cells[(int)index];

                // If cell is uninitialized
                if (IsCellEmpty(cell))
                {
                    Cells[(int)index] = new Cell(probeDistance, key, value);
                    return;
                }

                if (cell.Key == key)
                    throw new ArgumentException();

                // If another cell already exists
                uint existingProbeDistance = cell.Distance;
                if (existingProbeDistance < probeDistance)
                {
                    // Swap cells
                    Cells[(int)index] = new Cell(probeDistance, key, value);
                    key = cell.Key;
                    value = cell.Value;
                    probeDistance = existingProbeDistance;
                }

                index = (index + 1) & HashMask; // Loop index back to 0 if it will exceed Capacity.
                probeDistance++;
            }
        }

        public void Insert(String key, T value)
        {
            if (key is null)
                throw new ArgumentNullException();

            if (++CellCount >= Threshold)
                Resize();

            InsertNoResize(key, value);
        }
        void IStringMap.Insert(String key, object value)
        {
            Insert(key, value is T ? (T)value : throw new InvalidCastException());
        }
        void IStringMap.Insert(String key)
        {
            Insert(key, default(T));
        }

        public bool Remove(String key)
        {
            if (key is null)
                throw new ArgumentNullException();

            uint index = key.Hash & HashMask;

            uint probeDistance = 0;
            while (true)
            {
                Cell cell = Cells[(int)index];

                // If cell is uninitialized
                if (IsCellEmpty(cell))
                {
                    return false;
                }
                else if (probeDistance > cell.Distance)
                {
                    return false;
                }
                else if (key == cell.Key)
                {
                    break;
                }

                index = (index + 1) & HashMask; // Loop index back to 0 if it will exceed Capacity.
                probeDistance++;
            }

            uint lastIndex = index;
            uint nextIndex = index;
            while (true)
            {
                nextIndex = (nextIndex + 1) & HashMask; // Loop index back to 0 if it will exceed Capacity.

                Cell nextCell = Cells[(int)nextIndex];

                if (IsCellEmpty(nextCell))
                {
                    Cell cell = Cells[(int)index];
                    cell.Key = null;
                    Cells[(int)index] = cell;

                    break;
                }
                else if (nextCell.Distance == 0)
                {
                    Cell cell = Cells[(int)index];
                    cell.Key = null;
                    Cells[(int)index] = cell;

                    break;
                }
                else
                {
                    Cells[(int)lastIndex] = Cells[(int)nextIndex];
                    Cell cell = Cells[(int)lastIndex];
                    cell.Distance--;
                    Cells[(int)lastIndex] = cell;
                }


                lastIndex = nextIndex; // Loop index back to 0 if it will exceed Capacity.
            }

            CellCount--;
            return true;
        }

        public bool TryGetValue(String key, out T value)
        {
            if (key is null)
                throw new ArgumentNullException();

            uint index = key.Hash & HashMask;

            uint probeDistance = 0;
            while (true)
            {
                Cell cell = Cells[(int)index];

                // If cell is uninitialized
                if (IsCellEmpty(cell))
                {
                    value = default;
                    return false;
                }
                else if (probeDistance > cell.Distance)
                {
                    value = default;
                    return false;
                }
                else if (key == cell.Key)
                {
                    value = Cells[(int)index].Value;
                    return true;
                }

                index = (index + 1) & HashMask; // Loop index back to 0 if it will exceed Capacity.
                probeDistance++;
            }
        }

        public T this[String key]
        {
            get
            {
                T value;
                if (TryGetValue(key, out value))
                    return value;
                else
                    throw new KeyNotFoundException();
            }
        }
        object IStringMap.this[String key]
        {
            get
            {
                return this[key];
            }
        }

        public bool ContainsKey(String key)
        {
            return TryGetValue(key, out _);
        }

        private float GetAverageProbeCount()
        {
            float total = 0;

            for (int i = 0; i < Cells.Count; i++)
            {
                Cell cell = Cells[i];

                if (!IsCellEmpty(cell))
                {
                    total += cell.Distance;
                }
            }

            return total / CellCount + 1;
        }

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count => (int)CellCount;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public object this[int index] { get => Cells[index]; set => throw new NotImplementedException(); }

        int IStringMap.OccupiedIndexToAbsoluteIndex(int index)
        {
            int i = 0;
            for (int j = -1; j < index; i++)
            {
                if (!IsCellEmpty(Cells[i]))
                    j++;
            }

            return i - 1;
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index >= Cells.Count || index < 0)
                return;

            int lastIndex = index;
            int nextIndex = index;
            while (true)
            {
                nextIndex = (int)((nextIndex + 1) & HashMask); // Loop index back to 0 if it will exceed Capacity.

                Cell nextCell = Cells[nextIndex];

                if (IsCellEmpty(nextCell))
                {
                    Cell cell = Cells[index];
                    cell.Key = null;
                    Cells[index] = cell;

                    break;
                }
                else if (nextCell.Distance == 0)
                {
                    Cell cell = Cells[index];
                    cell.Key = null;
                    Cells[index] = cell;

                    break;
                }
                else
                {
                    Cells[lastIndex] = Cells[nextIndex];
                    Cell cell = Cells[lastIndex];
                    cell.Distance--;
                    Cells[lastIndex] = cell;
                }

                lastIndex = nextIndex; // Loop index back to 0 if it will exceed Capacity.
            }

            CellCount--;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<String, T>> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<KeyValuePair<String, T>>, IDictionaryEnumerator
        {
            private StringMap<T> stringMap;
            private int absoluteCellsIndex;
            private int index;
            private KeyValuePair<String, T> current;

            internal Enumerator(StringMap<T> stringMap)
            {
                this.stringMap = stringMap;
                absoluteCellsIndex = 0;
                index = 0;
                current = new KeyValuePair<String, T>();
            }

            public bool MoveNext()
            {
                while ((uint)index < (uint)stringMap.Count)
                {
                    var cell = stringMap.Cells[absoluteCellsIndex];
                    if (cell.Key is not null && !cell.Key.IsPseudoNull())
                    {
                        current = new KeyValuePair<String, T>(stringMap.Cells[absoluteCellsIndex].Key, stringMap.Cells[absoluteCellsIndex].Value);
                        absoluteCellsIndex++;
                        index++;
                        return true;
                    }
                    absoluteCellsIndex++;
                }

                index = stringMap.Count + 1;
                current = new KeyValuePair<String, T>();
                return false;
            }

            public KeyValuePair<String, T> Current => current;

            public void Dispose()
            {
            }

            object IEnumerator.Current => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : new KeyValuePair<String, T>(current.Key, current.Value);

            void IEnumerator.Reset()
            {
                absoluteCellsIndex = 0;
                index = 0;
                current = new KeyValuePair<String, T>();
            }

            DictionaryEntry IDictionaryEnumerator.Entry => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : new DictionaryEntry(current.Key, current.Value);

            object IDictionaryEnumerator.Key => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : current.Key;

            object IDictionaryEnumerator.Value => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : current.Value;
        }
    }
}