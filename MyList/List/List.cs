using System;
using System.Collections;

namespace List
{
    public class List : IEnumerable, IEnumerator
    {
        private const int InitialSize = 4;
        private const int ExtendTimes = 2;

        private object[] _array;
        private int _count;
        private int _currentIndex = -1;

        public int Count { get { return _count; } }

        public object Current => _array[_currentIndex];

        public object this[int index]
        {
            get
            {
                if (index < _count)
                {
                    return _array[index];
                }
                throw new IndexOutOfRangeException();
            }
        }

        public List()
        {
            _array = new object[InitialSize];
        }

        public void Add(object objectToAdd)
        {
            if (objectToAdd == null)
            {
                throw new ArgumentNullException("objectToAdd");
            }

            int length = _array.Length;

            TryAddObjectToFirstEmptySpace(objectToAdd, out bool result);

            if (!result)
            {
                ExtendArray();
                _array[length] = objectToAdd;
            }
            
            _count++;
        }

        public void Clear()
        {
            _array = new object[4];
            _count = 0;
        }

        public bool Contains(object item)
        {
            bool result = false;

            foreach (var current in _array)
            {
                if (current.Equals(item))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        public void Remove(object objectToRemove)
        {
            int indexRemove = -1;

            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(objectToRemove))
                {
                    indexRemove = i;
                    break;
                }
            }

            if (indexRemove == -1)
            {
                return;
            }

            RemoveAt(indexRemove);
        }
        
        public void RemoveAt(int index)
        {
            int indexLastObject = _count - 1;

            if (index < 0 && index >= _count)
            {
                throw new IndexOutOfRangeException("Index is greater than array length.");
            }

            for (int i = index; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[indexLastObject] = null;

            _count--;
        }

        public void Insert(int index, object objectToAdd)
        {
            if (index <= _count)
            {
                if (_count == _array.Length)
                {
                    ExtendArray();
                }

                for (int i = _array.Length - 2; i > index-1; i--)
                {
                    _array[i + 1] = _array[i];
                }

                _array[index] = objectToAdd;
                _count++;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is greater than array length.");
            }
        }

        private void TryAddObjectToFirstEmptySpace(object objectToAdd, out bool success)
        {
            success = false;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == null)
                {
                    _array[i] = objectToAdd;
                    success = true;
                    return;
                }
            }
        }

        private void ExtendArray()
        {
            var newArray = new object[_array.Length * ExtendTimes];

            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }
        
        public bool MoveNext()
        {
            _currentIndex++;
            
            return _currentIndex < _count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }
    }
}
