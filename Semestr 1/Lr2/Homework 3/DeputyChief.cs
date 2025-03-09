using System;
using System.Linq;

namespace Homework_3
{
    public class DeputyChief : ChiefNumbers
    {
        private int[] _array;

        public DeputyChief(int[] array)
        {
            _array = array;
        }

        public int FindElement(int element)
        {
            int index = Array.IndexOf(_array, element);
            return index != -1 ? index : -1;
        }

        public void RemoveElement(int element)
        {
            _array = _array.Where(e => e != element).ToArray();
        }

        public int GetArrayLength()
        {
            return _array.Length;
        }

        public int FindMin()
        {
            return _array.Min();
        }

        public int FindMax()
        {
            return _array.Max();
        }

        public void PrintArray()
        {
            Console.WriteLine("Текущий массив: " + string.Join(", ", _array));
        }
    }
}