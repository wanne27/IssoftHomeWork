using System;

namespace task2
{
    public class Stack<T> : IStack<T> where T : struct
    {
        private T[] items;
        private int count;
        private const int n = 100;

        public Stack()
        {
            items = new T[n];
        }

        public Stack(int lenght)
        {
            items = new T[lenght];
        }

        public bool IsEmpty()
        {
           return count == 0;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new ArgumentException("Stack is empty");
            T item = items[--count];
            items[count] = default(T); 
            return item;
        }

        public void Push(T e)
        {
            if (count == items.Length)
                throw new ArgumentException("Stack is overflow");
            items[count++] = e;
        }
    }
}
