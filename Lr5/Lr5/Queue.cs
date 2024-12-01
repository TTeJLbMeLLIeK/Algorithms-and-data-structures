using System;

namespace Lr5
{
    internal class Queue<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public Queue(int capacity)
        {
            _items = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
                throw new InvalidOperationException("Очередь переполнена.");
            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Очередь пуста.");
            T item = _items[_head];
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;
        }
    }
}