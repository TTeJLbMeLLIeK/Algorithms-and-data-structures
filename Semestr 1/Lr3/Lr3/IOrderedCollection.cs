namespace Lr3
{
    public interface IOrderedCollection
    {
        void Insert(int value);
        void Remove(int value);
        int GetMin();
        int GetMax();
        int Search(int value);
        void PrintElements();
    }
}