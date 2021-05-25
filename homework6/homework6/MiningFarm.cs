using System;
using System.Collections.Generic;
using System.Numerics;

namespace homework6
{
    public static class MiningFarm
    {
        public static List<BigInteger> Factorization(BigInteger N)
        {
            if (N < 2)
            {
                throw new ArgumentException("ArgumentException: N < 2");
            }

            var divides = new List<BigInteger>();
            var div = 2;
            while (N % div == 0)
            {
                divides.Add(div);
                N /= div;
            }

            div = 3;

            while (Math.Pow(div, 2) <= (double)N)
            {
                if (N % div == 0)
                {
                    divides.Add(div);
                    N /= div;
                }
                else
                {
                    div += 2;
                }
            }

            if (N > 1)
            {
                divides.Add(N);
            }

            return divides;
        }
    }
}
