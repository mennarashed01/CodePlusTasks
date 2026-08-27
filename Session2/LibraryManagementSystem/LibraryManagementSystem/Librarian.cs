using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Librarian
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Librarian(string id , string name)
        {
            Id = id;
            Name = name;
        }

        public void AddBook(Library library, Book book)
        {
            library.AddBook(book);
        }

        public void RemoveBook(Library library , string isbn)
        {
            library.RemoveBook(isbn);
        }

    }
}
