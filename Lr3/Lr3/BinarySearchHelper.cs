namespace Homework4
{
    public static class BinarySearchHelper
    {
        public static int FindInsertPosition(int[] array, int count, int value)
        {
            int left = 0, right = count - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (array[middle] < value)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return left;
        }

        public static int FindIndex(int[] array, int count, int value)
        {
            int left = 0, right = count - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (array[middle] == value)
                    return middle;
                if (array[middle] < value)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return -1;
        }
    }
}
