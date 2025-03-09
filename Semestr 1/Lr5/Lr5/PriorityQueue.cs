using System;

namespace Lr5
{
    internal class PriorityQueue<T> where T : IComparable<T>
    {
        private int _maxSize;
        private T[] _queueArray;
        private int _nItems;

        public PriorityQueue(int size)
        {
            _maxSize = size;
            _queueArray = new T[_maxSize];
            _nItems = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Приоритетная очередь переполнена.");

            int j;
            if (_nItems == 0)
            {
                _queueArray[_nItems++] = item;
            }
            else
            {
                for (j = _nItems - 1; j >= 0; j--)
                {
                    if (item.CompareTo(_queueArray[j]) > 0)
                    {
                        _queueArray[j + 1] = _queueArray[j];
                    }
                    else
                    {
                        break;
                    }
                }
                _queueArray[j + 1] = item;
                _nItems++;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Приоритетная очередь пуста.");
            return _queueArray[--_nItems];
        }

        public T PeekMin()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Приоритетная очередь пуста.");
            return _queueArray[_nItems - 1];
        }

        public bool IsEmpty()
        {
            return _nItems == 0;
        }

        public bool IsFull()
        {
            return _nItems == _maxSize;
        }
    }
}