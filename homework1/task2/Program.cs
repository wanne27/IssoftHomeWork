using System;
//Задание 2.При старте приложение запрашивает у пользователя два целых числа a и b (считать, что пользователь вводит целые числа без ошибок).
//Затем приложение выводит все положительные целые числа в диапазоне от a (включительно) до b(включительно), которые в своём двоичном представлении имеют ровно 4 единицы.
//Разработать консольное приложение, реализующее указанный функционал.
//Примечание 1: для преобразования строки s в значение int используйте метод-функцию int.Parse(s).
namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            Console.Write("Введите число a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите число b: ");
            int b = int.Parse(Console.ReadLine());           

            if(a>b)
            {
                int c = a;
                a = b;
                b = c;
            }            

            for (; a <= b; a++) 
            {
                if (a > 0)
                {
                    string bin = Convert.ToString(a, 2);
                    count = 0;

                    for (int i = 0; i < bin.Length; i++)
                    {
                        if (bin[i] == '1')
                            count++;                      
                    }

                    if (count == 4)
                    {
                        Console.WriteLine(a);
                        count = 0;
                    }
                }
               
            }

        }
    }
}
 