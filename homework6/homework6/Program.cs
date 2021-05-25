using System;
using System.Numerics;

namespace homework6
{
    class Program
    {
        static void Main(string[] args)
        {           
            BigInteger N = 9138968124799367125;
            BigInteger M = 15251515554283812391;

            Console.WriteLine("{0} = {1}", string.Join(" * ",MiningFarm.Factorization(N)),N);

            var task = ThreadMiningFarm.FactorizationAsync(111);
            Console.WriteLine("{0} = {1}", string.Join(" * ", task.Result), N);

            var task2 = ThreadMiningFarm.FactorizationAsync(432);
            Console.WriteLine("{0} = {1}", string.Join(" * ", task2.Result), M);

            Console.WriteLine("NOD : " + Helper.NodAsync(17,15).Result);
            Console.ReadLine();
        }
    }
}
