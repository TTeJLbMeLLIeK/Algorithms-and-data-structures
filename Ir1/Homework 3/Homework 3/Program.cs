using System;
namespace Homework_3
{
    public class Program
    {
        public static void Main()
        {
            Speaking speaker = new Speaker();
            int[] array = { 5, 3, 9, 1, 7, 6};

            Console.WriteLine("Оригинальный массив: " + string.Join(", ", array));

            int element = 3;
            int index = speaker.FindElement(array, element);
            Console.WriteLine($"Элемент {element} найден на индексе: {index}");

            int[] newArray = speaker.RemoveElement(array, 9);
            Console.WriteLine("Массив после удаления элемента 9: " + string.Join(", ", newArray));

            int length = speaker.GetArrayLength(array);
            Console.WriteLine("Длина массива: " + length);

            int min = speaker.FindMin(array);
            int max = speaker.FindMax(array);
            Console.WriteLine($"Минимальное значение: {min}");
            Console.WriteLine($"Максимальное значение: {max}");
        }
    }
}