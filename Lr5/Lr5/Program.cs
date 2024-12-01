using System;

namespace Lr5
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите строку для проверки на палиндром:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: строка не может быть пустой.");
            }
            else
            {
                string normalizedInput = input.ToLower().Replace(" ", "");
                bool isPalindrome = PalindromeChecker.IsPalindrome(normalizedInput);
                Console.WriteLine(isPalindrome ? "Это палиндром." : "Это не палиндром.");
            }

            var stack = new Stack<int>(3);
            try
            {
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                Console.WriteLine("Стек заполнен. Пытаемся извлечь элемент:");

                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            var queue = new Queue<int>(3);
            try
            {
                queue.Enqueue(10);
                queue.Enqueue(20);
                queue.Enqueue(30);
                queue.Enqueue(40);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            var priorityQueue = new PriorityQueue<int>();
            try
            {
                priorityQueue.Enqueue(30);
                priorityQueue.Enqueue(10);
                priorityQueue.Dequeue();
                priorityQueue.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}