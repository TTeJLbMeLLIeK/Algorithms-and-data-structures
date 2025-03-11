using System;
namespace Homework_3
{
    public class Program
    {
        public static void Main()
        {
            int[] array = { 5, 3, 9, 1, 7, 6 };

            DeputyChief speaker = new DeputyChief(array);

            speaker.PrintArray();

            int element = 3;
            int index = speaker.FindElement(element);
            Console.WriteLine($"Элемент {element} найден на индексе: {index}");

            speaker.RemoveElement(9);
            speaker.PrintArray();

            int length = speaker.GetArrayLength();
            Console.WriteLine("Длина массива: " + length);

            int min = speaker.FindMin();
            int max = speaker.FindMax();
            Console.WriteLine($"Минимальное значение: {min}");
            Console.WriteLine($"Максимальное значение: {max}");
        }
    }
}