using System;

namespace Homework4
{
    public class OrderedArray : IOrderedArray
    {
        private int[] items;
        private int count;

        public OrderedArray(int capacity)
        {
            items = new int[capacity];
            count = 0;
        }

        public int Min => items[0];
        public int Max => items[count - 1];

        public void Insert(int value)
        {
            if (count == items.Length)
                throw new InvalidOperationException("Array capacity exceeded");

            int index = BinarySearchHelper.FindInsertPosition(items, count, value);

            ArrayHelper.ShiftRight(items, index, count);

            items[index] = value;
            count++;
        }

        public void Remove(int value)
        {
            int index = BinarySearchHelper.BinarySearch(items, value, count);
            if (index == -1)
                throw new InvalidOperationException("Element not found");

            ArrayHelper.ShiftLeft(items, index, count);
            count--;
        }

        public int[] GetAllElements()
        {
            int[] currentElements = new int[count];
            Array.Copy(items, currentElements, count);
            return currentElements;
        }
    }
}
