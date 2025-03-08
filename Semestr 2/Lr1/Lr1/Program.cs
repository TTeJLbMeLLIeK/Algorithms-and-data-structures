using System;
using System.Diagnostics;
using System.Collections.Generic;

// Интерфейс для генераторов последовательностей интервалов
interface ISequenceGenerator
{
    int[] GenerateGaps(int size);
}

// Последовательность интервалов по методу Шелла ( / 2)
class ShellSequence : ISequenceGenerator
{
    public int[] GenerateGaps(int size)
    {
        var gaps = new List<int>();
        for (int gap = size / 2; gap > 0; gap /= 2)
            gaps.Add(gap);
        return gaps.ToArray();
    }
}

// Последовательность интервалов по методу Хиббарда (2^k - 1)
class HibbardSequence : ISequenceGenerator
{
    public int[] GenerateGaps(int size)
    {
        var gaps = new List<int>();
        int k = 1;
        while ((1 << k) - 1 < size)
        {
            gaps.Insert(0, (1 << k) - 1);
            k++;
        }
        return gaps.ToArray();
    }
}

// Последовательность интервалов по методу Кнута (3^k - 1 / 2)
class KnuthSequence : ISequenceGenerator
{
    public int[] GenerateGaps(int size)
    {
        var gaps = new List<int>();
        int h = 1;
        while (h < size)
        {
            gaps.Insert(0, h);
            h = h * 3 + 1;
        }
        return gaps.ToArray();
    }
}

// Класс сортировки Шелла, использующий заданную интервальную последовательность
class ShellSorter
{
    private readonly int[] _array;
    private readonly ISequenceGenerator _sequenceGenerator;

    public ShellSorter(int size, ISequenceGenerator sequenceGenerator)
    {
        _array = new int[size];
        _sequenceGenerator = sequenceGenerator;
        FillArrayWithRandomValues();
    }

    // Заполняем массив случайными значениями
    private void FillArrayWithRandomValues()
    {
        Random rand = new Random();
        for (int i = 0; i < _array.Length; i++)
            _array[i] = rand.Next(1, 1000);
    }

    // Основной алгоритм сортировки Шелла
    public void Sort()
    {
        int[] gaps = _sequenceGenerator.GenerateGaps(_array.Length);
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
                }
                _array[j] = temp;
            }
        }
    }

    // Измерение времени выполнения сортировки
    public long MeasureSortTime()
    {
        Stopwatch sw = Stopwatch.StartNew();
        Sort();
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}

// Основная программа
class Program
{
    public static void Main()
    {
        int size = 10000; // Размер массива
        var sequences = new Dictionary<string, ISequenceGenerator>
        {
            { "Shell", new ShellSequence() },
            { "Hibbard", new HibbardSequence() },
            { "Knuth", new KnuthSequence() }
        };

        // Запускаем сортировку для каждой интервальной последовательности
        foreach (var seq in sequences)
        {
            var sorter = new ShellSorter(size, seq.Value);
            long elapsedTime = sorter.MeasureSortTime();
            Console.WriteLine($"{seq.Key} sequence: {elapsedTime} ms");
        }
    }
}