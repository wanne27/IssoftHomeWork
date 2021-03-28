using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Lecture lecture = new Lecture();
            PracticaLesson practicaLesson = new PracticaLesson();
            Lecture lecture1 = new Lecture();
            PracticaLesson practicaLesson1 = new PracticaLesson();
            Training training = new Training(practicaLesson,practicaLesson1);
            Training training1 = training.Clone();
            training.Add(practicaLesson1);
            training1.Add(lecture);

            for (int i = 0; i < training.pack.Length; i++)
            {
                Console.WriteLine(training.pack[i]);
            }

            Console.WriteLine(training.IsPractical());
            Console.WriteLine();

            for (int i = 0; i < training1.pack.Length; i++)
            {
                Console.WriteLine(training1.pack[i]);
            }
                       
            Console.WriteLine(training1.IsPractical());
            Console.ReadLine();
        }        
    }

    public class Training
    {
        public string description = "";
        public object[] pack; 

        public Training(params object[] obj)
        {
            pack = new object[obj.Length];
            for(int i = 0; i < obj.Length; i++)
            {
                pack[i] = obj[i];
            }
        }

        public void Add(object obj)
        {
            Array.Resize(ref pack, pack.Length + 1);
            pack[pack.Length-1] = obj;
        }

        public bool IsPractical()
        {            
            for(int i = 0; i < pack.Length; i++)
            {
                if (pack[i] is PracticaLesson) { }             
                else
                {
                    return false;
                }              
            }            
            return true;
        }

        public Training Clone()
        {            
            return new Training
            {
                description = this.description,
                pack = this.pack

            };
        }
    }

    public class Lecture
    {
        public string description = "";
        public string topic = "";
        public string task = "";
        public string decision = "";
    }

    public class PracticaLesson
    {
        public string description = "";
    }
}
