using System;

namespace Lr3
{
    public class OrderedArray : ArrayHelper
    {
        public OrderedArray(int capacity) : base(capacity) { }

        public override void Insert(int value)
        {
            if (count == items.Length)
                throw new InvalidOperationException("Превышена вместимость массива.");

            int index = 0;
            while (index < count && items[index] < value)
                index++;

            ShiftRight(index);
            items[index] = value;
            count++;
        }

        public override void Remove(int value)
        {
            int index = Search(value);;

            ShiftLeft(index);
            count--;
        }

        public override int Search(int value)
        {
            int left = 0, right = count - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (items[middle] == value)
                    return middle;
                if (items[middle] < value)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return -1;
        }

        public override int GetMin()
        {
            return count > 0 ? items[0] : throw new InvalidOperationException("Массив пуст.");
        }

        public override int GetMax()
        {
            return count > 0 ? items[count - 1] : throw new InvalidOperationException("Массив пуст.");
        }
    }
}