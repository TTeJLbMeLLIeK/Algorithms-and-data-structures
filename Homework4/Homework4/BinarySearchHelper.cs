namespace Homework4
{
    public static class BinarySearchHelper
    {
        public static int FindInsertPosition(int[] array, int count, int value)
        {
            int left = 0;
            int right = count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] < value)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }

        public static int BinarySearch(int[] array, int value, int count)
        {
            int left = 0;
            int right = count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == value)
                    return mid;
                else if (array[mid] < value)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
