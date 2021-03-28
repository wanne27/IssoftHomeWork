using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime(year: 2000, month: 5, day: 24);
            Book book = new Book("book", dateTime, "sss", "sss");
            Book book2 = new Book("book2", dateTime, "2ss", "3ss");
            Catalog books = new Catalog();

            books.Add("1234567891233", book);
            books.Add("123-4-56-789123-2", book2);
            Console.WriteLine(books["123-4-56-789123-2"]);

            foreach(var item in books)
            {
                Console.WriteLine(item);
            }           
        } 
    }
}
