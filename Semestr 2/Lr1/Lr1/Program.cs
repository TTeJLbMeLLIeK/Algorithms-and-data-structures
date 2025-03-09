using System;
using System.Diagnostics;

namespace Lr1
{
    class Program
    {
        static void Main()
        {
            int[] sizes = { 1000, 5000, 10000, 50000 };
            foreach (int size in sizes)
            {
                Console.WriteLine($"Анализ сортировки для массива размера {size}:");
                SortableArray shellSortArray = new SortableArray(size, 1, 10000);

                Console.WriteLine("Использование последовательности Шелла:");
                shellSortArray.ShellSort(SortableArray.ShellSequence);

                Console.WriteLine("Использование последовательности Хиббарда:");
                shellSortArray.ShellSort(SortableArray.HibbardSequence);

                Console.WriteLine("Использование последовательности Кнута:");
                shellSortArray.ShellSort(SortableArray.KnuthSequence);

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

        public static int[] ShellSequence(int size)
        {
            var sequence = new System.Collections.Generic.List<int>();
            for (int gap = size / 2; gap > 0; gap /= 2)
            {
                sequence.Add(gap);
            }
            return sequence.ToArray();
        }

        public static int[] HibbardSequence(int size)
        {
            var sequence = new System.Collections.Generic.List<int>();
            int k = 1, gap;
            while ((gap = (int)Math.Pow(2, k) - 1) < size)
            {
                sequence.Add(gap);
                k++;
            }
            sequence.Reverse();
            return sequence.ToArray();
        }

        public static int[] KnuthSequence(int size)
        {
            var sequence = new System.Collections.Generic.List<int>();
            int h = 1;
            while (h < size)
            {
                sequence.Add(h);
                h = 3 * h + 1;
            }
            while (sequence.Count > 0 && sequence[sequence.Count - 1] >= size)
            {
                sequence.RemoveAt(sequence.Count - 1);
            }
            sequence.Reverse();
            return sequence.ToArray();
        }
    }
}
