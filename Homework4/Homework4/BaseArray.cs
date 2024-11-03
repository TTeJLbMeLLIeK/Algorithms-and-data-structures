using System;

namespace Homework4
{
    public abstract class BaseArray : IArrayOperations
    {
        protected int[] items;
        protected int count;

        public BaseArray(int capacity)
        {
            items = new int[capacity];
            count = 0;
        }

        public int Count => count;

        public abstract void Insert(int value);
        public abstract void Remove(int value);
        public abstract int[] GetAllElements();

        public void PrintElements()
        {
            Console.WriteLine("Элементы массива:");
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
