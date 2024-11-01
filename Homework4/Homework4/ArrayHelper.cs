namespace Homework4
{
    public static class ArrayHelper
    {
        public static void ShiftRight(int[] array, int index, int count)
        {
            for (int i = count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        public static void ShiftLeft(int[] array, int index, int count)
        {
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[count - 1] = 0;
        }
    }
}
