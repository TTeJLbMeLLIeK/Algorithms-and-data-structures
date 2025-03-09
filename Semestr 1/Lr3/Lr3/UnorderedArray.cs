using System;

namespace Lr3
{
    public class UnorderedArray : ArrayHelper
    {
        public UnorderedArray(int capacity) : base(capacity) { }

        public override void Insert(int value)
        {
            if (count == items.Length)
                throw new InvalidOperationException("Превышена вместимость массива.");

            items[count] = value;
            count++;
        }

        public override void Remove(int value)
        {
            int index = Search(value);

            ShiftLeft(index);
            count--;
        }

        public override int Search(int value)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] == value) return i;
            }
            return -1;
        }

        public override int GetMin()
        {
            if (count == 0) throw new InvalidOperationException("Массив пуст.");
            int min = items[0];
            for (int i = 1; i < count; i++)
            {
                if (items[i] < min) min = items[i];
            }
            return min;
        }

        public override int GetMax()
        {
            if (count == 0) throw new InvalidOperationException("Массив пуст.");
            int max = items[0];
            for (int i = 1; i < count; i++)
            {
                if (items[i] > max) max = items[i];
            }
            return max;
        }
    }
}