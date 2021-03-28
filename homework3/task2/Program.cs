using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(20);
            Stack<int> stack1 = new Stack<int>();

            for (int i = 0; i < 20; i++)
                stack.Push(i);

            stack1 = (Stack<int>)stack.Reverse();

            for (int i = 0; !stack1.IsEmpty(); i++)
                Console.WriteLine(stack1.Pop());

            for (int i = 0; !stack.IsEmpty(); i++)
                Console.WriteLine(stack.Pop());

            Console.ReadLine();
        }
    }
}
