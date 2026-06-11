using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox
{
    public interface IStringMap
    {
        public void Insert(string key, object value);

        public bool Remove(string key);

        public object this[string key] { get; }

        public bool ContainsKey(string key);

        public int OccupiedIndexToBackingIndex(int index);

        public List<KeyValuePair<string, object>> ToList();
    }

    [Serializable]
    public class StringMap<T> : IStringMap, IList, IEnumerable<KeyValuePair<string, T>>
    {
        private const int InitialSize = 256;
        private const int LoadFactor = 90;

        [Serializable]
        public struct Cell
        {
            public Cell(uint distance, string key, T value)
            {
                Occupied = true;
                Distance = distance;
                Key = key;
                Value = value;
            }

            public override string ToString() => !Occupied ? "Empty" : $"{{{Key}, {Value}}}";

            public bool Occupied;
            public uint Distance;
            public string Key;
            public T Value;
        }

        [SerializeField]
        private int Threshold;
        [SerializeField]
        private uint HashMask; // Since this map has a 2^n size, (hash & HashMask) or (hash & Capacity - 1)
                               // serves the same remapping purpose as (hash % Capacity)

        [SerializeField]
        private int OccupiedCount;
        [SerializeField]
        private List<Cell> CellsBacking; // Unfortunately, we have to use a List<T> instead of an array because SerializedProperty.boxedObject won't work any other way which is weird

        #region PUBLIC
        public StringMap()
        {
            OccupiedCount = 0;

            Allocate(InitialSize);
        }

        public StringMap(int capacity)
        {
            OccupiedCount = 0;

            Allocate(capacity <= InitialSize ? InitialSize : RoundUpToPowerOfTwo(capacity));
        }

        public void Insert(string key, T value)
        {
            if (key is null)
                throw new ArgumentNullException();

            if (!InsertNoResize(key, value))
                throw new ArgumentException("Key already exists!");

            if (++OccupiedCount >= Threshold)
                Resize();
        }
        void IStringMap.Insert(string key, object value) => Insert(key, value is T valueT ? valueT : throw new InvalidCastException());
        

        public void InsertOrUpdate(string key, T value)
        {
            if (key is null)
                throw new ArgumentNullException();

            bool inserted = InsertOrUpdateNoResize(key, value);

            if (inserted && (++OccupiedCount >= Threshold))
                Resize();
        }

        public bool TryGetValue(string key, out T value)
        {
            if (key is null)
                throw new ArgumentNullException();

            StrCode keyHash = new StrCode(key);
            int index = (int)(keyHash & HashMask);

            uint probeDistance = 0;
            while (true)
            {
                Cell slot = CellsBacking[index];

                // If slot is unoccupied or next available slot is unoccupied
                if (!slot.Occupied || probeDistance > slot.Distance)
                {
                    value = default;
                    return false;
                }
                // Found
                else if (key == slot.Key)
                {
                    value = slot.Value;
                    return true;
                }
 
                // Loop index back to 0 if it will exceed Capacity.
                index = (int)((index + 1) & HashMask);
                probeDistance++;
            }
        }

        public T this[string key]
        {
            get => TryGetValue(key, out T value) ? value : throw new KeyNotFoundException();
            set => InsertOrUpdate(key, value);
        }
        object IStringMap.this[string key] => this[key];

        public bool ContainsKey(string key) => TryGetValue(key, out _);
        
        public bool Remove(string key)
        {
            if (key is null)
                throw new ArgumentNullException();

            StrCode keyHash = new StrCode(key);
            int index = (int)(keyHash & HashMask);

            uint probeDistance = 0;
            while (true)
            {
                Cell slot = CellsBacking[index];

                // If slot is unoccupied or next available slot is unoccupied
                if (!slot.Occupied || probeDistance > slot.Distance)
                {
                    return false;
                }
                // Found
                else if (key == slot.Key)
                {
                    break;
                }

                // Loop index back to 0 if it will exceed Capacity.
                index = (int)((index + 1) & HashMask);
                probeDistance++;
            }

            int lastIndex = index;
            int nextIndex = index;
            while (true)
            {
                // Loop index back to 0 if it will exceed Capacity.
                nextIndex = (int)((nextIndex + 1) & HashMask);

                Cell nextCell = CellsBacking[nextIndex];

                if (!nextCell.Occupied || nextCell.Distance == 0)
                {
                    CellsBacking[index] = new Cell();

                    break;
                }
                else
                {
                    nextCell.Distance--;
                    CellsBacking[lastIndex] = nextCell;
                }

                lastIndex = nextIndex;
            }

            OccupiedCount--;
            return true;
        }
        
        #endregion

        #region PRIVATE
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

        private void Allocate(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException();

            CellsBacking = new List<Cell>(capacity);
            for (int i = 0; i < capacity; i++)
                CellsBacking.Add(new Cell());

            Threshold = capacity * LoadFactor / 100;

            HashMask = unchecked((uint)(capacity - 1));
        }

        private void Resize()
        {
            List<Cell> oldBacking = CellsBacking;

            int newCapacity = CellsBacking.Count * 2;

            Allocate(newCapacity);

            foreach (Cell cell in oldBacking)
                if (cell.Occupied)
                    InsertNoResize(cell.Key, cell.Value);
        }

        private bool InsertNoResize(string key, T value)
        {
            StrCode keyHash = new StrCode(key);
            int index = (int)(keyHash & HashMask);

            uint probeDistance = 0;
            while (true)
            {
                Cell slot = CellsBacking[index];

                // If slot is open, insert cell
                if (!slot.Occupied)
                {
                    CellsBacking[index] = new Cell(probeDistance, key, value);
                    return true;
                }

                // Nothing added
                if (slot.Key == key)
                    return false;

                // If another cell already exists
                uint existingProbeDistance = slot.Distance;
                if (existingProbeDistance < probeDistance)
                {
                    // Swap cells
                    CellsBacking[index] = new Cell(probeDistance, key, value);
                    key = slot.Key;
                    value = slot.Value;
                    probeDistance = existingProbeDistance;
                }

                // Loop index back to 0 if it will exceed Capacity.
                index = (int)((index + 1) & HashMask);
                probeDistance++;
            }
        }

        private bool InsertOrUpdateNoResize(string key, T value)
        {
            StrCode keyHash = new StrCode(key);
            int index = (int)(keyHash & HashMask);

            uint probeDistance = 0;
            while (true)
            {
                Cell slot = CellsBacking[index];

                // If slot is open, insert cell
                if (!slot.Occupied)
                {
                    CellsBacking[index] = new Cell(probeDistance, key, value);
                    return true;
                }

                // Nothing added
                if (slot.Key == key)
                {
                    slot.Value = value;
                    CellsBacking[index] = slot;
                    return false;
                }

                // If another cell already exists
                uint existingProbeDistance = slot.Distance;
                if (existingProbeDistance < probeDistance)
                {
                    // Swap cells
                    CellsBacking[index] = new Cell(probeDistance, key, value);
                    key = slot.Key;
                    value = slot.Value;
                    probeDistance = existingProbeDistance;
                }
                
                // Loop index back to 0 if it will exceed Capacity.
                index = (int)((index + 1) & HashMask);
                probeDistance++;
            }
        }

        private float GetAverageProbeCount()
        {
            uint total = 0;

            foreach (Cell cell in CellsBacking)
                if (cell.Occupied)
                    total += cell.Distance;

            return ((float)total / OccupiedCount) + 1;
        }
        #endregion

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count => OccupiedCount;

        public bool IsSynchronized => false;

        public object SyncRoot => throw new NotImplementedException();

        public object this[int index] { get => CellsBacking[index]; set => throw new NotImplementedException(); }

        // Annoying hack for editor; we have a list of occupied cells and need to get the index of each one in terms of their indices in the backing array
        int IStringMap.OccupiedIndexToBackingIndex(int index)
        {
            int i = 0;
            for (int j = -1; j < index; i++)
            {
                if (CellsBacking[i].Occupied)
                    j++;
            }

            return i - 1;
        }

        public int Add(object value) => throw new NotImplementedException();

        public void Clear()
        {
            OccupiedCount = 0;
            for (int i = 0; i < CellsBacking.Count; i++)
                CellsBacking[i] = new Cell();
        }

        public bool Contains(object value) => throw new NotImplementedException("Use ContainsKey");

        public int IndexOf(object value) => throw new NotImplementedException();

        public void Insert(int index, object value) => throw new NotImplementedException();

        public void Remove(object value) => throw new NotImplementedException();

        public void RemoveAt(int index)
        {
            if (index >= CellsBacking.Count || index < 0)
                return;

            int lastIndex = index;
            int nextIndex = index;
            while (true)
            {
                nextIndex = (int)((nextIndex + 1) & HashMask); // Loop index back to 0 if it will exceed Capacity.

                Cell nextCell = CellsBacking[nextIndex];

                if (!nextCell.Occupied)
                {
                    Cell cell = CellsBacking[index];
                    cell.Key = null;
                    cell.Occupied = false;
                    CellsBacking[index] = cell;

                    break;
                }
                else if (nextCell.Distance == 0)
                {
                    Cell cell = CellsBacking[index];
                    cell.Key = null;
                    cell.Occupied = false;
                    CellsBacking[index] = cell;

                    break;
                }
                else
                {
                    CellsBacking[lastIndex] = CellsBacking[nextIndex];
                    Cell cell = CellsBacking[lastIndex];
                    cell.Distance--;
                    CellsBacking[lastIndex] = cell;
                }

                lastIndex = nextIndex; // Loop index back to 0 if it will exceed Capacity.
            }

            OccupiedCount--;
        }

        public void CopyTo(Array array, int index) => throw new NotImplementedException();

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => new Enumerator(this);

        public struct Enumerator : IEnumerator<KeyValuePair<string, T>>, IDictionaryEnumerator
        {
            private readonly StringMap<T> stringMap;
            private int absoluteCellsIndex;
            private int index;
            private KeyValuePair<string, T> current;

            internal Enumerator(StringMap<T> stringMap)
            {
                this.stringMap = stringMap;
                absoluteCellsIndex = 0;
                index = 0;
                current = new KeyValuePair<string, T>();
            }

            public bool MoveNext()
            {
                while (index < stringMap.Count)
                {
                    Cell cell = stringMap.CellsBacking[absoluteCellsIndex];
                    if (cell.Occupied)
                    {
                        current = new KeyValuePair<string, T>(stringMap.CellsBacking[absoluteCellsIndex].Key, stringMap.CellsBacking[absoluteCellsIndex].Value);
                        absoluteCellsIndex++;
                        index++;
                        return true;
                    }
                    absoluteCellsIndex++;
                }

                index = stringMap.Count + 1;
                current = new KeyValuePair<string, T>();
                return false;
            }

            public KeyValuePair<string, T> Current => current;

            public void Dispose()
            {
            }

            object IEnumerator.Current => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : new KeyValuePair<string, T>(current.Key, current.Value);

            void IEnumerator.Reset()
            {
                absoluteCellsIndex = 0;
                index = 0;
                current = new KeyValuePair<string, T>();
            }

            DictionaryEntry IDictionaryEnumerator.Entry => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : new DictionaryEntry(current.Key, current.Value);

            object IDictionaryEnumerator.Key => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : current.Key;

            object IDictionaryEnumerator.Value => (index == 0 || (index == stringMap.Count + 1)) ? throw new IndexOutOfRangeException() : current.Value;
        }

        public List<KeyValuePair<string, object>> ToList()
        {
            var res = new List<KeyValuePair<string, object>>();
            foreach (Cell cell in this.CellsBacking)
            {
                if (!cell.Occupied)
                {
                    continue;
                }

                res.Add(new KeyValuePair<string, object>(cell.Key, cell.Value));
            }

            return res;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}