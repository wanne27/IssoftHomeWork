using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    class Book
    {
        private string nameOfBook;
        private DateTime datePablication;
        private HashSet<string> authors;

        public Book(string nameOfBook, DateTime dateTime, params string[] authors)
        {
            if(nameOfBook == null)
            {
                throw new ArgumentNullException("nameOfBook is null");
            }

            this.nameOfBook = nameOfBook;
            datePablication = new DateTime();
            datePablication = dateTime;
            this.authors = new HashSet<string>(authors);            
        }

        public override string ToString()
        {
            string _authors = "";
            foreach(var item in authors)
            {
                _authors += " " + item;
            }

            string book = nameOfBook + " " + datePablication + " " + _authors;
            return book;
        }
    }
}
