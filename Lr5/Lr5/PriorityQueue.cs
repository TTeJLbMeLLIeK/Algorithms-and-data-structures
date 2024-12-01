using System;
using System.Collections.Generic;

namespace Lr5
{
    internal class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> _items = new List<T>();

        public void Enqueue(T item)
        {
            _items.Add(item);
            _items.Sort();
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Приоритетная очередь пуста.");
            T item = _items[0];
            _items.RemoveAt(0);
            return item;
        }
    }
}