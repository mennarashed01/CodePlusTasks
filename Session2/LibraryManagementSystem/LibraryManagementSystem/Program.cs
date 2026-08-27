namespace LibraryManagementSystem
{
    internal class Program
    {
        static Library library = new Library();
        static Librarian librarian = new Librarian("Mohamed", "L001");
        static List<User> users = new List<User>();


        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        library.DisplayAllBooks();
                        break;
                    case "4":
                        RegisterUser();
                        break;
                    case "5":
                        BorrowBook();
                        break;
                    case "6":
                        ReturnBook();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }

                Console.WriteLine();
            }
            static void ShowMenu()
            {
                Console.WriteLine("===== Library Menu =====");
                Console.WriteLine("1. Add Book (Librarian)");
                Console.WriteLine("2. Remove Book (Librarian)");
                Console.WriteLine("3. Display All Books");
                Console.WriteLine("4. Register New User");
                Console.WriteLine("5. Borrow Book");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
            }
            static void AddBook()
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter Author: ");
                string author = Console.ReadLine();
                Console.Write("Enter ISBN: ");
                string isbn = Console.ReadLine();

                Book book = new Book(title, author, isbn);
                librarian.AddBook(library, book);
            }
            static void RemoveBook()
            {
                Console.Write("Enter ISBN of the book to remove: ");
                string isbn = Console.ReadLine();
                librarian.RemoveBook(library, isbn);
            }
            static void RegisterUser()
            {
                Console.Write("Enter your User ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                User user = new User(id, name);
                users.Add(user);
                Console.WriteLine($"{user.Name} now has a library card: {user.LibraryCardNumber}");
            }

            static void BorrowBook()
            {
                Console.Write("Enter your User ID: ");
                string userId = Console.ReadLine();
                User user = users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    Console.WriteLine("User not found. Please register first.");
                    return;
                }

                Console.Write("Enter ISBN of the book to borrow: ");
                string isbn = Console.ReadLine();
                Book book = library.FindBookByIsbn(isbn);

                if (book == null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                user.BorrowBook(book);
            }

            static void ReturnBook()
            {
                Console.Write("Enter your User ID: ");
                string memberId = Console.ReadLine();
                User user = users.FirstOrDefault(m => m.Id == memberId);

                if (user == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                Console.Write("Enter ISBN of the book to return: ");
                string isbn = Console.ReadLine();
                Book book = user.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);

                if (book == null)
                {
                    Console.WriteLine("This user did not borrow this book.");
                    return;
                }

                user.ReturnBook(book);
            }
        }
    }
}
