using System;
using System.Collections.Generic;

namespace Lr2
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

        public (int comparisons, int swaps) QuickSort()
        {
            int comparisons = 0, swaps = 0;
            QuickSortRecursive(0, _array.Length - 1, ref comparisons, ref swaps);
            return (comparisons, swaps);
        }

        private void QuickSortRecursive(int left, int right, ref int comparisons, ref int swaps)
        {
            if (right - left < 10)
            {
                InsertionSortRange(left, right, ref comparisons, ref swaps);
                return;
            }

            int pivotIndex = Partition(left, right, ref comparisons, ref swaps);
            QuickSortRecursive(left, pivotIndex - 1, ref comparisons, ref swaps);
            QuickSortRecursive(pivotIndex + 1, right, ref comparisons, ref swaps);
        }

        private int Partition(int left, int right, ref int comparisons, ref int swaps)
        {
            int pivot = _array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                comparisons++;
                if (_array[j] < pivot)
                {
                    i++;
                    Swap(i, j);
                    swaps++;
                }
            }
            Swap(i + 1, right);
            swaps++;
            return i + 1;
        }

        private void InsertionSortRange(int left, int right, ref int comparisons, ref int swaps)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = _array[i];
                int j = i - 1;
                while (j >= left && _array[j] > key)
                {
                    comparisons++;
                    _array[j + 1] = _array[j];
                    j--;
                    swaps++;
                }
                _array[j + 1] = key;
            }
        }

        public (int comparisons, int swaps) QuickSortNonRecursive()
        {
            int comparisons = 0, swaps = 0;
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((0, _array.Length - 1));

            while (stack.Count > 0)
            {
                var (left, right) = stack.Pop();
                if (right - left < 10)
                {
                    InsertionSortRange(left, right, ref comparisons, ref swaps);
                    continue;
                }

                int pivotIndex = Partition(left, right, ref comparisons, ref swaps);
                if (pivotIndex - 1 > left) stack.Push((left, pivotIndex - 1));
                if (pivotIndex + 1 < right) stack.Push((pivotIndex + 1, right));
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

    class Program
    {
        static void Main()
        {
            const int arraySize = 500000;

            SortableArray quickSortArray = new SortableArray(arraySize, 1, 10000);
            var quickSortResult = quickSortArray.QuickSort();
            Console.WriteLine("Быстрая сортировка (рекурсивная):");
            Console.WriteLine($"Количество операций сравнения: {quickSortResult.comparisons}");
            Console.WriteLine($"Количество операций обмена: {quickSortResult.swaps}");

            Console.WriteLine(new string('-', 40));

            SortableArray quickSortNRArray = new SortableArray(arraySize, 1, 10000);
            var quickSortNRResult = quickSortNRArray.QuickSortNonRecursive();
            Console.WriteLine("Быстрая сортировка (не рекурсивная):");
            Console.WriteLine($"Количество операций сравнения: {quickSortNRResult.comparisons}");
            Console.WriteLine($"Количество операций обмена: {quickSortNRResult.swaps}");
        }
    }
}