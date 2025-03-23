using System;
using System.Diagnostics;

namespace Lr1
{
    class Program
    {
        static void Main()
        {
            int[] sizes = { 10000, 50000, 500000, 1000000 };
            foreach (int size in sizes)
            {
                Console.WriteLine($"Анализ сортировки для массива размера {size}:");
                SortableArray array = new SortableArray(size, 1, 10000);

                Console.WriteLine("Сортировка Шелла (последовательность Шелла):");
                array.ShellSort(SortableArray.ShellSequence);

                Console.WriteLine("Быстрая сортировка:");
                array.QuickSort();

                Console.WriteLine("Сортировка слиянием:");
                array.MergeSort();

                Console.WriteLine(new string('-', 70));
            }
        }
    }

    public class SortableArray
    {
        private int[] _array;
        private int[] _originalArray;
        private Random _random = new Random();

        public SortableArray(int size, int minValue, int maxValue)
        {
            _originalArray = GenerateRandomArray(size, minValue, maxValue);
            _array = new int[size];
        }

        private int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = _random.Next(minValue, maxValue + 1);
            }
            return array;
        }

        public void ShellSort(Func<int, int[]> sequenceGenerator)
        {
            Array.Copy(_originalArray, _array, _originalArray.Length);
            int comparisons = 0, swaps = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();

            int[] gaps = sequenceGenerator(_array.Length);
            foreach (int gap in gaps)
            {
                for (int i = gap; i < _array.Length; i++)
                {
                    int temp = _array[i];
                    int j = i;
                    while (j >= gap && _array[j - gap] > temp)
                    {
                        _array[j] = _array[j - gap];
                        j -= gap;
                        comparisons++;
                        swaps++;
                    }
                    _array[j] = temp;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс, Сравнений: {comparisons}, Перестановок: {swaps}\n");
        }

        public void QuickSort()
        {
            Array.Copy(_originalArray, _array, _originalArray.Length);
            int comparisons = 0, swaps = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            QuickSortRecursive(0, _array.Length - 1, ref comparisons, ref swaps);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс, Сравнений: {comparisons}, Перестановок: {swaps}\n");
        }

        private void QuickSortRecursive(int left, int right, ref int comparisons, ref int swaps)
        {
            if (left >= right) return;

            int pivot = _array[right];
            int partitionIndex = left;
            for (int i = left; i < right; i++)
            {
                comparisons++;
                if (_array[i] < pivot)
                {
                    (_array[i], _array[partitionIndex]) = (_array[partitionIndex], _array[i]);
                    swaps++;
                    partitionIndex++;
                }
            }
            (_array[partitionIndex], _array[right]) = (_array[right], _array[partitionIndex]);
            swaps++;

            QuickSortRecursive(left, partitionIndex - 1, ref comparisons, ref swaps);
            QuickSortRecursive(partitionIndex + 1, right, ref comparisons, ref swaps);
        }

        public void MergeSort()
        {
            Array.Copy(_originalArray, _array, _originalArray.Length);
            int comparisons = 0, swaps = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            MergeSortRecursive(0, _array.Length - 1, ref comparisons, ref swaps);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс, Сравнений: {comparisons}, Перестановок: {swaps}\n");
        }

        private void MergeSortRecursive(int left, int right, ref int comparisons, ref int swaps)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            MergeSortRecursive(left, mid, ref comparisons, ref swaps);
            MergeSortRecursive(mid + 1, right, ref comparisons, ref swaps);
            Merge(left, mid, right, ref comparisons, ref swaps);
        }

        private void Merge(int left, int mid, int right, ref int comparisons, ref int swaps)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                comparisons++;
                if (_array[i] <= _array[j]) temp[k++] = _array[i++];
                else { temp[k++] = _array[j++]; swaps++; }
            }
            while (i <= mid) temp[k++] = _array[i++];
            while (j <= right) temp[k++] = _array[j++];

            for (i = left, k = 0; i <= right; i++, k++) _array[i] = temp[k];
        }

        public static int[] ShellSequence(int size)
        {
            var sequence = new System.Collections.Generic.List<int>();
            for (int gap = size / 2; gap > 0; gap /= 2)
                sequence.Add(gap);
            return sequence.ToArray();
        }
    }
}