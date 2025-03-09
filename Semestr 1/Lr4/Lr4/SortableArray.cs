using System;

namespace Lr4
{
    public class SortableArray
    {
        private int[] _array;

        public SortableArray(int size, int minValue, int maxValue)
        {
            _array = GenerateRandomArray(size, minValue, maxValue);
        }

        private int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }

        public (int comparisons, int swaps) BubbleSort()
        {
            int comparisons = 0, swaps = 0;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                for (int j = 0; j < _array.Length - i - 1; j++)
                {
                    comparisons++;
                    if (_array[j] > _array[j + 1])
                    {
                        Swap(j, j + 1);
                        swaps++;
                    }
                }
            }
            return (comparisons, swaps);
        }

        public (int comparisons, int insertions) InsertionSort()
        {
            int comparisons = 0;
            int insertions = 0;

            for (int i = 1; i < _array.Length; i++)
            {
                int key = _array[i];
                int j = i - 1;

                while (j >= 0)
                {
                    comparisons++;
                    if (_array[j] > key)
                    {
                        _array[j + 1] = _array[j];
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (_array[j + 1] != key)
                {
                    _array[j + 1] = key;
                    insertions++;
                }
            }

            return (comparisons, insertions);
        }

        public (int comparisons, int swaps) SelectionSort()
        {
            int comparisons = 0, swaps = 0;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < _array.Length; j++)
                {
                    comparisons++;
                    if (_array[j] < _array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(i, minIndex);
                    swaps++;
                }
            }
            return (comparisons, swaps);
        }

        private void Swap(int i, int j)
        {
            int temp = _array[i];
            _array[i] = _array[j];
            _array[j] = temp;
        }

        public void PrintArray()
        {
            foreach (int item in _array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}