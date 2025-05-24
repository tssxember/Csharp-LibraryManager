using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public bool IsCheckedOut { get; set; }
    public Book(string title)
    {
        Title = title;
        IsCheckedOut = false;
    }
}

class LibraryManager
{
    static void Main()
    {
        List<Book> books = new List<Book>();
        const int maxBooks = 5;
        int borrowedCount = 0;
        const int borrowLimit = 3;

        while (true)
        {
            Console.WriteLine("Would you like to 1.add, 2.remove, 3.search, 4.borrow, 5.return, or 6.exit? (add/remove/search/borrow/return/exit)");
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    AddBook(books, maxBooks);
                    break;
                case "2":
                    RemoveBook(books);
                    break;
                case "3":
                    SearchBook(books);
                    break;
                case "4":
                    BorrowBook(books, ref borrowedCount, borrowLimit);
                    break;
                case "5":
                    ReturnBook(books, ref borrowedCount);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'borrow', 'return', or 'exit'.");
                    break;
            }

            DisplayBooks(books);
            Console.WriteLine($"Books currently borrowed: {borrowedCount}/{borrowLimit}");
        }
    }

    static void AddBook(List<Book> books, int maxBooks)
    {
        if (books.Count >= maxBooks)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }
        Console.WriteLine("Enter the title of the book to add:");
        string newBook = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newBook) && books.Find(b => b.Title.Equals(newBook, StringComparison.OrdinalIgnoreCase)) == null)
        {
            books.Add(new Book(newBook));
        }
        else
        {
            Console.WriteLine("Invalid or duplicate book title.");
        }
    }

    static void RemoveBook(List<Book> books)
    {
        Console.WriteLine("Enter the title of the book to remove:");
        string removeBook = Console.ReadLine();
        Book book = books.Find(b => b.Title.Equals(removeBook, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Removed: {removeBook}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void SearchBook(List<Book> books)
    {
        Console.WriteLine("Enter the title of the book to search for:");
        string searchTitle = Console.ReadLine();
        Book book = books.Find(b => b.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            Console.WriteLine($"'{searchTitle}' is available in the library. Checked out: {book.IsCheckedOut}");
        }
        else
        {
            Console.WriteLine($"'{searchTitle}' is not in the collection.");
        }
    }

    static void BorrowBook(List<Book> books, ref int borrowedCount, int borrowLimit)
    {
        if (borrowedCount >= borrowLimit)
        {
            Console.WriteLine($"You have reached your borrowing limit of {borrowLimit} books.");
            return;
        }
        Console.WriteLine("Enter the title of the book to borrow:");
        string borrowTitle = Console.ReadLine();
        Book book = books.Find(b => b.Title.Equals(borrowTitle, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            if (!book.IsCheckedOut)
            {
                book.IsCheckedOut = true;
                borrowedCount++;
                Console.WriteLine($"You have borrowed '{borrowTitle}'.");
            }
            else
            {
                Console.WriteLine($"'{borrowTitle}' is already checked out.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void ReturnBook(List<Book> books, ref int borrowedCount)
    {
        Console.WriteLine("Enter the title of the book to return:");
        string returnTitle = Console.ReadLine();
        Book book = books.Find(b => b.Title.Equals(returnTitle, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            if (book.IsCheckedOut)
            {
                book.IsCheckedOut = false;
                borrowedCount--;
                Console.WriteLine($"You have returned '{returnTitle}'.");
            }
            else
            {
                Console.WriteLine($"'{returnTitle}' was not checked out.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void DisplayBooks(List<Book> books)
    {
        Console.WriteLine("Available books:");
        if (books.Count == 0)
        {
            Console.WriteLine("(none)");
        }
        else
        {
            foreach (var book in books)
            {
                string status = book.IsCheckedOut ? "[Checked Out]" : "[Available]";
                Console.WriteLine($"{book.Title} {status}");
            }
        }
    }
}