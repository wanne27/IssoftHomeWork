using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    class SparseMatrix : IEnumerable<int>
    {
        public List<MatrixElement> list;
        public int m, n;
        private int count;
        private int version;

        public SparseMatrix(int i, int j)
        {            
            m = i;
            n = j;
            CheckIndexes(i, j);
            list = new List<MatrixElement>();
            count = 0;
            version = 0;            
        }
         
        public int this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                int index = 0;
                while (index < count && i > list[index].I)
                    index++;

                if(index < count && i == list[index].I)
                {
                    while (index < count && i == list[index].I && j > list[index].J)
                        index++;
                }

                if (index < count && i == list[index].I && j == list[index].J)
                {
                    return list[index].Value;
                }                   

                return 0;
            }

            set
            {
                bool insert = false;
                CheckIndexes(i, j);

                if (value == 0)
                {
                    DeleteElement(i, j);
                    version++;
                    return;
                }

                int index = 0;

                while (index < count && i > list[index].I)
                    index++;

                if (index < count && i == list[index].I)
                {
                    while (index < count && i == list[index].I && j > list[index].J)
                        index++;
                }

                if (index < count && i == list[index].I && j == list[index].J)
                {
                    list[index].Value = value;
                    insert = true;
                }

                if (!insert)
                {
                    MatrixElement element = new MatrixElement(i, j, value);
                    list.Insert(index, element);
                    version++;
                    count++;
                }  
                
            }  
              
        }

        public int GetCount(int x)
        {
            int counter = 0;
            foreach(var item in GetNonZeroElements())
            {
                if (item.Item3 == x)
                    counter++;
            }

            if (x == 0)
            {
                return version - count;
            }

            return counter;
        }

        public IEnumerable<(int, int, int)> GetNonZeroElements()
        {
            int index = 0;
            (int, int, int) element;

            while (index < count)
            {
                element = (list[index].I, list[index].J, list[index].Value);
                index++;
                yield return element;
            }
        }        

        void DeleteElement(int i, int j)
        {
            if (count == 0)
                return;

            int index = 0;

            while (index < count && i > list[index].I)
                index++;

            if (index < count && i == list[index].I)
            {
                while (index < count && i == list[index].I && j > list[index].J)
                    index++;
            }

            if(index < count && i==list[index].I && j == list[index].J)
            {
                list.RemoveAt(index);
                count--;
            }
        }

        private void CheckIndexes(int i, int j)
        {
            Check(i, nameof(i),m);
            Check(j, nameof(j),n);

            void Check(int index, string indexName, int lastIndex)
            {
                if (index < 0 || index > lastIndex)
                {
                    throw new IndexOutOfRangeException(indexName);
                }
            }
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var element = this[i,j];
                    result += $"{(element == 0 ? "0" : element.ToString()),-10}";
                }

                result += Environment.NewLine;
            }

            return result;
        }

        public IEnumerator<int> GetEnumerator() => new SparseMatrixEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        private class SparseMatrixEnumerator : IEnumerator<int>
        {
            private readonly SparseMatrix _sparseMatrix;
            private readonly int _capturedVersion;
            private int i = 0;
            private int j = -1;            

            public SparseMatrixEnumerator(SparseMatrix sparseMatrix)
            {
                _sparseMatrix = sparseMatrix;
                _capturedVersion = sparseMatrix.version;
            }

            public int Current => _sparseMatrix[i, j] == 0 ? 0 : _sparseMatrix[i, j];

            object IEnumerator.Current => Current;          

            public bool MoveNext()
            {
                if(_capturedVersion != _sparseMatrix.version)
                {
                    throw new InvalidOperationException();
                }

                j++;

                if (j >= _sparseMatrix.n)
                {
                    MakeIAndJ();
                }

                if (i >= _sparseMatrix.m || j >= _sparseMatrix.n)
                {
                    return false;
                }

                return true;
            }

            public void MakeIAndJ()
            {
                i++;
                j = 0;
            }

            public void Reset() 
            {
                i = 0;
                j = -1;
            }

            public void Dispose()
            {
               
            }

        }
    }
}
