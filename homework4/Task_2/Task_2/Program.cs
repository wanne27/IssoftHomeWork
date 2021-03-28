using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Segment segment = new Segment(4, 12);
            Segment segment1 = new Segment(12, 4);
            Segment segmentSum = segment + segment1;
            uint a = (uint)segmentSum;
            (int, int) tuple = (10, 5);
            Segment segment2 = tuple;
            Console.WriteLine(segment2);
            Console.WriteLine(segment1);
            Console.WriteLine(segmentSum);
            Console.WriteLine(segment1.Equals(segment));
            Console.WriteLine(segment.GetHashCode());
            Console.WriteLine(segment1.GetHashCode());
            Console.ReadLine();
        }
    }
}
