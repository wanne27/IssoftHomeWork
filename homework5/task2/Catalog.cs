using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace task2
{
    class Catalog : IEnumerable<Book>
    {
        Dictionary<string, Book> dicCatalog;

        public Catalog()
        {
            dicCatalog = new Dictionary<string, Book>();
        }

        public Catalog(string isbn, Book book)
        {
            dicCatalog = new Dictionary<string, Book>();
            dicCatalog.Add(isbn, book);
        }

        public Book this [string isbn]
        {
            get
            {
                if (!IsCorrectIsbn(isbn))
                {
                    throw new ArgumentException("Ancorrect Isbn");
                }

                isbn = isbn.Replace("-", "");
                return dicCatalog[isbn];
            }
        }

        public void Add(string isbn, Book book)
        {
            if(!IsCorrectIsbn(isbn))
            {
                throw new ArgumentException("Ancorrect Isbn");
            }

            isbn = isbn.Replace("-", "");
            dicCatalog.Add(isbn, book);
        }

        private bool IsCorrectIsbn(string isbn)
        {
            return Regex.IsMatch(isbn, @"^\d{3}-\d{1}-\d{2}-\d{6}-\d{1}$") || Regex.IsMatch(isbn, @"^\d{13}$");
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var item in dicCatalog)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
