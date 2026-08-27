using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LibraryCardNumber { get; private set; }
        public List<Book> BorrowedBooks { get; private set; }

        public User(string id , string name)
        {
            Id = id;
            Name = name;
            LibraryCardNumber = "CARD-" + id;
            BorrowedBooks = new List<Book>();
        }
        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                book.MarkAsBorrowed();
                BorrowedBooks.Add(book);
                Console.WriteLine($"{Name} borrowed \"{book.Title}\" successfully.");
            }
            else
            {
                Console.WriteLine($"Sorry, \"{book.Title}\" is not available right now.");
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                book.MarkAsReturned();
                BorrowedBooks.Remove(book);
                Console.WriteLine($"{Name} returned \"{book.Title}\".");
            }
        }
    }
}
