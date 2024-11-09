using System;

namespace Homework4
{
    public class OrderedArray : BaseArray, IOrderedOperations
    {
        public OrderedArray(int capacity) : base(capacity) { }

        public override void Insert(int value)
        {
            if (count == items.Length)
                throw new InvalidOperationException("Превышена вместимость массива.");

            int index = BinarySearchHelper.FindInsertPosition(items, count, value);
            ArrayHelper.ShiftRight(items, index, count);
            items[index] = value;
            count++;
        }

        public override void Remove(int value)
        {
            int index = BinarySearchHelper.FindIndex(items, count, value);
            if (index == -1)
                throw new InvalidOperationException("Значение не найдено в массиве.");

            ArrayHelper.ShiftLeft(items, index, count);
            count--;
        }

        public int GetMin()
        {
            if (count == 0) throw new InvalidOperationException("Массив пуст.");
            return items[0];
        }

        public int GetMax()
        {
            if (count == 0) throw new InvalidOperationException("Массив пуст.");
            return items[count - 1];
        }

        public override int[] GetAllElements()
        {
            int[] elements = new int[count];
            Array.Copy(items, elements, count);
            return elements;
        }
    }
}
