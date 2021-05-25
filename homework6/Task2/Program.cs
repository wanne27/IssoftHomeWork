using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data((1.5, 2.1));
            KNN kNN = new KNN();
            kNN.LoadData(@"D:\issoft\homework6\Task2\data.txt");
            Console.WriteLine(kNN.IdentifyName(3, data));
        }
    }
}
