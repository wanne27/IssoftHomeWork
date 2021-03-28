using System;

namespace homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix sparseMatrix = new SparseMatrix(3, 3);
            int[] mas = new int[9] { 1, 0, 3, 0, 4, 4, 0, 0, 4 };
            
            int a = 0;

            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    sparseMatrix[i, j] = mas[a];
                    a++;
                }                  
            }

            foreach(var item in sparseMatrix)
            {
                Console.Write(item + "\t");
            }

            foreach (var item in sparseMatrix.GetNonZeroElements())
            {
                Console.Write("\n" + item);
            }

            Console.WriteLine("\n" + sparseMatrix.GetCount(4));          
            Console.WriteLine("\n\n" + sparseMatrix);
            Console.ReadLine();
        }
    }
}
