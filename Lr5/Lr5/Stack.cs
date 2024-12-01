using System;

namespace Lr5
{
    internal class Stack<T>
    {
        private T[] _items;
        private int _size;

        public Stack(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if (_size == _items.Length)
                throw new InvalidOperationException("Стек переполнен.");
            _items[_size++] = item;
        }

        public T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("Стек пуст.");
            return _items[--_size];
        }
    }
}