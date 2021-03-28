using System;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    class MatrixElement
    {
        private int i, j, val;
        
        public MatrixElement(int i,int j, int value)
        {
            this.i = i;
            this.j = j;
            val = value;
        }
        
        public int I
        {
            get { return i; }
        }

        public int J
        {
            get { return j; }
        }

        public int Value
        {
            get { return val; }
            set { val = value; }
        }
    }
}
