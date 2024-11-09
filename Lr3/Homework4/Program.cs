using System;

namespace Homework4
{
    class Program
    {
        static void PrintAllElements(IArrayOperations array)
        {
            int[] elements = array.GetAllElements();
            foreach (var item in elements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            IArrayOperations orderedArray = new OrderedArray(10);

            orderedArray.Insert(10);
            orderedArray.Insert(20);
            orderedArray.Insert(5);
            orderedArray.Insert(15);

            Console.WriteLine("Массив до удаления:");
            PrintAllElements(orderedArray);

            int valueToRemove = 10;
            Console.WriteLine($"Удаляем значение: {valueToRemove}");
            orderedArray.Remove(valueToRemove);

            Console.WriteLine("Массив после удаления:");
            PrintAllElements(orderedArray);

            var orderedOps = orderedArray as IOrderedOperations;
            if (orderedOps != null)
            {
                Console.WriteLine("Минимальное значение: " + orderedOps.GetMin());
                Console.WriteLine("Максимальное значение: " + orderedOps.GetMax());
            }
        }
    }
}