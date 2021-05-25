using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace homework6
{
    public static class ThreadMiningFarm
    {
        public static Task<List<BigInteger>> FactorizationAsync(BigInteger N)
        {
            var tcs = new TaskCompletionSource<List<BigInteger>>();
            new Thread(Calc).Start();            
            return tcs.Task;

            void Calc()
            {
                try
                {
                    var result = MiningFarm.Factorization(N);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }
    }   
}
