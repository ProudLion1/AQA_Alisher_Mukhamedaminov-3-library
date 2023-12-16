using System;
using System.Collections.Generic;
using System.Linq;

// Main class of the program
class Program
{
    static Library library = new Library(); // Instance of the library class
    static List<Book> books = new List<Book>(); // List of books in the library
    static List<BookLoan> bookLoans = new List<BookLoan>(); // List of book loans

    // Main method of the program
    static void Main()
    {
        ShowMainMenu();
    }

    // Method to display the main menu
    static void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("1. View library contact information");
            Console.WriteLine("2. Manage books");
            Console.WriteLine("3. Book lending and returning");
            Console.WriteLine("4. Statistics");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowLibraryInfo();
                    break;
                case "2":
                    ManageBooks();
                    break;
                case "3":
                    ManageBookLoans();
                    break;
                case "4":
                    ShowStatistics();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    // Method to display information about the library
    static void ShowLibraryInfo()
    {
        Console.WriteLine("Library contact information:");
        Console.WriteLine($"Name: {library.Name}");
        Console.WriteLine($"Location: {library.Location}");
        Console.WriteLine($"Contact phone number: {library.ContactNumber}");
        Console.WriteLine($"Working hours: {library.WorkingHours}");
        Console.WriteLine($"Librarian: {library.LibrarianName}");
        Console.WriteLine();
    }

    // Method to manage books
    static void ManageBooks()
    {
        while (true)
        {
            Console.WriteLine("1. View catalog of books without sorting");
            Console.WriteLine("2. View catalog of books with sorting");
            Console.WriteLine("3. Add a new book to the catalog");
            Console.WriteLine("4. Edit information about a book in the catalog");
            Console.WriteLine("5. Remove a book from the catalog");
            Console.WriteLine("6. Search for a book by author");
            Console.WriteLine("7. Search for a book by title");
            Console.WriteLine("8. Return to the main menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowBookCatalog();
                    break;
                case "2":
                    ShowSortedBookCatalog();
                    break;
                case "3":
                    AddBook();
                    break;
                case "4":
                    EditBook();
                    break;
                case "5":
                    RemoveBook();
                    break;
                case "6":
                    SearchByAuthor();
                    break;
                case "7":
                    SearchByTitle();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    // Method to display the catalog of books
    static void ShowBookCatalog()
    {
        Console.WriteLine("Catalog of books in the library:");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Title} - {book.Author}");
        }
        Console.WriteLine();
    }

    // Method to display the sorted catalog of books
    static void ShowSortedBookCatalog()
    {
        Console.WriteLine("1. Sort by author");
        Console.WriteLine("2. Sort by title");
        Console.WriteLine("3. Return to the previous menu");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ShowSortedBooks("author");
                break;
            case "2":
                ShowSortedBooks("title");
                break;
            case "3":
                return;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                break;
        }
    }

