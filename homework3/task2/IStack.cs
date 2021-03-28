namespace task2
{
    public interface IStack<T> where T : struct
    {
        void Push(T e);
        T Pop();
        bool IsEmpty();
    }
}
