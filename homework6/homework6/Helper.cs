using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace homework6
{
    static class Helper
    {
        public static async Task<BigInteger> NodAsync(BigInteger a, BigInteger b)
        {
            var simplesA = await ThreadMiningFarm.FactorizationAsync(a);
            var simplesB = await ThreadMiningFarm.FactorizationAsync(b);
            var nod = await SearchNod(simplesA, simplesB);
            return nod;
        }

        private static Task<BigInteger> SearchNod(List<BigInteger> a, List<BigInteger> b )
        {
            var task = new Task<BigInteger>(() =>
            {
                BigInteger nod = 1;            
                List<BigInteger> result = a.Intersect(b).ToList();
                
                foreach(var item in result)
                {
                    nod *= item;
                }

                return nod;
            });

            task.Start();
            return task;
        }
    }
}
