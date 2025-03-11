using System;

namespace Lr5
{
    internal class Program
    {
        static void Main()
        {
            TestPalindromeChecker();
            TestStack();
            TestQueue();
            TestPriorityQueue();
        }

        static void TestPalindromeChecker()
        {
            Console.WriteLine("Введите строку для проверки на палиндром:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: строка не может быть пустой.");
                return;
            }

            string normalizedInput = input.ToLower().Replace(" ", "");
            bool isPalindrome = PalindromeChecker.IsPalindrome(normalizedInput);
            Console.WriteLine(isPalindrome ? "Это палиндром." : "Это не палиндром.");
        }

        static void TestStack()
        {
            try
            {
                var stack = new Stack<int>(3);
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);

                Console.WriteLine("Элементы в стеке:");
                while (!stack.IsEmpty())
                {
                    Console.WriteLine(stack.Pop());
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void TestQueue()
        {
            try
            {
                var queue = new Queue<int>(3);
                queue.Enqueue(10);
                queue.Enqueue(20);
                queue.Enqueue(30);

                Console.WriteLine("Элементы в очереди:");
                while (!queue.IsEmpty())
                {
                    Console.WriteLine(queue.Dequeue());
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void TestPriorityQueue()
        {
            try
            {
                var priorityQueue = new PriorityQueue<int>(3);
                priorityQueue.Enqueue(30);
                priorityQueue.Enqueue(10);
                priorityQueue.Enqueue(20);

                Console.WriteLine("Элементы в приоритетной очереди (от меньшего к большему):");
                while (!priorityQueue.IsEmpty())
                {
                    Console.WriteLine(priorityQueue.Dequeue());
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}