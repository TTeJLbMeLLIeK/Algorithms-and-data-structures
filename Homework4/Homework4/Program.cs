using System;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderedArray array = new OrderedArray(10);

            array.Insert(10);
            array.Insert(20);
            array.Insert(5);
            array.Insert(15);

            Console.WriteLine("Элементы массива до удаления:");
            PrintAllElements(array);

            Console.WriteLine("Минимальный элемент: " + array.Min);
            Console.WriteLine("Максимальный элемент: " + array.Max);

            int elementToRemove = 10;
            Console.WriteLine($"Удаляем элемент: {elementToRemove}");

            array.Remove(elementToRemove);

            Console.WriteLine("Элементы массива после удаления:");
            PrintAllElements(array);
        }

        static void PrintAllElements(IOrderedArray array)
        {
            int[] elements = array.GetAllElements();
            foreach (var item in elements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}