    // Method to display sorted books
    static void ShowSortedBooks(string sortBy)
    {
        List<Book> sortedBooks;
        if (sortBy.ToLower() == "author")
        {
            sortedBooks = books.OrderBy(b => b.Author).ToList();
        }
        else
        {
            sortedBooks = books.OrderBy(b => b.Title).ToList();
        }

        Console.WriteLine($"Sorted catalog of books by {sortBy}:");

        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"{book.Title} - {book.Author}");
        }

        Console.WriteLine();
    }

    // Method to add a new book
    static void AddBook()
    {
        Console.WriteLine("Enter the title of the book:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the author of the book:");
        string author = Console.ReadLine();

        books.Add(new Book { Title = title, Author = author });
        Console.WriteLine("The book has been successfully added to the library catalog!\n");
    }

    // Method to edit information about a book
    static void EditBook()
    {
        Console.WriteLine("Enter the title of the book to edit its information:");
        string title = Console.ReadLine();

        Book bookToEdit = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToEdit != null)
        {
            Console.WriteLine("Enter the new title of the book:");
            bookToEdit.Title = Console.ReadLine();

            Console.WriteLine("Enter the new author of the book:");
            bookToEdit.Author = Console.ReadLine();

            Console.WriteLine("The information about the book has been successfully edited!\n");
        }
        else
        {
            Console.WriteLine("The book was not found in the library catalog.\n");
        }
    }

    // Method to remove a book from the catalog
    static void RemoveBook()
    {
        Console.WriteLine("Enter the title of the book to remove from the catalog:");
        string title = Console.ReadLine();

        Book bookToRemove = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("The book has been successfully removed from the library catalog!\n");
        }
        else
        {
            Console.WriteLine("The book was not found in the library catalog.\n");
        }
    }

    // Method to search for a book by author
    static void SearchByAuthor()
    {
        Console.WriteLine("Enter the author's name (2 or more consecutive characters):");
        string authorQuery = Console.ReadLine();

        var matchingBooks = books.Where(b => b.Author.IndexOf(authorQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

        if (matchingBooks.Any())
        {
            Console.WriteLine("Books found by the author:");
            foreach (var book in matchingBooks)
            {
                Console.WriteLine($"{book.Title} - {book.Author}");
            }
        }
        else
        {
            Console.WriteLine("No books found by the author.");
        }

        Console.WriteLine();
    }

    // Method to search for a book by title
    static void SearchByTitle()
    {
        Console.WriteLine("Enter the title of the book (2 or more consecutive characters):");
        string titleQuery = Console.ReadLine();

        var matchingBooks = books.Where(b => b.Title.IndexOf(titleQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

        if (matchingBooks.Any())
        {
            Console.WriteLine("Books found by the title:");
            foreach (var book in matchingBooks)
            {
                Console.WriteLine($"{book.Title} - {book.Author}");
            }
        }
        else
        {
            Console.WriteLine("No books found by the title.");
        }

        Console.WriteLine();
    }

    // Method to manage book lending and returning
    static void ManageBookLoans()
    {
        while (true)
        {
            Console.WriteLine("1. Lend a book to a customer");
            Console.WriteLine("2. Return a book by a customer");
            Console.WriteLine("3. Return to the previous menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    IssueBook();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    // Method to lend a book to a customer
    static void IssueBook()
    {
        Console.WriteLine("Enter the title of the book to lend:");
        string title = Console.ReadLine();

        Book bookToIssue = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToIssue != null)
        {
            Console.WriteLine("Enter customer information:");
            Console.WriteLine("First name:");
            string clientFirstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            string clientLastName = Console.ReadLine();
            Console.WriteLine("Mobile phone number:");
            string clientPhoneNumber = Console.ReadLine();
            Console.WriteLine("Issue date (in DD.MM.YYYY format):");
            string issueDateStr = Console.ReadLine();

            if (DateTime.TryParseExact(issueDateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime issueDate))
            {
                if (bookLoans.Any(bl => bl.Book == bookToIssue && bl.ReturnDate == null))
                {
                    Console.WriteLine("The book is already issued and cannot be issued again.");
                }
                else
                {
                    bookLoans.Add(new BookLoan
                    {
                        Book = bookToIssue,
                        ClientFirstName = clientFirstName,
                        ClientLastName = clientLastName,
                        ClientPhoneNumber = clientPhoneNumber,
                        IssueDate = issueDate
                    });

                    Console.WriteLine("The book has been successfully issued to the customer!\n");
                }
            }
            else
            {
                Console.WriteLine("Incorrect date format. Book issuance canceled.\n");
            }
        }
        else
        {
            Console.WriteLine("The book was not found in the library catalog.\n");
        }
    }

    // Method to return a book by a customer
    static void ReturnBook()
    {
        Console.WriteLine("Enter the title of the book to be returned by the customer:");
        string title = Console.ReadLine();

        Book bookToReturn = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToReturn != null)
        {
            var loan = bookLoans.FirstOrDefault(bl => bl.Book == bookToReturn && bl.ReturnDate == null);

            if (loan != null)
            {
                Console.WriteLine("Enter the return date (in DD.MM.YYYY format):");
                string returnDateStr = Console.ReadLine();

                if (DateTime.TryParseExact(returnDateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime returnDate))
                {
                    loan.ReturnDate = returnDate;
                    Console.WriteLine("The book has been successfully returned to the library!\n");
                }
                else
                {
                    Console.WriteLine("Incorrect date format. Book return canceled.\n");
                }
            }
            else
            {
                Console.WriteLine("The book is not issued to the customer or has already been returned.\n");
            }
        }
        else
        {
            Console.WriteLine("The book was not found in the library catalog.\n");
        }
    }

    // Method to display statistics
    static void ShowStatistics()
    {
        while (true)
        {
            Console.WriteLine("1. List of customers who have not returned books");
            Console.WriteLine("2. Statistics on borrowed and returned books");
            Console.WriteLine("3. Return to the previous menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowOverdueLoans();
                    break;
                case "2":
                    ShowBookLoanStatistics();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    // Method to display a list of customers who have not returned books
    static void ShowOverdueLoans()
    {
        var overdueLoans = bookLoans.Where(bl => bl.ReturnDate == null && DateTime.Now > bl.IssueDate).ToList();

        if (overdueLoans.Any())
        {
            Console.WriteLine("List of customers who have not returned books:");
            foreach (var loan in overdueLoans)
            {
                Console.WriteLine($"Issue date: {loan.IssueDate.ToShortDateString()}");
                Console.WriteLine($"Book: {loan.Book.Title} - {loan.Book.Author}");
                Console.WriteLine($"Customer: {loan.ClientFirstName} {loan.ClientLastName} ({loan.ClientPhoneNumber})");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("All books are available.");
        }
        Console.WriteLine();
    }

    // Method to display statistics on borrowed and returned books
    static void ShowBookLoanStatistics()
    {
        foreach (var loan in bookLoans)
        {
            Console.WriteLine($"Issue date: {loan.IssueDate.ToShortDateString()}");
            Console.WriteLine($"Return date: {loan.ReturnDate?.ToShortDateString() ?? "The book has not been returned yet"}");
            Console.WriteLine($"Book: {loan.Book.Title} - {loan.Book.Author}");
            Console.WriteLine($"Customer: {loan.ClientFirstName} {loan.ClientLastName} ({loan.ClientPhoneNumber})");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

// Class representing a book
class Book
{
    public string Title { get; set; } // Book title
    public string Author { get; set; } // Book author
}

// Class representing a library
class Library
{
    public string Name { get; set; } // Library name
    public string Location { get; set; } // Library location
    public string ContactNumber { get; set; } // Library contact number
    public string WorkingHours { get; set; } // Library working hours
    public string LibrarianName { get; set; } // Librarian name
}

// Class representing a book loan to a customer
class BookLoan
{
    public Book Book { get; set; } // Book lent to the customer
    public string ClientFirstName { get; set; } // Customer's first name
    public string ClientLastName { get; set; } // Customer's last name
    public string ClientPhoneNumber { get; set; } // Customer's phone number
    public DateTime IssueDate { get; set; } // Date of issuance
    public DateTime? ReturnDate { get; set; } // Return date (null if the book has not been returned yet)
}