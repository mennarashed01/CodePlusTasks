using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book \"{book.Title}\" added to the collection.");
        }

        public void RemoveBook(string isbn)
        {
            Book bookToRemove = FindBookByIsbn(isbn);
            if(bookToRemove != null )
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"Book \"{bookToRemove.Title}\" removed from the collection.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        public Book FindBookByIsbn(string isbn)
        {
            return books.FirstOrDefault(b => b.ISBN == isbn);
        }
        public void DisplayAllBooks()
        {
            if(books.Count == 0)
            {
                Console.WriteLine("NO books in the library.");
                return;
            }

            Console.WriteLine("---- Library Collection ----");
            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

    }
}
