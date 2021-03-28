using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public static class SumMatrix
    {
        public static DiagonalMatrix Sum(this  DiagonalMatrix matrix,DiagonalMatrix matrix1)
        {
            DiagonalMatrix diagonalMatrix;

            if (matrix1.Size > matrix.Size)
            {
                diagonalMatrix = new DiagonalMatrix(matrix1.diagonal);
                for (int i = 0; i < matrix.Size; i++)
                {
                    diagonalMatrix.diagonal[i] += matrix.diagonal[i];
                }
            }
            else
            {
                diagonalMatrix = new DiagonalMatrix(matrix.diagonal);
                for (int i = 0; i < matrix1.Size; i++)
                {
                    diagonalMatrix.diagonal[i] += matrix1.diagonal[i];
                }
            }     


            return diagonalMatrix;
        }
    }
}
