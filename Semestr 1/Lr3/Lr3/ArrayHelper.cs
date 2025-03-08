using System;

namespace Lr3
{
    public abstract class ArrayHelper : IOrderedCollection
    {
        protected int[] items;
        protected int count;

        public ArrayHelper(int capacity)
        {
            items = new int[capacity];
            count = 0;
        }

        public abstract void Insert(int value);
        public abstract void Remove(int value);
        public abstract int Search(int value);

        protected void ShiftRight(int index)
        {
            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        protected void ShiftLeft(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[count - 1] = 0;
        }

        public abstract int GetMin();
        public abstract int GetMax();

        public void PrintElements()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
}