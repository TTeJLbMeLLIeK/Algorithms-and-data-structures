using System;

namespace Lr3
{
    class Program
    {
        static void Main()
        {
            IOrderedCollection orderedArray = new OrderedArray(10);
            IOrderedCollection unorderedArray = new UnorderedArray(10);

            orderedArray.Insert(10);
            orderedArray.Insert(20);
            orderedArray.Insert(5);
            orderedArray.Insert(15);

            Console.WriteLine("Упорядоченный массив:");
            orderedArray.PrintElements();

            Console.WriteLine($"Минимум: {orderedArray.GetMin()}");
            Console.WriteLine($"Максимум: {orderedArray.GetMax()}");

            orderedArray.Remove(10);
            Console.WriteLine("После удаления 10:");
            orderedArray.PrintElements();

            unorderedArray.Insert(10);
            unorderedArray.Insert(20);
            unorderedArray.Insert(5);
            unorderedArray.Insert(15);

            Console.WriteLine("\nНеупорядоченный массив:");
            unorderedArray.PrintElements();

            Console.WriteLine($"Минимум: {orderedArray.GetMin()}");
            Console.WriteLine($"Максимум: {orderedArray.GetMax()}");

            unorderedArray.Remove(10);
            Console.WriteLine("После удаления 10:");
            unorderedArray.PrintElements();
        }
    }
}