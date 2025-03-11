using System;

namespace Lr5
{
    internal class Stack<T>
    {
        private int _maxSize;
        private T[] _stackArray;
        private int _top;

        public Stack(int size)
        {
            _maxSize = size;
            _stackArray = new T[_maxSize];
            _top = -1;
        }

        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Стек переполнен.");
            _stackArray[++_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");
            return _stackArray[_top--];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");
            return _stackArray[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public bool IsFull()
        {
            return _top == _maxSize - 1;
        }
    }
}