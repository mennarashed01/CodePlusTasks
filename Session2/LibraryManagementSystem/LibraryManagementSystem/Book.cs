using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public string ISBN { get; private set; }
        public bool IsAvailable { get; private set; }

        public Book(string title , string author , string isbn )
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }

        public void MarkAsBorrowed()
        {
            IsAvailable = false;
        }

        public void MarkAsReturned()
        {
            IsAvailable = true;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "Available" : "Borrowed";
            return $"[{ISBN}] {Title} - by {Author} ({status})";
        }


    }
}
