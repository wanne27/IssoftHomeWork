
using System;

namespace homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test("Ilya", 19);        

            Logger logger = new Logger("logger.json");
            logger.Track<Test>(test);

            Console.WriteLine("Hello World!");
        }
    }
}
