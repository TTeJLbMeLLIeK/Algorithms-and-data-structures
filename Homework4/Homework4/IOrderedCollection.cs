namespace Homework4
{
    public interface IOrderedArray
    {
        void Insert(int value);
        void Remove(int value);
        int Min { get; }
        int Max { get; }
        int[] GetAllElements();
    }
}
