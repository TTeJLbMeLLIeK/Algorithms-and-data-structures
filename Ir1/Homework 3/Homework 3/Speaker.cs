using System;
using System.Linq;

namespace Homework_3
{
    public class Speaker: Speaking
    {
        public int FindElement(int[] array, int element)
        {
            int index = Array.IndexOf(array, element);
            return index != -1 ? index : -1;
        }

        public int[] RemoveElement(int[] array, int element)
        {
            return array.Where(e => e != element).ToArray();
        }

        public int GetArrayLength(int[] array)
        {
            return array.Length;
        }

        public int FindMin(int[] array)
        {
            return array.Min();
        }

        public int FindMax(int[] array)
        {
            return array.Max();
        }
    }
}
