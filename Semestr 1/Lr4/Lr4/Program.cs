using System;

namespace Lr4
{
    class Program
    {
        static void Main()
        {
            const int arraySize = 10000;

            SortableArray bubbleSortArray = new SortableArray(arraySize, 1, 10000);
            SortableArray insertionSortArray = new SortableArray(arraySize, 1, 10000);
            SortableArray selectionSortArray = new SortableArray(arraySize, 1, 10000);

            var bubbleResult = bubbleSortArray.BubbleSort();
            Console.WriteLine("Пузырьковая сортировка:");
            Console.WriteLine($"Количество операций сравнения: {bubbleResult.comparisons}");
            Console.WriteLine($"Количество операций обмена: {bubbleResult.swaps}");

            var insertionResult = insertionSortArray.InsertionSort();
            Console.WriteLine("\nСортировка методом вставки:");
            Console.WriteLine($"Количество операций сравнения: {insertionResult.comparisons}");
            Console.WriteLine($"Количество операций вставки: {insertionResult.insertions}");

            var selectionResult = selectionSortArray.SelectionSort();
            Console.WriteLine("\nСортировка методом выбора:");
            Console.WriteLine($"Количество операций сравнения: {selectionResult.comparisons}");
            Console.WriteLine($"Количество операций обмена: {selectionResult.swaps}");
        }
    }
}