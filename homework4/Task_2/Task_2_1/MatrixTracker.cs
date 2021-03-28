using System;
namespace Task
{         
    class MatrixTracker<T> where T : IComparable<T>
    {   
        public T Old { get; set; }
        public T New { get; set; }
        public int Index { get; set; }

        readonly DiagonalMatrix<T> diagonalMatrix;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            diagonalMatrix.ElementChanged += Add;
            this.diagonalMatrix = diagonalMatrix;
        }

        private void Add(object? a, ElementChangedEventArgs<T> args)
        {
            Old = args.Old;
            New = args.New;
            Index = args.Index;
        }

        public void Undo()
        {
            diagonalMatrix[Index, Index] = Old;
        }
    }
}