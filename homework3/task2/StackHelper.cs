using System;

namespace task2
{
    public static class StackHelper
    {
        public static IStack<T> Reverse<T>(this IStack<T> stack) where T : struct
        {           
            Stack<T> newStack = new Stack<T>();
            T[] buf = new T[100];
            int count = 0;

            if (stack != null)
            {
                for (int i = 0; !stack.IsEmpty(); i++)
                {
                    buf[i] = stack.Pop();
                    newStack.Push(buf[i]);
                    count++;
                }

                for (int i = count - 1; i >= 0; i--)
                {
                    stack.Push(buf[i]);
                }

                return newStack;
            }

            throw new InvalidOperationException("NULL");
        }
    }
}
