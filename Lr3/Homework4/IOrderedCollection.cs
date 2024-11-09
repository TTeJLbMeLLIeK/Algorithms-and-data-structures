namespace Homework4
{
    public interface IArrayOperations
    {
        void Insert(int value);
        void Remove(int value);
        int[] GetAllElements();
    }

    public interface IOrderedOperations
    {
        int GetMin();
        int GetMax();
    }
}
