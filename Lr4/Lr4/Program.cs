using System;

class Program
{
    static void Main()
    {
        const int arraySize = 10000;
        int[] originalArray = GenerateRandomArray(arraySize, 1, 10000);

        int[] bubbleSortArray = (int[])originalArray.Clone();
        int[] insertionSortArray = (int[])originalArray.Clone();
        int[] selectionSortArray = (int[])originalArray.Clone();

        var bubbleResult = BubbleSort(bubbleSortArray);
        Console.WriteLine("Пузырьковая сортировка:");
        Console.WriteLine($"Количество операций сравнения: {bubbleResult.comparisons}");
        Console.WriteLine($"Количество операций обмена: {bubbleResult.swaps}");

        var insertionResult = InsertionSort(insertionSortArray);
        Console.WriteLine("\nСортировка методом вставки:");
        Console.WriteLine($"Количество операций сравнения: {insertionResult.comparisons}");
        Console.WriteLine($"Количество операций вставки: {insertionResult.insertions}");

        var selectionResult = SelectionSort(selectionSortArray);
        Console.WriteLine("\nСортировка методом выбора:");
        Console.WriteLine($"Количество операций сравнения: {selectionResult.comparisons}");
        Console.WriteLine($"Количество операций обмена: {selectionResult.swaps}");
    }

    static int[] GenerateRandomArray(int size, int minValue, int maxValue)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }
        return array;
    }

    static (int comparisons, int swaps) BubbleSort(int[] array)
    {
        int comparisons = 0, swaps = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                comparisons++;
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                    swaps++;
                }
            }
        }
        return (comparisons, swaps);
    }

    static (int comparisons, int insertions) InsertionSort(int[] array)
    {
        int comparisons = 0;
        int insertions = 0;

        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Сравниваем элементы, сдвигая их
            while (j >= 0)
            {
                comparisons++;
                if (array[j] > key)
                {
                    array[j + 1] = array[j]; // Перемещение элемента
                    j--;
                }
                else
                {
                    break;
                }
            }

            // Фактическая вставка key на своё место
            if (array[j + 1] != key)
            {
                array[j + 1] = key;
                insertions++;
            }
        }

        return (comparisons, insertions);
    }

    static (int comparisons, int swaps) SelectionSort(int[] array)
    {
        int comparisons = 0, swaps = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                comparisons++;
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                Swap(array, i, minIndex);
                swaps++;
            }
        }
        return (comparisons, swaps);
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}