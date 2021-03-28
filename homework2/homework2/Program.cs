using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix diagonalMatrix = new DiagonalMatrix(1, 1, 1, 1, 1);
            DiagonalMatrix diagonalMatrix1 = new DiagonalMatrix(1, 1, 1, 1, 1);
            DiagonalMatrix diagonalMatrix2 = new DiagonalMatrix(3, 4, 5, 6);            
            Console.WriteLine(diagonalMatrix + "\n");
            Console.WriteLine(diagonalMatrix2.ToString() + "\n");    
            Console.WriteLine(diagonalMatrix1.Equals(diagonalMatrix + "\n"));
            Console.WriteLine("\n"+diagonalMatrix.Track() + "\n");
            Console.WriteLine(SumMatrix.Sum(diagonalMatrix2,diagonalMatrix) + "\n");
            Console.WriteLine(diagonalMatrix.GetHashCode() + "\n" + diagonalMatrix1.GetHashCode());
            Console.ReadLine();
        }
    }

    public class DiagonalMatrix
    {
        public int[] diagonal;
        private int size;       
        public int this[int i, int j]
        {
            get
            {
                if (i != j || i < 0 || j < 0 || i >= size || j >= size)  
                {
                   return  0;
                }
                 return  diagonal[i];
            }           
        }

        public  int Size
        {
            get => size;
        }

        public DiagonalMatrix(params int[] elements)
        {
            if(elements == null)
            {
                diagonal = new int[0];
                size = diagonal.Length;
                
            }
            else
            {
                this.diagonal = elements;
                size = diagonal.Length;
            }                 
        }

        public DiagonalMatrix()
        {
            diagonal = new int[0];
            size = diagonal.Length;
        }

        public int Track()
        {
            int sum = 0;
            foreach(int elem in diagonal)
            {
                sum +=elem;
            }
            return sum;
        }

        public override int GetHashCode()
        {
            return (size + " " + diagonal.Length).GetHashCode();
        }
        public override string ToString()
        {
            string elem = "";
            for (int i = 0; i < diagonal.Length; i++)
            {
                for (int j = 0; j < diagonal.Length; j++)
                {
                    elem += this[i, j].ToString() + "\t";
                }
                elem += "\n";
            }
            return elem;
        }

        public override bool Equals(object obj)
        {
            return obj is DiagonalMatrix p &&
                size == p.size &&
                ToString() == p.ToString();
           
        }
    }
}
