using System;

namespace Lr5
{
    internal class Queue<T>
    {
        private int _maxSize;
        private T[] _queueArray;
        private int _front;
        private int _rear;
        private int _nItems;

        public Queue(int size)
        {
            _maxSize = size;
            _queueArray = new T[_maxSize];
            _front = 0;
            _rear = -1;
            _nItems = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Очередь переполнена.");
            if (_rear == _maxSize - 1) _rear = -1;
            _queueArray[++_rear] = item;
            _nItems++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Очередь пуста.");
            T temp = _queueArray[_front++];
            if (_front == _maxSize) _front = 0;
            _nItems--;
            return temp;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Очередь пуста.");
            return _queueArray[_front];
        }

        public bool IsEmpty()
        {
            return _nItems == 0;
        }

        public bool IsFull()
        {
            return _nItems == _maxSize;
        }

        public int Size()
        {
            return _nItems;
        }
    }
}