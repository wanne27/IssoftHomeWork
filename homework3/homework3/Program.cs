using System;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {           
            Key key = new Key(Octave.First, Note.A, Accidental.Sharp);            
            Key key1 = new Key(Octave.First, Note.B, Accidental.Flat);

            Console.WriteLine(key.Equals(key1));
            Console.WriteLine(key.CompareTo(key1));
            Console.WriteLine(key.GetHashCode());
            Console.WriteLine(key1.GetHashCode());

            Console.ReadLine();
        }
    }
}
